using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LabCorpAutomation.Drivers
{
    public class WebDriverManager 
    {
        public IWebDriver Driver { get; private set; }

        public WebDriverManager()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  //Waiting implicitely for 5 sec
        }



        public void Quit()  
        {
            Driver.Quit();
        }

        
    }
}
