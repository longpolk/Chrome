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
        private static Screenshot ss;
        private static IWebDriver driver;
        private static Actions builder;
        private static IAction actionChain;
        private static StringBuilder verificationErrors;
        private WebDriverWait wait;
        private static IJavaScriptExecutor js;

        [AssemblyInitialize]
        public static void SetupTest(TestContext context)
        {
            //String strPath = Directory.GetCurrentDirector();
            //driver = new FirefoxDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            driver = new ChromeDriver(options);
            //driver = new ChromeDriver();
            //driver = new InternetExplorerDriver();
            verificationErrors = new StringBuilder();
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
            actionChain = builder.DragAndDropToOffset(drag, 100, 200).Build();
            actionChain.Perform();
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
            actionChain = builder.ClickAndHold(canvas)
            .MoveByOffset(-40, -60)
            .MoveByOffset(20, 20)
            .MoveByOffset(100, 150)
            .Release(canvas)
            .Build();
            actionChain.Perform();
            //Take screenshot here:__________
            ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("e:\\TestMethod4.png", ScreenshotImageFormat.Png);
        }
        [TestMethod]
        public void TestMethod5()
        {
            driver.Navigate().GoToUrl("http://map.google.com");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until((d) => { return d.FindElement(By.Id("searchboxinput")); });

            driver.FindElement(By.Id("searchboxinput")).Clear();
            driver.FindElement(By.Id("searchboxinput")).SendKeys("135/37 PHAM DANG GIANG");
            driver.FindElement(By.Id("searchbox-searchbutton")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until((d) => { return d.FindElement(By.XPath("//button[@class='section-hero-header-directions noprint']")); });
            driver.FindElement(By.XPath("//button[@class='section-hero-header-directions noprint']")).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            wait.Until((d) => { return d.FindElement(By.XPath("//input[@class='tactile-searchbox-input']")); });
            driver.FindElement(By.ClassName("tactile-searchbox-input")).Clear();
            driver.FindElement(By.ClassName("tactile-searchbox-input")).SendKeys("so 366 nguyen trai");
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //wait.Until((d) => { return d.FindElement(By.XPath("//input[@class='tactile-searchbox-input'][@value='so 366 nguyen trai']")); });
            //IAction pressKey = builder.KeyDown(Keys.ArrowDown).Build();
            //pressKey.Perform();
        }
        [TestMethod]
        public void FDUX001UIRoleConsumer()
        {
            //Step 1:
            driver.Navigate().GoToUrl("http://vpservices7002:8080/fdui81/login/index.jsp");
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("dmadmin");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("FirstDoc123");
            driver.FindElement(By.Id("button-1015-btnInnerEl")).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until((d) => { return d.FindElement(By.Id("textfield-1014-inputEl")); });
            //IWebElement search = driver.FindElement(By.Id("textfield-1014-inputEl"));
            //IWebElement Adsearch = driver.FindElement(By.Id("textfield-1014-inputEl"));
            //IWebElement home = driver.FindElement(By.Id("button-1017-btnIconEl"));
            //Step 2:
            string[] listToverify = { "textfield-1014-inputEl", "button-1015-btnInnerEl", "button-1017-btnIconEl", "test-missing-icon", "button-1018-btnIconEl", "button-1019-btnIconEl", "button-1021-btnIconEl", "button-1022-btnIconEl", "button-1023-btnIconEl" };
            for (int i = 0;i<listToverify.Length; i++) {
                //IWebElement element = driver.FindElement(By.Id(listToverify[i]));
                if (checkExistByID(listToverify[i])==false)
                {
                    System.Console.WriteLine("Missing element: "+ listToverify[i]);
                    ss = ((ITakesScreenshot)driver).GetScreenshot();
                    ss.SaveAsFile("E:\\Selenium Screen Prints/Step2-Missing-element-" + listToverify[i]+ ".png", ScreenshotImageFormat.Png);
                }
            }
                ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile("E:\\Selenium Screen Prints/Step2.png", ScreenshotImageFormat.Png);
            //Step 3:
            driver.FindElement(By.Id("button-1035-btnIconEl")).Click();
            builder = new Actions(driver);
            actionChain = builder.SendKeys(Keys.Down).SendKeys(Keys.Down)
            .SendKeys(Keys.Enter)
            .Build();
            actionChain.Perform();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until((d) => { return d.FindElement(By.Id("fduiusersettings-1110")); });
            string[] tabsToverify = { "tab-1270-btnInnerEl", "tab-1271-btnInnerEl", "tab-1272-btnInnerEl", "tab-1273-btnInnerEl", "tab-1274-btnInnerEl", "test-missing-tab", "tab-1275-btnInnerEl" };
            //ReadOnlyCollection<IWebElement> tabs = driver.FindElements(By.CssSelector("span[class='x-tab-inner x-tab-inner-default']"));
            for (int j = 0; j < tabsToverify.Length; j++)
            {
                if (checkExistByID(tabsToverify[j]) == false)
                {
                    System.Console.WriteLine("Missing tab: " + tabsToverify[j]);
                    ss = ((ITakesScreenshot)driver).GetScreenshot();
                    ss.SaveAsFile("E:\\Selenium Screen Prints/Step3-Missing-tab-" + tabsToverify[j] + ".png", ScreenshotImageFormat.Png);
                }
            }
            //IWebElement settingDialog = driver.FindElement(By.Id("fduiusersettings-1110"));
            //builder = new Actions(driver);
            //IWebElement rightBorder = driver.FindElement(By.Id("fduiusersettings-1110-east-handle"));
            //actionChain = builder.ClickAndHold(rightBorder)
            //.MoveByOffset(200, 150)
            //.Release(rightBorder)
            //.Build();
            //actionChain.Perform();
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //wait.Until((d) => { return settingDialog; });
            //js = (IJavaScriptExecutor) driver;
            //js.ExecuteScript("arguments[0].setAttribute('style', 'width:1024px')", settingDialog);
            //Step 4:
            driver.FindElement(By.Id("tab-1182-btnInnerEl")).Click();
            string[] optionsToverify = { "Properties", "Versions", "Relationships", "Locations", "Renditions", "Parent Virtual Documents", "Your Permissions", "test-missing-option" };
            ReadOnlyCollection<IWebElement> options = driver.FindElements(By.CssSelector("div[class='x-grid-cell-inner']"));
            int k = 0;
            foreach (IWebElement option in options)
            {
                System.Console.WriteLine(option.GetAttribute("innerHTML"));
                if (!optionsToverify[k].Equals(option.GetAttribute("innerHTML")))
                {
                    System.Console.WriteLine("Missing option: " + optionsToverify[k]);
                    ss = ((ITakesScreenshot)driver).GetScreenshot();
                    ss.SaveAsFile("E:\\Selenium Screen Prints/Step4-Missing-option-" + optionsToverify[k] + ".png", ScreenshotImageFormat.Png);
                }
                k++;
            }
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
        public static bool checkExistByID(string s) {
            try {
                IWebElement element = driver.FindElement(By.Id(s));
                if (element.Displayed)
                    return true;
            }
            catch (NoSuchElementException e) {
                //return false;
            }
            return false;
        }
        public static bool checkExistByText(string s)
        {
            try
            {
                IWebElement element = driver.FindElement(By.LinkText(s));
                if (element.Displayed)
                    return true;
            }
            catch (NoSuchElementException e)
            {
                //return false;
            }
            return false;
        }
    }
}
