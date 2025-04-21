Feature: LabCorp Job Search

A short summary of the feature

@tag1
 Scenario: Search and validate QA Test Automation job details
    Given I navigate to LabCorp website
    Then I click on global navigation button
    And I navihate to Carrer link
    When I click on the Careers link
    Then career page opened in new tab
    And I search for "QA Test Automation Developer"
    Then I fetch the first job details
    And I click on the job title
    And the Job is opened  
    Then I validate job details on the new page

