using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace BaigiamasisDarbas.Tools
{
    public class MyScreenshot
    {
        public static void MakePhoto(IWebDriver webDriver)
        {
            Screenshot myScreenshot = webDriver.TakeScreenshot();

            string screenShotDirectory = 
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            Assembly.GetExecutingAssembly().Location)));

            string screenShotFolder = Path.Combine(screenShotDirectory, "screenshots");

            Directory.CreateDirectory(screenShotFolder);

            string screenShotName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:HH-mm}.png";

            string screenShotPath = Path.Combine(screenShotFolder, screenShotName);

            myScreenshot.SaveAsFile(screenShotPath, ScreenshotImageFormat.Png);

            Console.WriteLine($"Issaugojom {screenShotPath}");
        }
    }
}
