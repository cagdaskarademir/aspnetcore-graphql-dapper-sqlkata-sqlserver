# tutorial-aspnetcore-graphql-sqlserver  
Tutorial Asp.Net Core 3.0 + GraphQLApi + Sql Server  
  
This tutorial sample was created by .net core, dapper and sqlkata.  
  
If you new on graphql for .net, you could use that sample.   
  
This example is very simple. You could connect database, search entity or entities and show the result data.  
  
You must run below commands. ...  
  
- Create New Database   
- Run database scripts in database folder (create-table, bulk-data)  
- Change connection string in AppSettings file  
- dotnet restore  
- dotnet build  
- dotnet run  
  
Open the browser and enter the address : https://localhost:5001/ui/playground   
  
Sample :   
query {  
  company(companyId:5) {  
    id  
    name  
    isActive  
  }  
}  
  
  
![enter image description here](https://raw.githubusercontent.com/cagdaskarademir/tutorial-aspnetcore-graphql-sqlserver/master/content/graphql-1.png)  
  
![enter image description here](https://raw.githubusercontent.com/cagdaskarademir/tutorial-aspnetcore-graphql-sqlserver/master/content/graphql-2.png)  
  
![enter image description here](https://raw.githubusercontent.com/cagdaskarademir/tutorial-aspnetcore-graphql-sqlserver/master/content/graphql-3.png)