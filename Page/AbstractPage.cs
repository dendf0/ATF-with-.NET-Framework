using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Page
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected const int WAIT_TIMEOUT_SECONDS = 10;
        protected readonly string windowHandle;

        public AbstractPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIMEOUT_SECONDS));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WAIT_TIMEOUT_SECONDS);
            this.driver = driver;
            windowHandle = driver.CurrentWindowHandle;
            PageFactory.InitElements(driver, this);
        }

        public string GetWindowHandle()
        {
            return windowHandle;
        }

        public void SwitchFrame(By locator)
        {
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(locator));
        }

        public IWebElement MoveToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(false);", element);
            return element;
        }

        public IWebElement WaitAndFindElement(By locator) => wait.Until(ExpectedConditions.ElementExists(locator));


    }
}