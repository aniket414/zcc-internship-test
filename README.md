# Zendesk Ticket Viewer

The internship project is done using dot net core 3.1

Steps to run the code:

1. Clone the repository to your machine
2. Make sure you have Visual Studio 2019/2017 installed on your machine
3. Open the solution [.sln] file in Visual Studio; Location: [zcc-internship-test/Zendesk.Ticket.Viewer/Zendesk.Ticket.Viewer.sln]
4. Build the solution [This will restore all the dependancies]. The option to Build the solution will be present on the menu bar
5. Next to the build command there will be Run command using which we can host our API.

The username and password is hard coded in zcc-internship-test/Zendesk.Ticket.Viewer/Zendesk.Ticket.Viewer.Data/ZendeskAdapter.cs however as for best practice we should store them in encrypted form in Configuration Store such as Consul KV [consul.io] or we can also store them in AWS Parameter Store and fetch from there.

The API Request and Response documentation is present in Zendesk_Ticket_Viewer_Documentation.pdf

The project also has integrated github actions to automatically run unit tests every time a new commit is made to the repository.
