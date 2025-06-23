
Create Procedure SP_UpdateEmployee
@EmployeeId int , 
@FirstName nvarchar(100),
@LastName nvarchar(100),
@JobTitle nvarchar(100),
@Level nvarchar(100)
as 
 Begin

    Update Employees 
	set FirstName=@FirstName,LastName=@LastName,JobTitle=@JobTitle,Level=@Level
	where Id=@EmployeeId;
 End