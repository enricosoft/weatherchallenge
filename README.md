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

1) Api to set the weather forecast for a specific city and dates. The data are saved into Musement Db.  
   The request payload and the response are in JSON format.  

*POST /api/v3/cities/{id}/weatherforecast*

**Request Payload:**
```
{
	"forecasts": [
		{
			"date": "2022-09-17",
			"forecast": "Rainy"
		},
		{
			"date": "2022-09-18",
			"forecast": "Sunny"
		}
	]
}
```

**Response types:**

CASE SUCCESS:
```
{
	"success": true,
	"error_message": ""
}
```

CASE FAIL:
```
{
	"success": false,
	"error_message": "this is the description of the error"
}
```
  
  
2) Api to get the weather forecast for a specific city within a range of dates.   
   The request payload and the response are in JSON format.  
   N.B.: the data are retrieved from Musement db, not from weatherapi.com api.  

*GET /api/v3/cities/{id}/weatherforecast*

**Request Payload:**
```
{
	"from_date": "2022-09-17",
	"to_date": "2022-09-18"
}
```

**Response types:**

CASE SUCCESS:
```
{
	"success": true,
	"error_message": "",
	"data": {
		"city_id": "14",
		"city_name": "Milan",
		"forecasts": [
			{
				"date": "2022-09-17",
				"forecast": "Rainy"
			},
			{
				"date": "2022-09-18",
				"forecast": "Sunny"
			}
		]
	}
}
```

CASE FAIL:
```
{
	"success": false,
	"error_message": "this is the description of the error",
	"data": null
}
```

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
- Set your own "weatherapi.com" api key in the two "Config.json" files 
- Open a terminal in VS Code and run the following commands:  
  > cd WeatherChallengeCli  
  > dotnet restore  
  > dotnet run  
