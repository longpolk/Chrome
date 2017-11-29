using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace Advanced_User_Interactions
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.theautomatedtester.co.uk/demo2.html");
            //IWebElement someElement = driver.FindElement(By.ClassName("draggable"));
            //IWebElement otherElement = driver.FindElement(By.ClassName("droppable"));
            Actions builder = new Actions(driver);
            //drag n drop on other element
            //IAction dragAndDrop = builder.ClickAndHold(someElement)
            //.MoveToElement(otherElement)
            //.Release(otherElement)
            //.Build();
            //dragAndDrop.Perform();
            //drag n drop to other position
            IWebElement drag = driver.FindElement(By.ClassName("draggable"));
            IAction dragAndDrop = builder.DragAndDropToOffset(drag, 100, 200).Build();
            dragAndDrop.Perform();
            //Open context menu
            driver.Navigate().GoToUrl("http://www.theautomatedtester.co.uk/demo1.html");
            builder = new Actions(driver);
            IWebElement element = driver.FindElement(By.TagName("body"));
            IAction contextClick = builder.ContextClick(element)
            .Build();
            contextClick.Perform();
            //selecting multiple items on a select item
            //IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://book.theautomatedtester.co.uk/multi-select.html");
            builder = new Actions(driver);
            IWebElement select = driver.FindElement(By.TagName("select"));
            ReadOnlyCollection<IWebElement> options = select.FindElements(By.TagName("option"));
            System.Console.WriteLine("list: "+options);
            //IAction multipleSelect = builder.KeyDown(Keys.Shift)
            ////.Click(options[0])
            //.Click(options[1])
            //.Build();
            //multipleSelect.Perform();

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
    }
}
