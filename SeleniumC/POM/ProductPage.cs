using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumC.POM
{
    public class ProductPage : BasePage
    {
        private string symbol;

        private string productSymbolSelector = "h1.product_name";
        private string buttonNextSelector = "div.container > div > div > div > a.next";
        private string buttonPreviousSelector = "div.container > div > div > div > a.prev";
        private string addToCartButtonSelector = "form > div > button";
        private string imageThumbnailProductGallerySelector = "img[data-index]";

        public ICollection<IWebElement> imageThumbnailProductGalleryFilesList;

        public ProductPage(IWebDriver driver, String symbol) : base(driver)
        {
            this.symbol = symbol;
        }

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }


        public String GetProductSymbol()
        {

            String productSymbol = driver.FindElement(By.CssSelector(productSymbolSelector)).Text;
            return productSymbol;
        }

        public ProductPage ViewNextProductPage()
        {

            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(buttonNextSelector)));
            IWebElement buttonNextProduct = driver.FindElement(By.CssSelector(buttonNextSelector));
            buttonNextProduct.Click();
            return this;
        }

        public ProductPage ViewPreviousProductPage()
        {

            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(buttonPreviousSelector)));
            IWebElement buttonPreviousProduct = driver.FindElement(By.CssSelector(buttonPreviousSelector));
            buttonPreviousProduct.Click();
            return this;

        }
        
        public CartPage AddToCart()
        {

            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(addToCartButtonSelector)));
            IWebElement addToCartButton = driver.FindElement(By.CssSelector(addToCartButtonSelector));
            addToCartButton.Click();
            return new CartPage(driver);
        }

        public String GetImageFullProductGalleryFile()
        {

            string imageFullProductGallerySelector = "img[alt*=' " + symbol + " ']";
            return driver.FindElements(By.CssSelector(imageFullProductGallerySelector))[0].GetAttribute("src");
        }

        public ICollection<IWebElement> GetImageThumbnailProductGalleryFilesList()
         {

             var imageThumbnailProductGalleryFilesList = driver.FindElements(By.CssSelector(imageThumbnailProductGallerySelector));
             return imageThumbnailProductGalleryFilesList;
         }

         public String ChangeImageFullProductGalleryFile(int imageThumbnailProductsGalleryFilesIndex)
         {

            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            imageThumbnailProductGalleryFilesList = driver.FindElements(By.CssSelector(imageThumbnailProductGallerySelector));
            IWebElement imageThumbnailProductGallery = (IWebElement)imageThumbnailProductGalleryFilesList;
            var count = 0;
            do {
                if (imageThumbnailProductGalleryFilesList.GetEnumerator().MoveNext())
                {
                    imageThumbnailProductGallery = (IWebElement)imageThumbnailProductGalleryFilesList;
                }
                count++;
            }
            while (count <= imageThumbnailProductsGalleryFilesIndex);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(imageThumbnailProductGallery));
            imageThumbnailProductGallery.Click();
            return this.GetImageFullProductGalleryFile();
         }

    }
}
