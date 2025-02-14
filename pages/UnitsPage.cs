using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Monument.PageObjects
{
    public class UnitsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public UnitsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ClickUnitsButton()
        {
            wait.Until(d => d.FindElement(UnitsPageLocators.unitsButton)).Click();
        }
        public void SearchForUnits(string unit)
        {
            /*IWebElement searchForUnits = */ wait.Until(d => d.FindElement(UnitsPageLocators.searchForUnit)).SendKeys(unit);
            //searchForUnits.Click();
            //searchForUnits.SendKeys(unit);
        }

        public void ClickUnit(string unit)
        {
            wait.Until(d => d.FindElement(UnitsPageLocators.clickUnit(unit))).Click();
        }
        public void ClickUnitOptions()
        {
            wait.Until(d => d.FindElement(UnitsPageLocators.UnitOptions)).Click();
        }

        public bool IsChangeUnitStatusDisplayed()
        {
            IWebElement changeUnitStatus = wait.Until(d => d.FindElement(UnitsPageLocators.ChangeUnitStatusButton));
            Assert.That(changeUnitStatus.Displayed);
            if (!changeUnitStatus.Displayed)
            {
            throw new Exception("Error: 'Change Unit Status' is not displayed.");
            }
            return true;
        }
        public bool IsDeleteUnitDisplayed()
        {
            IWebElement deleteUnit = wait.Until(d => d.FindElement(UnitsPageLocators.DeleteUnitButton));
            Assert.That(deleteUnit.Displayed);
            if (!deleteUnit.Displayed)
            {
            throw new Exception("Error: 'Change Unit Status' is not displayed.");
            }
            return true;
        }
    }
}