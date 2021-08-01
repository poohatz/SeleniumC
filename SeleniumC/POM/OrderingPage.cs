using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections;

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

        public OrderingPage FillAddressInStepOneForm(String address)
        {

            driver.FindElement(By.CssSelector(addressInputInStepOneFormOrderingPageSelector)).SendKeys(address);
            return this;
        }

        public OrderingPage ClearAddressInStepOneForm()
        {

            driver.FindElement(By.CssSelector(addressInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }


        public OrderingPage FillCodeInStepOneForm(String code)
        {

            driver.FindElement(By.CssSelector(codeInputInStepOneFormOrderingPageSelector)).SendKeys(code);
            return this;
        }

        public OrderingPage ClearCodeInStepOneForm()
        {

            driver.FindElement(By.CssSelector(codeInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }

        public OrderingPage FillCityInStepOneForm(String city)
        {

            driver.FindElement(By.CssSelector(cityInputInStepOneFormOrderingPageSelector)).SendKeys(city);
            return this;
        }

        public OrderingPage ClearCityInStepOneForm()
        {

            driver.FindElement(By.CssSelector(cityInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }

        public OrderingPage FillTelInStepOneForm(String tel)
        {

            driver.FindElement(By.CssSelector(telInputInStepOneFormOrderingPageSelector)).SendKeys(tel);
            return this;
        }


        public OrderingPage ClearTelInStepOneForm()
        {

            driver.FindElement(By.CssSelector(telInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }


        public OrderingPage FillEmailInStepOneForm(String email)
        {

            driver.FindElement(By.CssSelector(emailInputInStepOneFormOrderingPageSelector)).SendKeys(email);
            return this;
        }

        public OrderingPage ClearEmailInStepOneForm()
        {

            driver.FindElement(By.CssSelector(emailInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }

        public OrderingPage FillCommentsInStepOneForm(String comments)
        {

            driver.FindElement(By.CssSelector(commentsInputInStepOneFormOrderingPageSelector)).SendKeys(comments);
            return this;
        }


        public OrderingPage ClearCommentsInStepOneForm()
        {

            driver.FindElement(By.CssSelector(commentsInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }

        public OrderingPage IsInvoiceNeededOptionSteoOneForm(Boolean invoice)
        {

            driver.FindElement(By.CssSelector(invoiceOptionInStepOneFormOrderingPageSelector)).Click();
            return this;
        }

        public OrderingPage ClearIsInvoiceNeededOptionSteoOneForm()
        {

            driver.FindElement(By.CssSelector(invoiceOptionInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }

        public OrderingPage FillNipInStepOneForm(String nip)
        {

            driver.FindElement(By.CssSelector(nipInputInStepOneFormOrderingPageSelector)).SendKeys(nip);
            return this;
        }

        public OrderingPage ClearNipInStepOneForm()
        {

            driver.FindElement(By.CssSelector(nipInputInStepOneFormOrderingPageSelector)).Clear();
            return this;
        }


        public OrderingPage SaveAndContinueOrderingPage()
        {

            driver.FindElement(By.CssSelector(continueButtonInStepOneFormOrderingPageSelector)).Click();
            return this;
        }

        public Hashtable GetAddressDataFromStepTwoOrderingPage()
        {

            IList<IWebElement> summaryData = driver.FindElements(By.CssSelector(dataFromSummaryOrderingPageSelector));
            Hashtable summaryDataFromOrderingPage = new Hashtable();
            summaryDataFromOrderingPage.Add("name", summaryData[0].Text);
            summaryDataFromOrderingPage.Add("address", summaryData[1].Text);
            summaryDataFromOrderingPage.Add("code", summaryData[2].Text);
            summaryDataFromOrderingPage.Add("city", summaryData[3].Text);
            summaryDataFromOrderingPage.Add("email", summaryData[4].Text);
            summaryDataFromOrderingPage.Add("tel", summaryData[5].Text);
            summaryDataFromOrderingPage.Add("nip", summaryData[6].Text);

            return summaryDataFromOrderingPage;
        }

        public OrderingPage ReturnToStepOneOrderingPage()
        {

            driver.FindElement(By.CssSelector(returnToStepOneButtonOrderingPageSelector)).Click();
            return this;

        }


        public OrderingPage CheckTermsConfirmation()
        {

            driver.FindElement(By.CssSelector(termsConfirmationCheckboxOrderingPageSelector)).Click();
            return this;
        }

        public OrderingPage CheckRodoConfirmation()
        {

            driver.FindElement(By.CssSelector(rodoConfirmationChceckboxOrderingPageSelector)).Click();
            return this;
        }

        public OrderingPage FinalizeAndConfirmOrder()
        {

            driver.FindElement(By.CssSelector(finalOrderButtonOrderingPageSelector)).Click();
            return this;
        }





    }

}
