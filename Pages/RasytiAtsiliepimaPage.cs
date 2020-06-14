using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BaigiamasisDarbas.Pages
{
    public class RasytiAtsiliepimaPage : PageBase
    {

        private static SelectElement JusuStatusasList => new SelectElement(_driver.FindElement(By.Id("name")));
        private IWebElement _pasirinktasStatusas => _driver.FindElement(By.XPath("//*[@id='name']/option[2]"));
        private IWebElement _emailIvedimoLaukelis => _driver.FindElement(By.Name("your_email"));
        private IWebElement _atsiliepimoIvedimoLaukelis => _driver.FindElement(By.Name("content"));
        private IWebElement _trysZvaigzdutesIvertinimas => _driver.FindElement(By.CssSelector(".page-ratings > label:nth-child(6)"));
        private IWebElement _siustiButton => _driver.FindElement(By.CssSelector(".post-button"));
        private IWebElement _errorMessage => _driver.FindElement(By.CssSelector(".error-msg"));


        public RasytiAtsiliepimaPage(IWebDriver webdriver) : base(webdriver) { }


        public RasytiAtsiliepimaPage PasirinktiStatusa(string pasirinkimas)
        {
            Thread.Sleep(1000);
            JusuStatusasList.SelectByText(pasirinkimas.ToString());
            _pasirinktasStatusas.Click();
            return this;
        }

        public RasytiAtsiliepimaPage EnterEmail(string myIncorrectEmail)
        {
            _emailIvedimoLaukelis.Clear();
            _emailIvedimoLaukelis.SendKeys(myIncorrectEmail);
            return this;
        }

        public RasytiAtsiliepimaPage EnterMessage(string myMessage)
        {
            _atsiliepimoIvedimoLaukelis.Clear();
            _atsiliepimoIvedimoLaukelis.SendKeys(myMessage);
            return this;
        }

        public RasytiAtsiliepimaPage ClickIvertintiZvaigzdutemis()
        {
            Thread.Sleep(1000);
            _trysZvaigzdutesIvertinimas.Click();
            return this;
        }
        public RasytiAtsiliepimaPage ClickSiustiButton()
        {
            Thread.Sleep(1000);
            _siustiButton.Click();
            return this;
        }

        public RasytiAtsiliepimaPage PatikrintiArPavykoIssiusti(string expectedNepavyko)
        {
            GetWait().Until(ExpectedConditions.TextToBePresentInElement(_errorMessage, expectedNepavyko));
            Assert.True(_errorMessage.Text.Contains(expectedNepavyko));
            return this;
        }
    }
}
