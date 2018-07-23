using OpenQA.Selenium;



namespace SeleniumWDHomework.PageClasses
{
    class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SearchInput => _driver.FindElement(By.CssSelector(".rz-header-search-input-text.passive"));
    }
}
