@UAT @PROD @TEST
Feature: Navigate main site top products menu
	As a visitor of the Brother main site
	I am able to navigate to each of the
	tab items within the top products menu

# Products navigation 
Scenario: User is able to navigate to the products page via the top main site products menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I have clicked the top products menu button
	Then I am navigated to the products page

# Printers navigation
Scenario: User is able to navigate to the printers page via the top main site products menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the printers option
	Then I am navigated to the printers page

		Scenario: User is able to navigate to view the colour laser range of printers
			Given I have navigated to the Brother Main Site "United Kingdom" products pages
			Then I hover over the top products menu button
			Then I hover and click the printers option
			Then I am navigated to the printers page
			Then I click the colour laser menu option
			Then I click to view the colour laser range
			Then I click tp view all colour lasers
			Then I am navigated to view all colour laser printers

		Scenario: User is able to navigate to view the mono laser range of printers
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the printers option
			Then I am navigated to the printers page
			Then I click the mono laser menu option
			Then I click to view the mono laser range
			Then I click tp view all mono lasers
			Then I am navigated to view all mono laser printers
		
		Scenario: User is able to navigate to view the inkjet range of printers
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the printers option
			Then I am navigated to the printers page
			Then I click the inkjet menu option
			Then I click to view the inkjet range
			Then I click tp view all inkjet
			Then I am navigated to view all inkjet printers
		
		Scenario: User is able to navigate to view the portable range of printers
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the printers option
			Then I am navigated to the printers page
			Then I click the portable menu option
			Then I click to view the portable range
			Then I click tp view all portable
			Then I am navigated to view all portable printers
		
		Scenario: User is able to navigate to view the workgroup range of printers
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the printers option
			Then I am navigated to the printers page
			Then I click the workgroup menu option
			Then I click to view the workgroup range
			Then I am navigated to view all workgroup printers

		Scenario: User is able to navigate to view all the range of printers
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the printers option
			Then I am navigated to the printers page
			Then I click the all printers menu option
			Then I click to view the full range
			Then I am navigated to view all printers

# Scannners navigation
Scenario: User is able to navigate to the scanners page via the top main site products menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top products menu button
	Then I hover and click the scanners option
	Then I am navigated to the scanners page
		
		Scenario: User is able to navigate to view all the range of scanners
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the scanners option
			Then I am navigated to the scanners page
			Then I click to view all scanners
			Then I am navigated to view all scanners
		
		Scenario: User is able to navigate to view portable range of scanners
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the scanners option
			Then I am navigated to the scanners page
			Then I click to view all scanners
			Then I click to take it on the road
			Then I am navigated to view all portable scanners
	
		Scenario: User is able to navigate to view office range of scanners
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the scanners option
			Then I am navigated to the scanners page
			Then I click to view all scanners
			Then I click to keep it in the office
			Then I am navigated to view all office scanners

				Scenario: User is able to navigate to view office space saver range of scanners
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top products menu button
					Then I hover and click the scanners option
					Then I am navigated to the scanners page
					Then I click to view all scanners
					Then I click to keep it in the office
					Then I click to save me space
					Then I am navigated to the office space saver scanners
			
				Scenario: User is able to navigate to view office desktop range of scanners
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top products menu button
					Then I hover and click the scanners option
					Then I am navigated to the scanners page
					Then I click to view all scanners
					Then I click to keep it in the office
					Then I click to give me power
					Then I am navigated to the office desktop scanners
					
		Scenario: User is able to navigate to the scanner software page
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the scanners option
			Then I am navigated to the scanners page
			Then I click to view software
			Then I am navigated to the scanner software page

				Scenario: User is able to navigate to the scanner software certification page
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top products menu button
					Then I hover and click the scanners option
					Then I am navigated to the scanners page
					Then I click to view software
					Then I click the certification menu option
					Then I am navigated to the scanner software certification page
				
				Scenario: User is able to navigate to the scanner videos page
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top products menu button
					Then I hover and click the scanners option
					Then I am navigated to the scanners page
					Then I click to view software
					Then I click the scanner videos menu option
					Then I click to view videos
					Then I am navigated to the scanner videos page

				Scenario: User is able to navigate to the scanner supported models page
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top products menu button
					Then I hover and click the scanners option
					Then I am navigated to the scanners page
					Then I click to view software
					Then I click the supported models menu option
					Then I click the supported models button
					Then I am navigated to the scanner supported models page
				
				Scenario: User is able to navigate to the scanner ABBYY page
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top products menu button
					Then I hover and click the scanners option
					Then I am navigated to the scanners page
					Then I click to view software
					Then I click the ABBYY menu option
					Then I click the ABBYY button
					Then I am navigated to the scanner ABBYY page

				Scenario: User is able to navigate to the scanner KOFAX page
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top products menu button
					Then I hover and click the scanners option
					Then I am navigated to the scanners page
					Then I click to view software
					Then I click the KOFAX menu option
					Then I click the KOFAX button
					Then I am navigated to the scanner KOFAX page

# Labelling navigation
Scenario: User is able to navigate to the labelling page
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top products menu button
	Then I hover and click the labelling option
	Then I am navigated to the labelling page

		Scenario: User is able to navigate to view all labelling products
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the labelling option
			Then I click to view all labelling products
			Then I am navigated to view all labelling products

		Scenario: User is able to navigate to view home labelling products
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the labelling option
			Then I click to view all labelling products
			Then I click to view the home labelling
			Then I am navigated to view the home labelling products

		Scenario: User is able to navigate to view professional labelling products
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the labelling option
			Then I click to view all labelling products
			Then I click to view the professional labelling
			Then I am navigated to view the professional labelling products
			
				Scenario: User is able to navigate to view office and industrial professional labelling products
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top products menu button
					Then I hover and click the labelling option
					Then I click to view all labelling products
					Then I click to view the professional labelling
					Then I click to view office and industrial labelling
					Then I am navigated to view office and industrial labelling products

						Scenario: User is able to navigate to view office and industrial great all rounder labelling products
							Given I have navigated to the "<site>" MainSite URL for country "<country>"
							And I hover over the top products menu button
							Then I hover and click the labelling option
							Then I click to view all labelling products
							Then I click to view the professional labelling
							Then I click to view office and industrial labelling
							Then I click to view great all rounder industrial labelling
							Then I am navigated to view great all rounder industrial labelling products
												
						Scenario: User is able to navigate to view office and industrial high volume labelling products
							Given I have navigated to the "<site>" MainSite URL for country "<country>"
							And I hover over the top products menu button
							Then I hover and click the labelling option
							Then I click to view all labelling products
							Then I click to view the professional labelling
							Then I click to view office and industrial labelling
							Then I click to view high volume industrial labelling
							Then I am navigated to view high volume labelling products
					
				Scenario: User is able to navigate to view electrical or gardening labelling products
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top products menu button
					Then I hover and click the labelling option
					Then I click to view all labelling products
					Then I click to view the professional labelling
					Then I click to view electrical or garden labelling
					Then I am navigated to view electrical or garden labelling products

						Scenario: User is able to navigate to view electricians and datacoms labelling products
							Given I have navigated to the "<site>" MainSite URL for country "<country>"
							And I hover over the top products menu button
							Then I hover and click the labelling option
							Then I click to view all labelling products
							Then I click to view the professional labelling
							Then I click to view electrical or garden labelling
							Then I click to view electricians and datacoms labelling
							Then I am navigated to view electricians and datacoms labelling products

						Scenario: User is able to navigate to view gardening and horticulture products
							Given I have navigated to the "<site>" MainSite URL for country "<country>"
							And I hover over the top products menu button
							Then I hover and click the labelling option
							Then I click to view all labelling products
							Then I click to view the professional labelling
							Then I click to view electrical or garden labelling
							Then I click to view gardening and horticultue labelling
							Then I am navigated to view gardening and horticultue labelling products

# Fax navigation
Scenario: User is able to navigate to the fax page
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top products menu button
	Then I hover and click the fax option
	Then I am navigated to the fax page

		Scenario: User is able to navigate to view all fax products
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the fax option
			Then I click to view all fax machines
			Then I am navigated to view all fax machines

		Scenario: User is able to navigate to view home office fax products
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the fax option
			Then I click to view all fax machines
			Then I click to view home office fax machines
			Then I am navigated to view home office fax machines

		Scenario: User is able to navigate to view busy office fax products
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top products menu button
			Then I hover and click the fax option
			Then I click to view all fax machines
			Then I click to view busy office fax machines
			Then I am navigated to view busy office fax machines

# Sewing navigation (Further page navigation in this area to be split into its own feature)
Scenario: User is able to navigate to the sewing machine page
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top products menu button
	Then I hover and click the sewing option
	Then I am navigated to the sewing page

# Tape creator navigation
Scenario: User is able to navigate to the tape creator page
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top products menu button
	Then I hover and click the tape creator option
	Then I am navigated to the tape creator page

# Web conferencing navigation (Further page navigation in this area to be split into its own feature)
Scenario: User is able to navigate to the web conferencing page
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top products menu button
	Then I hover and click the web conferencing option
	Then I am navigated to the web conferencing page

# Where to buy navigation (Further page navigation in this area covered in tests earlier on in this feature)
Scenario: User is able to navigate to the where to buy page
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top products menu button
	Then I hover and click the where to buy option
	Then I am navigated to the where to buy page

# Supplies navigation
Scenario: User is able to navigate to the supplies page
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top products menu button
	Then I hover and click the supplies option
	Then I am navigated to the supplies page

# Why choose brother originals navigation
Scenario: User is able to navigate to the why choose brother originals page
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top products menu button
	Then I hover and click why choose brother originals option
	Then I am navigated to the why choose brother originals page

# Latest promotions navigation
Scenario: User is able to navigate to the latest promotions page
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top products menu button
	Then I hover and click latest promotions option
	Then I am navigated to the latest promotions page
	Then I click to register and claim
	Then I am navigated to register for brother online













						 





		



				



	
