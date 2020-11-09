# README

As part of your application to Geotab, we ask that you complete the following challenge.

## Task 1 - Fix some ugly code

Imagine yourself working at Joke Company™. This company has an app that gets random Chuck Norris jokes and can substitute other peoples names into the joke instead of Chuck Norris'.

Your task as a professional developer is to clean up this app and make it something you can be proud of.

*Note: This is NOT a representation of our codebase, to be clear. We did have fun crafting this beauty however ;)*

## Task 2 - Write a report

### Bugs:
- 'c' and 'r' commands don’t work unless you use ‘?’ First - **FIXED**
- User is asked if they want to specify a category, but is never provided a chance to enter a value when they chose no for ‘Want to use a random name?’ - **FIXED**
- Regardless of the number of jokes requested, one is always returned - **FIXED**
- The value ‘2’ for the number of jokes does not work - **FIXED**
- If the user requests ‘y’ for ‘Want to use a random name’, they are forced to enter a category regardless of their selection. - **FIXED**
- select ‘c’ option to see all categories crashes the application - **FIXED**
- no way for user to exit the application gracefully - **FIXED**
- line ending does not show correctly so options the user has entered show up next to text prompting user for information - **FIXED**
- incorrect category results in the application crashing - **OUTSTANDING**

### Improvements:
- Refactored and deprecated all methods in ConsolePrinter.cs as the implementation was unnecessary and static variable PrintValue was not thread-safe and error prone
- Refactored and deprecated all methods in JsonFeed.cs.  This class did too many things (API calls, joke generation logic etc) It was separated between:
    - ApiClient.cs (ChuckNorrisIoApiClient.cs and NamePrivServApiClient) - these classes are responsible for talking to the APIs and returning DTOs with the data
    - ChuckNorrisIoCategoriesDTO.cs, ChuckNorrisIoJokeDTO.cs and NamePrivServNameDTO.cs are now used to pass response data back to the application.  This provides a strict definition and expectation of the data returned to the rest of the application
    - JokeGeneratorService.cs replaces the main logic of JsonFeed which takes the API responses and modifies the joke responses, and returns the data in a generic way.  This service class could be used in the future to be called by a class that provides a rest endpoint.
- Cleaned up and refactored Program.cs - including using new classes and methods from above, rework of some of the logic.  I was not able to finish the full refactoring (see items in Outstanding Improvements on changes I would make given more time)
- Added Unit Tests to the project to provide coverage.  Although not all methods and classes were covered, this was a start and more would be added time permitting

### Outstanding Improvements:
- update random name to return a tuple
- make DTOs readonly (only constructor no set)
- use URIBuilder for URLs
- improve exception handling
- refactor to remove use of ConsoleKeyInfo in Program.cs
- further refactor Program.cs breaking down main method to provide easier readability, and ability to unit test
- further refactor Program.cs to remove the use of static variables as these make for extremely brittle and hard to follow code
- add more unit test coverage
- mock objects such as HttpClient so unit tests don't require internet connection and don't require access to the API

## What do I need

- [.NET Core](https://www.microsoft.com/net/core) - any platform

## Who do I talk to

If you have any questions please email careers@geotab.com

## Name Generator (new!)

- [https://names.privserv.com/](https://names.privserv.com/)
