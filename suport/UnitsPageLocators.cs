using OpenQA.Selenium;

namespace Monument.PageObjects
{
    public class UnitsPageLocators
    {
        public static By unitsButton = By.XPath("//*[contains(text(), 'Units')]");
        public static By searchForUnit = By.CssSelector("input[name='search']");
        public static By clickUnit(string unit)
        { 
        return By.XPath($"//*[contains(text(), '{unit}')]");
        }
        public static By UnitOptions = By.CssSelector("button[class='MuiButtonBase-root MuiButton-root MuiButton-text MuiButton-textPrimary MuiButton-sizeMedium MuiButton-textSizeMedium MuiButton-root MuiButton-text MuiButton-textPrimary MuiButton-sizeMedium MuiButton-textSizeMedium css-rvc1k1']");
        public static By ChangeUnitStatusButton = By.XPath("//*[contains(text(), 'Change Unit Status')]");
        public static By DeleteUnitButton = By.XPath("//*[contains(text(), 'Delete Unit')]"); 
    }
}