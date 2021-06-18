# Part 3

# Project Assessment: Validate and test software

Student number: `880616253`

Student name: `David Cruwys`

### Background

One of the clubs in Sydney has contracted you to develop a simple membership system.

Currently the club has recorded their members’ details in a book but would like to start storing and managing the details electronically.

The system should allow club employees to add new members to the system, update their details, cancel their membership, and display all members’ details.

## Part 3: Document and manage test results

Evaluate test results to identify defect.
Track the defect and verify fixes.


```bash
Bug Ticket      : #9001
Title           : Employee Email Predicate
Description     : When a standard member was added with a domain name similar to our club, it assumed that the member was an employee when really they were not

Test steps      : use a valid email address that starts with our club domain, but has extra extension in it.
Example data    : david@club.com.au or david@club.nz
Expected result : Standard member
Actual result   : Employee

```

### 1 - Details of defect found

- Employee email predicated failed for @club.com.au

The employee predicate class is a validation that checks if a member email address is for someone who works at the club.

Employees can be members, but we want to flag that they are also employees.

example emails for employees include david@club.com and alice@club.com and this code works OK, but a billy@club.com.au [note the .AU] registered as a member and he is not an employee.

### 2 - Debugging steps to track the defect.

I went to the list of members and found a member who was also an employee `david@club.com` and changed the email address to `billy@club.com.au` and the flag for employee did not change.

So then went and created a new test for `billy@club.com.au`, see below and the test also failed.

**Test Failing**

![](predicate-failed-test.png)

**Unit Test Code**

The middle (or 2nd) test is the new test that was added is is currently failing.

![](./predicate-failed-code.png)

**Screen shot before**

The existing code checks if `"@club.com"` exists in the email address, this is fine for .com, but not good for `"@club.com.au" or "@club.com.xyz"`

![](./predicate-class-before-fix.png)

**Screen shot after**

Changed `.Contains` to `.EndsWith`

![](./predicate-class-after-fix.png)

### Test Results after Debugging

Test results after debugging: ALL GOOD

![](./predicate-success-test.png)   
