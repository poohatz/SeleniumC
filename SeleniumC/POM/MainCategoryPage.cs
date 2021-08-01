using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumC.POM
{
    public class MainCategoryPage : BasePage
    {
        public MainCategoryPage(IWebDriver driver) : base (driver) 
        {
        }

        public CategoryPage ViewCategoryByName(String categoryName)
        {

            CategoryPage categoryPage = new CategoryPage(driver);
            driver.FindElement(By.LinkText(categoryName)).Click();
            return categoryPage;
        }
    }
    
}
