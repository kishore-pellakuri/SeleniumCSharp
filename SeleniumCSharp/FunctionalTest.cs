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
    class FunctionalTest
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void DropDown()
        {
            IWebElement dropDown = driver.FindElement(By.XPath("//select[@class='form-control']"));
            SelectElement element = new SelectElement(dropDown); element.SelectByValue("consult");
            //IWebElement radio = driver.FindElement(By.XPath("//input[@value='user']"));
            //radio.Click();
            IList<IWebElement> radio = driver.FindElements(By.XPath("//input[@type = 'radio']"));
            foreach (IWebElement res in radio)
            {
                if (res.GetAttribute("value").Equals("user"))
                {
                    res.Click();
                }
            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean bo = driver.FindElement(By.Id("usertype")).Selected; Assert.That(bo, Is.True);
        }
    }
}
