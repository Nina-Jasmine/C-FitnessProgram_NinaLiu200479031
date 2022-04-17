# COMP2084ProjectNinaLiu200479031
# Created 2 Roles: Administrator, Client
# Anonymous users can view Home, About Us, Coach,  Program page 
# Login Users can reach Create membership function to apply membership in Membership Controller, but can not Edit or Delete.

# Forced authentication & authorization, Roles= Administrator to Roles controller, because only Administrator are allowed to view and edit/delete roles. 
#  Therefore, I hide the Roles Page Link from all non Administrator users in _Layout.cshtml

# Both Client users and Administrator users can reach membership/ClientBooking/ScheduleManagements controllers Index/Create method. Only Administrator users can reach Edit and Delete method to avoid Client users Edit other clients data.

#  Administrator users have the only authorization to create and edit/delete method in Coaches/Programs controller.
#  Therefore, hide Create/Edit/Delete Links in Both Index.cshtml of Coaches/Programs View to non Administrator users.
  
 
# Administrator User Account:
Nina@Nina.ca  password: Nina_890
Jasmine@nina.ca Password: Nina_890

# Client Users:
Kevin@Kevin.ca Password: Nina_890
Jasmine@nina.ca Password: Nina_890

# user without role:
Bear@bear.ca   password: Nina_890



![Table_Diagram](https://user-images.githubusercontent.com/82427284/163698655-fc028220-c5ae-448a-9e97-0f9cdb8a6203.png)
![table_CoachInfo](https://user-images.githubusercontent.com/82427284/163698654-fa2b35cd-1d1f-459b-9c11-b99d64012720.png)
![table_MembershipInfo](https://user-images.githubusercontent.com/82427284/163698656-244a8a96-a9ed-4535-a682-aae3c015ebe8.png)
![table_ProgramInfo](https://user-images.githubusercontent.com/82427284/163698657-3ca60cf4-3c8e-4848-ae22-2e17ffe24eee.png)
![table_ScheduleManagement](https://user-images.githubusercontent.com/82427284/163698658-0d99cc1c-bf1f-4979-a528-695a8167e78d.png)
![table_Subscription](https://user-images.githubusercontent.com/82427284/163698659-2cfc810d-efef-42ec-b050-47a0a88f5312.png)
