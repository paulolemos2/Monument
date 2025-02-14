using OpenQA.Selenium;

namespace Monument.PageObjects
{
    public class UsersAndPermissionsPageLocators
    {
        public static By SettingsButton = By.XPath("//*[contains(text(),'Settings')]");
        public static By UsersAndPermissionsButton = By.XPath("//*[contains(text(),'Users & Permissions')]");

        // Users Tab
        public static By UsersTab = By.Id("tab-Users");
        public static By AddUser = By.XPath("//*[contains(text(), 'Add User')]");
        public static By AddUserFirstName = By.CssSelector("input[name='firstName']");
        public static By AddUserLastName = By.CssSelector("input[name='lastName']");
        public static By AddUserEmail = By.CssSelector("input[name='email']");
        public static By AddUserRole = By.CssSelector("input[name='rootRoleId']"); 
        public static By EnableFacilitiesPermissions = By.CssSelector("input[class='PrivateSwitchBase-input MuiSwitch-input css-1m9pwf3']");
        public static By AddUserButton = By.XPath("//button[contains(.//text(), 'Add User')]");
        public static By VerifyNewUser(string email){
        return By.XPath($".//*[contains(text(), '{email}')]");
        }
        public static By UsersEditButton = By.XPath(".//*[contains(text(), 'paulo test')]/../../../../..//*[@data-testid='EditRegularIcon']");

        // Role Validation
        public static By AccessAllFacilitiesCheck = By.CssSelector("input[class='PrivateSwitchBase-input MuiSwitch-input css-1m9pwf3']");
        public static By RoleText = By.CssSelector("span[class='MuiBox-root css-7i7hzs']");
        public static By CancelButton = By.XPath("//*[contains(text(), 'Cancel')]");
        public static By RolesTabButton = By.Id("tab-Roles");
        public static By GetRolesEditButton(string userRole)
        {
        return By.XPath($".//*[contains(text(), '{userRole}')]/../..//*[@data-testid='EditRegularIcon']");
        }
        public static By UnitPermissionsCheckBox = By.XPath(".//*[contains(text(), 'Units')]/../..//*[@class='PrivateSwitchBase-input css-1m9pwf3']");
        public static By backButton = By.XPath("//*[contains(text(), 'Back')]");
    }
}