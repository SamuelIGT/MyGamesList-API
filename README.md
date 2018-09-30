# My Games List API


<a name="overview"></a>
## Overview
A Rest API made with ASP.NET Core + SQL Server to the My Games List app.


### Version information
*Version* : v1


### Contact information
*Contact* : [Samuel Alves](www.linkedin.com/in/samuel-alves-923239145/)


<a name="paths"></a>
## Database
### ER Diagram
![ER Diagram](https://github.com/SamuelIGT/MyGamesList-API/blob/master/My_Games_List_-_SQL_Server_Diagram_v1.1.PNG?raw=true)


<a name="paths"></a>
## Available Endpoints

<a name="apigamepost"></a>
### Creates a new Game.
```
POST /api/Game
```


#### Description
Request example:

    POST /game
    {
        "steamAppid": 1102,
        "title": "Half-Life",
        "shortDescription": "The best game ever.",
        "detailedDescription": "Half-life is the best game ever...",
        "headerImage": "https://steamcdn-a.akamaihd.net/steam/apps/1102/header.jpg",
        "price": 25.90
    }


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Body**|**game**  <br>*optional*|[Game](#game)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**201**|Returns the Game created|[Game](#game)|
|**400**|The Game passed is null|No Content|


#### Consumes

* `application/json-patch+json`
* `application/json`
* `text/json`
* `application/*+json`


#### Produces

* `application/json`


#### Tags

* Game


<a name="apigameget"></a>
### List all Games.
```
GET /api/Game
```


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**200**|Success|< [Game](#game) > array|


#### Produces

* `application/json`


#### Tags

* Game


<a name="apigamebyidget"></a>
### Lists the Game with corresponding id.
```
GET /api/Game/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**200**|Returns the expected Game|[Game](#game)|
|**404**|If no Game with the same id was found|No Content|


#### Produces

* `application/json`


#### Tags

* Game


<a name="apigamebyidput"></a>
### Updates a Game.
```
PUT /api/Game/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|
|**Body**|**game**  <br>*optional*|[Game](#game)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**204**|Updated with success|No Content|
|**400**|If the Game passed is null or its id is different from the one passed on the url.|No Content|
|**404**|If no Game with the same id was found|No Content|


#### Consumes

* `application/json-patch+json`
* `application/json`
* `text/json`
* `application/*+json`


#### Tags

* Game


<a name="apigamebyiddelete"></a>
### Deletes a Game.
```
DELETE /api/Game/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**204**|If no Game item with the same id was found|No Content|
|**400**|Deleted with success|No Content|


#### Tags

* Game


<a name="apiownedgamepost"></a>
### Creates a new OwnedGame.
```
POST /api/OwnedGame
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Body**|**game**  <br>*optional*|[OwnedGame](#ownedgame)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**201**|Returns the OwnedGame created|[OwnedGame](#ownedgame)|
|**400**|If the OwnedGame is null|No Content|


#### Consumes

* `application/json-patch+json`
* `application/json`
* `text/json`
* `application/*+json`


#### Produces

* `application/json`


#### Tags

* OwnedGame


<a name="apiownedgameget"></a>
### Lists all OwnedGames
```
GET /api/OwnedGame
```


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**200**|Success|< [OwnedGame](#ownedgame) > array|


#### Produces

* `application/json`


#### Tags

* OwnedGame


<a name="apiownedgamebyidget"></a>
### Lists the OwnedGame with corresponding id.
```
GET /api/OwnedGame/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**200**|Returns the expected OwnedGame|[OwnedGame](#ownedgame)|
|**404**|If no OwnedGame with the same id was found|No Content|


#### Produces

* `application/json`


#### Tags

* OwnedGame


<a name="apiownedgamebyidput"></a>
### Updates the OwnedGame.
```
PUT /api/OwnedGame/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|
|**Body**|**game**  <br>*optional*|[OwnedGame](#ownedgame)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**204**|Updated with success|No Content|
|**400**|If the OwnedGame passed is null or its id is different from the one passed on the url.|No Content|
|**404**|If no OwnedGame with the same id was found|No Content|


#### Consumes

* `application/json-patch+json`
* `application/json`
* `text/json`
* `application/*+json`


#### Tags

* OwnedGame


<a name="apiownedgamebyiddelete"></a>
### Deletes the OwnedGame.
```
DELETE /api/OwnedGame/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**204**|Deleted with success|No Content|
|**404**|If no OwnedGame with the same id was found|No Content|


#### Tags

* OwnedGame


<a name="apiuserpost"></a>
### Creates a new User.
```
POST /api/User
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Body**|**user**  <br>*optional*|[User](#user)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**201**|Returns the User created|[User](#user)|
|**400**|If the User is null|No Content|


#### Consumes

* `application/json-patch+json`
* `application/json`
* `text/json`
* `application/*+json`


#### Produces

* `application/json`


#### Tags

* User


<a name="apiuserget"></a>
### List all Users.
```
GET /api/User
```


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**200**|Success|< [User](#user) > array|


#### Produces

* `application/json`


#### Tags

* User


<a name="apiuserbyidget"></a>
### Lists the User with corresponding id.
```
GET /api/User/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**200**|Returns the expected User|[User](#user)|
|**404**|If no User with the same id was found|No Content|


#### Produces

* `application/json`


#### Tags

* User


<a name="apiuserbyidput"></a>
### Updates a User
```
PUT /api/User/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|
|**Body**|**user**  <br>*optional*|[User](#user)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**204**|Updated with success|No Content|
|**400**|If the User passed is null or its id is different from the one passed on the url.|No Content|
|**404**|If no User with the same id was found|No Content|


#### Consumes

* `application/json-patch+json`
* `application/json`
* `text/json`
* `application/*+json`


#### Tags

* User


<a name="apiuserbyiddelete"></a>
### Deletes a User
```
DELETE /api/User/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**204**|Deleted with success|No Content|
|**404**|If no User with the same id was found|No Content|


#### Tags

* User


<a name="apiwishlistitempost"></a>
### Creates a new WishlistItem.
```
POST /api/WishlistItem
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Body**|**item**  <br>*optional*|[WishlistItem](#wishlistitem)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**201**|Returns the WishlistItem created|[WishlistItem](#wishlistitem)|
|**400**|If the WishlistItem is null|No Content|


#### Consumes

* `application/json-patch+json`
* `application/json`
* `text/json`
* `application/*+json`


#### Produces

* `application/json`


#### Tags

* WishlistItem


<a name="apiwishlistitemget"></a>
### Lists all WishlistItems.
```
GET /api/WishlistItem
```


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**200**|Success|< [WishlistItem](#wishlistitem) > array|


#### Produces

* `application/json`


#### Tags

* WishlistItem


<a name="apiwishlistitembyidget"></a>
### Lists the WishlistItem with the corresponding id.
```
GET /api/WishlistItem/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**200**|Returns the expected WishlistItem|[WishlistItem](#wishlistitem)|
|**404**|If no WishlistItem with the same id was found|No Content|


#### Produces

* `application/json`


#### Tags

* WishlistItem


<a name="apiwishlistitembyidput"></a>
### Updates the WishlistItem.
```
PUT /api/WishlistItem/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|
|**Body**|**item**  <br>*optional*|[WishlistItem](#wishlistitem)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**204**|Updated with success|No Content|
|**400**|If the WishlistItem passed is null or its id is different from the one passed on the url.|No Content|
|**404**|If no WishlistItem with the same id was found|No Content|


#### Consumes

* `application/json-patch+json`
* `application/json`
* `text/json`
* `application/*+json`


#### Tags

* WishlistItem


<a name="apiwishlistitembyiddelete"></a>
### Deletes the WishlistItem.
```
DELETE /api/WishlistItem/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**204**|Deleted with success|No Content|
|**404**|If no WishlistItem with the same id was found|No Content|


#### Tags

* WishlistItem




<a name="definitions"></a>
## Models

<a name="game"></a>
### Game

|Name|Description|Schema|
|---|---|---|
|**detailedDescription**  <br>*optional*|**Length** : `0 - 3000`|string|
|**headerImage**  <br>*optional*|**Length** : `0 - 300`|string|
|**id**  <br>*optional*||integer (int64)|
|**price**  <br>*optional*||number (double)|
|**shortDescription**  <br>*optional*|**Length** : `0 - 500`|string|
|**steamAppid**  <br>*optional*||integer (int64)|
|**title**  <br>*required*|**Length** : `0 - 300`|string|


<a name="ownedgame"></a>
### OwnedGame

|Name|Schema|
|---|---|
|**game**  <br>*required*|[Game](#game)|
|**id**  <br>*optional*|integer (int64)|
|**playtimeForever**  <br>*optional*|integer (int64)|
|**playtimeTwoWeeks**  <br>*optional*|integer (int64)|


<a name="user"></a>
### User

|Name|Description|Schema|
|---|---|---|
|**email**  <br>*required*|**Length** : `0 - 250`|string|
|**id**  <br>*optional*||integer (int64)|
|**name**  <br>*required*|**Length** : `0 - 250`|string|
|**ownedGames**  <br>*optional*||< [OwnedGame](#ownedgame) > array|
|**wishlist**  <br>*optional*||< [WishlistItem](#wishlistitem) > array|


<a name="wishlistitem"></a>
### WishlistItem

|Name|Schema|
|---|---|
|**game**  <br>*required*|[Game](#game)|
|**id**  <br>*optional*|integer (int64)|
|**rankPosition**  <br>*optional*|integer (int32)|





