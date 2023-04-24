
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

using static SpecFlowProject1.Hooks.Util;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly IObjectContainer _container;
        private readonly string WebURL = "https://demowebshop.tricentis.com";

        public Hooks1(IObjectContainer container)
        {
            _container = container;
        }

        private static IWebDriver SetBrowser(string Browser)
        {
            IWebDriver driver = null;

            if (Browser.Equals("chrome"))
            {
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

            return driver;
        }


        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            string Browser = ReadJsonFile();
            IWebDriver driver = SetBrowser(Browser);

            _container.RegisterInstanceAs<IWebDriver>(driver);
            driver.Url = WebURL;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
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