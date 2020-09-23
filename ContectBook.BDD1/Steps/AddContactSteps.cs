using ContactBook.Commons.Wrapper;
using ContactsWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ContectBook.BDD.Steps
{
    [Binding]
    public sealed class AddContactSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly HttpClientWrapper _client;
        private ResponseWrapper response;

        public AddContactSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _client = new HttpClientWrapper();
        }

        [When(@"I create a contact with the following details '(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenICreateAContactWithTheFollowingDetails(string firstName, string lastName, string DOB, string emails, string phonenos)
        {
            var contact = new Contact()
            {
                FirstName = firstName,
                LastName = lastName,
                DOB = Convert.ToDateTime(DOB),
                Email = new List<string>() { emails },
                PhoneNos = new List<string>() { phonenos }
            };
            var content = JsonConvert.SerializeObject(contact);
            response = _client.Post(content);

        }

        [Then(@"the contact should be created with status code '(.*)'")]
        public void ThenTheContactShouldBeCreatedWithStatusCode(string statusCode)
        {
            if (!statusCode.Equals(response.StatusCode.ToString()))
            {
                throw new Exception("stat");
            }
        }


    }
}
