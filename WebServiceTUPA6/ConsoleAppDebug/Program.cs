using ConsoleAppDebug.TUPA6Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            WebService1SoapClient proxy = new WebService1SoapClient();

            ArrayOfString[] metaData = proxy.GetEmployeeMetaData();
            List<string[]> stringArrayList = new List<string[]>();
            for (int rowCount = 0; rowCount < metaData.Length; rowCount++) //row
            {
                ArrayOfString row = metaData[rowCount];
                string[] rowAsString = new string[row.Count];
                for (int columnCount = 0; columnCount < row.Count; columnCount++) //cell
                {
                    rowAsString[columnCount] = row[columnCount].ToString();
                    Console.WriteLine("Column no: " + columnCount + " " + rowAsString[columnCount]);
                }
                stringArrayList.Add(rowAsString);
            }
            Console.ReadLine();
        }
    }
    
}
