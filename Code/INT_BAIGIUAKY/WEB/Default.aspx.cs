using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AnalysisServices.AdomdClient;

namespace WEB
{
    public partial class _Default : Page
    {
        AdomdConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            string serverName = "TOGNOEK\\MSSQLSERVER_2019";
            string databaseName = "Multidimensional_GIUAKY";

            //string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True;";
            string connectionString = $"Provider=MSOLAP;Data Source={serverName};Initial Catalog={databaseName};Integrated Security=SSPI;";

            try
            {
                connection = new AdomdConnection(connectionString);
                {
                    connection.Open();
                    AdomdCommand command;
                    AdomdDataReader reader;
                    string mdxQuery;
                    mdxQuery = @"SELECT DISTINCT [gender] as A FROM [Tb DATASET]";
                    DropDownList1.Items.Clear();
                    command = new AdomdCommand(mdxQuery, connection);
                    {
                        reader = command.ExecuteReader();
                        {
                            reader.Read();
                            while (reader.Read())
                            {
                                string name = reader["A"].ToString();
                                DropDownList1.Items.Add(new ListItem(name, name));
                            }
                        }
                        reader.Close();
                    }
                    mdxQuery = @"SELECT DISTINCT [education] as A FROM [Tb DATASET]";
                    DropDownList2.Items.Clear();
                    command = new AdomdCommand(mdxQuery, connection);
                    {
                        reader = command.ExecuteReader();
                        {
                            reader.Read();
                            while (reader.Read())
                            {
                                string name = reader["A"].ToString();
                                DropDownList2.Items.Add(new ListItem(name, name));
                            }
                        }
                        reader.Close();
                    }
                    mdxQuery = @"SELECT DISTINCT [region] as A FROM [Tb DATASET]";
                    DropDownList3.Items.Clear();
                    command = new AdomdCommand(mdxQuery, connection);
                    {
                        reader = command.ExecuteReader();
                        {
                            reader.Read();
                            while (reader.Read())
                            {
                                string name = reader["A"].ToString();
                                DropDownList3.Items.Add(new ListItem(name, name));
                            }
                        }
                        reader.Close();
                    }
                    mdxQuery = @"SELECT DISTINCT [loyalty status] as A FROM [Tb DATASET]";
                    DropDownList4.Items.Clear();
                    command = new AdomdCommand(mdxQuery, connection);
                    {
                        reader = command.ExecuteReader();
                        {
                            reader.Read();
                            while (reader.Read())
                            {
                                string name = reader["A"].ToString();
                                DropDownList4.Items.Add(new ListItem(name, name));
                            }
                        }
                        reader.Close();
                    }
                    mdxQuery = @"SELECT DISTINCT [purchase frequency] as A FROM [Tb DATASET]";
                    DropDownList5.Items.Clear();
                    command = new AdomdCommand(mdxQuery, connection);
                    {
                        reader = command.ExecuteReader();
                        {
                            reader.Read();
                            while (reader.Read())
                            {
                                string name = reader["A"].ToString();
                                DropDownList5.Items.Add(new ListItem(name, name));
                            }
                        }
                        reader.Close();
                    }
                    mdxQuery = @"SELECT DISTINCT [product category] as A FROM [Tb DATASET]";
                    DropDownList6.Items.Clear();
                    command = new AdomdCommand(mdxQuery, connection);
                    {
                        reader = command.ExecuteReader();
                        {
                            reader.Read();
                            while (reader.Read())
                            {
                                string name = reader["A"].ToString();
                                DropDownList6.Items.Add(new ListItem(name, name));
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "LOI";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string textBox1Value = TextBox1.Text;
            string textBox2Value = TextBox2.Text;
            string dropDownList1Value = DropDownList1.SelectedValue;
            string dropDownList2Value = DropDownList2.SelectedValue;
            string dropDownList3Value = DropDownList3.SelectedValue;
            string dropDownList4Value = DropDownList4.SelectedValue;
            string dropDownList5Value = DropDownList5.SelectedValue;
            string dropDownList6Value = DropDownList6.SelectedValue;
            string sql = @"SELECT"+
                          "[Tb DATASET].[Purchase Frequency],"+
                          "Cluster() as Nhom" +
                       " From" +
                       "   [Tb DATASET]" +
                       " NATURAL PREDICTION JOIN" +
                       " (SELECT " + textBox1Value + " AS [Age], " +
                        "  '" +dropDownList1Value+ "' AS [Education], " +
                       "   '" + dropDownList2Value + "' AS [Gender], " +
                          textBox2Value + " AS [Income], " +
                          "'" + dropDownList3Value + "' AS [Loyalty Status], " +
                          "'" + dropDownList4Value + "' AS [Product Category], " +
                          "'" + dropDownList5Value + "' AS [Purchase Frequency], " +
                          "'" + dropDownList6Value + "' AS [Region]) AS t";
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
                            string Nhom = reader["Nhom"].ToString();
                            Label1.Text = Nhom.Substring(8);
                            //DropDownList1.Items.Add(new ListItem(Sex, Sex));
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ee)
            {
                Label1.Text = sql;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = @"CALL System.Microsoft.AnalysisServices.System.DataMining.Clustering.GetClusterProfiles ('Tb DATASET', '9',0.0005)";
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
                        DataTable table = new DataTable();
                        table.Load(reader);
                        GridView1.DataSource = table;
                        GridView1.DataBind();
                    }
                    reader.Close();
                }
            }
            catch (Exception ee)
            {
                //Label1.Text = sql;
            }
        }
    }
}