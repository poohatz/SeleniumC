using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumC.POM
{
    public abstract class BasePage
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public IWebElement acceptCookie;


        protected string acceptCookieSelector = "div#gdpr-warning > button.accept-cookie";
        private string numberOfProductsDisplaySelector = "span.cart-number";
        private string cartSelector = "a > img[alt='Koszyk']";
        private string messageWhileCartEmptySelector = "#cart_items";



        public BasePage(IWebDriver driver)
        {

            this.driver = driver;

        }
        public BasePage()
        {

        }

        public virtual void AcceptCookie()
        {

            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            try
            {

                acceptCookie = driver.FindElement(By.CssSelector(acceptCookieSelector));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(acceptCookie));
                if (acceptCookie != null) acceptCookie.Click();
            }
            catch (Exception E)
            {
            }
        }

        public MainCategoryPage ViewMainPage()
        {

            driver.Navigate().GoToUrl("https://www.decarte.com.pl/sklep/zaproszenia-slubne");
            return new MainCategoryPage(driver);
        }

        public virtual String GetNumberOfProductsDisplay()
        {

            String numberOfProductsDisplay = "";

            try
            {

                numberOfProductsDisplay = driver.FindElement(By.CssSelector(numberOfProductsDisplaySelector)).Text;
            }
            catch (NoSuchElementException e) { }

            return numberOfProductsDisplay;
        }

        public virtual CartPage ViewCartPage()
        {

            CartPage cartPage = new CartPage(driver);
            driver.FindElement(By.CssSelector(cartSelector)).Click();
            return cartPage;
        }

        public virtual String GetMessageWhileCartEmpty()
        {

            CartPage cartePage = new CartPage(driver);
            return driver.FindElement(By.CssSelector(messageWhileCartEmptySelector)).Text;
        }

    }
}
