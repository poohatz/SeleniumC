using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumC.POM;

namespace SeleniumC.Tests
{
    public class DisplayTests : BaseTest
    {

        private String category = "Mystic Moment";
        private String symbol = "mm04";
        private String category1 = "Mystic Moment";
        private String symbol1 = "mm07";
        private String category2 = "Folk&Boho";
        private String symbol2 = "FB01";
        private String category3 = "Vintage&Nature";
        private String symbol3 = "sa32";


        [Test]
        public void displayAndNavigateProductGalleryTest()
        {

            ProductPage productPage = mainCategoryPage.ViewCategoryByName(category).ViewProductBySymbol(symbol);

            String imageFirstFullProductGalleryFile = productPage
                    .GetImageFullProductGalleryFile();

            int numberOfThumbnails = productPage
                    .GetImageThumbnailProductGalleryFilesList()
                    .Count;

            String imageFirstThumbnailProductGalleryFile = productPage
                    .GetImageThumbnailProductGalleryFilesList().GetEnumerator().Current
                    .GetAttribute("src");

            Assert.IsTrue(imageFirstFullProductGalleryFile.Equals(imageFirstThumbnailProductGalleryFile));


            for (int i = 1; i < numberOfThumbnails; i++)
            {

                String imageNextThumbnailProductGalleryFile = productPage
                        .ChangeImageFullProductGalleryFile(i);

                String imageNextFullProductGalleryFile = productPage
                        .GetImageFullProductGalleryFile();

                Assert.IsTrue(imageNextFullProductGalleryFile.Equals(imageNextThumbnailProductGalleryFile));

            }
        }

        [Test]
        public void displayNumberOfProductsInCartWhileAddingOneTest()
        {

            String number = "1";

            String numberOfProductsDisplay = mainCategoryPage
                    .ViewCategoryByName(category)
                    .AddToCartByCategoryPage(symbol)
                    .ViewMainPage()
                    .GetNumberOfProductsDisplay();

            Assert.AreEqual(numberOfProductsDisplay, number);
        }

        [Test]
        public void displayNumberOfProductsInCartWhileDeletingOneTest()
        {

            String number = "";
            String numberOfProductsDisplay = "";

            numberOfProductsDisplay = mainCategoryPage
                    .ViewCategoryByName(category)
                    .AddToCartByCategoryPage(symbol)
                    .ViewMainPage()
                    .ViewCartPage()
                    .DeleteFromCartPage(symbol)
                    .ViewMainPage()
                    .GetNumberOfProductsDisplay();

            Assert.AreEqual(numberOfProductsDisplay, number);
        }

        [Test]
        public void displayNumberOfProductsInCartWhileAddingThreeTest()
        {

            String number1 = "1";
            String numberOfProductsDisplay1 = "";

            String number2 = "2";
            String numberOfProductsDisplay2 = "";

            String number3 = "3";
            String numberOfProductsDisplay3 = "";

            numberOfProductsDisplay1 = mainCategoryPage
                    .ViewCategoryByName(category1)
                    .AddToCartByCategoryPage(symbol1)
                    .ViewMainPage()
                    .GetNumberOfProductsDisplay();

            Assert.AreEqual(numberOfProductsDisplay1, number1);

            numberOfProductsDisplay2 = mainCategoryPage
                    .ViewCategoryByName(category2)
                    .AddToCartByCategoryPage(symbol2)
                    .ViewMainPage()
                    .GetNumberOfProductsDisplay();

            Assert.AreEqual(numberOfProductsDisplay2, number2);

            numberOfProductsDisplay3 = mainCategoryPage
                    .ViewCategoryByName(category3)
                    .AddToCartByCategoryPage(symbol3)
                    .ViewMainPage()
                    .GetNumberOfProductsDisplay();

            Assert.AreEqual(numberOfProductsDisplay3, number3);

        }

        [Test]
        public void displayNumberOfProductsInCartWhileDeletingThreeTest()
        {

            String number1 = "2";
            String numberOfProductsDisplay1 = "";

            String number2 = "1";
            String numberOfProductsDisplay2 = "";

            String number3 = "";
            String numberOfProductsDisplay3 = "";


            CartPage cartPage = mainCategoryPage
                    .ViewCategoryByName(category1)
                    .AddToCartByCategoryPage(symbol1)
                    .ViewMainPage()
                    .ViewCategoryByName(category2)
                    .AddToCartByCategoryPage(symbol2)
                    .ViewMainPage()
                    .ViewCategoryByName(category3)
                    .AddToCartByCategoryPage(symbol3);

            numberOfProductsDisplay1 = mainCategoryPage
                    .ViewCartPage()
                    .DeleteFromCartPage(symbol1)
                    .GetNumberOfProductsDisplay();

            Assert.AreEqual(numberOfProductsDisplay1, number1);

            numberOfProductsDisplay2 = mainCategoryPage
                    .ViewCartPage()
                    .DeleteFromCartPage(symbol2)
                    .GetNumberOfProductsDisplay();

            Assert.AreEqual(numberOfProductsDisplay2, number2);

            numberOfProductsDisplay3 = mainCategoryPage
                    .ViewCartPage()
                    .DeleteFromCartPage(symbol3)
                    .GetNumberOfProductsDisplay();

            Assert.AreEqual(numberOfProductsDisplay3, number3);

        }

        [Test]
        public void displayCartWithoutContentMessageTest()
        {

            String message = "Brak produktów w koszyku.";

            String messageWhileCartEmpty = mainCategoryPage
                    .ViewCartPage()
                    .GetMessageWhileCartEmpty();

            Assert.AreEqual(message, messageWhileCartEmpty);
        }


    }

}