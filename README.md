
Frontend 
React/typescript

Backend 
ASP.NET Core MInimal API / API Controller

Database
PostgreSQL

Architecture
API - Service layer (logic) - Repository - Database

Testing
XUnit / NUNit / Moq

Auth Services
ASP.NET CORE’s Identity User
OAuth2
JWT

Roles
If a user created a project then the user is == owner


Permissions per project
Owner: Creator of project, and manager.
Reader: Who accomplishes tasks assigned by the owner.
Manager: Can add Tasks, Sub Tasks.


Owner 
Can set deadlines for the Project, Task, and Sub-tasks.
Can set Status (Todo, In progress, Review, Done) for Project, Task, and Sub-tasks.
Assign User for the Project, Task, and Sub-Tasks.
Can add Tasks, and Sub-Tasks.

Manager
Can add Tasks, and Sub-Tasks.
Overview of Project
Review Tasks, and Sub-tasks and Set task status.

Reader
Comment Activity
Can set start date
Can set status except done
View Project overview and tasks.


ERD DIAGRAM
https://app.diagrams.net/#G1j_MtAW1FIiDHj7_iXUhkFogL5uj3GF-I#%7B%22pageId%22%3A%22Y5TF-2Qt-nU_Zk850tnN%22%7D
