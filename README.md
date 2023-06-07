# ReunionLogSoftware
C# Software for ReunionLog using .NET 6.0.116 and the framework MonoGame. 

This software is a WIP software with the purpose of creating .csv files from the [WarcraftLog]([http:](https://www.warcraftlogs.com/)) API V2. The hopes of this software is to add user customization such that the .csv file formats correctly without having to change the source code.

Furthermore this software also add clarity for the WarcraftLogs API since the documentation is mediocre at best. For further readings about the documentation of the process of creating this software and actual WarcraftLogs API documentation read [here]((Documentation/Documentation.pdf)).

# TOC
- [ReunionLogSoftware](#reunionlogsoftware)
- [TOC](#toc)
- [HOW-TO](#how-to)
- [Connection to WarcraftLogs API](#connection-to-warcraftlogs-api)
- [From Json to .CSV](#from-json-to-csv)
- [User Customization](#user-customization)


# HOW-TO
(**WIP**)

As of the moments this software is still WIP, so i'm just using the following command on Linux/Ubuntu22.04:
```bash
dotnet run
```
I guess you could use the build command but at this stage it shouldn't be necessary.

# Connection to WarcraftLogs API
When first you open the software, the software should look for a file `client.json` If no such file exists it will create it's own and ask the user for the WarcraftLog `ClientID` and `ClientSecret` (*WIP*). The structure of this document should look like this:

```JSON
{
    "client":{
        "client_id": "<Here is the ClientID>",
        "client_secret": "<Here is the ClientSecret>"
    }
}
```
The `ClientID` and `ClientSecret` has to be manually created through [WarcraftLogs webpage](https://www.warcraftlogs.com/api/docs).

The main connection to the API is done in the file `WarcraftLogAPI.cs`. This will return a credential which we save in a `.Credential.json`. And so by using GraphQL calls with our credential, we would get `Json` types returned

# From Json to .CSV
(**WIP**)

# User Customization
(**WIP**)
