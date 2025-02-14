using Monument.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel.DataAnnotations;

namespace Monument.Tests
{
    public class Web() 
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;
        public static void CreateChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Url.uri);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public static void EndChrome()
        {
            driver.Quit();
        }
}
}