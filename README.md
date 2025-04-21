# LabCorp UI Automation Test Suite

This project is an automated UI testing framework for validating job search functionalities on the [LabCorp Careers Website](https://careers.labcorp.com). It uses C#, Selenium WebDriver, Reqnroll (SpecFlow), and NUnit.

---

## 📂 Project Structure

```
├── .github/workflows/   # GitHub Actions CI pipeline
├── Drivers/             # WebDriver initialization and browser configuration
├── Features/            # Gherkin-based BDD test scenarios (.feature files)
├── Pages/               # Page Object Model (POM) classes encapsulating UI interactions
├── StepDefinitions/     # Step definitions mapping Gherkin steps to automation code
├── Hooks/               # Test setup and teardown logic (e.g., opening/closing browsers)
```
---

## 🚀 Getting Started

### Prerequisites
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) with `.NET` and `Test` workloads

### Install Dependencies
```
dotnet restore
```


### Run Tests
```
dotnet test
```

---

## ⚙️ CI/CD Pipeline with GitHub Actions

This project includes a GitHub Actions workflow (`.github/workflows/dotnet-ci.yml`) that:
- Builds the project
- Runs UI tests using NUnit + Reqnroll
- Uploads `.trx` test results as artifacts

To trigger CI:
```
git push origin main
```

🔍 Test Scenario
Scenario: Validate QA Automation Job on LabCorp

Searches for QA Test Automation Developer

Verifies first job's title, ID, and location

Validates job description after redirection

---

🛠 Tech Stack

C#

Selenium WebDriver

Reqnroll (SpecFlow BDD)

NUnit

GitHub Actions (CI)

📄 License
This project is licensed for learning/demo purposes.

---

Happy testing 🚀