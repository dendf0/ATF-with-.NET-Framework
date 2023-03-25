using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Page.Mail
{
    public class InboxPage : AbstractPage
    {
        private const int WAIT_EMAIL_SECONDS = 60;

        [FindsBy(How = How.Id, Using = "refresh")]
        private IWebElement refreshButton;

        [FindsBy(How = How.Id, Using = "nbmail")]
        private IWebElement numberOfIncomingEmailsElement;

        [FindsBy(How = How.XPath, Using = "//h3[contains (text(), 'Total Estimated Monthly Cost')]/parent::td/following-sibling::td/h3")]
        private IWebElement totalEstimatedMonthlyCostElement;

        private By mailBodyFrameLocator = By.Id("ifmail");
        [FindsBy(How = How.Id, Using = "ifmail")]
        private IWebElement mailBodyFrame;

        public InboxPage(IWebDriver driver) : base(driver)
        {
            
        }

        public bool IsEmailReceived()
        {
            WebDriverWait waitOneSecond = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            DateTime startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime).TotalSeconds < WAIT_EMAIL_SECONDS)
            {
                refreshButton.Click();
                try
                {
                    waitOneSecond.Until(ExpectedConditions.TextToBePresentInElement(numberOfIncomingEmailsElement, "1 mail"));
                    return true;
                }
                catch (WebDriverTimeoutException)
                {
                }
            }
            return false;
        }

        public string GetTotalEstimatedMonthlyCost()
        {
            SwitchFrame(mailBodyFrameLocator);
            return totalEstimatedMonthlyCostElement.Text;
        }
        
    }
}