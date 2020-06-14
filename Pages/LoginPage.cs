using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BaigiamasisDarbas.Pages
{
    public class LoginPage : PageBase
    {
        private const string PageAddress = "https://domoplius.lt/pasas/registracija";
        private IWebElement _prisijungimoIDIvedimoField => _driver.FindElement(By.Id("login_name"));
        private IWebElement _passwordIvedimoField => _driver.FindElement(By.Id("login_password"));
        private IWebElement _isimintiTickBox => _driver.FindElement(By.Id("remember_me"));
        private IWebElement _prisijungimoMygtukas => _driver.FindElement(By.CssSelector(".post-button"));
        private IWebElement _neteisingoPrisijungimoIdentifikatorius => _driver.FindElement(By.CssSelector(".error-msg"));
        private IWebElement _prisijungtidarkartTab => _driver.FindElement(By.CssSelector(".login-tabs li:nth-child(1) > a"));
        private IWebElement _domopliusLogo => _driver.FindElement(By.XPath("//*[@id='domoplius']/div[1]/div/div/div/ul/li[1]/a/img"));
        private IWebElement _teisingasPrisijungimas => _driver.FindElement(By.XPath("//*[@id='domoplius']/div[2]/div/div[1]/div[1]/a[6]/strong"));


        public LoginPage(IWebDriver webdriver) : base(webdriver) { }


        public LoginPage OpenPrisijungimasPage()
        {
            if (_driver.Url != PageAddress)
                _driver.Url = PageAddress;
            return this;
        }

        public LoginPage EnterCredentials(string myPrisijungimoID, string myPrisijungimoPassword)
        {
            _prisijungimoIDIvedimoField.Clear();
            _prisijungimoIDIvedimoField.SendKeys(myPrisijungimoID);
            _passwordIvedimoField.Clear();
            _passwordIvedimoField.SendKeys(myPrisijungimoPassword);
            return this;
        }

        public LoginPage IsimintiManeTick()
        {
            if (_isimintiTickBox.Selected != true)
                _isimintiTickBox.Click();
            return this;
        }

        public LoginPage ClickPrisijungtiButton()
        {
            _prisijungimoMygtukas.Click();
            return this;
        }

        public LoginPage PatikrintiArPavykoPrisijungti(string expectedNeteisingas)
        {
            GetWait().Until(ExpectedConditions.TextToBePresentInElement(_neteisingoPrisijungimoIdentifikatorius, expectedNeteisingas));
            Assert.True(_neteisingoPrisijungimoIdentifikatorius.Text.Contains(expectedNeteisingas));
            return this;
        }

        public LoginPage AddCookieConsent()
        {
            Cookie myCookie = new Cookie(
                "cookies_p[domoplius]",
                "1",
                ".domoplius.lt",
                "/",
                DateTime.Now.AddYears(1));

            _driver.Manage().Cookies.AddCookie(myCookie);
            _driver.Navigate().Refresh();
            return this;
        }

        public LoginPage ClickPrisijungtiTab()
        {
            _prisijungtidarkartTab.Click();
            return this;
        }

        public LoginPage PatikrintiArSikartPavykoPrisijungti(string expectedTeteisingas)
        {
            GetWait().Until(ExpectedConditions.TextToBePresentInElement(_teisingasPrisijungimas, expectedTeteisingas));
            Assert.True(_teisingasPrisijungimas.Text.Contains(expectedTeteisingas));
            return this;
        }

        public SearchPage ClickDomopliusLogo()
        {
            Thread.Sleep(1000);
            _domopliusLogo.Click();
            return new SearchPage(_driver);
        }
    }
}
