using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWDHomework.PageActions;
using SeleniumWDHomework.CoreClasses;
using System.Linq;



namespace SeleniumWDHomework.PageTests
{
    [TestClass]
    public class Tests
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void TestSetup()
        {
            _driver = SeleniumWebDriverChromeDriver.Driver;
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://rozetka.com.ua"; //"https://www.citrus.ua/"; - does not work on citrus at all
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void SearchInputTest()
        {
            var keyword = "macbook";
            var homePage = new HomePageActions(_driver);
            var resultsPage = new SearchResultsPageActions(_driver);
            homePage.Search(keyword);
            resultsPage.GetItemNames().ToList().ForEach(item => NUnit.Framework.Assert.That(item.Contains(keyword), Is.True));
        }


        [TestMethod]
        public void Test2()
        {
            _driver.Url = "https://rozetka.com.ua/ua/all-tv/c80037/";
            _driver.FindElement(By.Id("filter_producer_14")).Click();
            //lgFilter.Click();
            //var filterValue = lgFilter.FindElement(By.Id("reset_filter14")).Text;
            var filterValue = _driver.FindElement(By.XPath("//*[@id='reset_filter14']/a"));


            //NUnit.Framework.Assert.That(lgFilter.FindElement(By.Id("reset_filter14")).Text, Is.EqualTo("LG"));

        
        }

    }
}
