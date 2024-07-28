using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    class SeleniumFirst
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            //driver = new ChromeDriver(); driver = new EdgeDriver(); 
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Test1()
        {
            driver.Url = "https://www.w3schools.com/js/";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
        }
    }
}
