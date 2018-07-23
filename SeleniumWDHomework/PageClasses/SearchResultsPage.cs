using OpenQA.Selenium;
using System.Linq;

namespace SeleniumWDHomework.PageClasses
{
    class SearchResultsPage
    {
        private IWebDriver _driver;

        public SearchResultsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement[] ItemTitles => _driver.FindElements(By.CssSelector(".g-i-tile-i-title.clearfix")).ToArray();

    }
}
