@UAT @PROD @TEST @SMOKE
Feature: PublishedPages
	In order to validate the success of a new build, 
	previously published pages are verified to ensure 
	a CMS code change has not had an adverse effect	

@SMOKE
Scenario Outline: Navigate to published page to verify all page components 
	# Given I have navigated to the published url "http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseLeave"
	Given That I navigate to "<Site Url>" in order to validate a published page
	Then I can verify that the page header is displayed
	Then I can verify that the search icon is displayed
	Then I can verify that the top navigation component is displayed
	Then I can verify that the accordion compoment is displayed
	Then I can verify that the features carousel component is displayed
	Then I can verify that a features carousel tile is displayed
	Then I can verify that a banner bar component is displayed
	#Then I can verify that a banner bar tile is displayed
	# Info image module currently not publishing. Its displayed fine in experience editor
	# Then I can verify that an info image text module component is displayed
	Then I can verify that the secondary navigation component is displayed
	Then I can verify that the breadcrumbs component is displayed
	Then I can verify the case study component is displayed
	Then I can verify that the contact bar component is displayed
	Then I can verify that the benefit bar component is displayed
	Then I can verify that the benefit bar tile component is displayed
	Then I can verify that the latest news component is displayed
	Then I can verify that the header bar component is displayed
	Then I can verify that the full info tile component is displayed
	Then I can verify that the hero component is displayed
	Then I can verify that the secondary hero component is displayed
	Then I can verify that the feature module image left is displayed
	Then I can verify that the feature module image right is displayed
	Then I can verify that the feature bar component is displayed
	Then I can verify that the feature bar tile is displayed
	Then I can verify that the super carousel component is displayed
	Then I can verify that the video list module is displayed
	Then I can verify that the video tile bar is displayed
	Then I can verify that the full width hero is displayed
	Then I can verify that the special full info is displayed
	Then I can verify that the conversion bar is displayed
	Then I can verify that the wizard is displayed
	Then I can verify that the special feature is displayed
	Then I can verify that the steps bar is displayed
	Then I can verify that the hero carousel is displayed
	Then I can verify that the wizard step is displayed
	Then I can verify that the rich text module is displayed
	Then I can Verify that the link list item is displayed
	# WFFM is currently broken on DV2
	# Then I can verify that the Wffm component is displayed
	# Components above are for the 12 placeholder. Components for 8 and 4 placholders to be still added to this smoke test.
	# Once copy back of page and modules has been done in all environmemnts, this smoke test can be extended. 
	# Ideally this needs to go into Dev to verify the automated builds are stable.

Scenarios: 
	
	 |Site Url													   |
	 |http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseLeave |


@SMOKE
Scenario Outline: Navigate to published page to verify product page - UK
	Given That I navigate to "<Site Url>" in order to validate a published page
	Then I can validate the product page title is displayed
	
Scenarios: 
	
	 |Site Url																	    |
	 |http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/DCPL8400CDN |
	 |http://main.co.uk.brotherqas.eu/QA/TestAutomationPleaseDoNotTouch/DCP9020CDW |


@SMOKE
Scenario Outline: Navigate to published page to verify supplies product page - UK
	Given That I navigate to "<Site Url>" in order to validate a published page
	Then I can validate the product page title is displayed
	
Scenarios: 
	
	 | Site Url                                                                                           |
	 | http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/HGe131V5-SuppliesPage            |                                                               
	 | http://main.co.uk.brotherqas.eu/QA/TestAutomationPleaseDoNotTouch/AD18ESUK						  |


@SMOKE
Scenario Outline: Navigate to published page to verify News landing page - UK
	Given That I navigate to "<Site Url>" in order to validate a published page
	Then I can validate article is displayed on the page

Scenarios: 
	
	 | Site Url																							|
	 | http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/NewsLandingPage				|
	 | http://main.co.uk.cms.brotherqas.eu/QA/TestAutomationPleaseDoNotTouch/News-Landing-Page			|

		
@SMOKE
Scenario Outline: Navigate to published page to verify Glossary page - UK
	Given That I navigate to "<Site Url>" in order to validate a published page
	Then I can validate glossary section is displayed

Scenarios: 
	
	 | Site Url																							 |
	 | http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/glossary						 |
	 | http://main.co.uk.brotherqas.eu/QA/TestAutomationPleaseDoNotTouch/glossary						 |


@SMOKE
Scenario Outline: Navigate to published page to verify Printer Listing page - UK
	Given That I navigate to "<Site Url>" in order to validate a published page
	Then I can validate printers filter section is displayed

Scenarios: 
	
	 | Site Url																							 |
	 | http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/All-Printers					 |

@SMOKE
Scenario Outline: Navigate to published page to verify Supplies page - UK
	Given That I navigate to "<Site Url>" in order to validate a published page
	Then I can validate supplies section is displayed
	
Scenarios: 
	
	 | Site Url																							 |
	 | http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/AD18ESUK						 |
	 | http://main.co.uk.brotherqas.eu/QA/TestAutomationPleaseDoNotTouch/HGe131V5				 |

 