
Create Procedure SP_AddNewEmployee
@FirstName nvarchar(100),
@LastName nvarchar(100),
@JobTitle nvarchar(100),
@Level nvarchar(100)
as 
 Begin
    
	insert into Employees(FirstName,LastName,JobTitle,Level)
	values
	(@FirstName,@LastName,@JobTitle,@Level);


  End