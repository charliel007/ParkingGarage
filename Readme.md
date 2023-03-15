# ParkingGarageMVC Application

https://parkinggaragemvc.azurewebsites.net/

This application serves to proactively find and reserve parking at existing parking garages.  First, you will need to create a user account and be logged in to use the service.  It has been assumed that parking garages want record of what vehicles park in their garages, so a vehicle needs entered before a reservation.  A user has complete function of a Vehicle.  Reservations however are considered permanent and can only be created and read.  Reservations can be entered either in 0.5 hour increments via Parking Pass or bi-annually via a Parking Permit.  No additional reservations can be entered at a garage once it has reached its limit at any given point in time (via Total Spots).

The database consists of 5 tables with relationships shown in this image.
[Data Tables](./Data-Table-Relationships.png)

1.  The home page displays the about text with the seeded Locations that can be chosen when making a reservation.  It is outlined here that a user needs to use the register/login options to get started followed by entering a vehicle.

2. Once a user is logged in, from the home page, a user has three options to get started.
	- Click on the Vehicles link in the nav bar.
	- Click on the Reservations link in the nav bar.
	- Click the "Get Started" under either of the Locations.

3.  All Vehicles a user has will be listed on the Index starting page.  Also, a user can perform full CRUD (Create, Read, Update Delete).

4.	From the Vehicles Index page a User has a link to Add Reservation which will take them directely to creating a Reservation (if a vehicle is available).  Also, a user can use the Nav Bar to go to the Reservation Index Page.  On the Reservations Index page a user will see all Reservations they have.  As mentioned, a reservation is considered record so a user can only Create and Read the reservations.