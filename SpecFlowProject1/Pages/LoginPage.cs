using OpenQA.Selenium;


namespace SpecFlowProject1.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver) {
            this.driver = driver;
        }

        readonly By hitLoginLinkBy = By.LinkText("Log in");
        readonly By enterEmailBy = By.Id("Email");
        readonly By enterPasswordBy = By.Id("Password");
        readonly By clickOnLoginBy = By.XPath("//input[@type=\"submit\"][@value=\"Log in\"]");
        readonly By hasAlreadyLoggedInBy = By.LinkText("Log out");
       // readonly By testBy = By.XPath("//button[contains(.,'Akzeptieren und weiter')]");

      //  public WebElement test1() => (WebElement)driver.FindElement(testBy);
        public WebElement HitLoginLink() => (WebElement)driver.FindElement(hitLoginLinkBy);
        public WebElement EnterEmail() => (WebElement)driver.FindElement(enterEmailBy);
        public WebElement EnterPassword() => (WebElement)driver.FindElement(enterPasswordBy);
        public WebElement ClickOnLogin() => (WebElement)driver.FindElement(clickOnLoginBy);
        public WebElement HasAlreadyLoggedIn() => (WebElement)driver.FindElement(hasAlreadyLoggedInBy);

    }
}
