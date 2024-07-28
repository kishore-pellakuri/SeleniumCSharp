using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitFramework.PageObject
{
    class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//input[@name='terms']")]
        private IWebElement Checkbox;

        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement Signin;

        public ProductsPage ValidLogin(string user, string Pass)
        {
            username.SendKeys(user);
            password.SendKeys(Pass);
            Checkbox.Click();
            Signin.Click();
           return new ProductsPage(driver);
        }
        public IWebElement GetUsername()
        {
            return username;
        }
    }
}
