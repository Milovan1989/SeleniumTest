using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumTest
{
    class VezbaSeleniumZaTest : SeleniumBaseClass
    {
        [Test]
        public void Vezba1()
        {
            this.NavigateTo("https://www.google.rs/");
            this.DoWait(2);

            IWebElement gmail = this.FindElement(By.XPath("//a[contains(@class, 'gb_g') and contains(., 'Gmail')]"));
            gmail.Click();
            DoWait(2);
        }

        [SetUp]
        public void SetUpTests()
        {
            //this.Driver = new FirefoxDriver();
            this.Driver = new ChromeDriver();
            this.Driver.Manage().Cookies.DeleteAllCookies();
            this.Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDownTests()
        {
            this.Close();
        }
    }
}