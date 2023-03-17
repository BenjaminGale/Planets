
## SPA:

As this is the first time I've ever used ReactJS I opted to use the simplest approach to getting the SPA
up and running i.e. the script is embedded in the HTML and and I import the JSX compiler script so that
the JSX is compiled in the browser when loaded.

This does have the advantage that the SPA can be run directly from the browser without having to install
node.js and compile the scripts. I realise in a real-world app I would use the CLI to scaffold a new project
and the JS & HTML would be separated and the script would be precompiled. I did have a go at separating the
HTML and Javascript but got CORS errors in the javascript debug window so opted to keep things simple to
focus on getting the example working.

The test asked for the planets to be displayed as a list. I opted to use a Select element so that I didn't
need to import a javascript library to render the content as a list and provide the selection behaviour. It's
been a while since I've used javascript so I'm not aware of what is available to use so wanted to keep things
simple to get the basic functionality working.

I lost quite a bit of time diagnosing some issues I was getting with my ReactJS solution.

The first was that the planet detail endpoint was not being called when the selection was changed. I was
able to use the browser debugger to diagnose that the selection in the HTML was changing and the Visual
Studio debugger to establish that the endpoint was only ever being hit once. The endpoint was being called
in the `componentDidMount` event so I was able to figure out that this was only ever being called once which
was confirmed by the documentation. The solution was to move the `fetch` request to the selection changed
handler.

The second issue was that the planet detail was not being rendered after the selection was changed. I could
see that the endpoint was being hit on selection change (and was returning a response) so knew the issue was
related to the ReactJS code. After reading through the documentation and some Stackoverflow posts I was able
to figure out that I needed to use the `key` attribute so that ReactJS knew that the detail component needed
to be rerendered.

## REST API

I've structured the code using a 'clean architecture' so the code is separated in to 'domain', 'application',
'infrastructure' and 'webAPI' folders to house the code that I felt belonged to each of these layers. I opted to
use folders to organise these layers rather than projects as I prefer to keep things simple and migrate to using
projects when the need arises. I'm not a fan of having solutions with lots of projects with only a few classes as
it slows the build and complicates the solution which is why I prefer to start this way.

I wasn't sure if I should provide a service layer because the 'domain' is pretty simple and there isn't really any
business logic but decided to implement one anyway. The service layer includes 'use case' classes to provide the
application logic to retrieve the planet information. Again I've kept it simple for this application but in the
solutions I maintain at work we use Mediatr which provides a consistent service layer API and makes it easy to add
cross-cutting concerns such as validation and logging.

The service layer encapsulates the domain models so returns separate types that look very similar. I took this as
an opportunity to add some formatting to the planet data so that it is suitable for display in the client.

I decided to implement an in-memory repository for the data layer. This allows the application to remain
'self-contained' and runnable without a database being set up. I am most familiar with Dapper which requires
an existing database which wouldn't have been easy to set up for a sample. I am aware that it's possible to use
Entity Framework to scaffold a database and I think the Sqlite provider allows an in-memory database but it has
been a few years since I last used Entity Framework I decided to come back to this later. Due to the time I lost
debugging the SPA I was unable to get time to implement this.

All of the methods in the solution are synchronous. I realise this goes against best practices and would use async
in a real-world solution where I knew I would be contacting external databases and services. I decided to leave it
out here as I knew I was using an in-memory database so no async work was required and I didn't see any benefit in
making the methods async as I'd have had to add `Task.FromResult(...)` to all method calls which would have added
uneccessary noise.

The soution includes some integration and unit tests. The integration tests are very simple and just ensure that
everything is wired up correctly. I've only provided unit tests for the service classes as this is where most of
the 'logic' resides. In a real-world solution that had richer domain models I would obviously provide suitable test
coverage.

The unit tests make use of Moq and FluentAssertions. Moq is used to mock the `IPlanetRepository` interface and
FluentAssertions is used to write readable assertions (it also provides much better messages when tests fail). These
are both libraries I use regularly in my work so it made sense to use them here.