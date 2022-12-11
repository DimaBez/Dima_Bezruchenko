using OpenQA.Selenium;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class AdminPage
    {
        IWebDriver driver;

        private readonly By _jobButton = By.XPath("//li[@class='oxd-topbar-body-nav-tab --parent']");
        private readonly By _jobTitlesButton = By.XPath("//a[@class='oxd-topbar-body-nav-tab-link']");

        public AdminPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public JobPage GoToJobPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_jobButton));

            Thread.Sleep(200);
            driver.FindElement(_jobButton).Click();
            Thread.Sleep(200);
            driver.FindElement(_jobTitlesButton).Click();

            return new JobPage(driver);
        }
    }
}
