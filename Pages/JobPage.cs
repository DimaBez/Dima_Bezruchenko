using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class JobPage
    {
        IWebDriver driver;

        private readonly By _addButton = By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']");
        private readonly By _jobPoint = By.XPath("//div[text()='Title']");
        private readonly By _jobDelete = By.XPath("//div[text()='Title']//ancestor::div[@class='oxd-table-card']//child::i[@class='oxd-icon bi-trash']");
        private readonly By _jobDeleteDelete = By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--label-danger orangehrm-button-margin']");

        public JobPage(IWebDriver driver)
        {
            this.driver = driver;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_addButton));
        }

        public AddJobPage GoToAddJobPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_addButton));

            Thread.Sleep(200);
            driver.FindElement(_addButton).Click();

            return new AddJobPage(driver);
        }

        public bool PresentCheck()
        {
            IWebElement jobPoint = driver.FindElement(_jobPoint);
            return jobPoint.Displayed;
        }

        public bool AbsentCheck()
        {
            try
            {
                driver.FindElement(_jobPoint);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void DeleteJob()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_addButton));

            Thread.Sleep(200);
            IWebElement jobDelete = driver.FindElement(_jobDelete);
            jobDelete.Click();
            Thread.Sleep(200);
            IWebElement jobDeleteDelete = driver.FindElement(_jobDeleteDelete);
            jobDeleteDelete.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(_addButton));
        }
    }
}
