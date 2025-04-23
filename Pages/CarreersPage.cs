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


        public IWebElement searchIcon => driver.FindElement(By.XPath("//i[@class='icon icon-search']"));
        public IWebElement Searchbox => driver.FindElement(By.Id("typehead")); // Third using of By

        public IWebElement firstJob => driver.FindElement(By.XPath("//ul[@data-ph-at-id=\"jobs-list\"]/li[1]//div[@class=\"job-title\"]/span"));

        private IWebElement FirstJobTitle => driver.FindElement(By.XPath("(//a[contains(@class, 'au-target') and contains(@href, 'job')]/div[contains(@class, 'job-title')]/span)[1]"));
        private IWebElement FirstJobLocation => driver.FindElement(By.XPath("(//span[contains(@class, 'job-location')])[1]"));
        private IWebElement FirstJobId => driver.FindElement(By.XPath("(//span[contains(@class, 'jobId')]/span[last()])[1]"));



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
