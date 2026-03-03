# C# Task Manager – WinForms Desktop Application

## Overview

This project is a Windows desktop task management application developed using C# and .NET WinForms. The application allows users to create, track, and complete tasks with persistent data storage implemented through CSV file handling.

The purpose of this project was to reinforce core software engineering principles including object-oriented programming, modular UI design, and structured file I/O management within a desktop environment.

---

## Features

- Add new tasks
- Mark tasks as completed
- Persist tasks using CSV file storage
- Simple and responsive WinForms interface
- Separation of concerns between UI and data handling
- Object-oriented task modeling

---

## Technologies Used

- C#
- .NET Framework / .NET WinForms
- Windows Forms (GUI)
- CSV File Handling (System.IO)
- Object-Oriented Programming Principles

---

## Project Structure

- `Program.cs` – Application entry point
- `MainForm.cs` – Main application interface
- `AddTaskForm.cs` – Form for creating new tasks
- `CompleteTaskForm.cs` – Form for marking tasks complete
- `TaskItem.cs` – Task data model
- `CsvTasks.cs` – CSV persistence and file management
- `Tasks.sln` – Visual Studio solution file

---

## How to Run

1. Clone the repository:
git clone https://github.com/nicolio03/yTask-Manager.git
2. Open `Tasks.sln` in Visual Studio.
3. Build the solution.
4. Click **Start** (or press F5).

### Option 2 – Command Line (if .NET SDK is installed)

Navigate to the project directory and run:
dotnet build
dotnet run

---

## Design Highlights

- Uses object-oriented design for task modeling.
- Implements file-based persistence using structured CSV handling.
- Separates UI forms from data management logic.
- Demonstrates understanding of desktop application architecture in .NET.

---

## Future Improvements

- Replace CSV with database persistence (SQLite or SQL Server)
- Add task priority levels
- Add due dates and filtering
- Improve UI styling and UX feedback
- Add unit testing

---

## Author

Developed by Nicole Ostrander
Computer Science Student  
### Option 1 – Visual Studio

1. Clone the repository:
