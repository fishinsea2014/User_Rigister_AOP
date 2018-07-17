# User_Rigister_AOP
+ Main functions:
  + User register
  + Use AOP to check user authorities and notifying with text
  + The project has two main part.

+ Part 1: AOP, show different ways of AOP. Mainly focus on Unity AOP, which is in folder UnitWay

+ Part 2: Simulate a MVC AOP framework, 
	+ Define an BaseController
	+ Define an IOrderService interface inherited from BaseController, then define an OrderService
	+ Add an LogFilter attribute on Index method in Orderservice
	+ Define an AOPManager, and an Invoke(type name, method name, Object[] parameters) method in it
	+ The method is initiated when called
	+ Go through all exe and dll files, find the classes inherited from BaseController
	+ Invoke this classes by reflection, when finding LogFilter attribute, then implement log activities on the method
	