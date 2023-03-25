using Framework.Service;
using Framework.Util;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Test
{
    public class CommonConditions
    {
        public Steps.Steps steps = new Steps.Steps();
        public TestDataReader testData;

        [SetUp]
        public void Init()
        {
            string environment = TestContext.Parameters.Get("environment") ?? "dev";
            testData = new TestDataReader(environment);
            string browser= TestContext.Parameters.Get("browser") ?? "chrome";
            steps.InitBrowser(browser);
        }

        [TearDown]
        public void Cleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenshotUtil.TakeAndSaveScreenshot(steps.driver);
            }
            steps.CloseBrowser();
        }
    }
}
