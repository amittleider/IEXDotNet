## IEXDotNet
To run the tests, please modify the `appsettings.json` file in the `IEXDotNet.UnitTests` assembly. Make sure to use the test token from IEX and not the production token.

If you want to use this lib with Python, install QuantConnect's version of pythonnet.
	pip install git+https://github.com/QuantConnect/pythonnet.git
	
If you just need IEX on Python and not in C#, this lib is more developed: 
	https://github.com/addisonlynch/iexfinance

## Builds
[![Build Status](https://dev.azure.com/amittleider/IEXDotNet/_apis/build/status/amittleider.IEXDotNet?branchName=master)](https://dev.azure.com/amittleider/IEXDotNet/_build/latest?definitionId=2&branchName=master)

## Nuget package
https://www.nuget.org/packages/IEXDotNet/
