function ExecuteMpsWebTool(){

    param(
        [string]$WebToolPath = $(throw "WebToolPath must be specified"),
        [string]$Querystring,
        [string]$Env = "UAT"
    )

    $urls = @{
        'DEV' = 'http://online.brother.co.uk.local'; 
        'UAT' = 'http://online65.co.uk.cms.uat.brother.eu.com'
        }

    $authValues = @{
        'DEV' = 'OX6Z{mO~nQ87rE!32j6Sjo!21@+`by'; 
        'UAT' = '.Kol%CV#<X$6o4C4/0WKxK36yYaH10'
        }

    $baseWebToolPath = '/sitecore/admin/integration/mps2'
    
    $baseUrl = $urls[$Env]
    $headers = @{"X-BROTHER-Auth" = $authValues[$Env]}
    $uri = "$baseUrl$baseWebToolPath/$WebToolPath`?$Querystring"

    $R = Invoke-WebRequest -Uri $uri -Headers $headers
    return $R
        
}