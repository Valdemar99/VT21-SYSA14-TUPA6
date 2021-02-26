using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace WebServiceTUPA6
{
    public class DataAccessLayer : IXmlSerializable

    {
        private SqlConnection sqlConnection;
        private string connectionString = "Server=localhost;Database=Demo Database NAV (5-0);User Id = user2.0; Password = losen";

        public SqlConnection SqlConnection { get => SqlConnection; set => SqlConnection = value; }


        /*****************.
            *  Function             getBuildings
            *   Description         Method that, if successful, returns an sqlDataReader with all associated information from database
            *    Parameters
            *     Returns           SqlDataReader
            ***********/

        public Object[][] GetEmployeeMetaData()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT t.name, t.create_date, t.modify_date, t.object_id FROM sys.tables t JOIN sys.all_columns c ON c.object_id = t.object_id WHERE t.name = 'CRONUS Sverige AB$Employee' OR c.name = 'Employee No_' GROUP BY t.name, t.create_date, t.modify_date, t.object_id ", sqlConnection))
                {

                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        DataTable dataTable = new DataTable();



                        dataTable.Load(dataReader);
                        Object[][] returnArray = dataTable.AsEnumerable().Select(row => row.ItemArray).ToArray();
                        return returnArray;
                    }
                    catch (SqlException e)
                    {

                        throw e;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }

        }



        /*****************.
            *  Function             GetContent
            *   Description         Method that returns content from a table.
            *    Parameters         
            *     Returns           
            ***********/

        public Object[][] GetContentFromTable(string tableName)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [" + tableName + "]", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        Object[][] returnArray = dataTable.AsEnumerable().Select(row => row.ItemArray).ToArray();
                        returnArray = this.HandleDBNullValues(returnArray);
                        return returnArray;
                    }
                    catch (SqlException e)
                    {
                        throw e;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }



        /*****************.
            *  Function             addBuilding
            *   Description         Method that, if successful, adds a building in the database.
            *    Parameters         string address
            *     Returns           
            ***********/
        public Object[][] InformationAboutRelatives()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT No_, e.[First Name], e.[Last Name], [Job Title], " +
                    "e.Address, e.[Phone No_], e.[E-Mail], er.[Relative Code], er.[First Name], er.[Last Name], er.[Birth Date], " +
                    "er.[Phone No_] AS 'Relative Phone Number', er.[Relative_s Employee No_] " +
                    "FROM[CRONUS Sverige AB$Employee] e INNER JOIN[CRONUS Sverige AB$Employee Relative] er " +
                    "ON er.[Employee No_] = e.No_ ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        Object[][] returnArray = dataTable.AsEnumerable().Select(row => row.ItemArray).ToArray();
                        return returnArray;
                    }
                    catch (SqlException e)
                    {
                        throw e;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

               

            }
        }

        public Object[][] FindSickEmployeesFrom2004()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT emp.[No_], emp.[First Name], emp.[Last Name], emp.[Job Title], " +
                    "emp.[Address], emp.[Phone No_], emp.[E-Mail]  FROM[CRONUS Sverige AB$Employee Absence] ab JOIN[CRONUS Sverige AB$Employee] emp " +
                    "ON ab.[Employee No_] = emp.No_ WHERE[Cause of Absence Code] = 'SJUK' AND year(ab.[From Date]) = 2004 ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        Object[][] returnArray = dataTable.AsEnumerable().Select(row => row.ItemArray).ToArray();

                        return returnArray;
                    }
                    catch (SqlException e)
                    {
                        throw e;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }


            }
        }
        public Object[][] FindMostAbsentEmployee()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT TOP 1 emp.[First Name] FROM[CRONUS Sverige AB$Employee Absence] ab JOIN[CRONUS Sverige AB$Employee] emp ON ab.[Employee No_] = emp.No_ GROUP BY emp.[First Name] ORDER BY COUNT([Cause of Absence Code]) DESC ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        Object[][] returnArray = dataTable.AsEnumerable().Select(row => row.ItemArray).ToArray();
                        return returnArray;
                    }
                    catch (SqlException e)
                    {
                        throw e;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }



            }
        }

        public Object[][] GetAllTables()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT TABLE_NAME AS Tables FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME ASC ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        Object[][] returnArray = dataTable.AsEnumerable().Select(row => row.ItemArray).ToArray();
                        return returnArray;
                    }
                    catch (SqlException e)
                    {
                        throw e;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }



            }
        }
        public Object[][] GetAllKeys()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT name, type FROM sys.key_constraints ORDER BY name ASC ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        Object[][] returnArray = dataTable.AsEnumerable().Select(row => row.ItemArray).ToArray();
                        return returnArray;
                    }
                    catch (SqlException e)
                    {
                        throw e;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }



            }
        }

        public Object[][] GetAllIndexes()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT i.name, t.name, t.object_id FROM sys.indexes i INNER JOIN sys.tables t ON t.object_id = i.object_id ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        Object[][] returnArray = dataTable.AsEnumerable().Select(row => row.ItemArray).ToArray();
                        returnArray = this.HandleDBNullValues(returnArray);
                        return returnArray;
                    }
                    catch (SqlException e)
                    {
                        throw e;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }



            }
        }
        public Object[][] GetAllConstraints()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT CONSTRAINT_NAME, CONSTRAINT_TYPE FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS ORDER BY CONSTRAINT_NAME ASC ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        Object[][] returnArray = dataTable.AsEnumerable().Select(row => row.ItemArray).ToArray();
                        return returnArray;
                    }
                    catch (SqlException e)
                    {
                        throw e;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }



            }
        }

        public Object[][] GetAllEmployeeColumns()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COLUMN_NAME AS 'Column Name' FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CRONUS Sverige AB$Employee' ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        Object[][] returnArray = dataTable.AsEnumerable().Select(row => row.ItemArray).ToArray();
                        return returnArray;
                    }
                    catch (SqlException e)
                    {
                        throw e;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }



            }
        }
        public Object[][] HandleDBNullValues(Object[][] data)
        {
            foreach (Object[] row in data)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i] == DBNull.Value)
                    {
                        row[i] = "";
                    }
                }
            }
            return data;

        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}