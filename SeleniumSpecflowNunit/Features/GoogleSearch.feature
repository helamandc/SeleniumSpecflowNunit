Feature: Search something in Google

This is to test the search functionality of Google search engine.

Scenario: A random user opens Google website and search for Praemium
	Given I open Google search engine
	And I type Praemium in the search field
	When I click on Google Search button
	Then I would see results about Praemium
