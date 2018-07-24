using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace SeleniumWDHomework.CoreClasses
{
    public static class SeleniumWebDriverChromeDriver
    {
        public static IWebDriver Driver
        {
            get { return new ChromeDriver(); }

        }
    }
}
