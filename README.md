# COMP2084ProjectNinaLiu200479031
Anonymous users can view Home, About Us, Coach,  Program page, and Create membership to apply membership.

Forced authentication & authorization, Roles= Administrator to Roles controller, because only Administrator are allowed to view and edit/delete roles.

  Administrator users have the only authorization to create and edit/delete method in Coaches/Programs controller.
Both Client users and Administrator users can reach membership/ClientBooking/ScheduleManagements controllers Create method. Only Administrator users can reach Edit and Delete method.



![Table_Diagram](https://user-images.githubusercontent.com/82427284/163698655-fc028220-c5ae-448a-9e97-0f9cdb8a6203.png)
![table_CoachInfo](https://user-images.githubusercontent.com/82427284/163698654-fa2b35cd-1d1f-459b-9c11-b99d64012720.png)
![table_MembershipInfo](https://user-images.githubusercontent.com/82427284/163698656-244a8a96-a9ed-4535-a682-aae3c015ebe8.png)
![table_ProgramInfo](https://user-images.githubusercontent.com/82427284/163698657-3ca60cf4-3c8e-4848-ae22-2e17ffe24eee.png)
![table_ScheduleManagement](https://user-images.githubusercontent.com/82427284/163698658-0d99cc1c-bf1f-4979-a528-695a8167e78d.png)
![table_Subscription](https://user-images.githubusercontent.com/82427284/163698659-2cfc810d-efef-42ec-b050-47a0a88f5312.png)