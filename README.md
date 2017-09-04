# DapperUtility
Built on Dapper library for Entity Framework with some helper classes to utilize at its max.
The Dapper (https://www.nuget.org/packages/Dapper/) (https://github.com/StackExchange/Dapper) is a library which is a simple object mapper for .Net.
This DapperUtility uses the power of Dapper and creates less messy ways for creating new repositories for fetching data from SQL Server.
It even uses a common method to fetch response object from SQL Server that includes to output parameters in a Try Catch SQL Query, **result** an integer and **message** a nvarchar
