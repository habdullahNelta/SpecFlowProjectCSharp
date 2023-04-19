using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System.Reflection;
using static SpecFlowProject1.Hooks.Util;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly IObjectContainer _container;
        public Hooks1(IObjectContainer container) { 
        _container = container;
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            string Browser = ReadJsonFile()!;
            IWebDriver driver=null;
            
            if (Browser.Equals("chrome")) { 
                driver = new ChromeDriver();
            }
           else if (Browser.Equals("edge"))
            {
                driver = new EdgeDriver();
            }
           else if (Browser.Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else if (Browser.Equals("safari"))
            {
                driver = new SafariDriver();
            }
            else
            {
                Console.WriteLine($"no valid Browser");
            }
            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
          var driver =_container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
            else
            {
                Console.WriteLine("driver ist null");
            }
        }
    }
}