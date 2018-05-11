#Scripts for running tests#

- The Powershell module run-tests.psm1 is used to run all automation tests - please reference the comments in the module for usage.
- The script Sample-RunTests.ps1 gives an example of calling the module.
- All scripts matching the naming pattern RunTests*.ps1 are copied to the /scripts folder of the build artifacts, creating a self-contained runner package (although there is still a dependency on Nunit)
- If new scripts are required to run different combinations of categories and command line params, they should be added to this folder