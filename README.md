# Tender Tummies API

This is an API for the Tender Tummies FPIES database. This API will allow user to GET/POST/PUT/DELETE items from the Tender Tummies Database. This API is seeded with a dummy child's information, the actual database is not uploaded at the moment.

It uses .NET Core and SQLite.

## Table of Contents


  * [Installing Core Technologies](#installing-core-technologies)
    * [SQLite](#sqlite)
    	* [For OSX Users](#for-osx-users)
        * [For Windows Users](#for-windows-users)
    * [SQL Browser](#sql-browser)
    * [Visual Studio Code](#visual-studio-code)
    * [Install .NET Core](#install-net-core)
        * [Windows](#windows)
        * [OSX](#osx)
 * [Installing Tender Tummies API](#installing-tender-tummies-api)
 * [Using Tender Tummies API](#using-tender-tummies-api)
    * [Child Resource](#child-resource)
        * [GET](#get)
            * [Get All User's Children](#get-all-users-children)
            * [Get Single Child](#get-single-child)
        * [POST](#post)
        * [PUT](#put)
        * [DELETE](#delete)
    * [Food Resource](#food-resource)
        * [GET](#get-1)
            * [Get All Food](#get-all-food)
            * [Get Single Food](#get-single-food)
        * [POST](#post-1) 
    * [Ingestion Resource](#ingestion-resource)
        * [GET](#get-2)
            * [Get All Ingestions](#get-all-ingestions)
            * [Get Single Ingestion](#get-single-ingestion)
    * [Safe Resource](#safe-resource)
        * [GET](#get-3)
            * [Get All of one Child's Safes](#get-all-of-one-childs-safes)
            * [Get Single Safe](#get-single-safe)
        * [POST](#post-2)
        * [DELETE](#delete-1) 
    * [Symptom Resource](#symptom-resource)
        * [GET](#get-4)
            * [Get All Symptoms](#get-all-symptoms)
            * [Get Single Symptom](#get-single-symptom)
        * [POST](#post-3)
    * [Trigger Resource](#trigger-resource)
        * [GET](#get-5)
            * [Get All Child's Triggers](#get-all-childs-triggers)
            * [Get Single Trigger](#get-single-trigger)
        * [POST](#post-4)
            * [POST new Trigger](#post-new-trigger)
            * [POST new Symptom to an existing Trigger](#post-new-symptom-to-an-existing-trigger)
        * [DELETE](#delete-2)
            * [DELETE entire Trigger and all associated Symptoms](#delete-entire-trigger-and-all-associated-symptoms)
            * [DELETE a Single Symptom from a Trigger](#delete-a-single-symptom-from-a-trigger)
    * [Reaction Resource](#reaction-resource)
        * [GET](#get-6)
            * [Get All Child's Reactions](#get-all-childs-reactions)
            * [Get Single Reaction](#get-single-reaction)
        * [POST](#post-5)
            * [POST new Reaction](#post-new-reaction)
            * [POST new Trigger to Existing Reaction](#post-new-trigger-to-existing-reaction)
        * [PUT](#put-1)
        * [DELETE](#delete-3)
    * [Reaction Event Resource](#reaction-event-resource)
        * [GET](#get-7)
            * [GET All Reaction's Events](#get-all-reactions-events)
            * [GET Single Reaction Event](#get-single-reaction-event)
        * [POST](#post-6)
            * [POST new Reaction Event](#post-new-reaction-event)
            * [POST new Symptom to Existing Reaction Event](#post-new-symptom-to-existing-reaction-event)
        * [PUT](#put-2)
        * [DELETE](#delete-4)
            * [DELETE Reaction Event and Associated Symptoms](#delete-reaction-event-and-associated-symptoms)
            * [DELETE One Symptom from a Reaction Event](#delete-one-symptom-from-a-reaction-event)
    * [Trial Resource](#trial-resource)
        * [GET](#get-8)
            * [Get All Child's Trials](#get-all-childs-trials)
            * [Get Single Trial](#get-single-trait)
        * [POST](#post-7)
        * [PUT](#put-3)
        * [DELETE](#delete-5)
    * [Trial Event Resource](#trial-event-resource)
        * [GET](#get-9)
            * [GET All Trial's Events](#get-all-trials-events)
            * [GET Single Trial Event](#get-single-trial-event)
        * [POST](#post-8)
        * [PUT](#put-4)
        * [DELETE](#delete-6)


# Installing Core Technologies

## SQLite

### For OSX Users

```
brew install sqlite
```

### For Windows Users

Visit the [SQLite downloads](https://www.sqlite.org/download.html) and download the 64-bit DLL (x64) for SQLite version, unzip and install it.

## SQL Browser

The [DB browser for SQLite](http://sqlitebrowser.org/) will let you view, query and manage your databases during the course.

## Visual Studio Code

[Visual Studio Code](https://code.visualstudio.com/download) is Microsoft's cross-platform editor for writing C# and building .NET applications. Make sure you add the [C# extension](https://code.visualstudio.com/Docs/languages/csharp) immediately after installation completes.

## Install .NET Core

### Windows

https://www.microsoft.com/net/core#windows

  1. Click the link to download the .NET Core SDK for Windows (https://go.microsoft.com/fwlink/?LinkID=827524)
  2. Once installed open a command line app to intialize some code.
  3. Make a directory for your app: mkdir HelloWorld
  4. Move to the newly created directory. : cd HelloWorld
  5. Create a new app: dotnet new
  6. Build the app and restore any get any missing libraries (packages) : dotnet restore
  7. Run the app: dotnet run
  8. You should see the test "Hello World".
  9. Navigate to the folder where the app was created and https://docs.asp.net/en/latest/getting-started.html

### OSX

https://www.microsoft.com/net/core#macos

Create and run an ASP.NET application using .NET Core

https://docs.asp.net/en/latest/getting-started.html

# Installing Tender Tummies API

There are a few things you need to make sure are in place before the database can be up and running.
 1. Fork and clone the repo on to you local machine. 
 2. Run `dotnet restore`
 3. Run `dotnet ef database update` 
 4. Run `dotnet run` 
 > This will compile and run everything as well as initalizing the database with some data to get started

# Using Tender Tummies API
All calls to the API will be made from `http://localhost:5000` as the domain.



## Child Resource

Verbs supported: GET/POST/PUT/DELETE

### GET 

#### Get All User's Children
You can access a list of all of the children of a particular user by running a GET call to `http://localhost:5000/Child/{userName}`. 
> Example: The database is seeded with a dummy user who has two children. To get all of that user's children make the call to `http://localhost:5000/Child/User1`

#### Get Single Child
You can get the information on a single child by running a GET call to ```http://localhost:5000/Child/id/{childID}```. This method will return the child with their safe and trigger foods nested inside the object.
> Example: GET `http://localhost:5000/Child/id/1`

### POST 
You can POST a new child by running a Post call to `http://localhost:5000/Child` using data from the following table.
* Sample JSON: { "UserID": "User2", "FirstName":"Hattie", "LastName": "Bee", "WtNumber": 25, "WtUnit":"lbs", "Gender": "Girl", "Age": 2} 
>The UserID is intended to be generated by the client, so for the sake of this example we're using a dummy one.

     
   | Property  | Required | DataType | Example |
   |-----------|----------|----------|---------|
   | UserID    | Y        | String   | User2   |
   | FirstName | Y        | String   | Hattie  |
   | LastName  | Y        | String   | Bee     |
   | WtNumber  | Y        | Int      | 25      |
   | WtUnit    | Y        | Int      | lbs     |
   | Gender    |          | String   | Girl    |
   | Age       | Y        | Int      | 2       |
      
   

### PUT 
You can update the information on a specific child by running a Put call to `http://localhost:5000/Child/id/{id}`. 
> You must PUT the entire changed object, using the appropriate fields detailed above.
      
* Sample JSON: { "UserID": "User2", "FirstName":"Hattie", "LastName": "Bee", "WtNumber": 25, "WtUnit":"lbs", "Gender": "Girl", "Age": 2}

### DELETE 

You can delete the profile for a specific child by running a DELETE call to `http://localhost:5000/Child/id/{id}`. 



## Food Resource

Verbs supported: GET/POST

### GET 

#### Get All Food
You can access a list of all of the food types in the database by running a Get call to `http://localhost:5000/Food`. 

#### Get Single Food
You can get the information on a single food by running a GET call to ```http://localhost:5000/Food/id/{foodID}```. 
> Example: GET ```http://localhost:5000/Food/id/11``` will return Pork.


### POST 
You can post a new food by running a POST call to `http://localhost:5000/Food` using data from the following table. Any posts will be validated against the API to prevent duplicate foods being stored in the database.

The foods in this database are intended to be food types for allergy tracking and maintenance. An acceptable food would be "Wheat", whereas "Birthday Cake" would not be acceptable.

* Sample JSON: { "Name": "Cilantro" } 

     
   | Property  | Required | DataType | Example |
   |-----------|----------|----------|---------|
   | Name      | Y        | String   | Cilantro|
   




## Ingestion Resource

Verbs supported: GET. 

This resource details how a child ingested the trigger food that caused a reaction. It is unlikely that a user will need to add any other types of ingestions than what is provided, but should I be wrong please get in touch using my GitHub contact information.

### GET 

#### Get All Ingestions
You can access a list of all of the ingestion types in the database by running a GET call to `http://localhost:5000/Ingestion`. 

#### Get Single Ingestion
You can get the information on a single ingestion by running a GET call to ```http://localhost:5000/Ingestion/id/{ingestionID}```. 
> Example: GET ```http://localhost:5000/Ingestion/id/3``` will return Breastmilk.



## Safe Resource

Verbs supported: GET/POST/DELETE

### GET 

#### Get All of one Child's Safes
You can access a list of all of the safes associated with a certain child by running `http://localhost:5000/Child/{childID}`. 
> Example: The database is seeded with a dummy user who has two children. To get all of that user's children make the call to `http://localhost:5000/Safe/1`

#### Get Single Safe
You can get the information on a single safe by running a GET call to ```http://localhost:5000/Safe/id/{safeID}```. This method will return the safe food
> Example: GET `http://localhost:5000/Safe/id/1`

### POST 
You can POST a new child by running a Post call to `http://localhost:5000/Child` using data from the following table.
* Sample JSON: { "ChildID": 2, "FoodID":14 } 
>The UserID is intended to be generated by the client, so for the sake of this example we're using a dummy one.

     
| Property   | Required | DataType | Example      |
|------------|----------|----------|--------------|
| ChildID    | Y        | Int      | 1            |
| FoodID     | Y        | Int      | 1            |
      

### DELETE 

You can delete a safe by running a DELETE call to `http://localhost:5000/Safe/id/{id}`. 



## Symptom Resource

Verbs supported: GET/POST

### GET 

#### Get All Symptoms
You can access a list of all symptoms by running `http://localhost:5000/Symptom`. 
> Example: The database is seeded with a list of symptoms. To get all of that user's children make the call to `http://localhost:5000/Symptom

#### Get Single Symptom
You can get the information on a single symptom by running a GET call to ```http://localhost:5000/Symptom/id/{SymptomID}```

> Example: GET `http://localhost:5000/Symptom/id/1`

### POST 
You can POST a new symptom by running a Post call to `http://localhost:5000/Symptom` using data from the following table.
* Sample JSON: { "Name": "Vomit" } 
>The API will validate to be sure there are no duplicate symptoms

     
| Property   | Required | DataType | Example      |
|------------|----------|----------|--------------|
| Name       | Y        | String   | Vomit        |



## Trigger Resource

Verbs supported: GET/POST/PUT/DELETE

Posts triggers associated with a specific child

### GET 

#### Get All Child's Triggers
Access a list of all of a particular child's triggers by running a GET call to `http://localhost:5000/Trigger/{childID}`.
> Example: To get all of Sherman's triggers make the call to `http://localhost:5000/Trigger/1`

#### Get Single Trigger
Get the information on a single trigger by running a GET call to ```http://localhost:5000/Trigger/id/{TriggerID}```.
> Example: GET `http://localhost:5000/Trigger/id/1`

### POST

#### Post new Trigger
POST a new trigger the child's associated symptoms by running a POST call to `http://localhost:5000/Trigger` using data from the following table.
* Sample JSON: { "ChildID": 1, "FoodID": 1, "Severity": "Medium", "TriggerSymptomSubmissions": [{ "SymptomID":1, "Acute":"True", "Chronic":"False" }, { "SymptomID":2, "Acute":"False", "Chronic":"True" }] } 
> Take Note: Trigger Symptom Submission is a type of object that has the following format: 
> 
> { "SymptomID":2, "Acute":"True", "Chronic":"False" }
> 
> The TriggerSymptomSubmissions property in the Trigger POST accepts an array of Trigger Symptom Submission objects.

* Below are the properties on the Trigger POST object.

     
| Property                  | Required | DataType                    | Example         |
|---------------------------|----------|-----------------------------|-----------------|
| ChildID                   | Y        | Int                         | 1               |
| FoodID                    | Y        | Int                         | 1               |
| Severity                  | Y        | String                      | Medium          |
| TriggerSymptomSubmissions | Y        | TriggerSymptomSubmissions[] | See table below |

* Below are the properties in the Trigger Symptom Submission object.

| Property  | Required | DataType | Example |
|-----------|----------|----------|---------|
| SymptomID | Y        | Int      | 1       |
| Acute     | Y        | Bool     | True    |
| Chronic   | Y        | Bool     | True    |


#### POST new Symptom to an existing Trigger
Add a symptom to an existing trigger by running a POST call to `http://localhost:5000/Trigger/Symptom` with the body of the request in the following format.
* Sample JSON: { "TriggerID": 83, "SymptomID": 4, "Acute":"False", "Chronic":"True" }

| Property  | Required | DataType | Example |
|-----------|----------|----------|---------|
| TriggerID | Y        | Int      | 5       |
| SymptomID | Y        | Int      | 1       |
| Acute     | Y        | Bool     | True    |
| Chronic   | Y        | Bool     | True    |


### DELETE  

#### DELETE entire Trigger and all associated Symptoms

You can delete a trigger and all its symptoms by running a DELETE call to `http://localhost:5000/Trigger/id/{TriggerID}`.

#### DELETE a single Symptom from a Trigger

You can delete and individual symptom off of a trigger by running a DELETE call to `http://localhost:5000/Trigger/Symptom/{SymptomID}`.


## Reaction Resource

Verbs supported: GET/POST/PUT/DELETE

### GET 

#### Get All Child's Reactions
Access a list of all of the reactions of a particular child by running a GET call to `http://localhost:5000/Reaction/{childID}`. This will return all of the reactions with the trigger food(s) that caused the reaction nested inside.
> Example: To get all of Sherman's reaction information make the call to `http://localhost:5000/Reaction/1`

#### Get Single Reaction
Get the information on a single reaction by running a GET call to ```http://localhost:5000/Reaction/id/{reactionID}```. This method will return an individual reaction with the trigger food(s) that caused the reaction nested inside.
> Example: GET `http://localhost:5000/Reaction/id/1`



### POST

#### POST new Reaction
POST a new reaction and the trigger(s) that caused it by running a POST call to `http://localhost:5000/Reaction` using data from the following table.
* Sample JSON: { "ChildID": 1, "IngestionID": 1, "FoodType": "Chocolate Cake", "StartDate": "2017-1-16", "Description":"Sherman ate a bite of cake at a party", "TriggerIDs": [20,28,1,29] } 
> Take Note: The trigger IDs are NOT the food IDs; the trigger IDs should be the IDs of child's triggers. The API validates whether or not the triggerID belongs to the specified child.

     
| Property    | Required | DataType  | Example                              |
|-------------|----------|-----------|--------------------------------------|
| ChildID     | Y        | Int       | 1                                    |
| IngestionID | Y        | Int       | 1                                    |
| FoodType    | Y        | String    | Chocolate Cake                       |
| StartDate   | Y        | DateTime  | 2017-1-16                            |
| EndDate     | N        | DateTime  | 2017-1-21                            |
| Description | Y        | Int       | Sherman ate a bit of cake at a party |
| TriggerIDs  | Y        | Int[]     | [20, 28, 1, 29]                      |


#### POST new Trigger to Existing Reaction
Add a trigger to an existing reaction by running a POST call to `http://localhost:5000/Reaction/Trigger` with the body of the request in the following format.
* Sample JSON: { "ReactionID": 3, "TriggerID": 4 }

| Property    | Required | DataType  | Example                              |
|-------------|----------|-----------|--------------------------------------|
| ReactionID  | Y        | Int       | 1                                    |
| TriggerID   | Y        | Int       | 1                                    |
> Take Note: The trigger IDs are NOT the food IDs; the trigger IDs should be the IDs of child's triggers. The API validates whether or not the triggerID belongs to the specified child.

### PUT 
You can update the information on a specific child by running a Put call to `http://localhost:5000/Reaction/id/{ReactionID}`.
> You must PUT the entire changed object, using the appropriate fields detailed below. 

> Note that the PUT does not accept an array of trigger IDs.

| Property    | Required | DataType  | Example                              |
|-------------|----------|-----------|--------------------------------------|
| ChildID     | Y        | Int       | 1                                    |
| IngestionID | Y        | Int       | 1                                    |
| FoodType    | Y        | String    | Chocolate Cake                       |
| StartDate   | Y        | DateTime  | 2017-1-16                            |
| EndDate     | N        | DateTime  | 2017-1-21                            |
| Description | Y        | Int       | Sherman ate a bit of cake at a party |
      
* Sample JSON: { "ChildID": 1, "IngestionID": 1, "FoodType": "Chocolate Cake", "StartDate": "2017-1-16", "EndDate": "2017-1-21", "Description":"Sherman ate a whole bunch of cake at a party" }

### DELETE 

You can delete a reaction by running a DELETE call to `http://localhost:5000/Reaction/id/{reactionID}`. 


## Reaction Event Resource

Verbs supported: GET/POST/PUT/DELETE

These are the individual events in an ongoing reaction. For example, a child might be having a soy reaction where he throws up at 7pm. The information of the specific symptom (throwing up at 7pm on a certain date) is recorded as a reaction event.

### GET 

#### GET All Reaction's Events
Access a list of all of the events of a particular reaction by running a GET call to `http://localhost:5000/ReactionEvent/{reactionID}`. This will return all of the reaction events associated with a specific reaction.
> Example: `http://localhost:5000/ReactionEvent/1`

#### GET Single Reaction Event
Get the information on a single reaction event by running a GET call to ```http://localhost:5000/ReactionEvent/id/{reactionEventID}```. This method will return an individual reaction event with the associated symptoms nested inside.
> Example: GET `http://localhost:5000/ReactionEvent/id/1`

### POST 

#### POST new Reaction Event

POST a new reaction event and the symptoms displayed during that event by running a POST call to `http://localhost:5000/ReactionEvent` using data from the following table.
* Sample JSON: { "ReactionID": 1, "Acute": "True", "Chronic":"False", "DateTime": "2017-1-21 21:04:00", "Description":"Sherman threw up after eating chocolate cake", "SymptomIDs": [1, 2, 3] } 

     
| Property    | Required | DataType | Example                                      |
|-------------|----------|----------|----------------------------------------------|
| ReactionID  | Y        | Int      | 1                                            |
| TrialID     | N        | Int      | 1                                            |
| Acute       | Y        | Bool     | False                                        |
| Chronic     | Y        | Bool     | True                                         |
| DateTime    | Y        | DateTime | 2017-1-21 21:04:00                           |
| Description | N        | String   | Sherman threw up after eating chocolate cake |
| SymptomIDs  | Y        | Int[]    | [ 1, 2, 3 ]                                  |



#### POST new Symptom to Existing Reaction Event
Add a new symptom to an existing reaction event by running a POST call to `http://localhost:5000/ReactionEvent/Symptom/` with the body of the request being the SymptomID.
* Sample JSON: { "ReactionEventID": 1, "SymptomID": 1 }

| Property        | Required | DataType  | Example                              |
|-----------------|----------|-----------|--------------------------------------|
| ReactionEventID | Y        | Int       | 1                                    |
| SymptomID       | Y        | Int       | 1                                    |


### PUT 
You can update the information on a specific reaction event by running a PUT call to `http://localhost:5000/ReactionEvent/id/{ReactionEventID}`.
> You must PUT the entire changed object, using the appropriate fields detailed below. 

> Note that the PUT does not accept an array of symptom IDs.

| Property    | Required | DataType | Example                                      |
|-------------|----------|----------|----------------------------------------------|
| ReactionID  | Y        | Int      | 1                                            |
| TrialID     | N        | Int      | 1                                            |
| Acute       | Y        | Bool     | False                                        |
| Chronic     | Y        | Bool     | True                                         |
| DateTime    | Y        | DateTime | 2017-1-21 21:04:00                           |
| Description | N        | String   | Sherman threw up after eating chocolate cake |
      
* Sample JSON: { "ReactionID": 1, "Acute": "True", "Chronic":"True", "DateTime": "2017-1-21 21:04:00", "Description":"Sherman threw up after eating chocolate cake" }

### DELETE

#### DELETE Reaction Event and Associated Symptoms

Delete a reaction event and all associated symptoms by running a DELETE call to `http://localhost:5000/Reaction/id/{ReactionEventID}`. 

#### DELETE One Symptom from a Reaction Event

Delete and individual symptom from a Reaction Event. `http://localhost:5000/Reaction/Symptom/{ReactionEventSymptomID}`.

## Trial Resource

Users can track food trials. Verbs supported: GET/POST/PUT/DELETE

### GET 

#### Get All Child's Trials
Access a list of all of the trials of a particular child by running a GET call to `http://localhost:5000/Trial/{childID}`. This will return all of the trials with the food being testing in the trial.
> Example: To get all of Sherman's trial information make the call to `http://localhost:5000/Trial/1`

#### Get Single Trial
Get the information on a single reaction by running a GET call to ```http://localhost:5000/Trial/id/{reactionID}```. This method will return an individual reaction with the food, all associated trial events, and a link to any reactions that may have started during the trial.
> Example: GET `http://localhost:5000/Trial/id/1`

### POST
POST a new trial by running a POST call to `http://localhost:5000/Trial` using data from the following table.
* Sample JSON: { "ChildID": 1, "FoodID": 73, "StartDate": "2017-1-16" } 
> Take Note: The trigger IDs are NOT the food IDs; the trigger IDs should be the IDs of child's triggers. The API validates whether or not the triggerID belongs to the specified child and if the foodID on the trial matches the foodID of the trigger.

     
| Property  | Required | DataType | Example   |
|-----------|----------|----------|-----------|
| ChildID   | Y        | Int      | 5         |
| FoodID    | Y        | Int      | 1         |
| TriggerID | N        | Int      | 4         |
| StartDate | Y        | DateTime | 2017-5-27 |
| EndDate   | N        | DateTime | 2017-6-2  |
| Pass      | N        | Bool     | True      |


### PUT 
You can update the information on a specific child by running a Put call to `http://localhost:5000/Trial/id/{TrialID}`.
* Sample JSON: { "ChildID": 1, "FoodID": 73, "TriggerID":2, "StartDate": "2017-1-16", "EndDate":"2017-1-17", "Pass":"False" } 
> Take Note: The trigger IDs are NOT the food IDs; the trigger IDs should be the IDs of child's triggers. The API validates whether or not the triggerID belongs to the specified child and if the foodID on the trial matches the foodID of the trigger.


| Property  | Required | DataType | Example   |
|-----------|----------|----------|-----------|
| ChildID   | Y        | Int      | 5         |
| FoodID    | Y        | Int      | 1         |
| TriggerID | N        | Int      | 4         |
| StartDate | Y        | DateTime | 2017-5-27 |
| EndDate   | N        | DateTime | 2017-6-2  |
| Pass      | N        | Bool     | True      |
      

### DELETE 

You can delete a reaction by running a DELETE call to `http://localhost:5000/Reaction/id/{reactionID}`. 


## Trial Event Resource

Verbs supported: GET/POST/PUT/DELETE

These are the individual events in an ongoing trial. For example, a child might be trialling almonds (almond milk). The information of the specific meal (1/4 cup almond milk) are recorded using this resource.

### GET 

#### GET All Trial's Events
Access a list of all of the events of a particular trial by running a GET call to `http://localhost:5000/TrialEvent/{TrialID}`. This will return all of the trial events associated with a specific trial.
> Example: To get all of Sherman's trial information make the call to `http://localhost:5000/TrialEvent/2`

#### GET Single Trial Event
Get the information on a single trial event by running a GET call to ```http://localhost:5000/TrialEvent/id/{reactionEventID}```. This method will return an individual trial event with the associated symptoms nested inside.
> Example: GET `http://localhost:5000/ReactionEvent/id/1`

### POST 

POST a new trial event by running a POST call to `http://localhost:5000/TrialEvent` using data from the following table.
* Sample JSON: { "TrialID": 1, "Quantity": "1/4 Cup", "FoodType":"Almond Milk", "DateTime": "2017-5-27 08:00:00"} 

| Property | Required | DataType | Example            |
|----------|----------|----------|--------------------|
| TrialID  | Y        | Int      | 5                  |
| Quantity | Y        | String   | 1/4 cup            |
| FoodType | Y        | String   | Almond Milk        |
| DateTime | Y        | DateTime | 2017-5-27 08:00:00 |


### PUT 
You can update the information on a specific reaction event by running a PUT call to `http://localhost:5000/TrialEvent/id/{TrialEventID}`.
* Sample JSON: { "TrialID": 1, "Quantity": "1/4 Cup", "FoodType":"Almond Milk", "DateTime": "2017-5-27 08:20:00"}
> You must PUT the entire changed object, using the appropriate fields detailed above. 
      
### DELETE

Delete a trial event by running a DELETE call to `http://localhost:5000/TrialEvent/id/{ReactionEventID}`. 
