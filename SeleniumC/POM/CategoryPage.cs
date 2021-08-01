using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumC.POM
{
    public class CategoryPage : BasePage
    {
        private string categoryNameSelector = "h1";
        private string productSymbolFirstSelector = "ul#products > li > a > img";
        private string productSymbolLastSelector = "p.description";


        public CategoryPage(IWebDriver driver) : base(driver)
        {
        }


        public String GetCategoryName()
        {

            return driver.FindElement(By.CssSelector(categoryNameSelector)).Text;
        }


        public String FindLastProductSymbol()
        {

            var ProductsFromCategory = driver.FindElements(By.CssSelector(productSymbolLastSelector));
            int index = ProductsFromCategory.Count - 1;

            IWebElement lastProductFromCategory = ProductsFromCategory[index];
            String lastProductSymbol = lastProductFromCategory.Text;
            lastProductSymbol = lastProductSymbol.Substring(6);
            int spacePosition = lastProductSymbol.IndexOf(" ");
            lastProductSymbol = lastProductSymbol.Substring(0, spacePosition - 1);

            return lastProductSymbol;

        }


        public ProductPage ViewProductBySymbol(String symbol)
        {

            string productSymbolSelector = "img[alt='Model " + symbol + "']";
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            AcceptCookie();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(productSymbolSelector)));
            ProductPage productPage = new ProductPage(driver, symbol);
            driver.FindElement(By.CssSelector(productSymbolSelector)).Click();
            return productPage;
        }


        public ProductPage ViewFirstProductPage()
        {

            ProductPage productPage = new ProductPage(driver);
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(productSymbolFirstSelector)));
            IWebElement firstProductFromCategory = driver.FindElements(By.CssSelector(productSymbolFirstSelector))[0];
            firstProductFromCategory.Click();

            String productSymbol = productPage.GetProductSymbol();
            productPage = new ProductPage(driver, productSymbol);
            return productPage;

        }


        public CartPage AddToCartByCategoryPage(String symbol)
        {

            AcceptCookie();

            string orderButtonCategoryPageXPath = ".//a/img[@alt='Model " + symbol + "']/parent::a/parent::li/form/button";
            driver.FindElement(By.XPath(orderButtonCategoryPageXPath)).Click();
            CartPage cartPage = new CartPage(driver);
            ViewCartPage();
            return cartPage;
        }
    }

}
