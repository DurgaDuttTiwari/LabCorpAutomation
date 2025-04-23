using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices;

namespace LabCorpAutomation.Drivers
{
    public class WebDriverManager
    {
        public IWebDriver Driver { get; private set; }

        public WebDriverManager()
        {
            var options = new ChromeOptions();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Headless mode for CI (Linux)
                options.AddArguments(
                    "--headless",
                    "--disable-gpu",
                    "--no-sandbox",
                    "--disable-dev-shm-usage",
                    "--disable-extensions",
                    "--remote-debugging-port=9222"
                );

                // Use unique temp profile to avoid session issues in CI
                string tempUserDataDir = Path.Combine(Path.GetTempPath(), "ChromeProfile_" + Guid.NewGuid());
                options.AddArgument($"--user-data-dir={tempUserDataDir}");
            }
            else
            {
                // Headed mode for local (Windows/macOS)
                Console.WriteLine("Running in headed mode.");
            }

            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }


        public void Quit()
        {
            Driver.Quit();
        }

    }
}
