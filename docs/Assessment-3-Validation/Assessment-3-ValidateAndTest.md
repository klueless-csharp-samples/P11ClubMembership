# Project Assessment: Validate and test software

Student number: 880616253
Student name: David Cruwys

### Background

One of the clubs in Sydney has contracted you to develop a simple membership system.

Currently the club has recorded their members’ details in a book but would like to start storing and managing the details electronically.

The system should allow club employees to add new members to the system, update their details, cancel their membership, and display all members’ details.

## Part 1: Prepare test document and data

1.1 Review and analyse the software requirements in the case study. 

The system should allow club employees to:

- add new members to the system
- update their details
- cancel their membership
- display all member details. 

The following details must be captured when adding a new member to the system:

- Name (first and last)
- Email
- Phone number
- Date of birth


1.2 Use cases from the software requirements:

- User can see the list of all members;
- User can update members details; 
- User can add new members;
- User can remove members. 

2. Select one completed use case in your application.

2.1 Testing of adding a new member use case will be conducted.

2.2 To test completeness, reliability, and performance of the completed use case two following tests will be provided.

2.2.1 Addition of a new member creates a new record with First Name, Last Name, Email, Phone number, Date of birth in the list of membership

2.2.2 Addition of a new member without First Name doesn’t create a record in the list of membership and shows a message with warning “Field can't be empty”.

3.  Based on my research:

3.1 Test context and scope

DAVE: What are we going to test

context: test that controllers for (Index and Create) work?
The scope is only that the endpoints are hit, not the validity of the content returned.

The context software testing advocates testing based on the context of the project as opposed to go by books methodology testing or some fixed notion of best practices.

The scope of a test defines what areas of a customer's product are supposed to get tested, what functionalities to focus on, what bug types the customer is interested in, and what areas or features should not be tested by any means.
If something is in scope, please test it; if something is out of scope, it should not be tested. Understanding the scope of a test is crucial to be a successful tester on our platform.

3.2 Test standard and methodology

DAVE: 

Integration tests ia checking the end point works from a browser, checks users can access asystem publical and the too is selenium 

unit tests cehck the validatity of code using input and output, today Im using  via mstest
What 

The test standard is a standard for the format of documents used in different stages of software testing.

The test methodology is a methodology for establishing quality requirements, identifying, implementing, analyzing, and validating the process, and product of software quality metrics.
Examples of Testing Methodologies are Unit Testing, Integration Testing, System Testing, Performance Testing etc. Each testing methodology has a defined test objective, test strategy, and deliverables.

3.3 Test tools and types

As per above, tools are x & y

Testing tools in software testing can be defined as products that support various test activities starting from planning, requirement gathering, build creation, test execution, defect logging and test analysis. These testing tools are mainly used for testing software firmness, thoroughness, and other performance parameters.

The Best Software Testing Tools List: (part of test tools)
Rainforest QA.
SauceLabs.
Kualitee.
Katalon.
Telerik Test Studio.
TestArchitect.
QAProSoft.
Selenium.
Typically Testing is classified into three categories.
Functional Testing
Non-Functional Testing or Performance Testing
Maintenance (Regression and Maintenance)

Testing Category (part of methodology)
Types of Testing
Functional Testing
Unit Testing
Integration Testing
Smoke
UAT ( User Acceptance Testing)
Localization
Globalization
Interoperability
So on
Non-Functional Testing or Performance Testing
Performance
Endurance
Load
Volume
Scalability
Usability
So on
Maintenance (Regression and Maintenance)
Regression
Maintenance

This is not the complete list as there are more than 150 types of testing types and still adding. Also, note that not all testing types are applicable to all projects but depend on the nature & scope of the project.

3.4 Test design techniques

Test Design is creating a set of inputs for given software that will provide a set of expected outputs.  The idea is to ensure that the system is working good enough and it can be released with as few problems as possible for the average user.

Broadly speaking there are two main categories of Test Design Techniques. They are:
Static Techniques
Dynamic Techniques

Dynamic testing technique is the type of testing that validates the functionality of an application when the code is executed / by executing the code. In simple terms dynamic testing is performed by actually using the application and seeing if a functionality works the way it is expected to. 
Static testing as the name itself suggests is static in nature, which also means there are no changing conditions or parameters. In other words, this is performed without executing the code.
For example, when you are verifying a document or testing a document, you will go through the document, review it and then suggest or make changes.
Also, when there is a code review / walkthrough, the development team goes over the code step by step and checks whether the code written is according to the development standards and also it traverses through correctly to achieve the results desired.
Since, we are not changing anything in the documents, but also reviewing them, it is called static testing. We are testing, but it is static in nature.

The two main types of static testing techniques are
Manual examinations: Manual examinations include analysis of code done manually, also known as REVIEWS.
Automated analysis using tools: Automated analysis are basically static analysis which is done using tools.

4. Design test cases

4.1 Design test cases using static test design technique

UAT or code walkthrough/demonstration

4.2 Design test cases using dynamic test design technique

Code that runs, eg. unit test

4.3 Design test cases using appropriate test input data determined from the requirements

Mock some members and then ensure that a change user function changes bob to jane

4.4  Design test using appropriate formatting including test case number, description, preconditions, steps, expected result, and tool name (if applicable).


Test case number (TICKET # from Bug)
Description: When name is changed, make sure it is not upper case
Pre-conditions: name is lower

Test steps: set name to upper
Expected result: fail


Tool name
1.
This tool makes possible to find the weak spots of a system under development from the source code only, without the need of simulating live conditions.


END OF PART1


PART 2


1. Test environment requirements for each test

- UNIT TESTS
- add nuget packages
- setup mock db
- add mock records
- run target code
- check test ran

- UX TESTS
- setup selenium
- instantiate chrome browser wqith options
- close the browswer connection

2. Two automated test tools used and what makeas them different

mstest
mstest with selenium

3. URLS' of research documents

add in some readmes that as URLs in the repo


4. Testing test

Unit - screenshots
Selenium - screenshots

Test result


PART 3

1. Defects found

- employee email predicated failed for @work.com.au

2. Debugging steps to track the defect.

Showed code with valid work address that returned true
and invalid work address that also retruend true

The second would be the failure 

Screen shot before and after the fix

3. Details of fgixes implemented

4. Testresults after Debugging
   
PART 4

See test plan document.docx


Assessment 4

PART 1

1. Identify a suitable logging framework and its functions

System.Trace (allows for logging of text to different sink providers such as console or file)

2. Create custom efventvlog messagews using the logging framework. Include screenshots

Make sure I demonstrate, log level (debug, info), timestamp, if condition messages useful

Include links to each file:line # as URLS

Application Event:
  startup.cs
    AppStarted
Database events
  Membership.cs (DBContext)
    Member Created: david
HTTP Requests
    List of members (controller)
    David
    Ben
Execeptions
  -1 to show controller should log exception

3. Run the applicatyion

Print screen the output

4. Analysy the captured log messages and indicate the following:

- Operation performed and it's result
  - member 1, logged out david as expected
- Execution flow issues
  - have not got a catch for member -3
- Application errors
  - Did find an app error when trying to show member -3
- Performance issues: before and after timestamps - these well point out any performance issues in production


PART 2

1. Two debug tools and their function

Trace is a tool for printint internal state to console, file, etc...
Log4Net: is a move powerful version of above for enterprise with many out put proivders such as slack and sms

2. Debugging steps and screenshots

RUN the code in debug Model
Put a break point
Print a local variable
Show stack trace
Screenshots go here

3. Code to write debug messages to a file.

- Show the code example for adding tracelistener to file output stream.
- Show the log messages in the Field
- Conditional message using assert - (david vs ben) can have different messages
- Stop/close the output stream (show the code)


PART 3

Profiling tools

1. At least two profiling tools and their functions

Is Site Running.com: let you know if site is running

stackify prefix / retrace
open source visual studio profiler

Find 2 nuget profilers and just run them

2. Screenshot with Ram and Usage stats
3. Which part of application consuremd resources
4. Changes implement4ed to improve performance
   1. show code to a memoized db lookup




PART 4









































