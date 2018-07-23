using OpenQA.Selenium;
using SeleniumWDHomework.PageClasses;

namespace SeleniumWDHomework.PageActions
{
    class HomePageActions
    {
        private HomePage _homePage;

        public HomePageActions(IWebDriver driver)
        {

            _homePage = new HomePage(driver);
        }

        public void Search (string searchInput)
        {
            _homePage.SearchInput.SendKeys(searchInput);
            _homePage.SearchInput.Submit();
        }
    }
}
