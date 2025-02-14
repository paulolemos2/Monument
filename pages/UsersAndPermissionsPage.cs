using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Monument.PageObjects
{
    public class UsersAndPermissionsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public UsersAndPermissionsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateToUsersAndPermissions()
        {
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.SettingsButton)).Click();
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.UsersAndPermissionsButton)).Click();
        }

        public bool IsUsersTabDisplayed()
        {
            IWebElement userTab = wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.UsersTab));
            Assert.That(userTab.Displayed);
            if (!userTab.Displayed)
            {
            throw new Exception("Error: 'Users Tab' is not displayed.");
            }
            return true;
        }

        public void AddUser()
        {
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.AddUser)).Click();         
        }

        public bool AccessAllFacilitiesCheck() 
        {
            IWebElement facilities = wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.AccessAllFacilitiesCheck));
            Assert.That(facilities.Selected);
            if (!facilities.Selected)
            {
            throw new Exception("Error: 'Access All Facilities' checkbox is not selected.");
            }
            return true;
        }
        public string ClickEditUserAndGetUserRole()
        {
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.UsersEditButton)).Click();
            Thread.Sleep(2000); //role text element was not displayed at time without a timer
            IWebElement roleText = wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.RoleText));
            String roleText1 = roleText.GetAttribute("textContent");
            return roleText1;
        }

        public void CancelEdit()
        {
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.CancelButton)).Click();
        }

        public void OpenRolesTab()
        {
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.RolesTabButton)).Click();
        }

        public string GetRoleName(string roletext1)
        {
            String userRole = roletext1;
            return userRole;
        }
        public void ClickRoleEditButton(string userRole)
        {
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.GetRolesEditButton(userRole))).Click();
        }

        public bool IsUnitPermissionsCheckBoxSelected() // This solution does not worked and I didn´t had enough time for a workaround on it.
        {
            var checkbox = wait.Until(d => d.FindElements(UsersAndPermissionsPageLocators.UnitPermissionsCheckBox));
            //Assert.That(checkbox.Count == 4); 
             if (checkbox.Count < 4)
            {
                Console.WriteLine($"Error: {checkbox.Count} checkboxes, expected: 4.");
            }

            foreach (var checkboxItem in checkbox)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                bool isChecked = (bool)js.ExecuteScript("return arguments[0].checked;", checkbox);
                
            if (!isChecked)
            {
            return false;
            }
            }

            return true;
        }
        public void ClickBackButton()
        {
            wait.Until(d => d.FindElement(UsersAndPermissionsPageLocators.backButton)).Click();
        }
    }
}