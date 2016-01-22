Should I Tweet 2
================

This exercise is a continuation of 003-shoulditweet.

The application has been effective but has not kept up with cultural changes. The list of problematic phrases needs to be maintained. Extend the application so that the problematic phrases are stored in a SQL server database and can be maintained via a user interface that allows insertion, editing and deletion.

The stakeholder funding this project would like to capture data describing the operation of the application.

Non-functional Requirements
-------------

* The data access should be accomplished via EF code first.
* Add logging via serilog to a text file that tracks important runtime events.
* Extend the logging to also store logs in a seq instance
