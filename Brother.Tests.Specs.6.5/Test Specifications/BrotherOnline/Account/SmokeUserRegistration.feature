@TEST
Feature: B2C and B2B Registration
	In order to register myself with brother
	As a customer
	I need to create a new online account

#B2C User Registration without tax code

@SMOKE
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

@SMOKE
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

@SMOKE
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

@SMOKE
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

@SMOKE
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

@SMOKE
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

@SMOKE
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

@SMOKE
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

@SMOKE
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

@SMOKE
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

@SMOKE
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
| Italy         |  

@SMOKE
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

# B2C User registration with tax codes


# Create an account for Brother Online for spain sites
@SMOKE
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


# Create an account for Brother Online for spain sites
@SMOKE
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
	| NumeroDNI		  | PT980254698	   |
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


# Create an account for Brother Online for Italy
@SMOKE
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

# B2B Business User registration with tax codes and provides error message if tax code not given
@SMOKE
Scenario Outline: Customer creates a new Business account with Brother Online using valid credentials without VAT NUMBER, confirm by email on UK site and sign in and Sign Out
Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "IT and telecommunications services"
	And I select number of Employees as "11 - 50"
	And I have Agreed to the Terms and Conditions
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

Scenarios:
| Country         |
| United Kingdom  |


@SMOKE
Scenario Outline: Customer creates a new Business account with Brother Online using valid credentialS without VAT NUMBER, confirm by email on Ireland site and sign in and Sign Out
Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "IT and telecommunications services"
	And I select number of Employees as "11 - 50"
	And I have Agreed to the Terms and Conditions
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios:
| Country   | 
| Ireland   |  

@SMOKE
Scenario Outline: Customer able to create a new BOL Portugal account using the valid taxcode on Portugal BOL site
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I declare that I do use this account for business
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "Fabrico"
	And I select number of Employees as "11 - 50"
	And I enter a valid VAT number as "<Tax Code>" for Portugal
	And I have Agreed to the Terms and Conditions
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online

Scenarios: 
| Country  | Tax Code    |
| Portugal | PT181161699 |

@SMOKE
Scenario Outline: Customer gets valid error message on BOL Portugal site  with Invalid tax code.
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "<Business Sector>"
	# And I enter my Business Sector as "<Business Sector>"
	And I select number of Employees as "11 - 50"
	And I enter an invalid VAT Number as "<VAT Number>"
	And I have Agreed to the Terms and Conditions
	When I press Create Your Account
	Then I should see an error message due to an invalid tax code 
Scenarios:
| Country		| Business Sector		| VAT Number       |
| Portugal		| Fabrico				| INVALIDVATNUMBER |

@SMOKE
Scenario Outline: Customer gets valid error message on BOL Denmark site with invalid tax code
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "<Business Sector>"
	# And I enter my Business Sector as "<Business Sector>"
	And I select number of Employees as "11 - 50"
	And I enter an invalid VAT Number as "<VAT Number>"
	And I have Agreed to the Terms and Conditions
	When I press Create Your Account
	Then I should see an error message due to an invalid tax code 

Scenarios:
| Country		| Business Sector		| VAT Number       |
| Denmark		| Byggeri				| INVALIDVATNUMBER |

@SMOKE
Scenario Outline: Customer gets valid error message on BOL Netherlands site with invalid tax code
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 

	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "<Business Sector>"
	# And I enter my Business Sector as "<Business Sector>"
	And I select number of Employees as "11 - 50"
	And I enter an invalid VAT Number as "<VAT Number>"
	And I have Agreed to the Terms and Conditions
	When I press Create Your Account
	Then I should see an error message due to an invalid tax code 

Scenarios:
| Country		| Business Sector		| VAT Number       |
| Netherlands	| Bouw					| INVALIDVATNUMBER |

@SMOKE
Scenario Outline: Customer gets valid error message on BOL Norway site with invalid tax code
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "<Business Sector>"
	# And I enter my Business Sector as "<Business Sector>"
	And I select number of Employees as "11 - 50"
	And I enter an invalid VAT Number as "<VAT Number>"
	And I have Agreed to the Terms and Conditions 
	When I press Create Your Account
	Then I should see an error message due to an invalid tax code 

Scenarios:
| Country		| Business Sector		| VAT Number       |
| Norway		| Industri				| INVALIDVATNUMBER |

@SMOKE
Scenario Outline: Customer gets valid error message on BOL spain site with invalid tax code
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "<Business Sector>"
	# And I enter my Business Sector as "<Business Sector>"
	And I select number of Employees as "11 - 50"
	And I enter an invalid VAT Number as "<VAT Number>"
	And I have Agreed to the Terms and Conditions 
	When I press Create Your Account
	Then I should see an error message due to an invalid tax code 

Scenarios:
| Country		| Business Sector		| VAT Number       |
| Spain			| Servicios personales	| INVALIDVATNUMBER | 

@SMOKE
Scenario Outline: Customer gets valid error message on BOL France site  with invalid tax code
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
    And I fill in the registration information using a valid email address 
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "<Business Sector>"
	# And I enter my Business Sector as "<Business Sector>"
	And I select number of Employees as "11 - 50"
	And I enter an invalid VAT Number as "<VAT Number>"
	And I have Agreed to the Terms and Conditions 
	When I press Create Your Account
	Then I should see an error message due to an invalid tax code 

Scenarios:
| Country		| Business Sector		| VAT Number       |
| France		| Fabrication			| INVALIDVATNUMBER |

@SMOKE
Scenario Outline: Customer gets valid error message on BOL Germany site  with invalid tax code
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "<Business Sector>"
	# And I enter my Business Sector as "<Business Sector>"
	And I select number of Employees as "11 - 50"
	And I enter an invalid VAT Number as "<VAT Number>"
	And I have Agreed to the Terms and Conditions 
	When I press Create Your Account
	Then I should see an error message due to an invalid tax code 

Scenarios:
| Country		| Business Sector		| VAT Number       |
| Germany		| Bildung				| INVALIDVATNUMBER |

@SMOKE
Scenario Outline: Customer gets valid error message on BOL Austria site  with invalid tax code
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "<Business Sector>"
	# And I enter my Business Sector as "<Business Sector>"
	And I select number of Employees as "11 - 50"
	And I enter an invalid VAT Number as "<VAT Number>"
	And I have Agreed to the Terms and Conditions 
	When I press Create Your Account
    Then I should see an error message due to an invalid tax code 

Scenarios:
| Country		| Business Sector		| VAT Number       |
| Austria		| Bildung				| INVALIDVATNUMBER | 

@SMOKE
Scenario Outline: Customer gets valid error message on BOL Belgium site  with invalid tax code
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "<Business Sector>"
	# And I enter my Business Sector as "<Business Sector>"
	And I select number of Employees as "11 - 50"
	And I enter an invalid VAT Number as "<VAT Number>"
	And I have Agreed to the Terms and Conditions 
	When I press Create Your Account
	Then I should see an error message due to an invalid tax code 

Scenarios:
| Country		| Business Sector		| VAT Number       |
| Belgium		| Fabrication		    | INVALIDVATNUMBER | 

@SMOKE
Scenario: Sign Up for 14 day Free trial already signed into Brother Online
	# Create an account on BOL and sign in
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
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
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	When I navigate to my account for "United Kingdom"
	#Given I am logged onto Brother Online "United Kingdom" using valid credentials
	And I have navigated to the OmniJoin home page
	And If I click on Start Free Trial
	Then I should be directed to the OmniJoin Free Trial page
	When I have entered a valid First and Last name, "AutoTest", "AutoTest"
	And I have entered a valid email address
	And I have entered a valid phone number "01555 522522"
	And I have Agreed to the Free Trial Terms and Conditions
	And if I click Submit
	Then I should be directed to the download page indicating I have 14 days Free trial
	And Once I have Validated a Free Trial confirmation Email was received
	Then If I go back to Brother Online Home Page 
	Then I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

	
@ignore
Scenario Outline: Purchase OmniJoin subscription plan for <country> for a <Plan Type> plan on <Billing Type> billing
	Given I have navigated to the OmniJoin home page
	And I have clicked on Buy
	Then I should be redirected to the Plans page
	And If I then Choose the "<Plan Type>" Plan option column
	Then I should be directed to the relevant plan page
	And I check the correct billing type as "<Billing Type>"
	When I click Agree to terms and conditions
	And I Click Buy Now At Brother Online
	Then I should be directed to the Brother Online Basket page
	And When I click CheckOut
	Then I can add billing address details for Country "<Country>"
	And I can go through the order process for Country "<Country>" with order info "<Qty>"
	Then I should see the Order Confirmation page
	And The purchased plan billing type is correct "<Billing Type>"
	And If I click on My Account
	And I can click on Orders
	And I can validate the order "<Qty>" of "<Order Name>" @ "<Price>" on My Account page
	Then I am redirected to the Brother Home Page
	And I can validate an Order Confirmation email was received

Scenarios: 
	
	| Plan Type    | Country        | Billing Type | Qty | Order Name            | Price   |
	| Lite         | United Kingdom | Monthly      | 1   | OmniJoin Lite         | £18.00  |
	| Lite         | United Kingdom | Annual       | 1   | OmniJoin Lite         | £144.00 |
	| Business     | United Kingdom | Monthly      | 1   | OmniJoin Pro          | £70.80  |
	| Business     | United Kingdom | Annual       | 1   | OmniJoin Pro          | £678.00 |
	| Professional | United Kingdom | Monthly      | 1   | OmniJoin              | £34.80  |
	| Professional | United Kingdom | Annual       | 1   | OmniJoin              | £331.20 |

@ignore
# OmniJoin plan purchase - add existing accounts
Scenario: Purchase a Lite Use plan on Monthly Billing but click Cancel before submitting payment
	 And I have navigated to the OmniJoin home page
	 And I have clicked on Buy
	Then I should be redirected to the Plans page
	And If I then Choose the "Lite" Plan option column
	Then I should be directed to the relevant plan page
	When I click Agree to terms and conditions
	And I Click Buy Now At Brother Online
   Then I should be directed to the Brother Online Basket page
	And When I click CheckOut
	When I press Create Your Account
	Then I can add billing address details for Country "United Kingdom"
	And I can go through a dummy order process for Country "United Kingdom" with order info "1"
	Then I can navigate back to Brother Online home page
	Then I can sign out of Brother Online

