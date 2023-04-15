﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace ELB_LogAnalyzer
{
    internal class DataFncs
    {
        // This will create a 2D array: 1 with all the filenames selected and the second array will be the column name of that specific file 
        public static string[][] LinkSerialstoFiles(string[] Files, string SN_Identifier)
        {
            string[] LinesInFile;
            string[] ElementsInLine;
            string[] ValidPaths = { };
            string[] SerialNumbers = { };

            foreach (string singleFile in Files)
            {
                LinesInFile = File.ReadAllLines(singleFile);
                foreach (string line in LinesInFile)
                {
                    if (line.StartsWith(SN_Identifier))
                    {
                        // This filepath is valid, add it to the array
                        ValidPaths = ExtendedFunctions.Append(ValidPaths, singleFile);
                        ElementsInLine = line.Split(' ');
                        // This SN is valid, add it to the array
                        SerialNumbers = ExtendedFunctions.Append(SerialNumbers, ElementsInLine[1]);
                        break; // serial number found, no need to keep looking
                    }
                }

            }
            try
            {
                string[][] Output2DArray = { Files, SerialNumbers };
                return Output2DArray;
            }
            catch
            {
                return null;
            }

        }

        public static string[][] UniqueSerialIDs(string[][] FilesAndPathsArray)
        {
            string[] SerialsList = { };
            int counter = 0;
            foreach (string serial in FilesAndPathsArray[1])
            {
                if (!SerialsList.Contains(serial))
                {
                    // include it to the list and do nothing
                    SerialsList = ExtendedFunctions.Append(SerialsList, serial);
                }
                else
                {
                    FilesAndPathsArray[1][counter] = serial + "_rt1";
                }
                counter++;
            }
            return FilesAndPathsArray;
        }

        public static decimal GetRowAverage(DataGridViewRow row)
        {
            int rowcount = row.Cells.Count;
            decimal sum = 0;
            decimal value = 0;
            int validresultcount = 0;
            // sum all values in the row:
            for (int i = 1; i < rowcount; i++)
            {
                if (row.Cells[i].Value != null)
                {
                    value = Convert.ToDecimal(row.Cells[i].Value);
                    sum = sum + value;
                    validresultcount++;
                }
            }

            return sum / validresultcount;
        }

        public static double GetRowsStdDev(DataGridViewRow row, double average)
        {

            /*               
                Step 1: Find the mean.
                Step 2: For each data point, find the square of its distance to the mean.
                Step 3: Sum the values from Step 2.
                Step 4: Divide by the number of data points.
                Step 5: Take the square root.             
             */

            int rowcount = row.Cells.Count;
            int validresultscount = 0;
            double dev_sum = 0;
            double cell_val;
            double dist;
            double stdev;

            for (int i = 1; i < rowcount; i++)
            {
                if (row.Cells[i].Value != null) // Cell is not empty
                {
                    cell_val = Convert.ToDouble(row.Cells[i].Value);
                    dist = Math.Pow((cell_val - average),2); // step2
                    dev_sum = dev_sum + dist; //step 3
                    validresultscount++; // not all cells in the grid will have data
                }
            }
            stdev = dev_sum / validresultscount; // step 4
            stdev = Math.Sqrt(stdev); // step 5
            return stdev;

        }

        public static string[][] GetOnlyNumericTests(string filepath)
        {
            string[] test = { };
            string[] result = { };
            string[] LowLimit = { };
            string[] HighLimit = { };   
            string[] LinesInFile, ElementsInLine;

            LinesInFile = File.ReadAllLines(filepath);

            foreach (string line in LinesInFile)
            {              
              if (line.ToUpper().StartsWith("PASS") || line.ToUpper().StartsWith("FAIL"))
              {
                    try //Line starts with PASS so this is a test result
                    {
                        //Is it numeric?
                        ElementsInLine = line.Split(',');
                        // TestResult[0],Testname[1],HighLimit[2],Measurement[3],LowLimit[4]
                        if (Convert.ToDecimal(ElementsInLine[3]) != 0) // This is the numeric result
                        {
                            test = ExtendedFunctions.Append(test, ElementsInLine[1]);
                            result = ExtendedFunctions.Append(result, ElementsInLine[3]); //[3] is the numeric result
                            HighLimit = ExtendedFunctions.Append(HighLimit, ElementsInLine[2]);
                            LowLimit = ExtendedFunctions.Append(LowLimit, ElementsInLine[4]);
                        }
                    }
                    catch // Ignore unauthorized index exception  
                    {  
                    }
              }
            }
            try
            {
                string[][] OutputArray = { test, result, HighLimit, LowLimit };
                return OutputArray;
            }
            catch
            {
                return null;
            }


        }

        public static string[] UniqueTestList(string[] TestList, string TestNameToCheck)
        {
            if (!TestList.Contains(TestNameToCheck)) // This testname list contains the testname to check?
            {
                TestList = ExtendedFunctions.Append(TestList, TestNameToCheck); // if not, append it to the list
            }
            return TestList;
        }


    }
}
