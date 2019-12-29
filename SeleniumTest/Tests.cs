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
        public void Zadatak1()
        {
            this.NavigateTo("http://test5.qa.rs/");
            this.DoWait(2);

            IWebElement registerNew = this.FindElement(By.XPath("//a[contains(@href, 'register')]"));
            registerNew.Click();
            this.DoWait(1);
            IWebElement ime = this.FindElement(By.Name("ime"));
            this.SendKeys("Milovan", false, ime);
            this.DoWait(1);
            IWebElement prezime = this.FindElement(By.Name("prezime"));
            this.SendKeys("Lazarevic", false, prezime);
            this.DoWait(1);
            IWebElement email = this.FindElement(By.Name("email"));
            this.SendKeys("milovan@lazarevic.com", false, email);
            this.DoWait(1);
            IWebElement korisnicko = this.FindElement(By.Name("korisnicko"));
            this.SendKeys("Milovan", false, korisnicko);
            this.DoWait(1);
            IWebElement sifra = this.FindElement(By.Name("lozinka"));
            this.SendKeys("1234", false, sifra);
            this.DoWait(1);
            IWebElement sifraOpet = this.FindElement(By.Name("lozinkaOpet"));
            this.SendKeys("1234", false, sifraOpet);
            this.DoWait(1);
            IWebElement registruj = this.FindElement(By.Name("register"));
            registruj.Click();
            this.DoWait(3);
            IWebElement uspeh = this.FindElement(By.XPath("//div[@class='alert alert-success']"));
            Assert.True(uspeh.Displayed);
            this.DoWait(3);
        }

        [Test]
        public void Zadatak2()
        {
            this.NavigateTo("http://test5.qa.rs/");
            this.DoWait(2);

            IWebElement login = this.FindElement(By.XPath("//a[contains(@href, 'login')]"));
            login.Click();
            this.DoWait(2);
            IWebElement korisnicko = this.FindElement(By.Name("username"));
            this.SendKeys("Milovan", false, korisnicko);
            this.DoWait(1);
            IWebElement lozinka = this.FindElement(By.Name("password"));
            this.SendKeys("1234", false, lozinka);
            this.DoWait(1);
            IWebElement logovanje = this.FindElement(By.Name("login"));
            logovanje.Click();
            this.DoWait(3);

            IWebElement success = this.FindElement(By.XPath("//div[@class='alert alert-success' and @role='alert']"));
            if (success == null)
            {
                Assert.Pass("Korisnik je uspesno registrovan i test je prosao");
            }
            else
            {
                Assert.Fail("Korisnik nije mogao da bude registrovan i test nije prosao");
            }
        }
        [Test]
        public void Zadatak3()
        {
            this.NavigateTo("http://test5.qa.rs/");
            this.DoWait(1);
            IWebElement login = this.FindElement(By.XPath("//a[contains(@href, 'login')]"));
            login.Click();
            IWebElement korisnicko = this.FindElement(By.Name("username"));
            this.SendKeys("Milovan", false, korisnicko);
            IWebElement lozinka = this.FindElement(By.Name("password"));
            this.SendKeys("1234", false, lozinka);
            IWebElement logovanje = this.FindElement(By.Name("login"));
            logovanje.Click();
            this.DoWait(1);

            IWebElement kolicina1 = this.FindElement(By.XPath("//h3[contains(text(),'small')]/parent::div/following-sibling::div[1]//select"));
            var select1 = new SelectElement(kolicina1);
            select1.SelectByValue("3");
            int ocekivanaCena1 = Convert.ToInt32(this.FindElement(By.XPath("//h3[contains(text(),'small')]/parent::div/following-sibling::div[2]")).Text.Substring(1));
            this.DoWait(1);
            IWebElement order1 = this.FindElement(By.XPath("//h3[contains(text(),'small')]/parent::div/following-sibling::div[1]//input[@type='submit']"));
            order1.Click();
            this.DoWait(3);
            IWebElement shopping = this.FindElement(By.XPath("//a[contains(@class, 'btn-default') and contains(., 'Continue')]"));
            shopping.Click();
            this.DoWait(2);
            IWebElement kolicina2 = this.FindElement(By.XPath("//h3[contains(text(),'pro')]/parent::div/following-sibling::div[1]//select"));
            var select2 = new SelectElement(kolicina2);
            select2.SelectByValue("10");
            int ocekivanaCena2 = Convert.ToInt32(this.FindElement(By.XPath("//h3[contains(text(),'pro')]/parent::div/following-sibling::div[2]")).Text.Substring(1));
            this.DoWait(1);
            IWebElement order2 = this.FindElement(By.XPath("//h3[contains(text(),'pro')]/parent::div/following-sibling::div[1]//input[@type='submit']"));
            order2.Click();
            this.DoWait(3);
            IWebElement checkout = this.FindElement(By.XPath("//a[contains(@class, 'btn-primary') and contains(., 'Checkout')]"));
            checkout.Click();
            this.DoWait(2);

            int qty = Convert.ToInt32(this.FindElement(By.XPath("(//table//td)[2]")).Text);
            int price = Convert.ToInt32(this.FindElement(By.XPath("(//table//td)[3]")).Text.Substring(1));
            int subtotal = Convert.ToInt32(this.FindElement(By.XPath("(//table//td)[4]")).Text.Substring(1));
            Assert.AreEqual(subtotal, price);
            Assert.AreEqual(subtotal, qty * price);
            this.DoWait(1);
        }

        [SetUp]
        public void SetUpTests()
        {
            this.Driver = new FirefoxDriver();
            //this.Driver = new ChromeDriver();
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