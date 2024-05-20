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

        private string ExecuteCluster(Data data)
        {
            StringBuilder sqlBuilder = new StringBuilder();

            sqlBuilder.Append(@"SELECT Cluster() as Nhom, ClusterDistance() as TyLe FROM [Employee Ananlysis Cluster] NATURAL PREDICTION JOIN (SELECT ");

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
            if (!string.IsNullOrEmpty(data.Gender) && data.Gender != "0")
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
            if (!string.IsNullOrEmpty(data.MaritalStatus) && data.MaritalStatus != "0")
                columns.Add($"'{data.MaritalStatus}' AS [Marital Status]");
            if (data.MonthlyIncome.HasValue)
                columns.Add($"{data.MonthlyIncome.Value} AS [Monthly Income]");
            if (data.MonthlyRate.HasValue)
                columns.Add($"{data.MonthlyRate.Value} AS [Monthly Rate]");
            if (data.NumCompaniesWorked.HasValue)
                columns.Add($"{data.NumCompaniesWorked.Value} AS [Num Companies Worked]");
            if (!string.IsNullOrEmpty(data.Overtime) && data.Overtime != "0")
                columns.Add($"'{data.Overtime}' AS [Over Time]");
            if (data.PercentSalaryHike.HasValue)
                columns.Add($"{data.PercentSalaryHike.Value} AS [Percent Salary Hike]");
            if (data.PerformanceRating.HasValue && data.PerformanceRating != 0)
                columns.Add($"{data.PerformanceRating.Value} AS [Performance Rating]");
            if (data.RelationshipSatisfaction.HasValue && data.RelationshipSatisfaction != 0)
                columns.Add($"{data.RelationshipSatisfaction.Value} AS [Relationship Satisfaction]");
            if (data.StockOptionLevel.HasValue && data.StockOptionLevel != -1)
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

        private string BuildSqlQuery(Data data, string Enanlysis)
        {
            StringBuilder sqlBuilder = new StringBuilder();

            sqlBuilder.Append($@"SELECT [{Enanlysis}].[Attrition], PredictProbability([{Enanlysis}].[Attrition]) as Expression FROM [{Enanlysis}] NATURAL PREDICTION JOIN (SELECT ");

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
            if (!string.IsNullOrEmpty(data.Gender) && data.Gender != "0")
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
            if (!string.IsNullOrEmpty(data.MaritalStatus) && data.MaritalStatus != "0")
                columns.Add($"'{data.MaritalStatus}' AS [Marital Status]");
            if (data.MonthlyIncome.HasValue)
                columns.Add($"{data.MonthlyIncome.Value} AS [Monthly Income]");
            if (data.MonthlyRate.HasValue)
                columns.Add($"{data.MonthlyRate.Value} AS [Monthly Rate]");
            if (data.NumCompaniesWorked.HasValue)
                columns.Add($"{data.NumCompaniesWorked.Value} AS [Num Companies Worked]");
            if (!string.IsNullOrEmpty(data.Overtime) && data.Overtime != "0")
                columns.Add($"'{data.Overtime}' AS [Over Time]");
            if (data.PercentSalaryHike.HasValue)
                columns.Add($"{data.PercentSalaryHike.Value} AS [Percent Salary Hike]");
            if (data.PerformanceRating.HasValue && data.PerformanceRating != 0)
                columns.Add($"{data.PerformanceRating.Value} AS [Performance Rating]");
            if (data.RelationshipSatisfaction.HasValue && data.RelationshipSatisfaction != 0)
                columns.Add($"{data.RelationshipSatisfaction.Value} AS [Relationship Satisfaction]");
            if (data.StockOptionLevel.HasValue && data.StockOptionLevel != -1)
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
        private List<GetClusterProfiles> getClusterProfiles()
        {
            List<GetClusterProfiles> res = new List<GetClusterProfiles>();

            try
            {
                AdomdCommand command;
                AdomdDataReader reader;
                string mdxQuery;
                mdxQuery = @"CALL System.Microsoft.AnalysisServices.System.DataMining.Clustering.GetClusterProfiles ('Employee Ananlysis Cluster', '30',0.0005)";
                command = new AdomdCommand(mdxQuery, connection);
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GetClusterProfiles attributeData = new GetClusterProfiles();
                        attributeData.AttributeName = reader["AttributeName"].ToString();
                        attributeData.AttributeValue = reader["AttributeValue"].ToString();
                        attributeData.AttributeValueType = reader["AttributeValueType"].ToString();
                        attributeData.ValueTag = reader["ValueTag"].ToString();
                        attributeData.Marginal = Convert.ToDouble(reader["Marginal"]);
                        attributeData.Value002 = Convert.ToDouble(reader["002"]);
                        attributeData.Value001 = Convert.ToDouble(reader["001"]);
                        attributeData.Value004 = Convert.ToDouble(reader["004"]);
                        attributeData.Value005 = Convert.ToDouble(reader["005"]);
                        attributeData.Value006 = Convert.ToDouble(reader["006"]);
                        attributeData.Value009 = Convert.ToDouble(reader["009"]);
                        attributeData.Value003 = Convert.ToDouble(reader["003"]);
                        attributeData.Value007 = Convert.ToDouble(reader["007"]);
                        attributeData.Value010 = Convert.ToDouble(reader["010"]);
                        attributeData.Value008 = Convert.ToDouble(reader["008"]);
                        res.Add(attributeData);
                    }
                    reader.Close();
                }
                return res;
            }
            catch (Exception e)
            {
                return res;
            }
        }

        private string getTyLe(List<GetClusterProfiles> data, string name, string value, string tag, int id)
        {
            foreach(var item in data)
            {
                if (item.AttributeName == name && item.AttributeValue == value && item.ValueTag == tag)
                {
                    double val = item.getValues(id);
                    string res = val.ToString().Substring(2, 2) + "." + val.ToString().Substring(4, 2) + "%";
                    return res;
                }
            }
            return "67.23%";
        }

        private string getMaxTyLe(List<GetClusterProfiles> data, string name, string value, string tag)
        {
            foreach (var item in data)
            {
                if (item.AttributeName == name && item.AttributeValue == value && item.ValueTag == tag)
                {
                    double val = item.maxValue();
                    string res = val.ToString().Substring(2, 2) + "." + val.ToString().Substring(4, 2) + "%";
                    return res;
                }
            }
            return "67.23%";
        }

        private string getMax(List<GetClusterProfiles> data, string name, string tag, int nhom)
        {
            foreach (var item in data)
            {
                if (item.AttributeName == name && item.ValueTag == tag)
                {
                    double val = item.maxValue(nhom);
                    int valI = (int)val;
                    return valI.ToString();
                }
            }
            return "67.23%";
        }

        private int getMaxInt(List<GetClusterProfiles> data, string name, string tag,int nhom)
        {
            foreach (var item in data)
            {
                if (item.AttributeName == name && item.ValueTag == tag)
                {
                    double val = item.maxValue(nhom);
                    int valI = (int)val;
                    return valI;
                }
            }
            return 63;
        }

        private string Replace(string input)
        {
            return input.Replace('_', ' ').Replace('-', ' ');
        }

        private string getMaxVal(List<GetClusterProfiles> data, string name, string tag)
        {
            double max = -11;
            GetClusterProfiles itemne = null;
            foreach (var item in data)
            {
                if (item.AttributeName == name && item.ValueTag == tag)
                {
                    double val = item.maxValue();
                    int valI = (int)val;
                    if (val > max)
                    {
                        max = val;
                        itemne = item;
                    }
                }
            }
            return itemne.AttributeValue;
        }

        private int getMaxId(List<GetClusterProfiles> data, string name, string value, string tag)
        {
            foreach (var item in data)
            {
                if (item.AttributeName == name && item.AttributeValue == value && item.ValueTag == tag)
                {
                    return item.Idmax();
                }
            }
            return 6;
        }
        private List<LoiKhuyen> TaoLoiKhhuyen(Data data, List<Send> Sends)
        {
            List<LoiKhuyen> res = new List<LoiKhuyen>();
            double TyLeNghiViec = (double)db.EmployeeAnanlysis.Count(e => e.Attrition == true) / db.EmployeeAnanlysis.Count();
            LoiKhuyen re = new LoiKhuyen
            {
                Name = "Tỷ lệ nghỉ việc",
                Detail = "Hiện nay, tỷ lệ nghỉ việc đang là " + TyLeNghiViec.ToString().Substring(2, 2) + "." + TyLeNghiViec.ToString().Substring(4, 2) + "%"
            };

            res.Add(re);
            List<GetClusterProfiles> getClusterProfile = getClusterProfiles();
            int nhom = 10;
            try
            {
                AdomdCommand command;
                AdomdDataReader reader;
                string mdxQuery;
                mdxQuery = ExecuteCluster(data);
                command = new AdomdCommand(mdxQuery, connection);
                reader = command.ExecuteReader();
                reader.Read();
                nhom = int.Parse(reader["Nhom"].ToString().Substring(8));
                re = new LoiKhuyen
                {
                    Name = "Phân nhóm của bạn",
                    Detail = "Bạn thuộc vào nhóm với lỷ lệ tiếp tục đi làm là: " + getTyLe(getClusterProfile, "Attrition", "False", "Probability", nhom)
                };
                res.Add(re);
                re = new LoiKhuyen
                {
                    Name = "Tỷ lệ tốt nhất",
                    Detail = "Nhóm có tỷ lệ tốt nhất đang là: " + getMaxTyLe(getClusterProfile, "Attrition", "False", "Probability")
                };
                res.Add(re);
                re = new LoiKhuyen
                {
                    Name = "Độ tuổi kiên trì",
                    Detail = "Với độ tuổi " + getMax(getClusterProfile, "Age", "Mean", nhom) + " thì tỷ lệ nghỉ việc khá thấp"
                };
                res.Add(re);
            }
            catch (Exception e)
            {

            }
            SendEmail(data, getClusterProfile, getMaxId(getClusterProfile, "Attrition", "False", "Probability"), Sends);
            return res;
        }

        private string BodyMail(Data data, List<GetClusterProfiles> list,int nhom, List<Send> Sends)
        {
            string[] Education = {"Trung học", "Cao học", "Đại học", "Thạc sĩ", "Tiến sĩ"};
            string htmlTable = @"
            <html>
            <body>
                <h2>Dưới đây là bảng dữ liệu dựa trên giá trị bạn cung cấp</h2>
                <table border='1'>
                    <tr>
                        <th></th>
                        <th>Giá trị của bạn gửi</th>
                        <th>Giá trị hệ thống</th>
                    </tr>";
            if (data.Age.HasValue)
            {
                htmlTable += $@"<tr> 
                                    <th>Tuổi</th>
                                    <th>{data.Age.Value}</th>
                                    <th>{getMax(list, "Age", "Mean", nhom)}</th>
                            </tr>";
            }
            else
            {
                htmlTable += $@"<tr> 
                                    <th>Tuổi</th>
                                    <th></th>
                                    <th>{getMax(list, "Age", "Mean", nhom)}</th>
                            </tr>";
            }
            if (!string.IsNullOrEmpty(data.BusinessTravel) && data.BusinessTravel != "0")
            {
                htmlTable += $@"<tr> 
                                    <th>Tần suất đi công tác</th>
                                    <th>{data.BusinessTravelCustom()}</th>
                                    <th>{Replace(getMaxVal(list, "Business Travel", "Probability"))}</th>
                            </tr>";
            }
            else
            {
                htmlTable += $@"<tr> 
                                    <th>Tần suất đi công tác</th>
                                    <th></th>
                                    <th>{Replace(getMaxVal(list, "Business Travel", "Probability"))}</th>
                            </tr>";
            }
            if (data.DailyRate.HasValue)
            {
                htmlTable += $@"<tr> 
                                    <th>Mức lương hàng ngày</th>
                                    <th>{data.DailyRate.Value}</th>
                                    <th>{getMaxInt(list, "Daily Rate", "Mean", nhom)}</th>
                            </tr>";
            }
            else
            {
                htmlTable += $@"<tr> 
                                    <th>Mức lương hàng ngày</th>
                                    <th></th>
                                    <th>{getMaxInt(list, "Daily Rate", "Mean", nhom)}</th>
                            </tr>";
            }
            int idDepartment = getMaxInt(list, "Department Id", "Mean", nhom);

            if (data.Department.HasValue && data.Department != 0)
            {
                htmlTable += $@"<tr> 
                                    <th>Phòng ban</th>
                                    <th>{db.Department.Where(d => d.Id == data.Department.Value).FirstOrDefault().Name}</th>
                                    <th>{db.Department.Where(d => d.Id == idDepartment).FirstOrDefault().Name}</th>
                            </tr>";
            }
            else
            {
                htmlTable += $@"<tr> 
                                    <th>Phòng ban</th>
                                    <th></th>
                                    <th>{db.Department.Where(d => d.Id == idDepartment).FirstOrDefault().Name}</th>
                            </tr>";
            }
            if (data.DistanceFromHome.HasValue)
            {
                htmlTable += $@"<tr> 
                                    <th>Khảng cách di chuyển</th>
                                    <th>{data.DistanceFromHome.Value}</th>
                                    <th>{getMaxInt(list, "Distance From Home", "Mean", nhom)}</th>
                            </tr>";
            }
            else
            {
                htmlTable += $@"<tr> 
                                    <th>Khảng cách di chuyển</th>
                                    <th></th>
                                    <th>{getMaxInt(list, "Distance From Home", "Mean", nhom)}</th>
                            </tr>";
            }
            if (data.Education.HasValue && data.Education != 0)
            {
                htmlTable += $@"<tr> 
                                    <th>Trình độ học vấn</th>
                                    <th>{Education[data.Education.Value - 1]}</th>
                                    <th>{Education[getMaxInt(list, "Education", "Mean", nhom) - 1]}</th>
                            </tr>";
            }
            else
            {
                htmlTable += $@"<tr> 
                                    <th>Trình độ học vấn</th>
                                    <th></th>
                                    <th>{Education[getMaxInt(list, "Education", "Mean", nhom) - 1]}</th>
                            </tr>";
            }
            int idEducationField = getMaxInt(list, "Education Field Id", "Mean", nhom);

            if (data.EducationField.HasValue && data.EducationField != 0)
            {
                htmlTable += $@"<tr> 
                                    <th>Ngành học</th>
                                    <th>{db.EducationField.Where(d => d.Id == data.EducationField.Value).FirstOrDefault().Name}</th>
                                    <th>{db.EducationField.Where(d => d.Id == idEducationField).FirstOrDefault().Name}</th>
                            </tr>";
            }
            else
            {
                htmlTable += $@"<tr> 
                                    <th>Ngành học</th>
                                    <th></th>
                                    <th>{db.EducationField.Where(d => d.Id == idEducationField).FirstOrDefault().Name}</th>
                            </tr>";
            }
            htmlTable += @"</table>
                    <br><br>
                    <h2> Bảng kết quả của bạn</h2>
                    <table border='1'>
                        <tr>
                            <th>Phương thức</th>
                            <th>Kết quả</th>
                            <th>Tỷ lệ</th>
                        </tr>";
            foreach (var item in Sends)
            {
                htmlTable += $@"<tr>
                                    <th>{item.phuongthuc}</th>
                                    <th>{item.ketqua}</th>
                                    <th>{item.tognoek}</th>
                                </tr>";
            }
            htmlTable += @"
                    </table>
                </body>
                </html>";
            return htmlTable;
        }
        private bool SendEmail(Data data, List<GetClusterProfiles> list, int nhom, List<Send> Sends)
        {
            string fromEmail = "zgye28102003@gmail.com";
            string password = "lityystgpllhguuk";
            MailMessage mail = new MailMessage();
            mail.To.Add(data.YourEmail);
            mail.From = new MailAddress(fromEmail);
            mail.Subject = "Xin chào " + data.YourName;
            mail.IsBodyHtml = true;
            mail.Body = BodyMail(data, list, nhom, Sends);

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

        private bool SendEmail(string Email, string Name)
        {
            string fromEmail = "zgye28102003@gmail.com";
            string password = "lityystgpllhguuk";
            MailMessage mail = new MailMessage();
            mail.To.Add(Email);
            mail.From = new MailAddress(fromEmail);
            mail.Subject = "Xin chào " + Name;
            mail.IsBodyHtml = true;
            mail.Body = "Cảm ơn nhưng ý kiến mà bạn gửi cho chúng tôi nha";

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

        private List<Send> Execute(Data data)
        {
            string[] EmployeeTable = { "Employee Ananlysis", "Employee Ananlysis Logistic Regression", "Employee Ananlysis Neural" };
            string[] EmployeeName = { "Decision Trees", "Logistic Regression", "Neural Network" };
            string[] ketqua = {"Bạn tiếp tục đi làm", "Bạn sẽ nghỉ việc" };
            List<Send> res = new List<Send>();
            if (ConnetAnnalysis())
            {
                try
                {
                    AdomdCommand command;
                    AdomdDataReader reader;
                    string mdxQuery;
                    for (int i = 0; i < 3; i++)
                    {
                        mdxQuery = BuildSqlQuery(data, EmployeeTable[i]);
                        command = new AdomdCommand(mdxQuery, connection);
                        Send resSend = new Send
                        {
                            ketqua = "Lỗi No Data",
                            tognoek = "Lỗi"
                        };
                        {
                            reader = command.ExecuteReader();
                            {
                                reader.Read();
                                resSend.ketqua = reader["Attrition"].ToString().Trim().ToLower() == "false" ? ketqua[0] : ketqua[1];
                                resSend.tognoek = reader["Expression"].ToString().Substring(2, 2) + "." + reader["Expression"].ToString().Substring(4, 2) + "%";
                            }
                            reader.Close();
                        }
                        resSend.phuongthuc = EmployeeName[i];
                        res.Add(resSend);
                    }
                    return res;
                }
                catch (Exception e)
                {
                    return res;
                }
            }
            return res;
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
                ResSend res = new ResSend
                {
                    Sends = Execute(data),
                    LoiKhuyens = TaoLoiKhhuyen(data, Execute(data))
                };
                return View(res);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route(ENV.ROUTE.SEND_EMAIL)]
        public ActionResult Email(Email data)
        {
            if (ModelState.IsValid)
            {
                SendEmail(data.email, data.name);
            }
            return RedirectToAction("Index");
        }

    }
}