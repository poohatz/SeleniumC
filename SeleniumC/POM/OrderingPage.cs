using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumC.POM
{
    public class OrderingPage : BasePage
    {

        private string headingOrderingPageSelector = "h1";
        private string headingOrderConfirmationOrderingPageSelector = "div[class='col-12 col-md-9'] > h3";
        private string finalOrderButtonOrderingPageSelector = "input.btn.btn-warning";
        private string dataFromSummaryOrderingPageSelector = "tr > td";
        private string returnToStepOneButtonOrderingPageSelector = "Wróć do edycji danych";
        private string nameInputInStepOneFormOrderingPageSelector = "#shipping_details_name";
        private string addressInputInStepOneFormOrderingPageSelector = "#shipping_details_street";
        private string cityInputInStepOneFormOrderingPageSelector = "#shipping_details_city";
        private string codeInputInStepOneFormOrderingPageSelector = "#shipping_details_postalCode";
        private string telInputInStepOneFormOrderingPageSelector = "#shipping_details_phone";
        private string emailInputInStepOneFormOrderingPageSelector = "#shipping_details_email";
        private string commentsInputInStepOneFormOrderingPageSelector = "#shipping_details_notes";
        private string invoiceOptionInStepOneFormOrderingPageSelector = "#shipping_details_hasInvoice";
        private string nipInputInStepOneFormOrderingPageSelector = "#shipping_details_taxId";
        private string continueButtonInStepOneFormOrderingPageSelector = "#shipping_details_save";
        private string termsConfirmationCheckboxOrderingPageSelector = "#terms";
        private string rodoConfirmationChceckboxOrderingPageSelector = "#personal-data";


        public OrderingPage(IWebDriver driver) : base(driver)
        {
        }


        public String GetHeadingOrderingPage()
        {

            return driver.FindElement(By.CssSelector(headingOrderingPageSelector)).Text;

        }

        public String GetFinalHeadingOrderingPage()
        {

            return driver.FindElement(By.CssSelector(headingOrderConfirmationOrderingPageSelector)).Text;

        }

        public OrderingPage FillNameInStepOneForm(String name)
        {

            driver.FindElement(By.CssSelector(nameInputInStepOneFormOrderingPageSelector)).SendKeys(name);
            return this;
        }

        public OrderingPage ClearNameInStepOneForm()
        {

            driver.FindElement(By.CssSelector(nameInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }

        public OrderingPage fillAddressInStepOneForm(String address)
        {

            driver.FindElement(By.CssSelector(addressInputInStepOneFormOrderingPageSelector)).SendKeys(address);
            return this;
        }

        public OrderingPage clearAddressInStepOneForm()
        {

            driver.FindElement(By.CssSelector(addressInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }


        public OrderingPage fillCodeInStepOneForm(String code)
        {

            driver.FindElement(By.CssSelector(codeInputInStepOneFormOrderingPageSelector)).SendKeys(code);
            return this;
        }

        public OrderingPage clearCodeInStepOneForm()
        {

            driver.FindElement(By.CssSelector(codeInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }

        public OrderingPage fillCityInStepOneForm(String city)
        {

            driver.FindElement(By.CssSelector(cityInputInStepOneFormOrderingPageSelector)).SendKeys(city);
            return this;
        }

        public OrderingPage clearCityInStepOneForm()
        {

            driver.FindElement(By.CssSelector(cityInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }

        public OrderingPage fillTelInStepOneForm(String tel)
        {

            driver.FindElement(By.CssSelector(telInputInStepOneFormOrderingPageSelector)).SendKeys(tel);
            return this;
        }


        public OrderingPage clearTelInStepOneForm()
        {

            driver.FindElement(By.CssSelector(telInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }


        public OrderingPage fillEmailInStepOneForm(String email)
        {

            driver.FindElement(By.CssSelector(emailInputInStepOneFormOrderingPageSelector)).SendKeys(email);
            return this;
        }

        public OrderingPage clearEmailInStepOneForm()
        {

            driver.FindElement(By.CssSelector(emailInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }

        public OrderingPage fillCommentsInStepOneForm(String comments)
        {

            driver.FindElement(By.CssSelector(commentsInputInStepOneFormOrderingPageSelector)).SendKeys(comments);
            return this;
        }


        public OrderingPage clearCommentsInStepOneForm()
        {

            driver.FindElement(By.CssSelector(commentsInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }

        public OrderingPage isInvoiceNeededOptionSteoOneForm(Boolean invoice)
        {

            driver.FindElement(By.CssSelector(invoiceOptionInStepOneFormOrderingPageSelector)).Click();
            return this;
        }

        public OrderingPage clearIsInvoiceNeededOptionSteoOneForm()
        {

            driver.FindElement(By.CssSelector(invoiceOptionInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }

        public OrderingPage fillNipInStepOneForm(String nip)
        {

            driver.FindElement(By.CssSelector(nipInputInStepOneFormOrderingPageSelector)).SendKeys(nip);
            return this;
        }

        public OrderingPage clearNipInStepOneForm()
        {

            driver.FindElement(By.CssSelector(nipInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }


        public OrderingPage saveAndContinueOrderingPage()
        {

            driver.FindElement(By.CssSelector(continueButtonInStepOneFormOrderingPageSelector)).Click();
            return this;
        }

        /*public Map<String, String> getAddressDataFromStepTwoOrderingPage()
        {

            List<WebElement> summaryData = driver.findElements(dataFromSummaryOrderingPageSelector);
            Map<String, String> summaryDataFromOrderingPage = new HashMap<>();
            summaryDataFromOrderingPage.put("name", summaryData.get(0).getText());
            summaryDataFromOrderingPage.put("address", summaryData.get(1).getText());
            summaryDataFromOrderingPage.put("code", summaryData.get(2).getText());
            summaryDataFromOrderingPage.put("city", summaryData.get(3).getText());
            summaryDataFromOrderingPage.put("email", summaryData.get(4).getText());
            summaryDataFromOrderingPage.put("tel", summaryData.get(5).getText());
            summaryDataFromOrderingPage.put("nip", summaryData.get(6).getText());

            return summaryDataFromOrderingPage;
        }*/

        public OrderingPage returnToStepOneOrderingPage()
        {

            driver.FindElement(By.CssSelector(returnToStepOneButtonOrderingPageSelector)).Click();
            return this;

        }


        public OrderingPage checkTermsConfirmation()
        {

            driver.FindElement(By.CssSelector(termsConfirmationCheckboxOrderingPageSelector)).Click();
            return this;
        }

        public OrderingPage checkRodoConfirmation()
        {

            driver.FindElement(By.CssSelector(rodoConfirmationChceckboxOrderingPageSelector)).Click();
            return this;
        }

        public OrderingPage finalizeAndConfirmOrder()
        {

            driver.FindElement(By.CssSelector(finalOrderButtonOrderingPageSelector)).Click();
            return this;
        }





    }

}