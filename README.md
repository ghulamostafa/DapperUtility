# DapperUtility
Built on Dapper library for Entity Framework with some helper classes to utilize at its max.
The Dapper (https://www.nuget.org/packages/Dapper/) (https://github.com/StackExchange/Dapper) is a library which is a simple object mapper for .Net.
This DapperUtility uses the power of Dapper and creates less messy ways for creating new repositories for fetching data from SQL Server.
It even uses a common method to fetch response object from SQL Server that includes to output parameters in a Try Catch SQL Query, **result** an integer and **message** a nvarchar

The way to write an SQL Stored Procedure that is totally compatible with this library is as follows:

```
CREATE PROCEDURE <Procedure Name>
	@Action varchar(50)
	,@result int = 0 output
	,@message nvarchar(150) = NULL output
				
AS
BEGIN

SET NOCOUNT ON;

BEGIN TRY
	--Keep your queries above this line
	SELECT	@result = 1, @message = 'Success' --The success and result can depend as per your logic
END TRY

BEGIN CATCH
	SELECT	@result = 0, @message = ERROR_MESSAGE()
END CATCH
	
END
GO
```

If anyhow the execution makes problem it would result 0 and pop the error message.

After the execution the result sets must be allocated to the given List<> properties in the inherited classes from MainResponsObject. A sample assignment is as follows

```
private static MainResponseObject GetAppInfo(SqlMapper.GridReader objDetails)
{
	var obj = new GetAppInfoResponse(); //This class is inherited from **MainResponseObject**
	try
	{
		obj.AppInfo = objDetails.Read<AppInfo>().ToList(); //AppInfo is a List<> property in GetAppInfoResponse
	}
	catch (Exception) //If any exception in reading happens due to exception in SQL Server then the List<> properties should be kept empty lists
	{
		obj.AppInfo = new List<AppInfo>();                
	}
	return obj; //Returning to MainResponseObject
}
```

Any problem or confusion would be solved with a smile. :) Happy Coding!
