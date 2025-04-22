using OpenQA.Selenium;

namespace LabCorpAutomation.Pages
{
    public class CarreersPage
    {

        private IWebDriver driver;

        public CarreersPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement Searchbox => driver.FindElement(By.XPath("//input[@id='typehead']"));

        public IWebElement firstJob => driver.FindElement(By.XPath("(//a[contains(@class, 'au-target') and contains(@href, 'job')]/div[contains(@class, 'job-title')]/span)[1]"));

        private IWebElement FirstJobTitle => driver.FindElement(By.XPath("(//a[contains(@class, 'au-target') and contains(@href, 'job')]/div[contains(@class, 'job-title')]/span)[1]"));
        private IWebElement FirstJobLocation => driver.FindElement(By.XPath("(//span[contains(@class, 'job-location')])[1]"));
        private IWebElement FirstJobId => driver.FindElement(By.XPath("(//span[contains(@class, 'jobId')]/span[last()])[1]"));
        //private IWebElement FirstJobDescription => driver.FindElement(By.XPath("(//li[contains(@class, 'job-item')]//p[contains(@class, 'job-item__description')])[1]"));

        //public IWebElement FirstJobClickable => driver.FindElement(By.XPath("(//li[contains(@class, 'job-item')]//h2[contains(@class, 'job-item__title')]/a)[1]"));






        // To fetch details
        public (string title, string location, string jobId) GetFirstJobDetails()
        {
            string title = FirstJobTitle.Text.Trim();
            string location = FirstJobLocation.Text.Trim();
            string jobId = FirstJobId.Text.Trim().Replace("Job Id: ", "");
            //string description = FirstJobDescription.Text.Trim();

            return (title, location, jobId);
        }





    }
}
