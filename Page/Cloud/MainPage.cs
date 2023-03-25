using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Page.Cloud
{
    public class MainPage : AbstractPage
    {
        private string link = "https://cloud.google.com/";
        private string toSearch = "Google Cloud Platform Pricing Calculator";
        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement searchField;


        public MainPage(IWebDriver driver) : base(driver)
        {
            
        }

        public MainPage OpenPage()
        {
            driver.Navigate().GoToUrl(link);
            return this;
        }

        public ResultsPage SearchForCalculator()
        {
            searchField.SendKeys(toSearch + Keys.Enter);
            return new ResultsPage(driver);
        }
    }
}
