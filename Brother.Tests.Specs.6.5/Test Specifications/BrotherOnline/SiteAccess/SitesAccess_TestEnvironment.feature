@TEST
Feature: AccessALLTestSites
	In order to validate the status of a Websites on the Test environment
	As a sanity check
	We need to receive a 200 OK request back from a list of selected sites

# BrotherMainSite - Ireland
@SMOKE
Scenario: Get 200 OK response back from Brother Main Site Ireland on the Test environment
	Given The following site "http://ie.brotherdv2.eu/" to validate I should receive an Ok response back	

# BrotherMainSite - UK
@SMOKE
Scenario: Get 200 OK response back from Main Site United Kingdom on the Test environment
	Given The following site "http://uk.brotherdv2.eu/" to validate I should receive an Ok response back

# BrotherOnline - Ireland
@SMOKE
Scenario: Get 200 OK response back from Brother Online Ireland on the Test environment
	Given The following site "https://online.ie.brotherdv2.eu/" to validate I should receive an Ok response back

# BrotherOnline - UK
@SMOKE
Scenario: Get 200 OK response back from Brother Online United Kingdom on the Test environment
	Given The following site "https://online.uk.brotherdv2.eu/" to validate I should receive an Ok response back

# BrotherOnline - Spain
@SMOKE
Scenario: Get 200 OK response back from Brother Online Spain on the Test environment
	Given The following site "https://online.es.brotherdv2.eu/" to validate I should receive an Ok response back

# BrotherOnline - Poland
@SMOKE
Scenario: Get 200 OK response back from Brother Online Poland on the Test environment
	mentGiven The following site "https://online.pl.brotherdv2.eu/" to validate I should receive an Ok response back

# OmniJoin - UK
@SMOKE
Scenario: Get 200 OK response back from Web Conferencing United Kingdom on the Test environment
	Given The following site "http://webconferencing.uk.brotherdv2.eu/" to validate I should receive an Ok response back

# CreativeCentre - UK
@SMOKE
Scenario: Get 200 OK response back from Creative Centre United Kingdom on the Test environment
	Given The following site "http://creativecenter.eu.brotherdv2.eu/" to validate I should receive an Ok response back
