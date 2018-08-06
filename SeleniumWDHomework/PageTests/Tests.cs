using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWDHomework.PageActions;
using SeleniumWDHomework.CoreClasses;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

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
        public void SearchItemSoAllResultItemsNamesContainItem()
        {
            var keyword = "macbook";
            var homePage = new HomePageActions(_driver);
            var resultsPage = new SearchResultsPageActions(_driver);
            homePage.Search(keyword);
            resultsPage.GetItemNamesOnSearchResultsPage().ToList().ForEach(item => NUnit.Framework.Assert.That(item.Contains(keyword), Is.True));
        }


        [TestMethod]
        //[Microsoft.VisualStudio.TestTools.UnitTesting.Ignore]
        //this test will fail as selenium coould not find reset_filter14 element
        public void SelectBrandOnTVPageSoAllResultsItemsContainBrandAndRemovableBrandFilterIsVisisble()
        {
            _driver.Url = "https://rozetka.com.ua/ua/all-tv/c80037/";

            var tvPage = new TVPageActions(_driver);
            var filterName = "filter_producer_14";//LG reference
            tvPage.ClickOnElement(_driver.FindElement(By.Id(filterName)));
            Thread.Sleep(5000);
            var appliedFilterValue = tvPage.GetAplliedFilter("reset_filter14");
            var allItemsNames = tvPage.GetAllItemsNamesOnGeneralTVPage();

            NUnit.Framework.Assert.That(appliedFilterValue.Text, Is.EqualTo("LG"));
            tvPage.GetAllItemsNamesOnGeneralTVPage().ToList().ForEach(itemName => NUnit.Framework.Assert.That(itemName.Text.Contains("LG"), Is.True));

        
        }


        [TestMethod]
        public void SelectItemOnTVPageSoItemNameIsSameOnTVPageAndOnItemPage()
        {
            _driver.Url = "https://rozetka.com.ua/ua/all-tv/c80037/";
            var tvPage = new TVPageActions(_driver);

            var itemNameOnGeneralPage = tvPage.GetItemNameOnGeneralTVPage().Text.Trim();
            tvPage.GetItemNameOnGeneralTVPage().Click();
            var itemNameOnItemsPage = tvPage.GetItemNameOnTVProductPage().Text.Trim();


            NUnit.Framework.Assert.That(itemNameOnGeneralPage, Is.EqualTo(itemNameOnItemsPage));

        }


        [TestMethod]
        public void ValidateThatFiltersOnTVPageAreNamedAndOrderedAsExpected()
        {
            var filtersExpected = new List<string> { "Безвідсотковий кредит", "Виробник", "Діагональ екрана", "Підтримка Smart TV", "Роздільна здатність", "Wi-Fi", "Ціна", "Країна-виробник", "Діапазони цифрового тюнера", "ТВ-тюнер", "Особливі властивості", "HDR", "Продавець", "Колір" };
            _driver.Url = "https://rozetka.com.ua/ua/all-tv/c80037/";
            var tvPage = new TVPageActions(_driver);

            var filtersActual = tvPage.GetAllVisibleFiltersTVPage().Select(i => i.Text.Trim()).ToList();

            NUnit.Framework.Assert.That(filtersActual, Is.EqualTo(filtersExpected));
        }

    }
}
