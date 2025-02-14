using Monument.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Monument.Tests
{
    public class UnitPermissionsValidationTests
    {
        private LoginPage loginPage;
        private UsersAndPermissionsPage usersAndPermissionsPage;
        private UnitsPage unitsPage;

        [SetUp]
        public void Setup()
        {
            Web.CreateChrome();
            loginPage = new LoginPage(Web.driver);
            usersAndPermissionsPage = new UsersAndPermissionsPage(Web.driver);
            unitsPage = new UnitsPage(Web.driver);
        }

        [Test]
        public void UserWithAllFacilitiesAndUnitsPermissionsTest()
        {
            #region Test Data 
            var username = "darby.hadley+15@monument.io";
            var password = "u33thU#E";
            var unit = "1001";
            #endregion

            TestContext.Out.WriteLine("Step 1: Login Page.");
            loginPage.Login(username, password);

            TestContext.Out.WriteLine("Step 2: Navigate through Users and Permissions Page.");
            usersAndPermissionsPage.NavigateToUsersAndPermissions();

            TestContext.Out.WriteLine("Step 3: Edit User and verify facilites and role permissions.");
            string roleName = usersAndPermissionsPage.ClickEditUserAndGetUserRole();
            usersAndPermissionsPage.AccessAllFacilitiesCheck();
            usersAndPermissionsPage.CancelEdit();
            usersAndPermissionsPage.OpenRolesTab();
            usersAndPermissionsPage.GetRoleName(roleName);
            usersAndPermissionsPage.ClickRoleEditButton(roleName);
            //Thread.Sleep(5000);
            //usersAndPermissionsPage.IsUnitPermissionsCheckBoxSelected();
            usersAndPermissionsPage.ClickBackButton();
            
            TestContext.Out.WriteLine("Step 4: Verify if Unit permissions properly safe-guards access to the Units page.");
            unitsPage.ClickUnitsButton();
            unitsPage.SearchForUnits(unit);
            unitsPage.ClickUnit(unit);
            unitsPage.ClickUnitOptions();
            unitsPage.IsChangeUnitStatusDisplayed();
            unitsPage.IsDeleteUnitDisplayed();
            TestContext.Out.WriteLine("Units permissions are properly safe-guarding access to the Units page.");            
        }

        [TearDown]
        public void Teardown()
        {
            Web.EndChrome();
        }
    }
}