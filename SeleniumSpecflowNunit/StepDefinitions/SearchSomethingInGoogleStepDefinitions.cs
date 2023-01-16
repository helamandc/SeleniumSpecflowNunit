using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowNunit.StepDefinitions
{
    [Binding]
    public class SearchSomethingInGoogleStepDefinitions
    {

        string test_url = "https://www.google.com/";
        IWebDriver driver;
        string itemname = "Praemium";

        [Given(@"I open Google search engine")]
        public void GivenIOpenGoogleSearchEngine()
        {
            driver = new ChromeDriver();
            driver.Url = test_url;
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        [Given(@"I type (.*) in the search field")]
        public void GivenITypeInTheSearchField(string text)
        {
            IWebElement search = driver.FindElement(By.ClassName("gLFyf"));
            search.Click();
            search.Clear();
            search.SendKeys(itemname);
        }

        [When(@"I click on Google Search button")]
        public void WhenIClickOnGoogleSearchbutton()
        {
            IWebElement click = driver.FindElement(By.ClassName("gNO89b"));
            click.Click();
        }

        [Then(@"I would see results about Praemium")]
        public void ThenIWouldSeeResultsAboutPraemium()
        {
            IWebElement itemtext = driver.FindElement(By.ClassName("yuRUbf"));
            string gettext = itemtext.Text;
            Assert.That(gettext.Contains(itemname), Is.True);
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
