using NUnit.Framework;
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
    class E2ETest
    {
        IWebDriver driver;
        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [Test]
        public void E2ETesting()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//input[@value='user']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            IWebElement dropdown = driver.FindElement(By.XPath("//div[@class='form-group']/select"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByValue("consult");
            driver.FindElement(By.XPath("//input[@name='terms']")).Click();
            driver.FindElement(By.Id("signInBtn")).Click();
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            String[] arrProducts = { "iphone X", "Nokia Edge","Blackberry" };
            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            foreach (IWebElement product in products)
            {
                if (arrProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
            }
            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            //after adding items into cart we are doing vadilatons
            string[] actualProducts = new string[3];
            IList<IWebElement> CheckoutItems = driver.FindElements(By.XPath("//h4/a"));
            for(int i =0; i< CheckoutItems.Count; i++)
            {
                actualProducts[i] = CheckoutItems[i].Text;
            }
            Assert.AreEqual(arrProducts, actualProducts);

            driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();
            driver.FindElement(By.XPath("//input[@id='country']")).SendKeys("ind");
            WebDriverWait driverToWait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            driverToWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();
            driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
            driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();
            string successMsg = driver.FindElement(By.XPath("//div[contains(@class,'alert-dismissible')]")).Text;
            StringAssert.Contains("Success", successMsg);
        }
    }
}
