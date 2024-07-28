using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitFramework.PageObject
{
    class CheckOutPage
    {
        private IWebDriver _driver;
        public CheckOutPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        //IList<IWebElement> CheckoutItems = driver.FindElements(By.XPath("//h4/a"));
        [FindsBy(How = How.XPath, Using = "//h4/a")]
        private IList<IWebElement> ListOfItems;
        //driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();
        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-success']")]
        private IWebElement submit;
        public IList<IWebElement> GetItems()
        {
            return ListOfItems;
        }
        public ConfirmPage SubmitButton()
        {
            submit.Click();
            return new ConfirmPage(_driver);
        }
    }
}
