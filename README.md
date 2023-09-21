# prog6212-task-1

Readme: Time Management Application Introduction This is a time management application designed to help students organize their semester workload efficiently. The application was inspired by a desire to assist students like Lerato, who often find themselves overwhelmed with coursework and tight deadlines. Sipho, the developer of this application, understands the importance of time management and aims to make it easier for students to balance their academic responsibilities and personal life.

Features Module Management The application allows users to add and manage multiple modules for the semester. Each module is defined by the following attributes:

Code: A unique identifier for the module (e.g., PROG6212). Name: The name or title of the module (e.g., Programming 2B). Number of Credits: The credit value of the module (e.g., 15). Class Hours Per Week: The number of hours spent in class each week (e.g., 5). Semester Configuration

Users can configure the semester by specifying:

Number of Weeks: The total number of weeks in the semester. Start Date: The start date for the first week of the semester. Self-Study Hours Calculation The application calculates and displays the number of hours of self-study required for each module per week. This calculation is based on the following formula:

The application displays the remaining self-study hours for each module for the current week. This calculation takes into account the number of hours already recorded on specific days during the current week.

Data Storage Important: The application does not persist user data between runs. All data is stored in memory while the application is running.

A custom class library has been created to encapsulate data-related classes and calculations. The WPF application project references this custom class library.

Contribution and Feedback Contributions to this project are welcome. If you have any feedback, suggestions, or encounter any issues, please feel free to open an issue or create a pull request on the GitHub repository.

Thank you for using the Time Management Application. We hope it helps you better organize your academic life and achieve a healthier work-life balance.