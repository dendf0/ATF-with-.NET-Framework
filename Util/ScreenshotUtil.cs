using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Util
{
    public static class ScreenshotUtil
    {
        //private static string execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static void TakeAndSaveScreenshot(IWebDriver driver)
        {
            ITakesScreenshot? ts = driver as ITakesScreenshot;
            Screenshot screenshot = ts.GetScreenshot();
            SaveScreenShotWithTimeStamp(screenshot);
        }

        private static void SaveScreenShotWithTimeStamp(Screenshot screenshot)
        {
            DateTime dateTime = DateTime.Now;
            string folder = "Screenshots";
            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }
            Directory.CreateDirectory(folder);
            screenshot.SaveAsFile(Path.Combine(folder, $"screenshot_{GetTimeStamp(dateTime)}.jpeg"));
        }

        private static string GetTimeStamp(DateTime dateTime) => dateTime.ToString("yyyy-MM-dd_HH-mm-ss");
    }
}