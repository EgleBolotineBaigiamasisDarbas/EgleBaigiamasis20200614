using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BaigiamasisDarbas.Pages
{
    public class PageBase
    {
     protected static IWebDriver _driver;

     public PageBase(IWebDriver webdriver)
        {
            PageBase._driver = webdriver;
        }

    public void CloseBrowser()
        {
            _driver.Quit();
        }

    public WebDriverWait GetWait()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait;
        }
    }
}
