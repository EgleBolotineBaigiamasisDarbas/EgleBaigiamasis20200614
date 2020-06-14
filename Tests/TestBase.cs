using BaigiamasisDarbas.Drivers;
using BaigiamasisDarbas.Pages;
using BaigiamasisDarbas.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace BaigiamasisDarbas.Tests
{
    public class TestBase
    {
        public static IWebDriver _driver;
        public static LoginPage _neteisingasPrisijungimas;
        public static LoginPage _teisingasPrisijungimas;
        public static SearchPage _paieska;
        public static SearchPage _konkertizuotaPaieska;
        public static RasytiAtsiliepimaPage _atsiliepimas;


        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            _driver = CustomDrivers.GetChromeDriver();
            _neteisingasPrisijungimas = new LoginPage(_driver);
            _teisingasPrisijungimas = new LoginPage(_driver);
            _paieska = new SearchPage(_driver);
            _konkertizuotaPaieska = new SearchPage(_driver);
            _atsiliepimas = new RasytiAtsiliepimaPage(_driver);
        }


        [TearDown]
        public static void SingleTestTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.MakePhoto(_driver);
            }
        }


        [OneTimeTearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
