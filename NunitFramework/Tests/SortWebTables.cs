using NUnit.Framework;
using NunitFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    class SortWebTables : Base
    {
     
        [Test]
        public void Sorting()
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");
            //step 1 : store all the veggies into arrayList A 
            ArrayList a = new ArrayList();
            IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            }
            foreach (var element in a)
            {
                TestContext.Progress.WriteLine("elements Before sorting : " + element);
            }
            //step 2 : Sort the veggies of arrayList a.Sort(); 
            foreach (var element in a)
            {
                TestContext.Progress.WriteLine("elements After sorting : " + element);
            }
            //Step 3 : Go and click on sort button in web Page and store veggies into arrayList B 
            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();
            // //th[contains(@aria-label,'fruit name')] ----> in Xpath 
            ArrayList b = new ArrayList();
            IList<IWebElement> Freshveggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement result in Freshveggies)
            {
                b.Add(result.Text);
            }
            //Step 4 : Compare the elements of arrayList A with WebPage elemenets arrayList B
            Assert.AreEqual(a, b);
        }
    }
}
