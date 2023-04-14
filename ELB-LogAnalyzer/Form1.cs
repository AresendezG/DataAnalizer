using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ELB_LogAnalyzer
{
    public partial class Form1 : Form
    {
        public string[] SelectedFiles { get; set; }
        public string[] UniqueTestNames { get; set; }
        private string[][] FileandSerialsGrid { get; set; }        
        
        public Form1()
        {
            InitializeComponent();
            // Initialize UniqueTestNames List
            UniqueTestNames = new string[] { };
        }

        /*Functions of the form*/
        private void OpenFile_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDiagMain.ShowDialog(this);
            SelectedFiles = OpenFileDiagMain.FileNames; // Get the array of files to be parsed
            FileandSerialsGrid = DataFncs.LinkSerialstoFiles(SelectedFiles, "SN: ");
            CreatingDataView(FileandSerialsGrid);

        }


        /* Adds the result of each file to a new column*/
        private void CreatingDataView(string[][] SelectedFilesArray)
        {
            string[][] test_array;
            int loop_1 = 0;
            
            // Start with the new columns
            foreach (string serial in SelectedFilesArray[1])
            {
                int loop_2 = 0;
                int TestRow = 0;
                //Each iteration has one serial number
                DataGridViewColumn UUT_ResultCol = ExtendedFunctions.DefineNewColumn(serial);
                DGrid1.Columns.Add(UUT_ResultCol); // Column is added, now check this serial number 
                /* Now, analyze the whole file and return a 2d array with only Testname and Measurement to populate the rows: */
                test_array = DataFncs.GetOnlyNumericTests(SelectedFilesArray[0][loop_1]); //this parameter is the path of the file
                LogNewTestRow(test_array); // This will create the new row if needed
                foreach (string result in test_array[1])
                {
                    TestRow = FindTestRow(test_array[0][loop_2]);
                    DGrid1.CurrentCell = this.DGrid1[serial, TestRow]; //select that cell for the given 
                    DGrid1.CurrentCell.Value = result;
                    loop_2++;
                }
                loop_1++;
            }

        }

        /*Logs the result of the file into a new row*/

        private void LogNewTestRow(string[][] test_grid) // Testgrid is a 2d array with the test and the numeric result
        {
            foreach(string testname in test_grid[0])
            {
                // Verify if this test already exists or not...
                if (!UniqueTestNames.Contains(testname)) // The testname already contains the testname to check?
                {
                    DGrid1.Rows.Add(testname);
                    UniqueTestNames = ExtendedFunctions.Append(UniqueTestNames, testname);
                    //break;
                }
                // Manipulate individual rows and columns?
            }
        }


        private int FindTestRow(string testname)
        {
            int rowIndex = -1;
            DataGridViewRow row = DGrid1.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["testname"].Value.ToString().Equals(testname))
                .First();

            rowIndex = row.Index;
            return rowIndex;
        }


        /*Processing data stuff*/

        private void ParseFile(string FilePath)
        {

        }


    }
}
