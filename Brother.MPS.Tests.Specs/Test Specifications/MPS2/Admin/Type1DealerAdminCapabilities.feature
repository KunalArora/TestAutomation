@MPS @UAT @TEST @TYPE1 @LOW @ADMIN
Feature: Type1DealerAdminCapabilities
	Please check the attachment fror Operation that dealer can do on Admin Screen and automate those functionalities
	https://brother-bie.atlassian.net/browse/MPS-5269

Scenario Outline: Type1DealerAdminCapabilities
Given Country is "<Country>"
#Stage: 2 Manage Default Dealer Margins
Given I select Admin menu and click on Default Margins
Then I will be taken into the Default Margins tab
When I overtype default margins HardwareDefaultMargin of "<HardwareDefaultMargin>", AccessoriesDefaultMargin of "<AccessoriesDefaultMargin>", DeliveryDefaultMargin of "<DeliveryDefaultMargin>", InstallationDefaultMargin of "<InstallationDefaultMargin>", ServicePackDefaultMargin of "<ServicePackDefaultMargin>", MonoClickDefaultCommission of "<MonoClickDefaultCommission>", and ColourClickDefaultCommission of "<ColourClickDefaultCommission>"  with required % and click Save
Then I verify default margins will be amended
		| Model        | Price   | LowerTrayPrice | InstallationPack     | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour |
		| DCP-L8450CDW | 1000.00 | 1000.00        | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 20             | 250          |

#Stage: 3 Amend Dealership Profile
Given I select Admin menu and click on Delearship Profile
Then I will be taken into the Dealership Profile tab
When I amend Profile description and use the browse function to add a Jpeg as a logo, Click Save
Then I can verify that dealership profile was updated successfully

@BUK
Scenarios: 
		| Country        | HardwareDefaultMargin | AccessoriesDefaultMargin | DeliveryDefaultMargin | InstallationDefaultMargin | ServicePackDefaultMargin | MonoClickDefaultCommission | ColourClickDefaultCommission |
		| United Kingdom | 11.01                 | 22.02                    | 33.03                 | 44.04                     | 55.05                    | 66.06                      | 77.07                        |
#default value
#		| United Kingdom | 15.00                 | 15.00                    | 19.00                 | 19.00                     | 19.00                    | 19.00                      | 19.00                        |
