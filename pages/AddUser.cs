using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Monument.PageObjects
{
    public class AddUser
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddUser(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void EnterUserInformation(List<String> newUserCredentials , string emailDomain, string role)
        {
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.AddUserFirstName)).SendKeys(newUserCredentials[0]);
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.AddUserLastName)).SendKeys(newUserCredentials[1]);
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.AddUserEmail)).SendKeys(newUserCredentials[2] + emailDomain);
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.AddUserRole));
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.EnableFacilitiesPermissions)).Click();
        }

        public void ClickAddUserButton() {
           wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.AddUserButton)).Click(); 
        }

        public bool IsNewUserCreated(string email) {
           IWebElement newUser = wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.VerifyNewUser(email)));
            Assert.That(newUser.Displayed);
            if (!newUser.Displayed)
            {
            throw new Exception("Error: 'New user' is not displayed.");
            }
            return true;
        }
    }
}