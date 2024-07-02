Hello Everyone this is Csharp Web API for EmployeeAdmin

where I have integrated CRUD operation with few easy steps:

1> Create File inside VS 2022 (WEB API -  .net core)

2> Install Nuget package from manage nuget package by right clicking on dependencies(i)Microsoft.EnitiyFrameworkCore.SqlServer, (ii)Microsoft.EnitiyFrameworkCore.Tools.

3> (a)Create *Models* folder inside project folder and Create *Entities* folder inside Models folder ("An entities is basically something with an indentity")
   (b)Create Create *employee.cs* class inside Entities
   (c)Create identifier i.e (public Guid Id{get; set;} public Name Gmail etc ) inside employee.cs, You can use required keyword if you want name etc to be not null.
   
4> After defining employee Object Create *ApplicationDbContext* class inside *Data* Folder  
  a)Inherit DBContext class(comes from entity framework package installed) inside applicationDbContext 
  b)Create constructor by shortcut ctor
  c)pass parameter inside constructor -> DbContext options<ApplicationDbContext> options : base(options)
  b)Add a property for the collection stored in the database(we need to have a dbset type property in the database)
  c)prop shortcut -> public int myproperty{get;set} change type to class entity i.e (Dbset<employee>) and property name to prural of entity i.e (employees).
  
5>Create Connection string inside appsetting.json by adding this below allowedHosts ( "ConnectionStrings": {
   "DefaultConnection": "Sql server name given by default; Database = EmployeeDb; Trusted_connection=true; TrustServerCertificate = true;"
 }
 
6>Come to Program.cs and inject DbContextClass so that we can use it inside controller
  (a) use builder.class
  builder.services.AddDbContext*(method from EF core)*<ApplicationDbContext>*(type)*(options=>options.UseSqlServer(builder.Configuration.GetConnectionString(m*(pass connection string parameter name from appstting.json)*)
  "//injecting DbContext class here so that we can use anywhere
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));"

7>EF core migrations *This is a way for the application to create some files in C# and execute their files through connection string. It will convert all c# files classes to SQL to create database and table
  a)go to tools >NuGet Package package manager > package manager console> type -> {add-migration} "intial migration(because we are creating it for thefirst time)"
  b)it will create migration folder inside our project folder 
  c)write command {update-database} it will create database inside microsoft sql server, you can check by going to MSS-studio

8> Create API controller inside controller -> employeeController with controller name......
then use all get,post,put and delete for CRUD operations.
  
 
 
  
