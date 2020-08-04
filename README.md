# Google-Timeline-Analyser

## Installation Requirements:
 - MySQL, create a database and make sure the connection string in appsettings.json
 - Kendo MVC Core 2019.3 or later. Import the kendo mvc wrapper in the project and include kendo in the wwwroot/lib folder. It is configured in the libman.json already.
 - Initial data is seeded, an admin account and roles are created on application start. 
   admin:Secret1234!
   
## Features:
 - microsoft identity login and user management with roles
 - data separated by user
 - log management
 - report page showing a graph for physical activities and transport distances

## Usage:
Go to Google Takeout, and request Google Maps Timeline json extraction.
The files provided is a huge json file, and semantics summary files, the latter being used in this application to build a summary.
Import multiple files in the Fitness section 

## Notes:
 - the distance from my json files seemed to be in 10s of feet. I'm converting to km.

## TODO features:
 - test the Distance values
 - use reference table for activities instead of a string field in ImportData
 - Put all labels and texts in ressources
 - make application use a language cookie and make it bilingual
 - set English as default language, change the startup setting it as french
 - fix the home page scroller (update kendo?)
 - import location files too
 - add a register page to add new users by email registration
 - admins should be able to see and manage other user's data
