using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    class Locator
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Test()
        {
            // Xpath, name, id, css,linktext,ClassName driver.FindElement(By.Id("username")).SendKeys("kishore");
            driver.FindElement(By.Name("password")).SendKeys("12345");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            //Xpath => //TagName[@attribute = 'value'] //CssSelector => tagname[attribute='value']
            //driver.FindElement(By.XPath("//input[@id = 'signInBtn']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")), "Sign In"));
            //IWebElement link = driver.FindElement(By.LinkText("Sign in"));
            // link.GetAttribute("href");
        }
    }
}
