using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumTests
{
    //public class Tests
    //{
    //    private IWebDriver driver;

    //    private readonly By _usernameField = By.Name("username");
    //    private readonly By _passwordField = By.Name("password");
    //    private readonly By _loginButton = By.TagName("button");
    //    private readonly By _adminButton = By.XPath("//a[@href='/web/index.php/admin/viewAdminModule']");
    //    private readonly By _jobButton = By.XPath("//li[@class='oxd-topbar-body-nav-tab --parent']");
    //    private readonly By _jobTitlesButton = By.XPath("//a[@class='oxd-topbar-body-nav-tab-link']");
    //    private readonly By _addButton = By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']");
    //    private readonly By _jobTitleField = By.XPath("//div[@data-v-2fe357a6]//child::input[@data-v-844e87dc ]");
    //    private readonly By _jobDescriptionField = By.XPath("//textarea[@placeholder='Type description here']");
    //    private readonly By _jobNoteField = By.XPath("//textarea[@placeholder='Add note']");
    //    private readonly By _saveButton = By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary orangehrm-left-space']");
    //    private readonly By _jobPoint = By.XPath("//div[text()='Title']");
    //    private readonly By _jobDelete = By.XPath("//div[text()='Title']//ancestor::div[@class='oxd-table-card']//child::i[@class='oxd-icon bi-trash']");
    //    private readonly By _jobDeleteDelete = By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--label-danger orangehrm-button-margin']");
        

    //    [SetUp]
    //    public void Setup()
    //    {
    //        driver = new OpenQA.Selenium.Chrome.ChromeDriver("C:\\Projects\\C#\\SeleniumTests\\bin\\Debug\\netcoreapp3.1.exe");
    //        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
    //        driver.Manage().Window.Maximize();
    //    }

    //    [Test]
    //    public void Test1()
    //    {
    //        Thread.Sleep(200);
    //        IWebElement username = driver.FindElement(_usernameField);
    //        Thread.Sleep(200);
    //        username.SendKeys("Admin");
    //        Thread.Sleep(200);
    //        IWebElement password = driver.FindElement(_passwordField);
    //        Thread.Sleep(200);
    //        password.SendKeys("admin123");
    //        Thread.Sleep(200);
    //        IWebElement loginButton = driver.FindElement(_loginButton);
    //        loginButton.Click();

    //        Thread.Sleep(2000);
    //        IWebElement adminButton = driver.FindElement(_adminButton);
    //        adminButton.Click();
    //        Thread.Sleep(1000);
    //        IWebElement jobButton = driver.FindElement(_jobButton);
    //        jobButton.Click();
    //        Thread.Sleep(1000);
    //        IWebElement jobTitlesButton = driver.FindElement(_jobTitlesButton);
    //        jobTitlesButton.Click();
    //        Thread.Sleep(1000);
    //        IWebElement addButton = driver.FindElement(_addButton);
    //        addButton.Click();

    //        Thread.Sleep(1000);
    //        IWebElement jobTitleField = driver.FindElement(_jobTitleField);
    //        jobTitleField.SendKeys("Title");
    //        Thread.Sleep(1000);
    //        IWebElement jobDescriptionField = driver.FindElement(_jobDescriptionField);
    //        jobDescriptionField.SendKeys("Description");
    //        Thread.Sleep(1000);
    //        IWebElement jobNoteField = driver.FindElement(_jobNoteField);
    //        jobNoteField.SendKeys("Note");
    //        Thread.Sleep(1000);
    //        IWebElement saveButton = driver.FindElement(_saveButton);
    //        saveButton.Click();

    //        Thread.Sleep(6000);
    //        IWebElement jobPoint = driver.FindElement(_jobPoint);
    //        bool temp = jobPoint.Displayed;
    //        Thread.Sleep(1000);
    //        IWebElement jobDelete = driver.FindElement(_jobDelete);
    //        jobDelete.Click();
    //        Thread.Sleep(1000);
    //        IWebElement jobDeleteDelete = driver.FindElement(_jobDeleteDelete);
    //        jobDeleteDelete.Click();
            
    //    }
    //}


    public class Tests
    {
        private IWebDriver driver;

        private String _adminName = "Admin";
        private String _password = "admin123";
        private String _jobTitle = "Title";
        private String _jobDescription = "Description"; 
        private String _jobNote = "Note";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver("C:\\Projects\\C#\\SeleniumTests\\bin\\Debug\\netcoreapp3.1.exe");
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            LoginPage loginPage = new LoginPage(driver);
            DashboardPage homePage = loginPage.Login(_adminName, _password);
            AdminPage adminPage = homePage.GoToAdminPage();
            JobPage jobPage = adminPage.GoToJobPage();
            AddJobPage addJobPage = jobPage.GoToAddJobPage();
            addJobPage.AddJob(_jobTitle, _jobDescription, _jobNote);

            JobPage jobPage2 = new JobPage(driver);
            
            Assert.That(jobPage2.PresentCheck(), Is.EqualTo(true));
            jobPage2.DeleteJob();
            Assert.That(jobPage2.AbsentCheck(), Is.EqualTo(false));
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}


