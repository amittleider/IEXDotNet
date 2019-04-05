You must write a `.env` with 2 variables in it. One which specifies to use the sandbox environment (which you are not charged for) and the corresponding token. The below is an example of the `.env` file. 
```
SANDBOX=True
TOKEN=Tsk_232342TestTokenFromIEX
```

Put this .env file in your root project directory and make sure that you have it set to "Copy If Newer" in the `csproj`, like this:

```
  <ItemGroup>
    <None Update=".env">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>
```

If you want to use this lib with Python, install QuantConnect's version of pythonnet.
	pip install git+https://github.com/QuantConnect/pythonnet.git
	
If you just need IEX on Python and not in C#, this lib is more developed: 
	https://github.com/addisonlynch/iexfinance
