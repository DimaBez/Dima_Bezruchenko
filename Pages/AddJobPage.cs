using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTests
{
    class AddJobPage
    {
        IWebDriver driver;

        private readonly By _jobTitleField = By.XPath("//div[@data-v-2fe357a6]//child::input[@data-v-844e87dc ]");
        private readonly By _jobDescriptionField = By.XPath("//textarea[@placeholder='Type description here']");
        private readonly By _jobNoteField = By.XPath("//textarea[@placeholder='Add note']");
        private readonly By _saveButton = By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary orangehrm-left-space']");
        
        public AddJobPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public JobPage AddJob(String jobTitle, String jobDescription, String jobNote)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_jobTitleField));

            Thread.Sleep(200);
            driver.FindElement(_jobTitleField).SendKeys(jobTitle);
            Thread.Sleep(200);
            driver.FindElement(_jobDescriptionField).SendKeys(jobDescription);
            Thread.Sleep(200);
            driver.FindElement(_jobNoteField).SendKeys(jobNote);
            Thread.Sleep(200);
            driver.FindElement(_saveButton).Click();

            return new JobPage(driver);
        }
    }
}
