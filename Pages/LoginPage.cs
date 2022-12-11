using OpenQA.Selenium;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class LoginPage
    {
        IWebDriver driver;

        private readonly By _usernameField = By.Name("username");
        private readonly By _passwordField = By.Name("password");
        private readonly By _loginButton = By.TagName("button");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public DashboardPage Login(String username, String password)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_usernameField));

            driver.FindElement(_usernameField).SendKeys(username);
            Thread.Sleep(200);
            driver.FindElement(_passwordField).SendKeys(password);
            Thread.Sleep(200);
            driver.FindElement(_loginButton).Click();
            
            return new DashboardPage(driver);
        }
    }
}
