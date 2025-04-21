using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCorpAutomation.Pages
{
    public class JobDetailsPage
    {
        private IWebDriver driver;

        public JobDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        private IWebElement JobTitle => driver.FindElement(By.XPath("//h1[@class='job-title']"));
        private IWebElement JobLocation => driver.FindElement(By.XPath("//span[@class='au-target job-location']"));
        private IWebElement JobId => driver.FindElement(By.XPath("//span[@class='au-target jobId']"));
        //private IWebElement JobDescription => driver.FindElement(By.CssSelector(".job-description__body"));

        public string GetTitle() => JobTitle.Text.Trim();
        public string GetLocation() => JobLocation.Text.Trim();
        public string GetJobId() => JobId.Text.Trim().Replace("Job Id: ", "");
        //public string GetDescription() => JobDescription.Text.Trim();



    }
}
