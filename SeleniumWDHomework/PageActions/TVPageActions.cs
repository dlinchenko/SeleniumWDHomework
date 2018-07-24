using OpenQA.Selenium;
using System.Linq;

namespace SeleniumWDHomework.PageActions
{
    class TVPageActions
    {
        private IWebDriver _driver;

        public TVPageActions(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickOnElement(IWebElement element) => element.Click(); 

        public IWebElement GetItemNameOnGeneralTVPage() => _driver.FindElement(By.CssSelector(".g-i-tile-i-title.clearfix"));

        public IWebElement GetItemNameOnTVProductPage() => _driver.FindElement(By.ClassName("detail-title"));

        public IWebElement GetAplliedFilter(string filter) => _driver.FindElement(By.Id(filter));

        public IWebElement[] GetAllItemsNamesOnGeneralTVPage() => _driver.FindElements(By.CssSelector(".g-i-tile-i-title.clearfix")).ToArray();

        public IWebElement[] GetAllVisibleFiltersTVPage() => _driver.FindElements(By.CssSelector(".sprite-side.filter-parametrs-i-title")).ToArray();



    }
}
