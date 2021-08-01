using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumC.POM;

namespace SeleniumC.Tests
{

    public class BaseTest
    {
        protected IWebDriver driver;
        protected IJavaScriptExecutor jse;
        public MainCategoryPage mainCategoryPage;
        //protected CartPage cartPage;

        protected string[] categories = {"Nowości", "Mystic Moment", "Folk&Boho", "Wild Garden", "Vintage&Nature", "Pastellove",
            "Royal Style", "Simple Beauty", "Classic Elegance", "Colors of Love", "Passion&Fun" };

    
       
     [SetUp]
    public void TestSetUp()
        {

            driver = new ChromeDriver();

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.decarte.com.pl/sklep/zaproszenia-slubne");

            jse = (IJavaScriptExecutor) driver;

            mainCategoryPage = new MainCategoryPage(driver);
            mainCategoryPage.AcceptCookie();

        }

    [TearDown]
    public void CloseDriver()
        {

            driver.Close();
            driver.Quit();

        }
    }
}
