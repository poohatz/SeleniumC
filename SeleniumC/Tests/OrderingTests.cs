using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumC.POM;
using System.Collections;

namespace SeleniumC.Tests
{
    public class OrderingTests : BaseTest
    {
        private String name = "Anna Jankowska";
        private String address = "Kowala 12/2";
        private String city = "Lidzbark";
        private String code = "11-123";
        private String email = "anna@wp.pl";
        private String email2 = "annawp.pl";
        private String email3 = "@wop.pl";
        private String email4 = "@asdasd";
        private String tel = "678632127";
        private String comments = "";
        private Boolean invoice = true;
        private String nip = "98732123287";
        private String category = "Vintage&Nature";
        private String symbol = "sa32";

        [Test]
        public void OrderProductsFromCartPageHappyPath()
        {

            int deliveryType = 0;
            int realizationType = 1;

            String heading = "Krok 1 z 2: Podaj dane do wysyłki";
            String headingStepOneOrderingPage = "";

            headingStepOneOrderingPage = mainCategoryPage
                .ViewCategoryByName(category)
                .AddToCartByCategoryPage(symbol)
                .SetRealizationType(realizationType)
                .SetDeliveryType(deliveryType)
                .SaveAndOrderProductsFromCart()
                .GetHeadingOrderingPage();

            Assert.AreEqual(heading, headingStepOneOrderingPage);

        }

        [Test]
        public void fillingAddressFormStepOneOrderingPageTestNegativeWays()
        {

            int deliveryType = 0;
            int realizationType = 1;

            String message1 = "Wypełnij to pole.";
            String message2 = "Uwzględnij znak „@” w adresie e-mail. W adresie „" + email2 + "” brakuje znaku „@”.";
            String message3 = "Podaj część przed znakiem „@”. Adres „" + email3 + "” jest niepełny.";
            String message4 = "Część przed znakiem „@” nie może zawierać symbolu „;”.";

            String nameAlertMessage = "";
            String addressAlertMessage = "";
            String codeAlertMessage = "";
            String telAlertMessage = "";
            String emailAlertMessage = "";
            String cityAlertMessage = "";
            String commentsAlertMessage = "";
            String nipAlertMessage = "";


            //case 1 :: field name is empty

            MainCategoryPage mainCategoryPage = new MainCategoryPage(driver);
            mainCategoryPage.AcceptCookie();

            OrderingPage orderingPage = mainCategoryPage
                .ViewCategoryByName(category)
                .AddToCartByCategoryPage(symbol)
                .SetRealizationType(realizationType)
                .SetDeliveryType(deliveryType)
                .SaveAndOrderProductsFromCart()
                .FillAddressInStepOneForm(address)
                .FillCityInStepOneForm(city)
                .FillCodeInStepOneForm(code)
                .FillEmailInStepOneForm(email)
                .FillTelInStepOneForm(tel)
                .IsInvoiceNeededOptionSteoOneForm(invoice)
                .FillNipInStepOneForm(nip)
                .SaveAndContinueOrderingPage();

            nameAlertMessage = (String)jse.ExecuteScript(
                "const name = document.querySelector(\"#shipping_details_name\");"
                        + "message = name.validationMessage; return message;");

            Assert.AreEqual(message1, nameAlertMessage);


            //case 2 :: field address is empty

            orderingPage = orderingPage
                .ClearAddressInStepOneForm()
                .FillNameInStepOneForm(name)
                .SaveAndContinueOrderingPage();

            addressAlertMessage = (String)jse.ExecuteScript(
                "const address = document.querySelector(\"#shipping_details_street\");"
                        + "message = address.validationMessage; return message;");

            Assert.AreEqual(message1, addressAlertMessage);


            //case 3 :: field code is empty

            orderingPage = orderingPage
                .ClearCodeInStepOneForm()
                .FillAddressInStepOneForm(address)
                .SaveAndContinueOrderingPage();

            codeAlertMessage = (String)jse.ExecuteScript(
                "const code = document.querySelector(\"#shipping_details_postalCode\");"
                        + "message = code.validationMessage; return message;");

            Assert.AreEqual(message1, codeAlertMessage);


            //case 4 :: field email is empty

            orderingPage = orderingPage
                .ClearEmailInStepOneForm()
                .FillCodeInStepOneForm(code)
                .SaveAndContinueOrderingPage();

            emailAlertMessage = (String)jse.ExecuteScript(
                "const email = document.querySelector(\"#shipping_details_email\");"
                        + "message = email.validationMessage; return message;");

            Assert.AreEqual(message1, emailAlertMessage);


            //case 5 :: field tel is empty

            orderingPage = orderingPage
                .ClearTelInStepOneForm()
                .FillEmailInStepOneForm(email)
                .SaveAndContinueOrderingPage();

            telAlertMessage = (String)jse.ExecuteScript(
                "const tel = document.querySelector(\"#shipping_details_phone\");"
                        + "message = tel.validationMessage; return message;");

            Assert.AreEqual(message1, telAlertMessage);


            //case 6 :: field email has not got '@'

             orderingPage = orderingPage
                .ClearEmailInStepOneForm()
                .FillTelInStepOneForm(tel)
                .FillEmailInStepOneForm(email2)
                .SaveAndContinueOrderingPage();

            emailAlertMessage = (String)jse.ExecuteScript(
                "const email = document.querySelector(\"#shipping_details_email\");"
                        + "message = email.validationMessage; return message;");

            Assert.AreEqual(message2, emailAlertMessage);


            //case 7 :: field email has got nothing before '@'

            orderingPage = orderingPage
                .ClearEmailInStepOneForm()
                .FillEmailInStepOneForm(email3)
                .SaveAndContinueOrderingPage();

            emailAlertMessage = (String)jse.ExecuteScript(
                "const email = document.querySelector(\"#shipping_details_email\");"
                        + "message = email.validationMessage; return message;");

            Assert.AreEqual(message3, emailAlertMessage);


            //case 8 :: field email has got wrong sings

            orderingPage = orderingPage
                .ClearEmailInStepOneForm()
                .FillEmailInStepOneForm(email4)
                .SaveAndContinueOrderingPage();

            emailAlertMessage = (String)jse.ExecuteScript(
                "const email = document.querySelector(\"#shipping_details_email\");"
                        + "message = email.validationMessage; return message;");

            Assert.AreEqual(message4, emailAlertMessage, "Komunikat jest bledny");

        }

        [Test]
        public void fillingAddressFormStepOneOrderingPageTestPositiveWays()
        {

            int deliveryType = 0;
            int realizationType = 1;

            String heading = "Krok 2 z 2: Sprawdź swoje zamówienie";
            String headingStepTwoOrderingPage = "";

            //case 1 :: all fields filled in

            OrderingPage orderingPage = new OrderingPage(driver);

            headingStepTwoOrderingPage = mainCategoryPage
                .ViewCategoryByName(category)
                .AddToCartByCategoryPage(symbol)
                .SetRealizationType(realizationType)
                .SetDeliveryType(deliveryType)
                .SaveAndOrderProductsFromCart()
                .FillNameInStepOneForm(name)
                .FillAddressInStepOneForm(address)
                .FillCityInStepOneForm(city)
                .FillCodeInStepOneForm(code)
                .FillEmailInStepOneForm(email)
                .FillTelInStepOneForm(tel)
                .IsInvoiceNeededOptionSteoOneForm(invoice)
                .FillNipInStepOneForm(nip)
                .SaveAndContinueOrderingPage()
                .GetHeadingOrderingPage();

            Assert.AreEqual(heading, headingStepTwoOrderingPage);

            //case 2 :: checking if address data in summary is the same

            Hashtable summaryDataFromOrderingPage = orderingPage.GetAddressDataFromStepTwoOrderingPage();

            Assert.AreEqual(name, summaryDataFromOrderingPage["name"]);
            Assert.AreEqual(address, summaryDataFromOrderingPage["address"]);
            Assert.AreEqual(code, summaryDataFromOrderingPage["code"]);
            Assert.AreEqual(city, summaryDataFromOrderingPage["city"]);
            Assert.AreEqual(email, summaryDataFromOrderingPage["email"]);
            Assert.AreEqual(tel, summaryDataFromOrderingPage["tel"]);
            Assert.AreEqual(nip, summaryDataFromOrderingPage["nip"]);

            //case 3 :: only field nip is empty

            headingStepTwoOrderingPage = orderingPage
                .ReturnToStepOneOrderingPage()
                .ClearNipInStepOneForm()
                .SaveAndContinueOrderingPage()
                .GetHeadingOrderingPage();

            Assert.AreEqual(heading, headingStepTwoOrderingPage);


            //case 4 :: only field comments is empty

            headingStepTwoOrderingPage = orderingPage
                .ReturnToStepOneOrderingPage()
                .ClearCommentsInStepOneForm()
                .IsInvoiceNeededOptionSteoOneForm(true)
                .FillNipInStepOneForm(nip)
                .SaveAndContinueOrderingPage()
                .GetHeadingOrderingPage();

            Assert.AreEqual(heading, headingStepTwoOrderingPage);

        }

  
        [Test]
        public void finalizeOrderAndPayLaterInOrderingPagePositiveWay()
        {

            int deliveryType = 1;
            int realizationType = 1;

            String heading = "Dziękujemy za złożenie zamówienia w naszej firmie!";
            String finalOrderConfirmationHeading = "";

            finalOrderConfirmationHeading = mainCategoryPage
                .ViewCategoryByName(category)
                .AddToCartByCategoryPage(symbol)
                .SetRealizationType(realizationType)
                .SetDeliveryType(deliveryType)
                .SaveAndOrderProductsFromCart()
                .FillNameInStepOneForm(name)
                .FillAddressInStepOneForm(address)
                .FillCityInStepOneForm(city)
                .FillCodeInStepOneForm(code)
                .FillEmailInStepOneForm(email)
                .FillTelInStepOneForm(tel)
                .IsInvoiceNeededOptionSteoOneForm(invoice)
                .FillNipInStepOneForm(nip)
                .SaveAndContinueOrderingPage()
                .CheckRodoConfirmation()
                .CheckTermsConfirmation()
                .FinalizeAndConfirmOrder()
                .GetFinalHeadingOrderingPage();

            Assert.AreEqual(heading, finalOrderConfirmationHeading);

        }

        [Test]
        public void finalizeOrderAndPayLaterInOrderingPageNegativeWays()
        {

        int deliveryType = 1;
        int realizationType = 1;

        String message1 = "Zaznacz to pole, jeśli chcesz kontynuować.";
        String termsAlertMessage = "";
        String rodoAlertMessage = "";


        //case 1 :: Finalizing without accepting terms and rodo

        OrderingPage orderingPage = mainCategoryPage
                .ViewCategoryByName(category)
                .AddToCartByCategoryPage(symbol)
                .SetRealizationType(realizationType)
                .SetDeliveryType(deliveryType)
                .SaveAndOrderProductsFromCart()
                .FillNameInStepOneForm(name)
                .FillAddressInStepOneForm(address)
                .FillCityInStepOneForm(city)
                .FillCodeInStepOneForm(code)
                .FillEmailInStepOneForm(email)
                .FillTelInStepOneForm(tel)
                .IsInvoiceNeededOptionSteoOneForm(invoice)
                .FillNipInStepOneForm(nip)
                .SaveAndContinueOrderingPage()
                .FinalizeAndConfirmOrder();

        termsAlertMessage = (String)jse.ExecuteScript(
                "const terms = document.querySelector(\"#terms\");"
                        + "message = terms.validationMessage; return message;");

        Assert.AreEqual(message1, termsAlertMessage);


        //case 2 :: Finalizing without accepting terms

        orderingPage = orderingPage
                .ViewMainPage()
                .ViewCategoryByName(category)
                .AddToCartByCategoryPage(symbol)
                .SetRealizationType(realizationType)
                .SetDeliveryType(deliveryType)
                .SaveAndOrderProductsFromCart()
                .SaveAndContinueOrderingPage()
                .CheckRodoConfirmation()
                .FinalizeAndConfirmOrder();

        termsAlertMessage = (String)jse.ExecuteScript(
                "const terms = document.querySelector(\"#terms\");"
                        + "message = terms.validationMessage; return message;");

        Assert.AreEqual(message1, termsAlertMessage);


        //case 3 :: Finalizing without accepting rodo

        orderingPage = orderingPage
                .ViewMainPage()
                .ViewCategoryByName(category)
                .AddToCartByCategoryPage(symbol)
                .SetRealizationType(realizationType)
                .SetDeliveryType(deliveryType)
                .SaveAndOrderProductsFromCart()
                .SaveAndContinueOrderingPage()
                .CheckTermsConfirmation()
                .FinalizeAndConfirmOrder();

        rodoAlertMessage = (String)jse.ExecuteScript(
                "const rodo = document.querySelector(\"#personal-data\");"
                        + "message = rodo.validationMessage; return message;");

        Assert.AreEqual(message1, rodoAlertMessage);
    }

}
}
