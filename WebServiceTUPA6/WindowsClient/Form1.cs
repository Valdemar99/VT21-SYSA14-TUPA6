using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsClient.TUPA6Reference;

namespace WindowsClient
{
    public partial class Form1 : Form
    {
        private WebService1SoapClient proxy;
        public Form1()
        {
            InitializeComponent();
            proxy = new WebService1SoapClient();
            ShowAllData();
        }

        public void ShowAllData()
        {
            //Creating DataTable object and list of String arrays.
            DataTable table = new DataTable();
            List<ArrayOfString> metaData = proxy.GetEmployeeMetaData();
            List<string[]> stringArrayList = new List<string[]>();

            //Convert from List<ArrayOfString> to List<string[]> - move to a separate method.
            for (int rowCount = 0; rowCount < metaData.Count; rowCount++) //row
            {
                string[] row = metaData[rowCount].ToArray<string>();
                stringArrayList.Add(row);
            }

            table = this.ListToDataTable(stringArrayList, new string[] { "0", "1", "2", "3" });

            dataGridViewMetaData.DataSource = table;

            //Object[] relatives = proxy.InformationAboutRelatives();
            //dataGridViewRelatives.DataSource = relatives;

        }

        //Stackoverflow: CD.. URL: https://stackoverflow.com/questions/1253725/convert-ienumerable-to-datatable
        public DataTable ListToDataTable(List<string[]> items, string[] columnNames)
        {
            var tb = new DataTable();

            foreach (var column in columnNames)
            {
                tb.Columns.Add(column);
            }

            for (int rowCount = 0; rowCount < items.Count; rowCount++) //row
            {
                string[] row = items[rowCount];
                string[] rowAsString = new string[row.Length];
                for (int columnCount = 0; columnCount < row.Length; columnCount++) //cell
                {
                    rowAsString[columnCount] = row[columnCount].ToString();
                }
                tb.Rows.Add(rowAsString);
            }


            return tb;
        }

        private void dataGridViewMetaData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
