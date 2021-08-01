using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumC.POM;

namespace SeleniumC.Tests
{
    public class NavigationTests : BaseTest
    {

        private String category = "Vintage&Nature";
        private String symbol = "sa32";
        private String symbolNext = "VN66";
        private String symbolPrevious = "sa31";


        [Test]
        public void navigateCategoryTest()
        {
            for (int i = 0; i < categories.Length; i++)
            {

                String category_actual = categories[i];
                String categoryName = mainCategoryPage
                   .ViewCategoryByName(category_actual)
                   .GetCategoryName();

                Assert.IsTrue(category_actual.Equals(categoryName));
            }

        }

        [Test]
        public void navigateToProductPageTest()
        {

            String productSymbol = mainCategoryPage
                    .ViewCategoryByName(category)
                    .ViewProductBySymbol(symbol)
                    .GetProductSymbol();

            Assert.IsTrue(productSymbol.Contains(symbol));
        }

        [Test]
        public void navigateToNextProductTest()
        {

            ProductPage productPage = mainCategoryPage
                    .ViewCategoryByName(category)
                    .ViewProductBySymbol(symbol);

            String productSymbolNext = productPage
                    .ViewNextProductPage()
                    .GetProductSymbol();

            Assert.IsTrue(productSymbolNext.Contains(symbolNext));

        }

        [Test]
        public void navigateToPreviousProductTest()
        {

            ProductPage productPage = mainCategoryPage
                    .ViewCategoryByName(category)
                    .ViewProductBySymbol(symbol);

            String productSymbolPrevious = productPage
                    .ViewPreviousProductPage()
                    .GetProductSymbol();

            Assert.IsTrue(productSymbolPrevious.Contains(symbolPrevious));

        }

        [Test]
        public void navigateAllProductsByNextButtonTest()
        {

            CategoryPage categoryPage = mainCategoryPage.ViewCategoryByName(category);

            String productSymbolLast = categoryPage.FindLastProductSymbol();
            String symbolLast = productSymbolLast;

            ProductPage productPage = categoryPage.ViewFirstProductPage();

            String productSymbolFirst = productPage.GetProductSymbol();
            String productSymbolNext = productSymbolFirst;


            do
            {
                productSymbolNext = productPage.ViewNextProductPage().GetProductSymbol();
            }
            while (!productSymbolNext.Contains(symbolLast));

            Assert.IsTrue(productSymbolNext.Contains(symbolLast));

    }

        /*
    @org.testng.annotations.Test
    @Description("Checks if it is possible to navigate from cart to main page and then come back without loss of content")
    public void navigateFromCartToMainPageAnRevertTest()
    {

        String productSymbolInCart = mainCategoryPage
                .viewCategoryByName(category)
                .viewProductBySymbol(symbol)
                .addToCart()
                .getProductSymbolInCart(0);

        mainCategoryPage.viewMainPage();

        String productSymbolAfterRevert = mainCategoryPage
                .viewCategoryByName(category)
                .viewProductBySymbol(symbol)
                .addToCart()
                .getProductSymbolInCart(0);

        assertEquals(productSymbolAfterRevert, productSymbolInCart, "Nawigacja do strony glownej nie dziala, badz zawartosc koszyka nie zapisuje sie");
        */
    }
}
