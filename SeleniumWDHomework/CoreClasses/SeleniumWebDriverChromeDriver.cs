using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace SeleniumWDHomework.CoreClasses
{
    public static class SeleniumWebDriverChromeDriver
    {
        //private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            //get { return (_driver == null) ? _driver = new ChromeDriver() : _driver; } <-- thisis under question - antipattern

            get { return new ChromeDriver(); }

        }
    }
}
