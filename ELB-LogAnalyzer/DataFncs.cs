using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

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

        public static string[][] GetOnlyNumericTests(string filepath)
        {
            string[] test = { };
            string[] result = { };
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
                        if (Convert.ToDecimal(ElementsInLine[2]) != 0) // This is a numeric result
                        {
                            ExtendedFunctions.Append(test, ElementsInLine[1]);
                            ExtendedFunctions.Append(result, ElementsInLine[2]);
                        }
                    }
                    catch // Ignore unauthorized index exception  
                    {  
                    }
              }
            }
            try
            {
                string[][] Output2DArray = { test, result };
                return Output2DArray;
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
                ExtendedFunctions.Append(TestList, TestNameToCheck); // if not, append it to the list
            }
            return TestList;
        }


    }
}
