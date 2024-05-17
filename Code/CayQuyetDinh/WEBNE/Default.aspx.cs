using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AnalysisServices.AdomdClient;

namespace WEBNE
{
    public partial class _Default : Page
    {
        AdomdConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            string serverName = "TOGNOEK\\MSSQLSERVER_2019"; 
            string databaseName = "CayQuyetDinh"; 

            //string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True;";
            string connectionString = $"Provider=MSOLAP;Data Source={serverName};Initial Catalog={databaseName};Integrated Security=SSPI;";

            try
            {
                connection = new AdomdConnection(connectionString);
                {
                    connection.Open();
                    DropDownList1.Items.Clear();
                    AdomdCommand command;
                    AdomdDataReader reader;
                    string mdxQuery;
                    mdxQuery = @"SELECT DISTINCT [Sex] as S FROM [Db GIUAKY]";
                    command = new AdomdCommand(mdxQuery, connection);
                    {
                        reader = command.ExecuteReader();
                        {
                            reader.Read();
                            while (reader.Read())
                            {
                                string Sex = reader["S"].ToString();
                                DropDownList1.Items.Add(new ListItem(Sex, Sex));
                            }
                        }
                        reader.Close();
                    }
                    mdxQuery = @"SELECT DISTINCT [Blood Pressure] as B FROM [Db GIUAKY]";
                    command = new AdomdCommand(mdxQuery, connection);
                    {
                        reader = command.ExecuteReader();
                        {
                            reader.Read();
                            while (reader.Read())
                            {
                                string B = reader["B"].ToString();
                                DropDownList2.Items.Add(new ListItem(B, B));
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Loi";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string textBox1Value = TextBox1.Text;
            string dropDownList1Value = DropDownList1.SelectedValue;
            string dropDownList2Value = DropDownList2.SelectedValue;
            string textBox2Value = TextBox2.Text;
            string textBox3Value = TextBox3.Text;
            string textBox4Value = TextBox4.Text;
            string textBox5Value = TextBox5.Text;
            string textBox6Value = TextBox6.Text;
            string sql = @"SELECT"+
                      "[Db GIUAKY].[Heart Attack Risk],"+
                       "PredictProbability([Db GIUAKY].[Heart Attack Risk])" +
                     "From" +
                       "[Db GIUAKY]" +
                     "NATURAL PREDICTION JOIN" +
                     "(SELECT "+ textBox1Value +" AS[Age], '" +
                       dropDownList2Value+ "'AS[Blood Pressure], " +
                       textBox2Value + " AS[Diabetes], " +
                      textBox3Value + " AS[Family History], '" +
                       dropDownList1Value + "' AS[Sex], " +
                       textBox4Value + " AS[Smoking], " +
                       textBox5Value +  " AS[Stress Level], " +
                        textBox6Value + " AS[Triglycerides]) AS t";
            try
            {
                AdomdCommand command;
                AdomdDataReader reader;
                string mdxQuery;
                mdxQuery = sql;
                command = new AdomdCommand(mdxQuery, connection);
                {
                    reader = command.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            string Sex = reader["Heart Attack Risk"].ToString();
                            Label1.Text = Sex;
                            //DropDownList1.Items.Add(new ListItem(Sex, Sex));
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ee) {
                Label1.Text = sql;
            }
            //Label1.Text = sql;
        }
    }
}