using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumC.POM;

namespace SeleniumC.Tests
{
    public class CartTests : BaseTest
    {

        private String category = "Mystic Moment";
        private String symbol = "mm04";
        private String category1 = "Pastellove";
        private String symbol1 = "PL47";
        private String category2 = "Vintage&Nature";
        private String symbol2 = "sa32";
        private String quantity = "56";
        private String quantity1 = "121";
        private String quantity2 = "21";
        private String totalAmountNormal = "433,33";



        [Test]
        public void addOneProductToCartByProductPageTest()
        {

            String productSymbolInCart = mainCategoryPage
                    .ViewCategoryByName(category)
                    .ViewProductBySymbol(symbol)
                    .AddToCart()
                    .GetProductSymbolInCart(0);

            Assert.IsTrue(productSymbolInCart.Equals(symbol));

        }

        [Test]
        public void addSomeProductsToCartByProductPageTest()
        {

            String productSymbolInCart1 = mainCategoryPage
                    .ViewCategoryByName(category1)
                    .ViewProductBySymbol(symbol1)
                    .AddToCart()
                    .GetProductSymbolInCart(0);

            String productSymbolInCart2 = mainCategoryPage
                    .ViewCategoryByName(category2)
                    .ViewProductBySymbol(symbol2)
                    .AddToCart()
                    .GetProductSymbolInCart(1);

            Assert.IsTrue(productSymbolInCart1.Equals(symbol1) && productSymbolInCart2.Equals(symbol2));

        }

        [Test]
        public void addTwiceSameProductToCartTest()
        {

            String productQuantityInCartPage1;
            String productQuantityInCartPage2 = null;

            mainCategoryPage.AcceptCookie();

            CartPage productSymbolInCart1 = mainCategoryPage
                    .ViewCategoryByName(category1)
                    .ViewProductBySymbol(symbol1)
                    .AddToCart();

            CartPage productSymbolInCart2 = mainCategoryPage
                    .ViewCategoryByName(category1)
                    .ViewProductBySymbol(symbol1)
                    .AddToCart();

            productQuantityInCartPage1 = productSymbolInCart1.GetProductQuantity(0);

            try
            {
                productQuantityInCartPage2 = productSymbolInCart2.GetProductQuantity(1);
            }
            catch (Exception E)
            {
            }
        ;

            Assert.IsNull(productQuantityInCartPage2);
            Assert.AreEqual(productQuantityInCartPage1, "40");
        }

        [Test]
        public void addProductToCartFromCategoryPageTest()
        {

            String productSymbolInCart;

            CategoryPage categoryPage = mainCategoryPage
                    .ViewCategoryByName(category);

            CartPage cartPage = categoryPage
                    .AddToCartByCategoryPage(symbol);

            productSymbolInCart = cartPage
                    .ViewCartPage()
                    .GetProductSymbolInCart(0);

            Assert.IsTrue(productSymbolInCart.Equals(symbol));

        }

        [Test]
        public void changeQuantityOfProductInCartPageTest()
        {

            CartPage cartPage = mainCategoryPage
                    .ViewCategoryByName(category)
                    .AddToCartByCategoryPage(symbol);

            String productQuantityInCartPage = cartPage
                    .ChangeProductQuantity(0, quantity)
                    .GetProductQuantity(0);

            Assert.IsTrue(quantity.Equals(productQuantityInCartPage));

        }

        [Test]
        public void calculateTotalAmountInCartPageTest()
        {

            String totalAmountInCartPage = "";

            int deliveryType = 1;
            int realizationType = 2;

            //totalAmountNormal after including delivery value and realization value to test data
            var totalAmount = Double.Parse(totalAmountNormal.Replace(",", "."));
            if (deliveryType == 0 || deliveryType == 1) totalAmount += 15;
            if (deliveryType == 2) totalAmount += 20;
            if (realizationType == 1) totalAmount += 200;
            if (realizationType == 2) totalAmount += 450;
            String totalAmountFinal = totalAmount.ToString();
            if (totalAmountFinal.Contains(".")) totalAmountFinal = totalAmountFinal.Replace(".", ",");

            CartPage cartPage = mainCategoryPage
                    .ViewCategoryByName(category1)
                    .AddToCartByCategoryPage(symbol1)
                    .ChangeProductQuantity(0, quantity1);

            cartPage.AcceptCookie();

            totalAmountInCartPage = cartPage
                    .SetDeliveryType(deliveryType)
                    .SetRealizationType(realizationType)
                    .CalculateTotalAmount()
                    .GetTotalAmount();

            totalAmountInCartPage = mainCategoryPage
                    .ViewCategoryByName(category2)
                    .ViewProductBySymbol(symbol2)
                    .AddToCart()
                    .ChangeProductQuantity(1, quantity2)
                    .CalculateTotalAmount()
                    .GetTotalAmount()
                    .Replace(" ", "");

            if (totalAmountInCartPage.EndsWith("0") && totalAmountInCartPage.Contains(",")) totalAmountInCartPage = totalAmountInCartPage.Substring(0, totalAmountInCartPage.LastIndexOf("0"));

            Assert.IsTrue(totalAmountInCartPage.Equals(totalAmountFinal));
        }


        [Test]
        public void setIncorrectQuantityCartPageTest()
        {

            String message = "Wartość nie może być mniejsza niż 20.";
            String productQuantityInCart = "";
            String quantityAllertMessageCartTable = "";


            CartPage cartPage = mainCategoryPage
                    .ViewCategoryByName(category)
                    .ViewProductBySymbol(symbol)
                    .AddToCart()
                    .ChangeProductQuantity(0, quantity);

            cartPage.AcceptCookie();

            productQuantityInCart = cartPage
                    .CalculateTotalAmount()
                    .GetProductQuantity(0);

            quantityAllertMessageCartTable = (String)jse.ExecuteScript(
                            "const quantity = document.querySelector(\"input#cart_items_0_quantity\");"
                             + "message = quantity.validationMessage; return message;");

            Assert.IsTrue(quantityAllertMessageCartTable.Equals(message));
            Assert.IsTrue((productQuantityInCart.Contains(quantity)));

        }


        [Test]
        public void deleteOneProductFromCartPageTest()
        {

            String optionalSymbol = "";

            CartPage cartPage = mainCategoryPage
                    .ViewCategoryByName(category)
                    .AddToCartByCategoryPage(symbol)
                    .DeleteFromCartPage(symbol);

            try
            {

                optionalSymbol = cartPage.GetProductSymbolInCart(0);
            }
            catch (Exception e2) { }

            Assert.IsFalse(optionalSymbol.Equals(symbol));
        }

        [Test]
        public void deleteSomeProductsFromCartPageTest()
        {

            String optionalSymbol1 = "";
            String optionalSymbol2 = "";

            CartPage cartPage = mainCategoryPage
                    .ViewCategoryByName(category1)
                    .AddToCartByCategoryPage(symbol1);

            cartPage = mainCategoryPage
                    .ViewCategoryByName(category2)
                    .AddToCartByCategoryPage(symbol2)
                    .DeleteFromCartPage(symbol2)
                    .DeleteFromCartPage(symbol1);

            try
            {
                optionalSymbol1 = cartPage.GetProductSymbolInCart(1);
                optionalSymbol2 = cartPage.GetProductSymbolInCart(0);
            }
            catch (Exception e2) { }

            Assert.IsFalse(optionalSymbol1.Equals(symbol1) || optionalSymbol2.Equals(symbol2));
        }

        [Test]
        public void orderProductWithoutCheckingDeliveryAndRealizationTypeCartPage()
        {

            String message = "Wybierz jedną z opcji.";
            String deliveryTypeMessageCartTable = "";

            OrderingPage orderingPage = mainCategoryPage
                    .ViewCategoryByName(category)
                    .ViewProductBySymbol(symbol)
                    .AddToCart()
                    .SaveAndOrderProductsFromCart();

            deliveryTypeMessageCartTable = (String)jse.ExecuteScript(
                    "const delivery = document.querySelector(\"#cart_deliveryType_4\");"
                            + "message = delivery.validationMessage; return message;");

            Assert.IsTrue(deliveryTypeMessageCartTable.Equals(message));

        }

        [Test]
        public void orderProductWithoutCheckingRealizationTypeCartPage()
        {

            int deliveryType = 0;

            String message = "Wybierz jedną z opcji.";
            String realizationTypeMessageCartTable = "";

            OrderingPage orderingPage = mainCategoryPage
                    .ViewCategoryByName(category)
                    .ViewProductBySymbol(symbol)
                    .AddToCart()
                    .SetDeliveryType(deliveryType)
                    .SaveAndOrderProductsFromCart();

            realizationTypeMessageCartTable = (String)jse.ExecuteScript(
                    "const realization = document.querySelector(\"#cart_realizationType_2\");"
                            + "message = realization.validationMessage; return message;");

            Assert.IsTrue(realizationTypeMessageCartTable.Equals(message));

        }

        [Test]
        public void orderProductWithoutCheckingDeliveryTypeCartPage()
        {

            int realizationType = 1;

            String message = "Wybierz jedną z opcji.";
            String deliveryTypeMessageCartTable = "";

            OrderingPage orderingPage = mainCategoryPage
                    .ViewCategoryByName(category)
                    .ViewProductBySymbol(symbol)
                    .AddToCart()
                    .SetRealizationType(realizationType)
                    .SaveAndOrderProductsFromCart();

            deliveryTypeMessageCartTable = (String)jse.ExecuteScript(
                    "const delivery = document.querySelector(\"#cart_deliveryType_4\");"
                            + "message = delivery.validationMessage; return message;");

            Assert.IsTrue(deliveryTypeMessageCartTable.Equals(message));

        }

    }
}