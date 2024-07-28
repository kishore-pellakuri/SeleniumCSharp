using System;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NunitFramework.PageObject
{
    class ProductsPage
    {
        private IWebDriver _driver;
        By cardTitle = By.CssSelector(".card-title a");
        By cardFooter = By.CssSelector(".card-footer button");
        public ProductsPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        
        
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;
        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkOut;

        public void WaitForPageToDisplay()
        {
            WebDriverWait driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }
        public IList<IWebElement> GetCards()
        {
            return cards;
        }
        public By GetCardTitle()
        {
            return cardTitle;
        }
        public By GetCardFooter()
        {
            return cardFooter;
        }
        public CheckOutPage checkOutButton()
        {
             checkOut.Click();
            return new CheckOutPage(_driver);
        }
    }
}
