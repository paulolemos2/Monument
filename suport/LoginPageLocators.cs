using OpenQA.Selenium;

namespace Monument.PageObjects
{
    public class LoginPageLocators
    {
        public static By UsernameInput = By.Id("outlined-adornment-email-login");
        public static By PasswordInput = By.Id("outlined-adornment-password-login");
        public static By LoginButton = By.CssSelector("button[class='MuiButtonBase-root MuiButton-root MuiButton-contained MuiButton-containedSecondary MuiButton-sizeLarge MuiButton-containedSizeLarge MuiButton-fullWidth MuiButton-root MuiButton-contained MuiButton-containedSecondary MuiButton-sizeLarge MuiButton-containedSizeLarge MuiButton-fullWidth css-11974tq']");

    }
}