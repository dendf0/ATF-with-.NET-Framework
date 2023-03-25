using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Page.Cloud
{
    public class ResultsPage : AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='gs-title']/a[@href='https://cloud.google.com/products/calculator']")]
        private IWebElement calculatorLink;

        public ResultsPage(IWebDriver driver) : base(driver)
        {
            
        }

        public CalculatorPage OpenPricingCalculatorPage()
        {
            calculatorLink.Click();
            return new CalculatorPage(driver);
        }
    }
}
