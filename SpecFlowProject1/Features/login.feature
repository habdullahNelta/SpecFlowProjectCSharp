@loginFeature
Feature: Login

A short summary of the feature

@login
Scenario Outline: TC4: Login User with correct email and password
    Given user navigates to demo shop site
    And   user hits Log in link
    When  user enters Email as "<email>" and Password as "<password>"
    Then  login should be successful

    Examples:
      | email                 | password  |
      | tester@test.de        | 123456789 |
