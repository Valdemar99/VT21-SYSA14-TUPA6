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
        public List<List<string>> GetEmployeeMetaData()
        {
            return dal.GetEmployeeMetaData();
        }

        [WebMethod]
        public Object[][] GetContentFromTable(string tableName)
        {
            return dal.GetContentFromTable(tableName);
        }

        [WebMethod]
        public Object[][] InformationAboutRelatives()
        {
            return dal.InformationAboutRelatives();
        }

        [WebMethod]
        public Object[][] FindSickEmployeesFrom2004()
        {
            return dal.FindSickEmployeesFrom2004();
        }

        [WebMethod]
        public Object[][] FindMostAbsentEmployee()
        {
            return dal.FindMostAbsentEmployee();
        }

        [WebMethod]
        public Object[][] GetAllTables()
        {
            return dal.GetAllTables();
        }

        [WebMethod]
        public Object[][] GetAllKeys()
        {
            return dal.GetAllKeys();
        }

        [WebMethod]
        public Object[][] GetAllIndexes()
        {
            return dal.GetAllIndexes();
        }

        [WebMethod]
        public Object[][] GetAllConstraints()
        {
            return dal.GetAllConstraints();
        }

        [WebMethod]
        public Object[][] GetAllEmployeeColumns()
        {
            return dal.GetAllEmployeeColumns();
        }

    }
}
