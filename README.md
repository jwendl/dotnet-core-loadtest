# .NET Core + Cosmos DB + Load Test

How to run - docs wip

1) Open up with Visual Studio 2017.
1) Create a cosmos db application and update appsettings.json.
1) Deploy the web application (DotNetCore) to a standard web application.
1) Run http://webapp.azurewebsites.net/api/setup to setup cosmos collections.
1) Update the link to your webapp in MainScenarioCoded.cs to point at the web app from above.
1) Open up the LoadTest project and double click on the MainScenario.webtest then click on the run button to make sure it's working.
1) Create a VSTS account and link it to your Azure subscription.
1) Go to the LoadTest and double click on the MainLaodTest.loadtest file and click on run.

