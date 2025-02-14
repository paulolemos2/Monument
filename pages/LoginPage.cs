using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Monument.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        public void Login(string username, string password)
        {
            wait.Until(d => d.FindElement(LoginPageLocators.UsernameInput)).SendKeys(username);
            wait.Until(d => d.FindElement(LoginPageLocators.PasswordInput)).SendKeys(password);
            wait.Until(d => d.FindElement(LoginPageLocators.LoginButton)).Click();
        }
    }
}