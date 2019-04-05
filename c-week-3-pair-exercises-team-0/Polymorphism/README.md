# Polymorphism

The purpose of this exercise is to provide you the opportunity to practice writing code using the principle of [polymorphism][what-is-polymorphism].

## Learning Objectives

After completing this exercise, students will understand:

* How to design and create interfaces.
* How to implement interfaces.
* How to use classes polymorphically.

## Evaluation Criteria & Functional Requirements

* The project must not have any build errors.
* Appropriate variable names and data types are being used.
* Code is presented in a clean, organized format.
* The principle of [polymorphism][what-is-polymorphism] is being applied appropriately.
* The code meets the specifications defined below.
* The output for each program matches what is defined in the requirements.

In order to practice applying polymorphism, your task is to create interface definitions and class implementations for the exercises defined below. In any of the cases, you may add attributes (i.e. properties) and other supporting methods to the classes in order to fully implement the interface.

**Notes for All Classes**

* X in the set column indicates it **should have a `set` accessor**.
* Nothing in the set column indicates the property is a [derived property][derived-properties].
* Readonly properties do not require a `set` accessor.
* Private setters require the property to have `private set`.

### IWorker Interface

| Property Name | Type     | Get | Set |
| ------------- | -------- | --- | --- |
| `FirstName`   | `string` | X   |     |
| `LastName`    | `string` | X   |     |

| Method                                | Return Type |
| ------------------------------------- | ----------- |
| `CalculateWeeklyPay(int hoursWorked)` | `double`    |

### SalaryWorker

Create a `SalaryWorker` class that implements the `IWorker` interface.

| Property Name  | Type     | Get | Set |
| -------------- | -------- | --- | --- |
| `AnnualSalary` | `double` | X   |     |

| Constructor                                                            |
| ---------------------------------------------------------------------- |
| `SalaryWorker(double annualSalary, string firstName, string lastName)` |

A salaried employee "is-a" worker. hoursWorked expresses the number of hours for which the salaried employee worked in a given week. Since employee salaries are based on a 40 hour week, any hours above or below 40 are ignored and the following formula is used to calculate the weekly salary:

> pay = annual salary / 52

### HourlyWorker

Create an `HourlyWorker` class that implements the `IWorker` interface.

| Property Name | Type     | Get | Set |
| ------------- | -------- | --- | --- |
| `HourlyRate`  | `double` | X   |     |

| Constructor                                                          |
| -------------------------------------------------------------------- |
| `HourlyWorker(double hourlyRate, string firstName, string lastName)` |

An hourly employee "is-a" worker whose hoursWorked express the number of hours the employee should be paid for.

> pay = hourly rate _ hoursWorked
> overtime = hoursWorked - 40
> pay = pay + (hourly rate _ overtime \* .5)

### VolunteerWorker

Create a `VolunteerWorker` class that implements the `IWorker` interface.

| Constructor                                          |
| ---------------------------------------------------- |
| `VolunteerWorker(string firstName, string lastName)` |

A volunteer "is-a" worker whose hoursWorked express the number of hours volunteered. There is no monetary amount associated with volunteers, but the hours are recorded as pay.

> pay = hoursWorked * 0

### Program

Following the approach discussed in the lecture, create a List that represents a company's payroll and holds a collection of workers in it. The objective will be to:

- output each employee, the number of hours they've worked (you can use a random number generator), and the amount they will be paid for the week
- at the end show the sum of total hours worked and total weekly payroll

_Expected Output_

```
Employee             Hours Worked           Pay
====================================================
Mouse, Mickey        90                     $750.00
Geef, George (Goofy) 90                     $0.00
Duck, Daisy          110                    $750.00
Mouse, Minnie        20                     $2100.00

Total Hours: 310
Total Pay: $3,600.00
```

## Getting Started

* Open the polymorphism-exercises-pair.sln solution in Visual Studio.
* Navigate to the project you want to work on.
* Open the Program.cs file, and begin providing enough code to begin running the application.
* The classes and interfaces you will be creating belong in each of the appropriate projects.
* Each of the programs will be a console application. This will be how you will verify your code works as expected.

## Tips and Tricks

* When writing your program, a question to ask yourself to ensure you are writing your code polymorphically is, "If a new requirement were provided, how much of my code will I need to change?" If the answer to this question is, "quite a bit", then you may have the opportunity to improve the quality of your code. Your code should be "open to extension, and closed for modification.[open-closed-principle]." In other words, what will happen if the Postal Service adds a new Economy delivery type? What would happen to the Toll Booth calculator if a new requirement were added for another type of vehicle?
* As you work on this assignment, you will need to verify that the application is working as expected for all of the scenarios outlined in the requirements. To do this, you will be practicing a form of testing referred to as ["Manual Testing"][what-is-manual-testing]. Ideally, you will write automated unit tests to verify the applications you work on behave as expected. However, manual testing is equally important, and is a skill that is important on software development teams.
* Be sure you are verifying all of the execution paths for the application you are working on. For instance, verify that the postage calculator determines the correct rate when the distance is greater than 500 miles, and when the distance is less than 500 miles. Verify that the rates for each of the classes is being calculated correctly as well. Use the rate tables specified in the requirements for guidance.

---

[derived-properties]: https://www.uml-diagrams.org/derived-property.html
[open-closed-principle]: https://stackify.com/solid-design-open-closed-principle/
[what-is-manual-testing]: https://www.toolsqa.com/software-testing/manual-testing/
[what-is-polymorphism]: http://book.techelevator.com/java/55-polymorphism/05-what-is-polymorphism.html
