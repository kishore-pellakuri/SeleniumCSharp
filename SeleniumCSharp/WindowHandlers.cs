using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    class WindowHandlers
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void WindowHandle()
        {
            driver.FindElement(By.XPath("//a[@class='blinkingText']")).Click();
            //To check how many window tabs opened in browser
            TestContext.Progress.WriteLine(driver.WindowHandles.Count);
            //To switch tabs we need to follow based on INDEX. for ex: index[0] is 1st tab
            string childWindowName = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindowName);
            TestContext.Progress.WriteLine(driver.FindElement(By.XPath("//p[@class='im-para red']")).Text);
            //we strored this "Please email us at mentor@rahulshettyacademy.com  with below template to receive response " into below text variable
            string text = driver.FindElement(By.XPath("//p[@class='im-para red']")).Text;
            //we have to split the above text and take the eamil only into one variable
            string[] splittedtext = text.Split("at");
            string[] trimmedText = splittedtext[1].Trim().Split(" ");
            string email = "mentor@rahulshettyacademy.com";
            Assert.AreEqual(email, trimmedText[0]);
            string parentWindow = driver.WindowHandles[0];
            driver.SwitchTo().Window(parentWindow);
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeys(trimmedText[0]);

        }
    }
}
