using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
//using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo
{
    [TestClass]
    public class Class1
    {
        static IWebDriver driver;
        //private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [AssemblyInitialize]
        public static void SetupTest(TestContext context)
        {
            //String strPath = Directory.GetCurrentDirector();
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            //verificationErrors = new StringBuilder();
        }

        [AssemblyCleanup]
        public static void TeardownTest()
        {
            try
            {
                //driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
           // Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheUntitledTest()
        {
            baseURL = "http://newtours.demoaut.com/";
            driver.Navigate().GoToUrl(baseURL + "/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until((d) => { return d.FindElement(By.Name("userName")); });

            driver.FindElement(By.Name("userName")).Clear();
            driver.FindElement(By.Name("userName")).SendKeys("tutorial");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("tutorial");
            driver.FindElement(By.Name("login")).Click();

            wait.Until((d) => { return d.FindElement(By.Name("fromPort")); });

            //c1 - Find by Name
            //IWebElement cboFromPort = driver.FindElement(By.Name("fromPort"));
            //SelectElement selectElement = new SelectElement(cboFromPort);
            //selectElement.SelectByText("London");

            //C2 - Find by XPath
            new SelectElement(driver.FindElement(By.XPath("//select[@name='fromPort']"))).SelectByText("London");

            new SelectElement(driver.FindElement(By.XPath("//select[@name='fromMonth']"))).SelectByText("September");
            new SelectElement(driver.FindElement(By.XPath("//select[@name='toPort']"))).SelectByText("Paris");
            new SelectElement(driver.FindElement(By.XPath("//select[@name='toMonth']"))).SelectByText("December");
            driver.FindElement(By.XPath("//input[@name='servClass'][@type='radio'][@value='First']")).Click();
            new SelectElement(driver.FindElement(By.XPath("//select[@name='airline']"))).SelectByText("Pangea Airlines");
            driver.FindElement(By.XPath("//input[@name='tripType'][@type='radio'][@value='oneway']")).Click();
            driver.FindElement(By.Name("findFlights")).Click();


        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
