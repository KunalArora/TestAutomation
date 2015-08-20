@UAT @PROD @TEST
Feature: Contact us feature
	As a visitor of the Brother main site
	I am able to use the contact us
	feature to get in touch with Brother
	for any needed support 

# Product related contact
Scenario: User is able to submit the contact us form with a product releated enquiry
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top support menu button
	Then I hover and click the contact us option
	Then I am navigated to the contact us page
	And I select product related for question category
	And I select a model category
	And I select a model
	And I enter a serial number
	And I select an operating system
	And I enter first name
	And I enter last name
	And I enter a telephone number
	And I select the country of residence
	And I enter a valid contact email address
	And I enter a question
	And I click the submit contact request button
	Then I see confirmation that my contact request has been sent

# Non product related contact
Scenario: User is able to submit the contact us form with a non product releated enquiry
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top support menu button
	Then I hover and click the contact us option
	Then I am navigated to the contact us page
	And I select non product related for question category
	And I enter a serial number
	And I select an operating system
	And I enter first name
	And I enter last name
	And I enter a telephone number
	And I select the country of residence
	And I enter a valid contact email address
	And I enter a question
	And I click the submit contact request button
	Then I see confirmation that my contact request has been sent

# Contact us form mandatory fields
Scenario: User is only able to send a contact request to brother after all mandatroy fields are completed
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top support menu button
	Then I hover and click the contact us option
	Then I am navigated to the contact us page
	And I select non product related for question category
	And I click the submit button
	Then I see an error regarding the missing operating system
	And I select product related for question category
	And I click the submit button
	Then I see an error regarding the missing model category
	And I select a model category
	And I click the submit button
	Then I see an error regarding missing model
	And I select a model
	And I click the submit button
	Then I see an error regarding the missing operating system
	And I select an operating system
	And I click the submit button
	Then I see an error regarding the missing first name
	And I enter first name
	And I click the submit button
	Then I see an error regarding the missing last name
	And I enter last name
	And I click the submit button 
	Then I see an error regarding the missing country of residence
	And I select the country of residence
	And I click the submit button
	Then I see an error regarding the missing email 
	And I enter a valid contact email address
	And I click the submit button
	Then I see an error regarding the missing question
	And I enter a question
	And I click the submit button
	Then I see confirmation that my contact request has been sent

# Contact us form requires a valid email address before it can be submitted
Scenario Outline: User is only able to send a contact request to brother with a valid email address
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top support menu button
	Then I hover and click the contact us option
	Then I am navigated to the contact us page
	And I select product related for question category
	And I select a model category
	And I select a model
	And I enter a serial number
	And I select an operating system
	And I enter first name
	And I enter last name
	And I enter a telephone number
	And I select the country of residence
	And I enter a question
	And I enter an invalid contact email address containing <Email Address>
	And I click the submit button
	Then I see an invalid email address error on the contact us form

Scenarios:
	| Email Address                               |
	| "This is a space@guerrillamail.com"         |
	| "CannotUsePercent%@guerrillamail.com"       |
	| "CannotUseCurlyBraces{}@guerrillamail.com"  |
	| "CannotUsePlus+@guerrillamail.com"          |
	| "CannotUseDollar$@guerrillamail.com"        |
	| "CannotUsePound£@guerrillamail.com"         |
	| "CannotUseQuotes"@guerrillamail.com"        |
	| "CannotUseAsterix*@guerrillamail.com"       |
	| "CannotUseTwoAmpersands@@guerrillamail.com" |
	| "CannotUseQuestionMark?@guerrillamail.com"  |
	| "CannotUseOpenBrace(@guerrillamail.com"     |
	| "CannotUseEquals=@guerrillamail.com"        |
	| "specialcharactersüñîçøðé@guerrillamail.com"|