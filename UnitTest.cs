using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumTests
{
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


