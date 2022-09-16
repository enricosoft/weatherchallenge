**Author:** Enrico Piccini

**Repo:** https://github.com/enricosoft/weatherchallenge

-------------------------------------

### [STEP1]

**Requirements:**
- An IDE like Visual Studio 2022
- .NET 6 sdk
- personal "WeatherApi.com" Api key

**How to run the project:**
- Open "WeatherChallengeCli.sln" file using Visual Studio 2022
- Inside "Config.json" file of the two projects, set your own "weatherapi.com" api key
- Build the solution (it will restore NuGet packages)
- Click on visual studio's start button

-------------------------------------

### [STEP2]

*TODO*

-------------------------------------

### [OPTIONAL: docker development environment]

**Requirements:**
- Docker installed on your local machine
- Visual Studio Code

**How to open and run the project in a container:**
- Open Docker app on your local machine
- Open the project root folder using VS Code
- At this point VS Code should open a pop-up that asks you to "Reopen in Container". 
  Click that button and VS Code will create the dev env for you.
- Open a terminal in VS Code and run the following commands:  
  > cd WeatherChallengeCli  
  > dotnet restore  
  > dotnet run  
