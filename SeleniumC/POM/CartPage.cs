using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumC.POM
{
    public class CartPage : BasePage
    {
        private string productInCartSymbolSelector = "h2 > a";
        private string calculateTotalAmountButtonSelector = "#cart_save";
        private string totalAmountSelector = "div.cart-total-price > strong";
        private string deliveryTypeOptionSelector = "input[type='radio'][name='cart[deliveryType]']";
        private string realizationTypeOptionSelector = "input[type='radio'][name='cart[realizationType]']";
        private string saveAndOrderButtonSelector = "#cart_save_and_order";

        private String symbol;
        private IWebElement productQuantityInCart;

        public CartPage(IWebDriver driver) : base(driver)
        {
        }


        public String GetProductSymbolInCart(int index)
        {

            String productInCartSymbol = driver.FindElements(By.CssSelector(productInCartSymbolSelector))[index].Text;
            int spacePosition = productInCartSymbol.LastIndexOf(" ");
            productInCartSymbol = productInCartSymbol.Substring(spacePosition + 1);
            return productInCartSymbol;
        }

        public CartPage ChangeProductQuantity(int index, string quantity)
        {

            String inputQuantitySelector = "input#cart_items_" + index + "_quantity";
            productQuantityInCart = driver.FindElement(By.CssSelector(inputQuantitySelector));
            productQuantityInCart.Clear();
            productQuantityInCart.SendKeys(quantity);
            return this;

        }

        public CartPage CalculateTotalAmount()
        {

            IWebElement calculateTotalAmountButton = driver.FindElement(By.CssSelector(calculateTotalAmountButtonSelector));
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(calculateTotalAmountButton));
            calculateTotalAmountButton.Click();

            return this;

        }

         public String GetTotalAmount()
         {

            IWebElement totalAmountInCartPage = driver.FindElement(By.CssSelector(totalAmountSelector));

            return totalAmountInCartPage.Text;
         }


         public String GetProductQuantity(int index)
        {

            string inputQuantitySelector = "input#cart_items_" + index + "_quantity";
            productQuantityInCart = driver.FindElement(By.CssSelector(inputQuantitySelector));
  
            return productQuantityInCart.GetAttribute("value");

        }


          public CartPage SetDeliveryType(int i)
          {

                CartPage cartPage = new CartPage(driver);
                AcceptCookie();
                wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(deliveryTypeOptionSelector)));
                driver.FindElements(By.CssSelector(deliveryTypeOptionSelector))[i].Click();
                return cartPage;
          }

          public CartPage SetRealizationType(int i)
          {

            CartPage cartPage = new CartPage(driver);
            AcceptCookie();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(realizationTypeOptionSelector)));
            driver.FindElements(By.CssSelector(realizationTypeOptionSelector))[i].Click();
            return cartPage;
          }

        public CartPage DeleteFromCartPage(String symbol)
        {

            string removeButtonCartPageXPath = ".//a[contains(text(), '" + symbol + "')]/parent::h2/following-sibling::a";
            driver.FindElement(By.XPath(removeButtonCartPageXPath)).Click();

            return this;
        }

       /*
        public OrderingPage SaveAndOrderProductsFromCart()
        {

            this.acceptCookie();
            OrderingPage orderingPage = new OrderingPage(driver);
            driver.findElement(saveAndOrderButtonSelector).click();
            logger.info("Save and Order Button clicked");
            return orderingPage;

        }*/


    }
}