using Framework.Page.Cloud;
using Framework.Page.Mail;
using Framework.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Test
{
    [TestFixture]
    public class CalculatorPageTest : CommonConditions
    {
        private GeneratorPage GenerateEmail()
        {
            return new MailMainPage(steps.driver)
                .OpenPage()
                .PressEmailGenerator();
        }

        [Test]
        [Category("Integration")]
        [Category("Regression")]
        public void GoogleCloudPricingCalculatorTest()
        {
            string email;
            string costInCalculator;
            string costInLetter;

            EstimatePage estimatePage = new MainPage(steps.driver)
                .OpenPage()
                .SearchForCalculator()
                .OpenPricingCalculatorPage()
                .ComputeEngine(testData.engine);
            costInCalculator = estimatePage.GetTotalEstimatedMonthlyCost();
            estimatePage.OpenEmailEstimateForm();
            GeneratorPage generatorPage = GenerateEmail();
            email = generatorPage.GetEmail();
            InboxPage inboxPage = generatorPage.OpenInbox();
            steps.driver.SwitchTo().Window(estimatePage.GetWindowHandle());
            estimatePage.InputEmail(email)
                .SendEmail();
            steps.driver.SwitchTo().Window(generatorPage.GetWindowHandle());

            Assert.IsTrue(inboxPage.IsEmailReceived());

            costInLetter = inboxPage.GetTotalEstimatedMonthlyCost();

            Assert.That(costInCalculator, Is.EqualTo(costInLetter));
        }
    }
}