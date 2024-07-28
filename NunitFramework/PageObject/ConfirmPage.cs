using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitFramework.PageObject
{
    class ConfirmPage
    {
        private IWebDriver _driver;
        public ConfirmPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        //driver.FindElement(By.XPath("//input[@id='country']")).SendKeys("ind");
        [FindsBy(How = How.XPath, Using = "//input[@id='country']")]
        private IWebElement input;
        //driver.FindElement(By.LinkText("India")).Click();
        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement country;
        //driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
        [FindsBy(How = How.XPath, Using = "//label[@for='checkbox2']")]
        private IWebElement checkBox1;
        //driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();
        [FindsBy(How = How.XPath, Using = "//input[@value='Purchase']")]
        private IWebElement purchase;
        //driver.FindElement(By.XPath("//div[contains(@class,'alert-dismissible')]")).Text;
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'alert-dismissible')]")]
        private IWebElement success;
        public void GetInput(string name)
        {
            input.SendKeys(name);
        }
        public void WaitToGetElements()
        {
            WebDriverWait driverToWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            driverToWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }
        public void GetCountry()
        {
            country.Click();
        }
        public void ClickCheckBox()
        {
            checkBox1.Click();
        }
        public void GetPurchase()
        {
            purchase.Click();
        }
        public IWebElement SuccessMsg()
        {
            return success;
        }
    }
}
