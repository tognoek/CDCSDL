USE master
GO
DROP DATABASE IF EXISTS IBM_Employee
GO
CREATE DATABASE IBM_Employee
GO
USE IBM_Employee
GO

CREATE TABLE "EducationField"(
	"Id" int PRIMARY KEY IDENTITY(1, 1),
	"Name" nvarchar(255) NOT NULL,
)
CREATE TABLE "JobRole"(
	"Id" int PRIMARY KEY IDENTITY(1, 1),
	"Name" nvarchar(255) NOT NULL
)
CREATE TABLE "Department"(
	"Id" int PRIMARY KEY IDENTITY(1, 1),
	"Name" nvarchar(255) NOT NULL
)
CREATE TABLE "EmployeeAnanlysis" (
	"Id" int PRIMARY KEY IDENTITY(1, 1),
    "Age" int NOT NULL,
    "Attrition" bit NOT NULL,
    "BusinessTravel" nvarchar(255) NOT NULL,
    "DailyRate" int NOT NULL,
    "DistanceFromHome" int NOT NULL,
    "Education" int NOT NULL,
    "EmployeeCount" int NOT NULL,
    "EmployeeNumber" int NOT NULL DEFAULT 1,
    "EnvironmentSatisfaction" int NOT NULL,
    "Gender" bit NOT NULL,
    "HourlyRate" int NOT NULL,
    "JobInvolvement" int NOT NULL,
    "JobLevel" int NOT NULL,
    "JobSatisfaction" int NOT NULL,
    "MaritalStatus" nvarchar(255) NOT NULL,
    "MonthlyIncome" int NOT NULL,
    "MonthlyRate" int NOT NULL,
    "NumCompaniesWorked" int NOT NULL,
    "Over18" bit NOT NULL,
    "OverTime" bit NOT NULL,
    "PercentSalaryHike" int NOT NULL,
    "PerformanceRating" int NOT NULL,
    "RelationshipSatisfaction" int NOT NULL,
    "StandardHours" int NOT NULL,
    "StockOptionLevel" int NOT NULL,
    "TotalWorkingYears" int NOT NULL,
    "TrainingTimesLastYear" int NOT NULL,
    "WorkLifeBalance" int NOT NULL,
    "YearsAtCompany" int NOT NULL,
    "YearsInCurrentRole" int NOT NULL,
    "YearsSinceLastPromotion" int NOT NULL,
    "YearsWithCurrManager" int NOT NULL,
	"DepartmentId" int NOT NULL,
	"EducationFieldId" int NOT NULL,
	"JobRoleId" int NOT NULL
    FOREIGN KEY ("DepartmentId") REFERENCES Department(Id),
    FOREIGN KEY ("EducationFieldId") REFERENCES EducationField(Id),
    FOREIGN KEY ("JobRoleId") REFERENCES JobRole(Id)
)
SELECT * FROM "EmployeeAnanlysis"