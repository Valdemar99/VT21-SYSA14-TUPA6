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
    public class DataAccessLayer 

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

        public List<List<string>> GetEmployeeMetaData()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT t.name, t.create_date, t.modify_date, t.object_id FROM sys.tables t JOIN sys.all_columns c ON c.object_id = t.object_id WHERE t.name = 'CRONUS Sverige AB$Employee' OR c.name = 'Employee No_' GROUP BY t.name, t.create_date, t.modify_date, t.object_id ", sqlConnection))
                {

                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        List<List<string>> stringList = new List<List<string>>();
                        DataTable dataTable = new DataTable();

                        List<string> columns = new List<string>();

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            columns.Add(dataReader.GetName(i));
                        }
                        stringList.Add(columns);

                        dataTable.Load(dataReader);
                        List<Object[]> objectList = dataTable.AsEnumerable().Select(row => row.ItemArray).ToList();

                        

                        foreach (Object[] row in objectList)
                        {
                            List<string> rowAsString = new List<string>();
                            foreach (Object cell in row)
                            {
                                rowAsString.Add(cell.ToString());
                            }
                            stringList.Add(rowAsString);
                        }

                        return stringList;
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

        public List<List<string>> GetContentFromTable(string tableName)
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

                        List<List<string>> stringList = new List<List<string>>();

                        List<string> columns = new List<string>();

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            columns.Add(dataReader.GetName(i));
                        }
                        stringList.Add(columns);

                        dataTable.Load(dataReader);
                        List<Object[]> objectList = dataTable.AsEnumerable().Select(row => row.ItemArray).ToList();

                        foreach (Object[] row in objectList)
                        {
                            List<string> rowAsString = new List<string>();
                            foreach (Object cell in row)
                            {
                                rowAsString.Add(cell.ToString());
                            }
                            stringList.Add(rowAsString);
                        }

                        return stringList;
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
        public List<List<string>> InformationAboutRelatives()
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
                        List<List<string>> stringList = new List<List<string>>();

                        List<string> columns = new List<string>();

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            columns.Add(dataReader.GetName(i));
                        }
                        stringList.Add(columns);

                        dataTable.Load(dataReader);
                        List<Object[]> objectList = dataTable.AsEnumerable().Select(row => row.ItemArray).ToList();

                        foreach (Object[] row in objectList)
                        {
                            List<string> rowAsString = new List<string>();
                            foreach (Object cell in row)
                            {
                                rowAsString.Add(cell.ToString());
                            }
                            stringList.Add(rowAsString);
                        }

                        return stringList;
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

        public List<List<string>> FindSickEmployeesFrom2004()
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
                        List<List<string>> stringList = new List<List<string>>();

                        List<string> columns = new List<string>();

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            columns.Add(dataReader.GetName(i));
                        }
                        stringList.Add(columns);

                        dataTable.Load(dataReader);
                        List<Object[]> objectList = dataTable.AsEnumerable().Select(row => row.ItemArray).ToList();

                        foreach (Object[] row in objectList)
                        {
                            List<string> rowAsString = new List<string>();
                            foreach (Object cell in row)
                            {
                                rowAsString.Add(cell.ToString());
                            }
                            stringList.Add(rowAsString);
                        }

                        return stringList;
                    
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
        public string FindMostAbsentEmployee()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT TOP 1 emp.[First Name] FROM[CRONUS Sverige AB$Employee Absence] ab JOIN[CRONUS Sverige AB$Employee] emp ON ab.[Employee No_] = emp.No_ GROUP BY emp.[First Name] ORDER BY COUNT([Cause of Absence Code]) DESC ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        string name = "";

                        while (dataReader.Read())
                        {
                            name = dataReader[0].ToString();

                        }

                        return name;
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

        public List<List<string>> GetAllTables()
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
                        List<List<string>> stringList = new List<List<string>>();

                        List<string> columns = new List<string>();

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            columns.Add(dataReader.GetName(i));
                        }
                        stringList.Add(columns);

                        dataTable.Load(dataReader);
                        List<Object[]> objectList = dataTable.AsEnumerable().Select(row => row.ItemArray).ToList();

                        foreach (Object[] row in objectList)
                        {
                            List<string> rowAsString = new List<string>();
                            foreach (Object cell in row)
                            {
                                rowAsString.Add(cell.ToString());
                            }
                            stringList.Add(rowAsString);
                        }

                        return stringList;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }



            }
        }
        public List<List<string>> GetAllKeys()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT name, type FROM sys.key_constraints ORDER BY name ASC ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        List<List<string>> stringList = new List<List<string>>();
                        DataTable dataTable = new DataTable();

                        List<string> columns = new List<string>();

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            columns.Add(dataReader.GetName(i));
                        }
                        stringList.Add(columns);

                        dataTable.Load(dataReader);
                        List<Object[]> objectList = dataTable.AsEnumerable().Select(row => row.ItemArray).ToList();



                        foreach (Object[] row in objectList)
                        {
                            List<string> rowAsString = new List<string>();
                            foreach (Object cell in row)
                            {
                                rowAsString.Add(cell.ToString());
                            }
                            stringList.Add(rowAsString);
                        }

                        return stringList;
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

        public List<List<string>> GetAllIndexes()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT i.name, t.name, t.object_id FROM sys.indexes i INNER JOIN sys.tables t ON t.object_id = i.object_id ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        List<List<string>> stringList = new List<List<string>>();
                        DataTable dataTable = new DataTable();

                        List<string> columns = new List<string>();

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            columns.Add(dataReader.GetName(i));
                        }
                        stringList.Add(columns);

                        dataTable.Load(dataReader);
                        List<Object[]> objectList = dataTable.AsEnumerable().Select(row => row.ItemArray).ToList();



                        foreach (Object[] row in objectList)
                        {
                            List<string> rowAsString = new List<string>();
                            foreach (Object cell in row)
                            {
                                rowAsString.Add(cell.ToString());
                            }
                            stringList.Add(rowAsString);
                        }

                        return stringList;
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
        public List<List<string>> GetAllConstraints()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT CONSTRAINT_NAME, CONSTRAINT_TYPE FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS ORDER BY CONSTRAINT_NAME ASC ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        List<List<string>> stringList = new List<List<string>>();
                        DataTable dataTable = new DataTable();

                        List<string> columns = new List<string>();

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            columns.Add(dataReader.GetName(i));
                        }
                        stringList.Add(columns);

                        dataTable.Load(dataReader);
                        List<Object[]> objectList = dataTable.AsEnumerable().Select(row => row.ItemArray).ToList();



                        foreach (Object[] row in objectList)
                        {
                            List<string> rowAsString = new List<string>();
                            foreach (Object cell in row)
                            {
                                rowAsString.Add(cell.ToString());
                            }
                            stringList.Add(rowAsString);
                        }

                        return stringList;
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

        public List<List<string>> GetAllEmployeeColumns()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COLUMN_NAME AS 'Column Name' FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CRONUS Sverige AB$Employee' ", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        List<List<string>> stringList = new List<List<string>>();
                        DataTable dataTable = new DataTable();

                        List<string> columns = new List<string>();

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            columns.Add(dataReader.GetName(i));
                        }
                        stringList.Add(columns);

                        dataTable.Load(dataReader);
                        List<Object[]> objectList = dataTable.AsEnumerable().Select(row => row.ItemArray).ToList();



                        foreach (Object[] row in objectList)
                        {
                            List<string> rowAsString = new List<string>();
                            foreach (Object cell in row)
                            {
                                rowAsString.Add(cell.ToString());
                            }
                            stringList.Add(rowAsString);
                        }

                        return stringList;
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

        public List<string> GetNamesOfEmployeeTables()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT t.name FROM sys.tables t JOIN sys.all_columns c ON c.object_id = t.object_id WHERE t.name = 'CRONUS Sverige AB$Employee' OR c.name = 'Employee No_' GROUP BY t.name", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        List<string> tableNames = new List<string>();
                        while(dataReader.Read())
                        {
                            tableNames.Add(dataReader.GetString(0));
                        }
                        return tableNames;
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
            //Loops through each row in the two-dimensional array:
            foreach (Object[] row in data)
            {
                //Loops through every cell on this row
                for (int i = 0; i < row.Length; i++)
                {
                    //Checks if it is equal to a DBNull value, and if so, edits it to an empty string.
                    if (row[i] == DBNull.Value)
                    {
                        row[i] = "";
                    }
                }
            }
            return data;

        }

    }
}