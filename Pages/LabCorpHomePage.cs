using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCorpAutomation.Pages
{
    public class LabCorpHomePage
    {
        private IWebDriver driver;

        public LabCorpHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }



        public IWebElement OpenglobalNavigation => driver.FindElement(By.XPath("//button[@aria-label='Open global Navigation']")); //Using first type of By
        public IWebElement CareersLink => driver.FindElement(By.LinkText("Careers"));  // use of Second By

    }
}
