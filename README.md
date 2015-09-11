BuxferSharp
===========
[![License](http://img.shields.io/:license-MIT-blue.svg)](https://raw.githubusercontent.com/giacomelli/BuxferSharp/master/LICENSE)


BuxferSharp is an easy-to-use C# client library to [Buxfer API](https://www.buxfer.com/help/api).


--------

Features
===
 - Full API support
 - Test on Windows 8 and Windows Phone 8.

--------


Usage
===

```csharp
// Creating client.
var client = new BuxferClient("<your user>", "<your password>");

// Getting all accounts.
var accounts = client.GetAccounts();

// Getting all budgets.
var budgets = client.GetBudgets();

// Getting all contacts.
var contacts = client.GetContacts();

// Getting all groups.
var groups = client.GetGroups();

// Getting all loans.
var loans = client.GetLoans();

// Getting all reminders.
var reminders = client.GetReminders();

// Getting all reports.
var reports = client.GetReports();

// Getting reports by filter.
reports = client.GetReports(new ReportFilter() 
{
	AccountName = "My Bank",
	Tag = "Car"
});

// Upload a statement.
var statement = new Statement();
statement.AccountId = "<account id>";
statement.Text = "<Quicken, MS Money, OFX, QIF, QFX, Excel, CSV file content>";
bool uploaded = client.UploadStatement(statement);

// Getting all tags.
var tags = client.GetTags();

// Getting last 25 transactions.
var lastTransactions = client.GetTransactions();


// Getting last transactions from page 2.
var page2Transactions = client.GetTransactions(new TransactionFilter() 
{
	Page = 2
});

// Add a transaction.
var transaction = new Transaction()
{
	Description = "Test transaction",
	Amount = 1,
   	AccountName = "<account name>"
};

var added = client(transaction);

```



--------

Roadmap
--------
 - Build on App Veyor.
 - Create and publish NuGet package.
 
--------

FAQ
======

Having troubles? 
 - Ask on Twitter [@ogiacomelli](http://twitter.com/ogiacomelli)
 - Ask on [Stack Overflow](http://stackoverflow.com/search?q=BuxferSharp)
 
 --------

How to improve it?
======

Create a fork of [BuxferSharp](https://github.com/giacomelli/BuxferSharp/fork). 

Did you change it? [Submit a pull request](https://github.com/giacomelli/BuxferSharp/pull/new/master).


License
======
Licensed under the The MIT License (MIT).
In others words, you can use this library for developement any kind of software: open source, commercial, proprietary and alien.


Change Log
======
0.5.0 First version.
