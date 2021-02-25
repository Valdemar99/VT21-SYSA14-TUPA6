using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

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
        public DataTable GetEmployeeMetaData()
        {
            return dal.GetEmployeeMetaData();
        }

        [WebMethod]
        public DataTable GetContentFromTable(string tableName)
        {
            return dal.GetContentFromTable(tableName);
        }

        [WebMethod]
        public DataTable InformationAboutRelatives()
        {
            return dal.InformationAboutRelatives();
        }

        [WebMethod]
        public DataTable FindSickEMployeesFrom2004()
        {
            return dal.FindSickEMployeesFrom2004();
        }

        [WebMethod]
        public DataTable FindMostAbsentEmployee()
        {
            return dal.FindMostAbsentEmployee();
        }

        [WebMethod]
        public DataTable GetAllTables()
        {
            return dal.GetAllTables();
        }

        [WebMethod]
        public DataTable GetAllKeys()
        {
            return dal.GetAllKeys();
        }

        [WebMethod]
        public DataTable GetAllIndexes()
        {
            return dal.GetAllIndexes();
        }

        [WebMethod]
        public DataTable GetAllConstraints()
        {
            return dal.GetAllConstraints();
        }

        [WebMethod]
        public DataTable GetAllEmployeeColumns()
        {
            return dal.GetAllEmployeeColumns();
        }

    }
}
