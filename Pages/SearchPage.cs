using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BaigiamasisDarbas.Pages
{
    public class SearchPage : PageBase
    {
        private IWebElement _tekstinePaieskosBox => _driver.FindElement(By.Id("qt"));
        private IWebElement _paieskosButton => _driver.FindElement(By.CssSelector(".submit-frm > strong"));
        private IWebElement _rezultatuAntraste => _driver.FindElement(By.XPath("//body[@id='domoplius']/div[3]/div/div/div[2]/div[4]/div/h1"));
        private IWebElement _metuNuoPasirinkimoBox => _driver.FindElement(By.Name("building_build_date_from"));
        private IWebElement _suNuotraukBox => _driver.FindElement(By.Id("has_photo"));
        private IWebElement _ieskotiButton => _driver.FindElement(By.ClassName("ico-search"));
        private IWebElement _paieskosRezultatuSkaicius => _driver.FindElement(By.CssSelector(".larger"));
        private IWebElement _rasykiteCiaButton => _driver.FindElement(By.LinkText("Rašykite čia"));

        public SearchPage(IWebDriver webdriver) : base(webdriver) { }


        public SearchPage EnterMiestas(string myMiestas)
        {
            Thread.Sleep(3000);
            _tekstinePaieskosBox.Clear();
            _tekstinePaieskosBox.SendKeys(myMiestas);
            return this;
        }

        public SearchPage ClickPaieskosButton()
        {
            _paieskosButton.Click();
            return this;
        }

        public SearchPage PatikrintiRezultatus(string expectedButaiNeringoje)
        {
            GetWait().Until(ExpectedConditions.TextToBePresentInElement(_rezultatuAntraste, expectedButaiNeringoje));
            Assert.True(_rezultatuAntraste.Text.Contains(expectedButaiNeringoje));
            return this;
        }

        public SearchPage EnterMetaiNuo(int metaiNuo)
        {
            _metuNuoPasirinkimoBox.Click();
            _metuNuoPasirinkimoBox.SendKeys(metaiNuo.ToString());
            return this;
        }

        public SearchPage TickSuNuotrauka()
        {
            if (_suNuotraukBox.Selected != true)
                _suNuotraukBox.Click();
            return this;
        }

        public SearchPage ClickIeskotiButton()
        {
            _ieskotiButton.Click();
            return this;
        }

        public SearchPage PatikrintiRezultatuKieki(int expectedResults)
        {
            int rezultatuKiekis = Convert.ToInt32(_paieskosRezultatuSkaicius.Text.Replace("(", "").Replace(")",""));
            Assert.GreaterOrEqual(rezultatuKiekis, expectedResults);
            return this;
        }
        public RasytiAtsiliepimaPage ClickRasykiteCia()
        {
            Thread.Sleep(1000);
            _rasykiteCiaButton.Click();
            return new RasytiAtsiliepimaPage(_driver);
        }
    }
}
