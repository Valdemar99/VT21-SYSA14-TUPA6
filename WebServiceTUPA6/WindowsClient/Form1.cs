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
            labelFeedBack.Text = "";
            FillTableWithData(dataGridViewMetaData, proxy.GetEmployeeMetaData());
            FillTableWithData(dataGridViewRelatives, proxy.InformationAboutRelatives());
            FillTableWithData(dataGridViewSickness, proxy.FindSickEmployeesFrom2004());
            labelAbsent.Text = "First name of the employee that has been absent the most: " + proxy.FindMostAbsentEmployee().ToString();
            FillTableWithData(dataGridViewAllTables, proxy.GetAllTables());
            FillTableWithData(dataGridViewAllKeys, proxy.GetAllKeys());
            FillTableWithData(dataGridViewIndexes, proxy.GetAllIndexes());
            FillTableWithData(dataGridViewConstraints, proxy.GetAllConstraints());
            FillTableWithData(dataGridViewEmpTable, proxy.GetAllEmployeeColumns());
            this.FillComboBox(proxy.GetNamesOfEmployeeTables());
           
        }

        public void FillTableWithData(DataGridView dataGridView, List<ArrayOfString> data)
        {
            //Creating DataTable object and list of String arrays.
            DataTable table = new DataTable();            

            table = this.ListToDataTable(data);

            dataGridView.DataSource = table;

        }

        //Stackoverflow: CD.. URL: https://stackoverflow.com/questions/1253725/convert-ienumerable-to-datatable
        public DataTable ListToDataTable(List<ArrayOfString> items)
        {
            var tb = new DataTable();

            foreach (string column in items[0])
            {
                if(tb.Columns.Contains(column)) {
                    tb.Columns.Add("Relative " + column);
                }
                else
                {
                    tb.Columns.Add(column);
                }
            }

            for (int rowCount = 1; rowCount < items.Count; rowCount++) //row
            {
                ArrayOfString row = items[rowCount];
                string[] rowAsString = new string[row.Count];
                for (int columnCount = 0; columnCount < row.Count; columnCount++) //cell
                {
                    rowAsString[columnCount] = row[columnCount].ToString();
                }
                tb.Rows.Add(rowAsString);
            }


            return tb;
        }

        public void FillComboBox(ArrayOfString items)
        {
            foreach (string column in items)
            {
                comboBoxTables.Items.Add(column);
                
            }
           
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FillTableWithData(dataGridViewTableContent, proxy.GetContentFromTable(comboBoxTables.SelectedItem.ToString()));

            }
            catch (NullReferenceException ex)
            {
                labelFeedBack.Text = "Please choose a table";
            }
            catch (System.Exception)
            {
                labelFeedBack.Text = "Please choose a table";
            }
        }
    }
}
