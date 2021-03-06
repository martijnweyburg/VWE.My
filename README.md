# VWE.My

This is the repository with an API for  

- Getting all vehicls from a database
- Getting a vehicle by registration number from a database
- Updating a vehicle by id. 

 HOW TO RUN THE APPLICATION:   
  I implemented Swagger for testing purposes. This is very simple to use.  
  - Start up the application in Visual studio
  - The UI of Swagger will be started. Here you can test the different functions.
  - Just click on a REST function and it will expand.
  - Click on "try it out". 
  ![alt text](https://github.com/martijnweyburg/VWE.My/blob/master/SwaggerTry_UI.png?raw=true)
  - Now you can fill in the Url parameters and the form values (in case of the update function:JSON Format)
  ![alt text](https://github.com/martijnweyburg/VWE.My/blob/master/SwaggerForm_UI.png?raw=true)
  - Click on Execute. The result will appear.
    
  CONNECTION STRING:  
  The connection string (VWEDatabase) can be changed in: 
  the appsettings.json file.
  Project: VWE.My.Web  

GETTING ALL VEHICLES REST CALL:  
  - Paging returns a maximum of 10 records per call  
    That means: if you fill in 12 pages, it will only return 10 pages.  
    
UPDATING VEHICLES REST CALL:      
  You can update the color and the construction year of the vehicle.  
  The construction year must be between 1885 and the current year.  
  That means: 1885 is not allowed and the current year is also not allowed.  
  For updating the construction date I used the year as input (not an entire date). This means that the updated vehicle date will contain a new year, but still contains the old   month and the old day.  
  For instance: Update 2020-11-01 with 2015 as year will become 2015-11-01  
  
  
  UNIT Testing:    
  This app contains a unittest project.  
  VWE.My.Tests  
  The following components are tested:  
   - Service layer with business logic
   - Validation attribute concerning the date validation.  
  
  
  I've mocked the repository objects, so we don't have a database dependency in our unittests. In this way we can test the service layer only.  
  For now I didn't test te controllers. There is no business logic in it.  
  
  Technical details:  
  This app uses:
  - .NET Core 3.1
  - Swagger and Swashbuckle
  - .NET Core entity framework: Database first
  - Automapper for mapping DTO files to Domain models and Vice versa
  - Moq for mocking Repository objects in Unit tests
  
  REPOSITORY PATTERN:  
  I've implemented a Repository pattern with a generic base repository for handling database transactions  
  I also used a service layer between the controllers and the repositories. It is not really necessary if you look at the complexitiy of the business logic right now.  
  But looking at the future when a project becomes more complex (complex business logic) it can be very handy.  
  I also thought about implementing the Unit of Work pattern. If you have database transactions that will need more repository objects in one transaction, it is a very usefull pattern.  
  
  <a href="https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application">Using Repository and Unit of work pattern</a>  
  
  But in this case I choose not to. Not enough time and for now a bit of overkill.
  
  DEPENDENCY INJECTION:    
  I Used the dependency injection functionality of the .NET Core framework. Every Repository class and service class uses a interface that can be implemented in the right class.  
  Every reporitory and service object is created in the startup.cs file by using these interfaces.  
  In this case it is very easy to implement different repository or service implementations in the future.  
  Just add a new class, give it the same interface and load it in the start up.  
  Dependency injection is a great start for having loosely coupled components.
  
  VALIDATION:  
  I've implemented a validation attrribute for handling the year validation. This validation attribute is used as an attribute on the DTO.  
  
  AUTOMAPPER:  
  I've used automapper in the service layer.  
  I know that many times it is used in the controllers.  
  For now I choose to follow the idea of having domain models that are not used in the controllers. The service layer handles the business logic and handles the mapping from domain model to DTO.  
  Automapper is instantiated in the startup.cs file.  
  
  DATABASE FIRST:  
  Because of having a database model in a file, I used entity framework database first.  
  I would prefer code first, but in this case I didn't use it. This is because of the short period of time I had to develop this.  
  
  
  
  
  
