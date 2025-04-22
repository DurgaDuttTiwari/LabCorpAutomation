using LabCorpAutomation.Drivers;
using Reqnroll;

namespace LabCorpAutomation.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks

        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private WebDriverManager? _webDriverManager;

        public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            _webDriverManager = new WebDriverManager();
            _scenarioContext["driver"] = _webDriverManager.Driver;
        }

        [AfterScenario]
        public void CleanUpWebDriver()
        {
            _webDriverManager?.Quit();
        }
    }
}