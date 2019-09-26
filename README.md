# LiquorStoreWebAppASP.NET
An ASP.NET webshop for a liquor store. 

This is a school project i had to make with ASP.NET MVC. 

There are 3 kind of roles 

Customer:
- You can create an account and see your accountinformation. You're able to make modifications to this as well. 
- As a custommer you can add different products to your shopbasket
- You can perform CRUD operations in the shopbasket
- You are able to simulate the buying process. 
- You can view all orders in account view. 

Product Managers: 
- Can perform all of the above 
- Will see an extra button popping up when logging on
- Is able to add new product with picture, catagories and producers to the database through the webapp

Administrators:
- Can perform all of the above 
- Has more functionalities in the same button the product managers sees
- Is able to look up all users who have created an account on the website
- Is able to look up all users who made a purchase on the website, can see their orders as well


Used Technologies: 
- C# as the coding language
- ASP.NET MVC for creating the WebApp
- SQL SERVER as database
- Entity Framework as ORM (Object Relational Mapper), database first
- Identity Framework to handle the creation of users and log- in & out


Future updates: 
- Fix the bug where the shopbasket is shared for all users
- Refactor code 
