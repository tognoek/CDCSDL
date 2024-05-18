using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.AnalysisServices.AdomdClient;
using WebApplication.Models;
using System.Net;
using System.Net.Mail;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        AdomdConnection connection;
        IBM_EmployeeEntities db = new IBM_EmployeeEntities();

        private string BuildSqlQuery(Data data)
        {
            StringBuilder sqlBuilder = new StringBuilder();

            sqlBuilder.Append(@"SELECT [Employee Ananlysis Neural].[Attrition], PredictProbability([Employee Ananlysis Neural].[Attrition]) as Expression FROM [Employee Ananlysis Neural] NATURAL PREDICTION JOIN (SELECT ");

            List<string> columns = new List<string>();

            if (data.Age.HasValue)
                columns.Add($"{data.Age.Value} AS [Age]");
            if (!string.IsNullOrEmpty(data.BusinessTravel) && data.BusinessTravel != "0")
                columns.Add($"'{data.BusinessTravel}' AS [Business Travel]");
            if (data.DailyRate.HasValue)
                columns.Add($"{data.DailyRate.Value} AS [Daily Rate]");
            if (data.Department.HasValue && data.Department != 0)
                columns.Add($"{data.Department.Value} AS [Department Id]");
            if (data.DistanceFromHome.HasValue)
                columns.Add($"{data.DistanceFromHome.Value} AS [Distance From Home]");
            if (data.Education.HasValue && data.Education != 0)
                columns.Add($"{data.Education.Value} AS [Education]");
            if (data.EducationField.HasValue && data.EducationField != 0)
                columns.Add($"{data.EducationField.Value} AS [Education Field Id]");
            if (data.EnvironmentSatisfaction.HasValue && data.EnvironmentSatisfaction != 0)
                columns.Add($"{data.EnvironmentSatisfaction.Value} AS [Environment Satisfaction]");
            if (!string.IsNullOrEmpty(data.Gender))
                columns.Add($"'{data.Gender}' AS [Gender]");
            if (data.HourlyRate.HasValue)
                columns.Add($"{data.HourlyRate.Value} AS [Hourly Rate]");
            if (data.JobInvolvement.HasValue && data.JobInvolvement != 0)
                columns.Add($"{data.JobInvolvement.Value} AS [Job Involvement]");
            if (data.JobLevel.HasValue && data.JobLevel != 0)
                columns.Add($"{data.JobLevel.Value} AS [Job Level]");
            if (data.JobRole.HasValue && data.JobRole != 0)
                columns.Add($"{data.JobRole.Value} AS [Job Role Id]");
            if (data.JobSatisfaction.HasValue && data.JobSatisfaction != 0)
                columns.Add($"{data.JobSatisfaction.Value} AS [Job Satisfaction]");
            if (!string.IsNullOrEmpty(data.MaritalStatus))
                columns.Add($"'{data.MaritalStatus}' AS [Marital Status]");
            if (data.MonthlyIncome.HasValue)
                columns.Add($"{data.MonthlyIncome.Value} AS [Monthly Income]");
            if (data.MonthlyRate.HasValue)
                columns.Add($"{data.MonthlyRate.Value} AS [Monthly Rate]");
            if (data.NumCompaniesWorked.HasValue)
                columns.Add($"{data.NumCompaniesWorked.Value} AS [Num Companies Worked]");
            if (!string.IsNullOrEmpty(data.Overtime))
                columns.Add($"'{data.Overtime}' AS [Over Time]");
            if (data.PercentSalaryHike.HasValue)
                columns.Add($"{data.PercentSalaryHike.Value} AS [Percent Salary Hike]");
            if (data.PerformanceRating.HasValue && data.PerformanceRating != 0)
                columns.Add($"{data.PerformanceRating.Value} AS [Performance Rating]");
            if (data.RelationshipSatisfaction.HasValue && data.RelationshipSatisfaction != 0)
                columns.Add($"{data.RelationshipSatisfaction.Value} AS [Relationship Satisfaction]");
            if (data.StockOptionLevel.HasValue && data.StockOptionLevel != 0)
                columns.Add($"{data.StockOptionLevel.Value} AS [Stock Option Level]");
            if (data.TotalWorkingYears.HasValue)
                columns.Add($"{data.TotalWorkingYears.Value} AS [Total Working Years]");
            if (data.TrainingTimesLastYear.HasValue)
                columns.Add($"{data.TrainingTimesLastYear.Value} AS [Training Times Last Year]");
            if (data.WorkLifeBalance.HasValue && data.WorkLifeBalance != 0)
                columns.Add($"{data.WorkLifeBalance.Value} AS [Work Life Balance]");
            if (data.YearsAtCompany.HasValue)
                columns.Add($"{data.YearsAtCompany.Value} AS [Years At Company]");
            if (data.YearsInCurrentRole.HasValue)
                columns.Add($"{data.YearsInCurrentRole.Value} AS [Years In Current Role]");
            if (data.YearsSinceLastPromotion.HasValue)
                columns.Add($"{data.YearsSinceLastPromotion.Value} AS [Years Since Last Promotion]");
            if (data.YearsWithCurrManager.HasValue)
                columns.Add($"{data.YearsWithCurrManager.Value} AS [Years With Curr Manager]");

            sqlBuilder.Append(string.Join(", ", columns));
            sqlBuilder.Append(") AS t");

            return sqlBuilder.ToString();
        }

        private bool SendEmail(Data data)
        {
            string fromEmail = "zgye28102003@gmail.com";
            string password = "lityystgpllhguuk";
            MailMessage mail = new MailMessage();
            mail.To.Add(data.YourEmail);
            mail.From = new MailAddress(fromEmail);
            mail.Subject = "Xin chào " + data.YourName;
            mail.Body = "tognoek";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromEmail, password);
            try
            {

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool ConnetAnnalysis()
        {
            string serverName = "TOGNOEK\\MSSQLSERVER_2019";
            string databaseName = "Multidimensional";

            //string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True;";
            string connectionString = $"Provider=MSOLAP;Data Source={serverName};Initial Catalog={databaseName};Integrated Security=SSPI;";
            try
            {
                connection = new AdomdConnection(connectionString);
                connection.Open();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private Send Execute(Data data)
        {
            if (ConnetAnnalysis())
            {
                try
                {
                    AdomdCommand command;
                    AdomdDataReader reader;
                    string mdxQuery;
                    mdxQuery = BuildSqlQuery(data);
                    command = new AdomdCommand(mdxQuery, connection);
                    Send res = new Send
                    {
                        ketqua = "Lỗi No Data",
                        tognoek = "Lỗi",
                        Email = "Chưa gửi"
                    };
                    {
                        reader = command.ExecuteReader();
                        {
                            reader.Read();
                            res.ketqua = reader["Attrition"].ToString();
                            res.tognoek = reader["Expression"].ToString();
                        }
                        reader.Close();
                    }
                    res.Email = SendEmail(data) ? "Đã gửi" : "Chưa gửi";
                    return res;
                }
                catch (Exception e)
                {
                    return new Send
                    {
                        ketqua = "Lỗi Execute",
                        tognoek = BuildSqlQuery(data),
                        Email = "Chưa gửi"
                    };
                }
            }
            return new Send
            {
                ketqua = "Lỗi Connet",
                tognoek = "Lỗi",
                Email = "Chưa gửi"
            };
        }



        private Index GetIndex()
        {
            Index Res = new Index
            {
                EducationFields = db.EducationField.ToList(),
                JobRoles = db.JobRole.ToList(),
                Departments = db.Department.ToList()
            };
            return Res;
        }


        [HttpGet]
        [Route(ENV.ROUTE.PAGE_INDEX)]
        public ActionResult Index(Data data)
        {
            return View(GetIndex());
        }

        [HttpPost]
        [Route(ENV.ROUTE.PAGE_SEND)]
        public ActionResult Send(Data data)
        {
            if (ModelState.IsValid)
            {
                return View(Execute(data));
            }
            return RedirectToAction("Index");
        }

    }
}