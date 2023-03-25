using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Steps
{
    public class Steps
    {
        public IWebDriver driver;

        public void InitBrowser(string browser)
        {
            driver = Driver.DriverSingleton.GetInstance(browser);
        }

        public void CloseBrowser()
        {
            Driver.DriverSingleton.CloseBrowser();
        }
    }
}