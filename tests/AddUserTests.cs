using Monument.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Monument.Tests
{
    public class AddUserTests
    {
        private LoginPage loginPage;
        private UsersAndPermissionsPage usersAndPermissionsPage;
        private AddUser addUser;

        [SetUp]
        public void Setup()
        {
            Web.CreateChrome();
            loginPage = new LoginPage(Web.driver);
            usersAndPermissionsPage = new UsersAndPermissionsPage(Web.driver);
            addUser = new AddUser(Web.driver);
        }

        [Test]
        public void AddANewUserAndValidateCreation()
        {
            #region Test Data
            var username = "darby.hadley+15@monument.io";
            var password = "u33thU#E";
            var emailDomain = "@gmail.com";
            var role = "admin";
            List<string> newUserCredentials = new List<string>();

            for (int i = 0; i < 3; i++)
            {
            newUserCredentials.Add(GenerateRandomString(8)); // String Size
            }
            
            static string GenerateRandomString(int length)
            {   
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new();
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            #endregion

            TestContext.Out.WriteLine("Step 1: Login Page.");
            loginPage.Login(username, password);

            TestContext.Out.WriteLine("Step 2: Navigate through Users and Permissions Page.");
            usersAndPermissionsPage.NavigateToUsersAndPermissions();
            usersAndPermissionsPage.AddUser();

            TestContext.Out.WriteLine("Step 3: Add a new User and verify if it was created.");
            addUser.EnterUserInformation(newUserCredentials, emailDomain, role);
            addUser.ClickAddUserButton();
            addUser.IsNewUserCreated(newUserCredentials[2]);
            TestContext.Out.WriteLine("User with email " + newUserCredentials[2] + emailDomain + " was created.");
        }

        [TearDown]
        public void Teardown()
        {
            Web.EndChrome();
        }
    }
}