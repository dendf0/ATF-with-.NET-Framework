using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Page.Mail
{
    public class GeneratorPage : AbstractPage
    {
        [FindsBy(How = How.Id, Using = "egen")]
        private IWebElement generatedEmail;

        [FindsBy(How = How.XPath, Using = "//button[@onclick='egengo();']")]
        private IWebElement openInboxButton;

        public GeneratorPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string GetEmail()
        {
            string email = generatedEmail.Text;
            return email;
        }

        public InboxPage OpenInbox()
        {
            openInboxButton.Click();
            return new InboxPage(driver);
        }

    }
}