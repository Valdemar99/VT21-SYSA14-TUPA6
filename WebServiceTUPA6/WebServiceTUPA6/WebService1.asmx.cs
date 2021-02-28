using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace WebServiceTUPA6
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
        
    {
        DataAccessLayer dal = new DataAccessLayer();

        [WebMethod]
        public List<List<string>> GetEmployeeMetaData()
        {
            return dal.GetEmployeeMetaData();
        }

        [WebMethod]
        public List<List<string>> GetContentFromTable(string tableName)
        {
            return dal.GetContentFromTable(tableName);
        }

        [WebMethod]
        public List<List<string>> InformationAboutRelatives()
        {
            return dal.InformationAboutRelatives();
        }

        [WebMethod]
        public List<List<string>> FindSickEmployeesFrom2004()
        {
            return dal.FindSickEmployeesFrom2004();
        }

        [WebMethod]
        public string FindMostAbsentEmployee()
        {
            return dal.FindMostAbsentEmployee();
        }

        [WebMethod]
        public List<List<string>> GetAllTables()
        {
            return dal.GetAllTables();
        }

        [WebMethod]
        public List<List<string>> GetAllKeys()
        {
            return dal.GetAllKeys();
        }

        [WebMethod]
        public List<List<string>> GetAllIndexes()
        {
            return dal.GetAllIndexes();
        }

        [WebMethod]
        public List<List<string>> GetAllConstraints()
        {
            return dal.GetAllConstraints();
        }

        [WebMethod]
        public List<List<string>> GetAllEmployeeColumns()
        {
            return dal.GetAllEmployeeColumns();
        }

        [WebMethod]
        public List<string> GetNamesOfEmployeeTables()
        {
            return dal.GetNamesOfEmployeeTables();
        }
    }
}
