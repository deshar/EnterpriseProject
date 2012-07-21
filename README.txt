PlanApp Project
All the files (including the project report) needed to run the app are in the 
PlanApp_RC directory on GitHub.

A selection of drawings is also included - the Drawings directory needs to be copied to the C drive.

1. The app takes in basic data for an application for planning permission.
2. It also collects all drawings related to that application and stores them in the Microsoft Azure Cloud.
3. It uses the BLOB (binary large object) storage facility of Azure to store the drawings.
4. The drawings need to be copied to a directory on the C drive called: Drawings.
5. The app uses the postal address to create the container name to hold the individual drawing files.

Unit Tests:
The app contains 9 unit tests one of which (T8) is a data driven unit test 
which will read from the Permission database.

The path to the database will need to be edited in the UnitTest1.cs file in the 
TestPlan1 project i.e. (line 66 which starts with [DataSource(...