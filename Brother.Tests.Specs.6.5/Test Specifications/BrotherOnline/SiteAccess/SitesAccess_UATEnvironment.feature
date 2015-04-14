@UAT
Feature: AccessAllUATSites
	In order to validate the status of a Websites on the UAT environment
	As a sanity check
	We need to receive a 200 OK request back from a list of selected sites

# BrotherMainSite - Ireland
@SMOKE
Scenario: Get 200 OK response back from Brother Main Site Ireland on the QAS environment
	Given The following site "http://ie.brotherqas.eu/" to validate I should receive an Ok response back	

# BrotherMainSite - UK
@SMOKE
Scenario: Get 200 OK response back from Main Site United Kingdom on the QAS environment
	Given The following site "http://uk.brotherqas.eu/" to validate I should receive an Ok response back

# BrotherOnline - Ireland
@SMOKE
Scenario: Get 200 OK response back from Brother Online Ireland on the QAS environment
	Given The following site "https://online.ie.brotherqas.eu/" to validate I should receive an Ok response back

# BrotherOnline - UK
@SMOKE
Scenario: Get 200 OK response back from Brother Online United Kingdom on the QAS environment
	Given The following site "https://online.uk.brotherqas.eu/" to validate I should receive an Ok response back

# BrotherOnline - Spain
@SMOKE
Scenario: Get 200 OK response back from Brother Online Spain on the QAS environment
	Given The following site "https://online.es.brotherqas.eu/" to validate I should receive an Ok response back

# BrotherOnline - Poland
@SMOKE
Scenario: Get 200 OK response back from Brother Online Poland on the QAS environment
	Given The following site "https://online.pl.brotherqas.eu/" to validate I should receive an Ok response back

# OmniJoin - UK
@SMOKE
Scenario: Get 200 OK response back from Web Conferencing United Kingdom on the QAS environment
	Given The following site "http://webconferencing.uk.brotherqas.eu/" to validate I should receive an Ok response back

# CreativeCentre - UK
@SMOKE
Scenario: Get 200 OK response back from Creative Centre United Kingdom on the QAS environment
	Given The following site "http://creativecenter.eu.brotherqas.eu/" to validate I should receive an Ok response back
