using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    class AlertLogics
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [Test]
        public void AlertFunctions()
        {
            String name = "kishore"; driver.FindElement(By.Id("name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onClick*='displayConfirm']")).Click();
            String result = driver.SwitchTo().Alert().Text; driver.SwitchTo().Alert().Accept();
            StringAssert.Contains(name, result);
        }
        [Test]
        public void AutoDropdown()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            //Thread.Sleep(3000); 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//li[@class='ui-menu-item']/div")));
            IList<IWebElement> opt = driver.FindElements(By.XPath("//li[@class='ui-menu-item']/div"));
            foreach (IWebElement res in opt)
            {
                if (res.Text.Equals("India"))
                {
                    res.Click();
                }
            }
            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
        }
        [Test]
        public void UserActions()
        {
            //example 1 for user interaction
            driver.Url = "https://rahulshettyacademy.com/practice-project";
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.XPath("//a[@class='dropdown-toggle']"))).Perform();
            Thread.Sleep(1000);
            a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();
            //Another ex for user interactions 
            //driver.Url = "https://demoqa.com/droppable/";
            //Actions a = new Actions(driver);
            //a.DragAndDrop(driver.FindElement(By.XPath("//div[@id='draggable']")),
            //driver.FindElement(By.XPath("//div[@id='droppable'][1]"))).Perform();
        }
        [Test]
        public void Iframe()
        {
            //To scroll page we need to use Javascript 
            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor ja = (IJavaScriptExecutor)driver;
            ja.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);
            // frame can be select using ID, Name, Index 
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.PartialLinkText("Access Plan")).Click();
        }
    }
}
