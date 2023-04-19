using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V109.Network;
using SpecFlowProject1.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly IWebDriver  driver;
        public LoginStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        private readonly string WebURL = "https://demowebshop.tricentis.com";
        LoginPage loginPage ;
        [Given(@"user navigates to demo shop site")]
        public void GivenUserNavigatesToDemoShopSite()
        {
            driver.Url = WebURL;
            loginPage = new LoginPage(driver);
        }

        [Given(@"user hits Log in link")]
        public void GivenUserHitsLogInLink()
        {
            loginPage.HitLoginLink().Click();
        }

        [When(@"user enters Email as ""([^""]*)"" and Password as ""([^""]*)""")]
        public void WhenUserEntersEmailAsAndPasswordAs(string email, string password)
        {
            loginPage.EnterEmail().SendKeys(email);
            loginPage.EnterPassword().SendKeys(password);
            loginPage.ClickOnLogin().Click();
        }

        [Then(@"login should be successful")]
        public void ThenLoginShouldBeSuccessful()
        {
            Assert.IsTrue(loginPage.HasAlreadyLoggedIn().Displayed);
        }
    }
}
