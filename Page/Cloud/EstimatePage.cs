using Framework.Util;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Page.Cloud
{
    public class EstimatePage : AbstractPage
    {
        [FindsBy(How = How.Id, Using = "Email Estimate")]
        private IWebElement emailEstimateButton;

        [FindsBy(How = How.XPath, Using = "//b[contains(text(), 'Total Estimated Cost')]")]
        private IWebElement totalEstimatedMonthlyCostElement;

        [FindsBy(How = How.XPath, Using = "//input[@type='email']")]
        private IWebElement emailInputField;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Send Email')]")]
        private IWebElement sendEmailButton;


        public EstimatePage(IWebDriver driver) : base(driver)
        {

        }

        public EstimatePage OpenEmailEstimateForm()
        {
            emailEstimateButton.Click();
            return this;
        }

        public string GetTotalEstimatedMonthlyCost()
        {
            return StringUtil.SubstringFromTo(MoveToElement(totalEstimatedMonthlyCostElement).Text, "Total Estimated Cost: ", " per 1 month");
        }

        public EstimatePage InputEmail(string email)
        {
            SwitchFrame(CalculatorPage.outerFrameLocator);
            SwitchFrame(CalculatorPage.innerFrameLocator);
            emailInputField.SendKeys(email);
            return this;
        }

        public EstimatePage SendEmail()
        {
            sendEmailButton.Click();
            return this;
        }
    }
}
