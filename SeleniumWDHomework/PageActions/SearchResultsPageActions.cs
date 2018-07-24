using SeleniumWDHomework.PageClasses;
using OpenQA.Selenium;
using System.Linq;
using System;

namespace SeleniumWDHomework.PageActions
{
    class SearchResultsPageActions
    {
        private SearchResultsPage _searchResultsPage;

        public SearchResultsPageActions(IWebDriver driver)
        {
            _searchResultsPage = new SearchResultsPage(driver);
        }

        public string[] GetItemNamesOnSearchResultsPage() =>_searchResultsPage.ItemTitles.Select(i => i.Text.ToLower()).ToArray();
        
    }
}
