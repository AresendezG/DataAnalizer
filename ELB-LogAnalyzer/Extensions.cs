using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ELB_LogAnalyzer
{
    public static class ExtendedFunctions
    {
        public static T[] Append<T>(this T[] array, T item)
        {
            if (array == null)
            {
                return new T[] { item };
            }
            T[] result = new T[array.Length + 1];
            array.CopyTo(result, 0);
            result[array.Length] = item;
            return result;
        }

        public static bool ValidateFileExists(string filename)
        {
            try
            {
               FileStream Fs = File.OpenRead(filename);
                Fs.Close();  
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static string[] ReadFileLines(string filename)
        {
            string[] ReturnArray = { };
            ReturnArray = File.ReadAllLines(filename);
            return ReturnArray;
        }



        public static string[] ParseSQLDataHosts(string [] SQLReturn, TableColumn ColName)
        {
            string[] cells;
            string[] ReturnArray = { };
            int column = Convert.ToInt32(ColName);
            
            foreach (string row in SQLReturn)
            {
                cells = row.Split(',');
                ReturnArray = ExtendedFunctions.Append(ReturnArray, cells[column]);
            }
            return ReturnArray;

        }

        // Define a new column for a data grid view object
        public static DataGridViewColumn DefineNewColumn(string RowName)
        {

            DataGridViewCell TemplateCell = new DataGridViewTextBoxCell();

            DataGridViewColumn ReturnCol = new DataGridViewColumn
            {
                Visible = true,
                HeaderText = RowName,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true,
                Name = RowName,
                SortMode = DataGridViewColumnSortMode.Automatic,
                CellTemplate = TemplateCell
            };

            return ReturnCol;
        }


        public static DataGridViewColumn DefineResultsColumn()
        {

            DataGridViewCell TemplateCell = new DataGridViewTextBoxCell();
            TemplateCell.Style.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            DataGridViewColumn ReturnCol = new DataGridViewColumn
            {
                Visible = true,
                HeaderText = "Test Result",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true,
                Name = "Results",
                SortMode = DataGridViewColumnSortMode.Automatic,
                CellTemplate = TemplateCell
            };

            return ReturnCol;
        }

        public static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }


        // Query a valid NTP Server to obtain datetime from the network
        public static DateTime GetNetworkTime()
        {
            //default Windows time server
            string ntpServer = "time.windows.com"; // = Properties.Settings.Default.NTPServer;
            // NTP message size - 16 bytes of the digest (RFC 2030)
            var ntpData = new byte[48];
            //Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)
            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //The UDP port number assigned to NTP is 123
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP uses UDP

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);

                //Stops code hang if NTP is blocked
                socket.ReceiveTimeout = 1500;

                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }

            //Offset to get to the "Transmit Timestamp" field (time at which the reply 
            //departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            //Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = ExtendedFunctions.SwapEndianness(intPart);
            fractPart = ExtendedFunctions.SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //**UTC** time
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        // Will check how many days have passed since the last time this model was tested
        public static string AnalyzeElapsedTime(DateTime LastTested, string DateOfLast)
        {
            string ReturnMessage = "";
            DateTime NTP_Time;
            NTP_Time = ExtendedFunctions.GetNetworkTime();

            ReturnMessage += "Last Tested Date: " + DateOfLast + "\n"; //Line2 [Array 1]
            TimeSpan Dif = NTP_Time - LastTested;

            // Data to be returned to the TCP/IP query
            ReturnMessage += "NTP Server Time: " + NTP_Time.ToString() + " \n"; //Line3 [Array 2]
            ReturnMessage += "Elapsed TimeSpan: " + Dif.ToString() + " \n"; //Line4 [Array 3]

            int ElapsedHours;

            if (Dif.Days > 0)
            {
                ElapsedHours = Dif.Hours + (Dif.Days * 24);
            }
            else
            {
                ElapsedHours = Dif.Hours;
            }
            ReturnMessage += "Complete Elapsed Days: " + Dif.Days + " \n"; //Line5 [Array 4]
            ReturnMessage += "Elapsed Hours: " + Dif.ToString() + " \n"; //Line6 [Array5]

            return ReturnMessage;

        }

    }


    public enum TableColumn
    {
        Hosts = 0,
        IPs = 1,
        MTP_ID = 2,
        Date = 3,
    }



}
