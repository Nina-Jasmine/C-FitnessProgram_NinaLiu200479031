# COMP2084ProjectNinaLiu200479031
# Topic Fitness website
# Created 2 Roles: Administrator, Client
# Anonymous users can view Home, About Us, Coach,  Program page 
# Login Users can reach Create membership function to apply membership in Membership Controller, but can not Edit or Delete.

# Forced authentication & authorization, Roles= Administrator to Roles controller, because only Administrator are allowed to view and edit/delete roles. 
  Therefore, I hide the Roles Page Link from all non Administrator users in _Layout.cshtml

# Both Client users and Administrator users can reach membership/ClientBooking/ScheduleManagements controllers Index/Create method. Only Administrator users can reach Edit and Delete method to avoid Client users Edit other clients data.

#  Administrator users have the only authorization to create and edit/delete method in Coaches/Programs controller.
   Therefore, hide Create/Edit/Delete Links in Both Index.cshtml of Coaches/Programs View to non Administrator users.
  
 
# Administrator User Account:
Nina@Nina.ca  password: Nina_890
Jasmine@nina.ca Password: Nina_890

# Client Users:
Kevin@Kevin.ca Password: Nina_890
Jasmine@nina.ca Password: Nina_890

# user without role:
Bear@bear.ca   password: Nina_890


![Table_Diagram](https://user-images.githubusercontent.com/82427284/163724671-bdc7d493-3176-4400-afec-a604b9dc024c.png)
![table_CoachInfo](https://user-images.githubusercontent.com/82427284/163698654-fa2b35cd-1d1f-459b-9c11-b99d64012720.png) 
![table_MembershipInfo](https://user-images.githubusercontent.com/82427284/163698656-244a8a96-a9ed-4535-a682-aae3c015ebe8.png)
![table_ProgramInfo](https://user-images.githubusercontent.com/82427284/163698657-3ca60cf4-3c8e-4848-ae22-2e17ffe24eee.png)

![TableClientBooking](https://user-images.githubusercontent.com/82427284/163724960-cd1612b7-7cde-4e18-94a4-09b223fb255d.png)
![table_ScheduleManagement](https://user-images.githubusercontent.com/82427284/163698658-0d99cc1c-bf1f-4979-a528-695a8167e78d.png)

![Home Page](https://user-images.githubusercontent.com/82427284/163724664-019baf1d-d248-4d98-9dd9-e8d038dc9e12.png)
![About Us page](https://user-images.githubusercontent.com/82427284/163724660-f301c0bf-ffef-47e1-a5aa-77139c067c49.png)
![Membership Index Page](https://user-images.githubusercontent.com/82427284/163724665-f09da40d-7c7c-4336-931e-d12fe5768914.png)
![Program create Page](https://user-images.githubusercontent.com/82427284/163724666-ab017185-586d-4ba1-88b0-65c664ada3e4.png)
![Client Booking Create Page](https://user-images.githubusercontent.com/82427284/163724662-e158012e-c208-4984-83eb-adcfbc784ec5.png)
![Fitness Coach Info age](https://user-images.githubusercontent.com/82427284/163724663-6efc0262-87d7-4ab2-a0c8-e04f1eb8c562.png)
![Schedule Management_Booked Progam Client_Page](https://user-images.githubusercontent.com/82427284/163724670-900d3de7-edf3-4cc4-ab56-3056c4078436.png)
![Roles Delete Page](https://user-images.githubusercontent.com/82427284/163724668-6a2cf644-dfb1-401a-8396-162c23c8acfc.png)
![Roles Index Page](https://user-images.githubusercontent.com/82427284/163724669-e870a870-55b4-4fba-b548-9bc21c5cbff9.png)




 



