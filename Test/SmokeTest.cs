using Framework.Page.Cloud;
using Framework.Page.Mail;
using Framework.Service;
using Framework.Steps;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Runtime.InteropServices;

namespace Framework.Test
{
    [TestFixture]
    public class SmokeTest : CommonConditions
    {
        [Test]
        [Category("Smoke")]
        [Category("Regression")]
        public void OpenCalculatorPageTest()
        {
            CalculatorPage calculatorPage = new MainPage(steps.driver)
                .OpenPage()
                .SearchForCalculator()
                .OpenPricingCalculatorPage();

            Assert.IsTrue(steps.driver.Title.Equals("Google Cloud Pricing Calculator"));
            
            Assert.Fail();
        }
    }
}