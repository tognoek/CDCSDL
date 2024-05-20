using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Data
    {
        public int? Age { get; set; }
        public string BusinessTravel { get; set; }
        public int? DailyRate { get; set; }
        public int? Department { get; set; }
        public int? DistanceFromHome { get; set; }
        public int? Education { get; set; }
        public int? EducationField { get; set; }
        public int? EnvironmentSatisfaction { get; set; }
        public string Gender { get; set; }
        public int? HourlyRate { get; set; }
        public int? JobInvolvement { get; set; }
        public int? JobLevel { get; set; }
        public int? JobRole { get; set; }
        public int? JobSatisfaction { get; set; }
        public string MaritalStatus { get; set; }
        public int? MonthlyIncome { get; set; }
        public int? MonthlyRate { get; set; }
        public int? NumCompaniesWorked { get; set; }
        public string Overtime { get; set; }
        public int? PercentSalaryHike { get; set; }
        public int? PerformanceRating { get; set; }
        public int? RelationshipSatisfaction { get; set; }
        public int? StockOptionLevel { get; set; }
        public int? TotalWorkingYears { get; set; }
        public int? TrainingTimesLastYear { get; set; }
        public int? WorkLifeBalance { get; set; }
        public int? YearsAtCompany { get; set; }
        public int? YearsInCurrentRole { get; set; }
        public int? YearsSinceLastPromotion { get; set; }
        public int? YearsWithCurrManager { get; set; }
        public string YourName { get; set; }
        public string YourEmail { get; set; }

        public string BusinessTravelCustom()
        {
            return BusinessTravel.Replace('_', ' ').Replace('-', ' ');
        }
    }

}