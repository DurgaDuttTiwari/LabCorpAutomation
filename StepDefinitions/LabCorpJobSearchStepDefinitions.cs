using System;
using LabCorpAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Reqnroll;

namespace LabCorpAutomation.StepDefinitions
{
    [Binding]
    public class LabCorpJobSearchStepDefinitions
    {

        private readonly IWebDriver driver;

        public LabCorpHomePage LabCorpHomePage;

        public CarreersPage CarreersPage { get; }
        public JobDetailsPage JobDetailsPage { get; }

        private readonly Actions actions;

        public LabCorpJobSearchStepDefinitions(ScenarioContext scenarioContext)
        {
            driver = (IWebDriver)scenarioContext["driver"];
            LabCorpHomePage = new LabCorpHomePage(driver);
            CarreersPage = new CarreersPage(driver);
            JobDetailsPage = new JobDetailsPage(driver);
            actions = new Actions(driver);
        }






        [Given("I navigate to LabCorp website")]
        public void GivenINavigateToLabCorpWebsite()
        {
            driver.Navigate().GoToUrl("https://www.labcorp.com/");
        }

        [Then("I click on global navigation button")]
        public void ThenIClickOnGlobalNavigationButton()
        {
            LabCorpHomePage.OpenglobalNavigation.Click();

        }

        [Then("I navihate to Carrer link")]
        public void ThenINavihateToCarrerLink()
        {
            Thread.Sleep(1000);
            actions.MoveToElement(LabCorpHomePage.CareersLink).ScrollByAmount(0,300).Perform();
        }


        [When("I click on the Careers link")]
        public void WhenIClickOnTheCareersLink()
        {
            LabCorpHomePage.CareersLink.Click();
            Thread.Sleep(5000);
        }

        [Then("career page opened in new tab")]
        public void ThenCareerPageOpenedInNewTab()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.WindowHandles.Count > 1);


            // Switch to the new tab
            var newTab = driver.WindowHandles.Last();
            driver.SwitchTo().Window(newTab);

            // Check if the URL is correct
            wait.Until(driver => driver.Url.Contains("careers.labcorp.com"));

            Console.WriteLine("Career page URL: " + driver.Url);
            Assert.That(driver.Url.Contains("careers.labcorp.com"), Is.True, "Career page not opened correctly.");
        }


        [Then("I search for {string}")]
        public void ThenISearchFor(string p0)
        {
            CarreersPage.Searchbox.SendKeys(p0);
            Thread.Sleep(5000);
            actions.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Perform();
        }


        private string? expectedTitle;
        private string? expectedLocation;
        private string? expectedJobId;
        //private string expectedDescription;

        [Then("I fetch the first job details")]
        public void ThenIFetchTheFirstJobDetails()
        {
            var details = CarreersPage.GetFirstJobDetails();

            expectedTitle = details.title;
            expectedLocation = details.location;
            expectedJobId = details.jobId;
            //expectedDescription = details.description;
        }

        [Then("I click on the job title")]
        public void ThenIClickOnTheJobTitle()
        {
            CarreersPage.firstJob.Click();
        }

        [Then("the Job is opened")]
        public void ThenTheJobIsOpened()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            wait.Until(driver => driver.Url.Contains("careers.labcorp.com/global/en/job/"));

            Console.WriteLine("Career page URL: " + driver.Url);
            Assert.That(driver.Url.Contains("careers.labcorp.com/global/en/job"), Is.True, "job page not opened correctly.");
        }



        

        [Then("I open the job details page")]
        public void ThenIOpenTheJobDetailsPage()
        {
            CarreersPage.firstJob.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url.Contains("careers.labcorp.com/global/en/job/"));
        }

        [Then("I validate job details on the new page")]
        public void ThenIValidateJobDetailsOnTheNewPage()
        {
            Console.WriteLine(expectedJobId);


            string actualTitle = JobDetailsPage.GetTitle();
            string actualLocation = JobDetailsPage.GetLocation();
            string actualJobId = JobDetailsPage.GetJobId();

            

            if (actualJobId.StartsWith("Job ID"))
            {
                actualJobId = actualJobId.Replace("Job ID :", "").Trim();
            }

            Console.WriteLine($"{actualTitle} {actualLocation} {actualJobId}");

            Assert.Multiple(() =>
            {
                Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Job Title does not match");
                Assert.That(actualLocation, Is.EqualTo(expectedLocation), "Job Location does not match");
                Assert.That(actualJobId, Is.EqualTo(expectedJobId), "Job ID does not match");
            });
        }

    }
}
