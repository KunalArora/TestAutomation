Feature: B2C and B2B Registration
	In order to register myself with brother
	As a customer
	I need to create a new online account

@TEST @UAT @PROD
#Portugal -On Dv2 SingIn page has got personalTax number field textbox but not in QAS environment
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on IE and UK site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country  |	
| United Kingdom    |
| Ireland           |

@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Portugal site 
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country  |	
| Portugal | 


@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Denmark Site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country  |	
| Germany | 

@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Austria Site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country  |	
| Austria | 

@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on switzerland site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country  |	
| Switzerland | 

@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Belgium site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country  |	
| Belgium | 

@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on French site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country  |	
| France | 

@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on netherlands site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country     |	
| Netherlands | 

@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Ireland site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country     |	
| Ireland     |


@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Russia site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country     |	
| Russia      |  

@TEST @UAT @PROD @SMOKE
#Hungary BOL site is not up and running.
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Hungary site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country      |	
| Hungary      |  


@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on poland site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country     |	
| Poland      |  


@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Slovakia site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country       |	
| Slovakia      |  
 
@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on italian site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value    |
	| FirstName       | AutoTest |
	| LastName        | AutoTest |
	| Password        | @@@@@    |
	| ConfirmPassword | @@@@@    |
	| DNINumber       | @@@@@		   |
	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country       |	
| ITaly    |  

@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with BOL using valid credentials, confirm by email on Spain site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country       |	
| Spain         |  


@TEST @UAT @PROD @SMOKE
Scenario Outline: Customer creates a new account with BOL using valid credentials, confirm by email on Czech Republic site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country                |	
| Czech Republic         |  

# B2C User registration with tax codes

@TEST @UAT @PROD
# Create an account for Brother Online for spain sites
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Spain sitesign in and Sign Out
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address and ID number
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |
	| NumeroDNI		  | 00000023T	   |
	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country |
|Spain	  | 

@TEST @UAT @PROD
# Create an account for Brother Online for spain sites
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, Portugal sitesign in and Sign Out
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address and ID number
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |
	| NumeroDNI		  | PT000023T	   |
	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my 
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country  |	
| Portugal | 


@TEST @UAT @PROD
# Create an account for Brother Online for Italy
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Italy site sign in and Sign Out
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address and ID number for italy
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	| CodiceFiscale	  |MRTMTT25D09F205Z	|
	
	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country |
| Italy   |
