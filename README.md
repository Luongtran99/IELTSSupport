# IELTSSupport
.NET CORE -version 2.1



IELTSSupport v1, features:
- Fix wrong word
- login / register user to use some feature 
- create essay
- edit essay

Back end

Create API services include logic, algorithm, database
Use .Net Core 2.1, .Net Framework 4.5.9
Use SQL Server to store data


Front end 
Call API to get data and show
Use HTML, CSS Bootstrap and JS 

To run 
dotnet run ieltssupport.dll

But firstly you need to build and install database
- add-migration InitalDBContext -OutputDir "Data/Migrations"
- update-database -verbose

Then insert dictionary from google dictionary api
- open seeddata class and remove // before the line "if(context.Words.Any())

Be Careful, it will be run time out by google dictionary api will limited your accession.
Measure: save your word that is inserting to param google api, and search in frequency text ( about 83000 frequency words) then delete from it up to top. finally, you remove the line in seed data if(context.Words.Any()). it will continue to insert word to your database


