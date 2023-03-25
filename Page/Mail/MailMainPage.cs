using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Page.Mail
{
    public class MailMainPage: AbstractPage
    {
        private string link = "https://yopmail.com/";

        [FindsBy(How = How.XPath, Using = "//a[@href='email-generator']")]
        private IWebElement emailGenerator;

        public MailMainPage(IWebDriver driver) : base(driver)
        {
            
        }

        public MailMainPage OpenPage()
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.Navigate().GoToUrl(link);
            return this;
        }

        public GeneratorPage PressEmailGenerator()
        {
            emailGenerator.Click();
            return new GeneratorPage(driver);
        }

    }
}