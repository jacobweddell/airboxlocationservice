# airboxlocationservice

This API exposes the following endpoints:

GET api/userlocation/current - Retrieves the current location for all users

GET api/userlocation/{id}/current - Retrieves the current location for a user given their id

GET api/userlocation/{id}/history - Retrieves the locaion history for a user given their id

GET api/userlocation/area - Retrieves all users whose current location resides within a pair of longitudes/latitudes

POST api/userlocation - Adds a user location entry
