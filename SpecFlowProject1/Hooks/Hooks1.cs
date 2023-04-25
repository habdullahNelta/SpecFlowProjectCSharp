
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System.Diagnostics;
using static SpecFlowProject1.Hooks.Util;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly IObjectContainer _container;
        private readonly string WebURL = "https://demowebshop.tricentis.com";

      //  private readonly string WebURL = "https://www.inside-digital.de/handy/datenbank/handyvergleich";

        public Hooks1(IObjectContainer container)
        {
            _container = container;
        }

        public void RunBatForReporting()
        {
            DirectoryInfo di = new("../../../");
            Process pros = new Process();
            // pros.StartInfo.FileName = di.FullName + "bin/Debug/net6.0/reportSpecflow.bat";
            pros.StartInfo.FileName = di.FullName + "reportSpecflow.bat";
            pros.Start();

       // lösung 2
            /*
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;
            string command = "timeout /t 5 /nobreak \n" +
                "livingdoc test-assembly SpecFlowProject1.dll -t TestExecution.json";
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();*/
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
            RunBatForReporting();
        }
    }
}