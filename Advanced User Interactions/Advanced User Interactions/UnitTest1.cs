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
using System.Drawing.Imaging;
using OpenQA.Selenium.Support.UI;

namespace Advanced_User_Interactions
{
    [TestClass]
    public class UnitTest1
    {
        public static Screenshot ss;
        public static IWebDriver driver;
        public static Actions builder;
        public static IAction dragAndDrop;

        [AssemblyInitialize]
        public static void SetupTest(TestContext context)
        {
            //String strPath = Directory.GetCurrentDirector();
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            //driver = new InternetExplorerDriver();
            //verificationErrors = new StringBuilder();
        }
        [TestMethod]
        public void TestMethod1()
        {
            //driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.theautomatedtester.co.uk/demo2.html");
            //IWebElement someElement = driver.FindElement(By.ClassName("draggable"));
            //IWebElement otherElement = driver.FindElement(By.ClassName("droppable"));
            builder = new Actions(driver);
            //drag n drop on other element
            //IAction dragAndDrop = builder.ClickAndHold(someElement)
            //.MoveToElement(otherElement)
            //.Release(otherElement)
            //.Build();
            //dragAndDrop.Perform();
            //drag n drop to other position
            IWebElement drag = driver.FindElement(By.ClassName("draggable"));
            dragAndDrop = builder.DragAndDropToOffset(drag, 100, 200).Build();
            dragAndDrop.Perform();
            //Take screenshot here:__________
            ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("e:\\TestMethod1.png", ScreenshotImageFormat.Png);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Open context menu
            driver.Navigate().GoToUrl("http://www.theautomatedtester.co.uk/demo1.html");
            builder = new Actions(driver);
            IWebElement element = driver.FindElement(By.TagName("body"));
            IAction contextClick = builder.ContextClick(element)
            .Build();
            contextClick.Perform();
            //Take screenshot here:__________
            ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("e:\\TestMethod2.png", ScreenshotImageFormat.Png);
        }
        [TestMethod]
        public void TestMethod3()
        {
            //selecting multiple items on a select item
            //IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://book.theautomatedtester.co.uk/multi-select.html");
            //builder = new Actions(driver);
            ReadOnlyCollection<IWebElement> allSelect = driver.FindElements(By.TagName("select"));
            foreach (IWebElement i in allSelect) {
                builder = new Actions(driver);
                ReadOnlyCollection<IWebElement> option = i.FindElements(By.TagName("option"));
                System.Console.WriteLine("list: " + option.Count);
                IAction multipleSelect = builder.KeyDown(Keys.Shift)
                .Click(option[0])
                .Click(option[1])
                .Build();
                multipleSelect.Perform();
            }
            //Take screenshot here:__________
            ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("e:\\TestMethod3.png", ScreenshotImageFormat.Png);
        }
        //IWebElement select = driver.FindElement(By.Id("selectWithMultipleEqualsMultiple"));
        //ReadOnlyCollection<IWebElement> options = select.FindElements(By.TagName("option"));
        //IAction multipleSelect = builder.KeyDown(Keys.Control)
        //.Click(options[1])
        //.Click(options[3])
        //.Build();
        //multipleSelect.Perform();
        [TestMethod]
        public void TestMethod4()
        {
            //holding the mouse button down while moving the mouse
            builder = new Actions(driver);
            driver.Navigate().GoToUrl("http://www.theautomatedtester.co.uk/demo1.html");
            IWebElement canvas = driver.FindElement(By.Id("tutorial"));
            dragAndDrop = builder.ClickAndHold(canvas)
            .MoveByOffset(-40, -60)
            .MoveByOffset(20, 20)
            .MoveByOffset(100, 150)
            .Release(canvas)
            .Build();
            dragAndDrop.Perform();
            //Take screenshot here:__________
            ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("e:\\TestMethod4.png", ScreenshotImageFormat.Png);
        }
        [TestMethod]
        public void TestMethod5()
        {
            driver.Navigate().GoToUrl("http://map.google.com");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until((d) => { return d.FindElement(By.Id("searchboxinput")); });

            driver.FindElement(By.Id("searchboxinput")).Clear();
            driver.FindElement(By.Id("searchboxinput")).SendKeys("135/37 PHAM DANG GIANG");
            driver.FindElement(By.Id("searchbox-searchbutton")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until((d) => { return d.FindElement(By.XPath("//button[@class='section-hero-header-directions noprint']")); });
            driver.FindElement(By.XPath("//button[@class='section-hero-header-directions noprint']")).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until((d) => { return d.FindElement(By.XPath("//input[@class='tactile-searchbox-input']")); });
            driver.FindElement(By.XPath("//input[@class='tactile-searchbox-input']")).Clear();
            driver.FindElement(By.XPath("//input[@class='tactile-searchbox-input']")).SendKeys("366 nguyen trai");
            builder.KeyDown(Keys.ArrowDown).Build().Perform();
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
