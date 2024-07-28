using NUnit.Framework;
using NunitFramework.PageObject;
using NunitFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    class E2ETest : Base
    {
        
        [Test,TestCaseSource("AddTestConfigData")]
        public void E2ETesting(string username, string password)
        {
            LoginPage login = new LoginPage(GetDriver());
          ProductsPage productsPage =  login.ValidLogin(username,password);
            //login.GetUsername().SendKeys("rahulshettyacademy");
            //driver.FindElement(By.Id("password")).SendKeys("learning");
            //driver.FindElement(By.XPath("//input[@value='user']")).Click();
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            //driver.FindElement(By.Id("okayBtn")).Click();
            //IWebElement dropdown = driver.FindElement(By.XPath("//div[@class='form-group']/select"));
            //SelectElement select = new SelectElement(dropdown);
            //select.SelectByValue("consult");
            //driver.FindElement(By.XPath("//input[@name='terms']")).Click();
            //driver.FindElement(By.Id("signInBtn")).Click();

            // 2. 
            
            String[] arrProducts = { "iphone X", "Nokia Edge", "Blackberry" };
            //WebDriverWait driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            //driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            productsPage.WaitForPageToDisplay();
            ////IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            IList<IWebElement> products = productsPage.GetCards();

            foreach (IWebElement product in products)
            {
                if (arrProducts.Contains(product.FindElement(productsPage.GetCardTitle()).Text))
                {
                    product.FindElement(productsPage.GetCardFooter()).Click();
                }
            }
           CheckOutPage checkOutPage =  productsPage.checkOutButton();

            //after adding items into cart we are doing vadilatons
            string[] actualProducts = new string[3];
            //IList<IWebElement> CheckoutItems = driver.FindElements(By.XPath("//h4/a"));
            IList<IWebElement> CheckoutItems = checkOutPage.GetItems();
            for (int i = 0; i < CheckoutItems.Count; i++)
            {
                actualProducts[i] = CheckoutItems[i].Text;
            }
            Assert.AreEqual(arrProducts, actualProducts);

            //driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();
           ConfirmPage confirm = checkOutPage.SubmitButton();

            //driver.FindElement(By.XPath("//input[@id='country']")).SendKeys("ind");
            confirm.GetInput("ind");
            //WebDriverWait driverToWait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //driverToWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            confirm.WaitToGetElements();
            //driver.FindElement(By.LinkText("India")).Click();
            confirm.GetCountry();
            //driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
            confirm.ClickCheckBox();
            //driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();
            confirm.GetPurchase();
            string successMsg = confirm.SuccessMsg().Text;
            StringAssert.Contains("Success", successMsg);
        }
        public static IEnumerable<TestCaseData> AddTestConfigData()
        {
           yield return new TestCaseData("rahulshettyacademy", "learning");
           yield return new TestCaseData("rahulshetty", "learning");
        }
    }
}
