@ignore
Feature: AccessAllSites
	In order to validate the status of a Websites on the Test environment
	As a sanity check
	We need to receive a 200 OK request back from a list of selected sites

## Credit Card Test Page - Digital River

Scenario: Get 200 OK response back from Credit Card test Site at Digital River
	Given The following site test site "https://testpage.payments.digitalriver.com/pay/?creq=BEii9whIovYlcGLxmfpW6BbtbwV8_Xdk8eulgVCMGaCTa5tOw9muh0vlW3Ssy5q-yR3VkBJrejq5rzxpEV_Q2Dk4Y828PQ4ry3SHMArP--5Yx_mmfVFGW54xZ_ZPXDFrpicvXPqlwSometDrmeMIHKakP096tQsIZkNqnwRbxCfIcoPNHd-fM8k9h38WIwtupxClzqdvbYGVeMt026yRAvJon6hYH9kDw3A-weaTf_5qytndiGB5q1XKiNFM_x7FvBOtUCbYR_ic-aGJlKU4rDTbDJ4fOzKz1qmkJ2LMw3H1nrei1FI5aRPbZoN2UtsFHyuPQ9r7UCuHzj4o2_GTHc0IiGyJA1lQZbSRUKtejiCiEMI2DErwxuKCc15uz7Qiu-fvZw0XJZ0WAgCcSNL129yFT8TJpCSwsrOrgHowWvOkrYYC8ek77OkyxvVJ-9b1dfKfMJ-PTlG__kw7S-zZgGRHa3ZGyLkjU-cs-Uj7lTN-Ix4oR7FmHRFcdiIbRHeDHoS7SVsAZZRSgX2OYWj_RwN-WrGYJgyeaacNo4wb8s4EhCb56Nnq6Ycm0RZej6oWFCqvFJyD77HENyOPB4t9Sp7Bd1dvjj21bXhACZmrh930hkopctYK-b9h8FgGjlrWcU_QLIdqkBn0" to validate I should receive an Ok response back	

## Email Token Test Pages
@TEST @ignore
Scenario: Get 200 OK response back from Email Token TEST Site United Kingdom on the Test environment
	Given The following site test site "http://online.uk.brotherdv2.eu/Test/EmailConfirmationToken.aspx" to validate I should receive an Ok response back	
@UAT @ignore
Scenario: Get 200 OK response back from Email Token UAT Site United Kingdom on the QAS environment
	Given The following site test site "http://cms.brotherqas.eu/Test/EmailConfirmationToken.aspx" to validate I should receive an Ok response back	

@PROD @ignore
Scenario: Get 200 OK response back from Email Token Production Site United Kingdom on the Live environment
	Given The following site test site "http://cms.brother.eu/Test/EmailConfirmationToken.aspx" to validate I should receive an Ok response back	

	