# Dr. Sillystringz's Factory

#### MVC web application to help kepp track of the factory machine repairs.

#### By Roman Kolivashko

## Technologies Used:
* C#
* .Net v5
* Entity Framework
* Migrations
* Razor
* MySQL 
* HTML
* CSS3


## User Stories

* As the factory manager, I need to be able to see a list of all engineers, and I need to be able to see a list of all machines.

* As the factory manager, I need to be able to select a engineer, see their details, and see a list of all machines that engineer is licensed to repair. I also need to be able to select a machine, see its details, and see a list of all engineers licensed to repair it.

* As the factory manager, I need to add new engineers to our system when they are hired. I also need to add new machines to our system when they are installed.

* As the factory manager, I should be able to add new machines even if no engineers are employed. I should also be able to add new engineers even if no machines are installed

* As the factory manager, I need to be able to add or remove machines that a specific engineer is licensed to repair. I also need to be able to modify this relationship from the other side, and add or remove engineers from a specific machine.

* I should be able to navigate to a splash page that lists all engineers and machines. Users should be able to click on an individual engineer or machine to see all the engineers/machines that belong to it.

## Setup/Installation Requirements

* _Clone this repository_ `git clone https://github.com/romankolivashko/Factory.git`
* _Navigate to `/Factory.Solution/Factory` directory_
* _Run `dotnet restore` command to download required dependencies_
* _Run `dotnet run` command to launch the application in a console_
* Download and install .NET Core
* Download and install MySQL Workbench
* Upon successful MySQL installation, proceed importing data:
  1. In Workbench: Select `Administration` Tab --> Under `Management` Tab 
  2. Select `Data Import/Restore` option
  3. In the pane to the right, select `Import from Self-Contained File` and navigate to this project's root directory
  4. Select `roman_kolivashko.sql` from this directory
  5. Next to `Default Target Schema` option select `New`, give the name of your liking
  6. Click `Start Import` button
  7. Create `appsettings.json` file in `/Factory.Solution/Factory` directory, make sure to append following to that file:
  ```
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=<schema_name>;uid=<user>;pwd=<password>;"
   }
  }
  ```
  Note: replace *"schema_name"* with the name of file from step 5, *"user"* and *"password"* will be your local MySQL env variables.


## Known Bugs

* Refer to [the GitHub issues page](https://github.com/romankolivashko/Factory/issues) to see existing bugs or report new ones. 

## License

MIT
## Contact Information

rkolivashko@gmail.com