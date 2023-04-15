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
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace ELB_LogAnalyzer
{
    public partial class Form1 : Form
    {
        public string[] SelectedFiles { get; set; }
        // Holds a unique list of test names and their High/Low limit 
        public string[] UniqueTestNames { get; set; }
        public string[] LowLimits { get; set; }
        public string[] HighLimits { get; set; }
        public string[] UniqueSerialNumbers { get; set; }
        private string[][] FileandSerialsGrid { get; set; }        
        private string[][] TestAndResultsGrid { get; set; }
        
        public Form1()
        {
            InitializeComponent();
            // Initialize UniqueTestNames List
            UniqueTestNames = new string[] { };
            LowLimits = new string[] { };
            HighLimits = new string[] { };
            UniqueSerialNumbers = new string[] { };
        }

        /*// Form Load fnc
         * */
        private void Form1_Load(object sender, EventArgs e)
        {
            Units_Label.Text = string.Empty;
            Models_Label.Text = string.Empty;   
        }

        /*Functions of the form*/
        private void OpenFile_Btn_Click(object sender, EventArgs e)
        {
            
            OpenFileDiagMain.ShowDialog(this);
            SelectedFiles = OpenFileDiagMain.FileNames; // Get the array of files to be parsed
            Units_Label.Text = SelectedFiles.Length.ToString();

            // Link each serial number with the file path
            FileandSerialsGrid = DataFncs.LinkSerialstoFiles(SelectedFiles, "SN: ");
            // Create Unique serial number for each filepath (if one or more is repeated then replace it with a unique id ext)
            FileandSerialsGrid = DataFncs.UniqueSerialIDs(FileandSerialsGrid);
            // Create the datagrid view
            CreatingDataView(FileandSerialsGrid);
            // Calculate the statistics of the data:
            LogStatistics();
            // Add statistics to the row


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
                    TestRow = FindTestRow(test_array[0][loop_2]); // Find the right place to put the data on the DGrid
                    DGrid1.CurrentCell = this.DGrid1[serial, TestRow]; //select that cell for the given 
                    DGrid1.CurrentCell.Value = result; //Update cell value
                    loop_2++; //Increase counter
                }
                loop_1++;
            }

            // return test_array;
        }

        /*Logs the result of the file into a new row*/

        private void LogNewTestRow(string[][] test_grid) // Testgrid is a 2d array with the test and the numeric result
        {
            int count = 0;
            // Testgrid is an array of tests and results from a single file
            foreach(string testname in test_grid[0])
            {
                // Verify if this test already exists or not...
                if (!UniqueTestNames.Contains(testname)) // The testname already contains the testname to check?
                {
                    DGrid1.Rows.Add(testname);
                    // Build an array with Testname, 
                    UniqueTestNames = ExtendedFunctions.Append(UniqueTestNames, testname);
                    try
                    {
                        HighLimits = ExtendedFunctions.Append(HighLimits, test_grid[2][count]);
                        LowLimits = ExtendedFunctions.Append(LowLimits, test_grid[3][count]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        HighLimits = ExtendedFunctions.Append(HighLimits, "NaN");
                        LowLimits = ExtendedFunctions.Append(LowLimits, "NaN");
                    }
                    //break;
                }
                // Manipulate individual rows and columns?
                count++;
            }
        }

        private void LogStatistics()
        {
            decimal avg;
            double stdev;
            //Define the new row
            DataGridViewColumn avgcol = ExtendedFunctions.DefineNewColumn("Average");
            DataGridViewColumn stdevcol = ExtendedFunctions.DefineNewColumn("StdDev");
            DataGridViewColumn HighLim = ExtendedFunctions.DefineNewColumn("HighLimit");
            DataGridViewColumn LowLim = ExtendedFunctions.DefineNewColumn("LowLimit");

            DGrid1.Columns.Add(avgcol);
            DGrid1.Columns.Add(stdevcol);
            DGrid1.Columns.Add(HighLim);
            DGrid1.Columns.Add(LowLim);
            //calculate first the averages 
            foreach (DataGridViewRow row in DGrid1.Rows)
            {
                if (row.Cells.Count > 0 && row.Cells[0].Value != null)
                {
                    avg = DataFncs.GetRowAverage(row);
                    stdev = DataFncs.GetRowsStdDev(row, Convert.ToDouble(avg));
                    // Add the average cell
                    DGrid1.CurrentCell = DGrid1["Average", row.Index];
                    DGrid1.CurrentCell.Value = avg.ToString();
                    // add the std cell
                    DGrid1.CurrentCell = DGrid1["StdDev", row.Index];
                    DGrid1.CurrentCell.Value = stdev.ToString();
                    // Add the high limit used in this test
                    DGrid1.CurrentCell = DGrid1["HighLimit", row.Index];
                    DGrid1.CurrentCell.Value = HighLimits[row.Index];
                    // Add the Low Limit
                    DGrid1.CurrentCell = DGrid1["LowLimit", row.Index];
                    DGrid1.CurrentCell.Value = LowLimits[row.Index];

                }
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
