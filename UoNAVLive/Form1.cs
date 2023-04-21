using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//String minipulation Regex, Mac Address
using System.Text.RegularExpressions;

namespace UoNAVLive
{
    public partial class Form1 : Form
    {

        //Database Stuff
        QueryDataBase DBQuery = new QueryDataBase();

        //
        string LastCellValue = string.Empty;
        string LastUoNDeviceID = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void GetDeviceData(string SearchString)
        {
            string ANDText = "";
            string ANDSearch = "";

            if (SearchString.IndexOf(" *AND* ", 0) > 0)
            {
                int checklenght = SearchString.Length - (SearchString.Length - (SearchString.IndexOf("*AND*", 0) + 6));
                ANDText = SearchString.Substring(checklenght);
                //MessageBox.Show(ANDText);
                ANDSearch = " AND ((DeviceID || Location || Building || Device || ModelNumber || Serial || COALESCE(MAC,'') || CleanMAC || COALESCE(PlannedIP,'') || ActualIP || LocalNetPort || SwitchPort || Location1 || PlanonRef || Notes || UONAsset) Like '%" + ANDText + "%' )";
                SearchString = SearchString.Substring(0, SearchString.IndexOf(" *AND* "));
            }

            string SQLSearch = "select * from UoNDevices where ((DeviceID || Location || Building || Device || ModelNumber || Serial || COALESCE(MAC,'') || CleanMAC || COALESCE(PlannedIP,'') || ActualIP || LocalNetPort || SwitchPort || Location1 || PlanonRef || Notes || UONAsset) Like '%" + SearchString + "%'" + ANDSearch + ")";
            //MessageBox.Show(SQLSearch);
            DGVUoNDevices.DataSource = DBQuery.DBGetDataSet(SQLSearch);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetDeviceData("");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                TextSearch(sender,e);
            }

        }

        private void TextSearch(object sender, EventArgs e)
        {
            string SearchString = textBoxSearchBox.Text;
            int HifenCount = SearchString.Count(f => f == '-');

            SearchString = SearchString.Replace(":", "");
            if (HifenCount > 1)
            {
                SearchString = SearchString.Replace("-", "");
            }
            //MessageBox.Show(SearchString);

            GetDeviceData(SearchString);
            
        }

        private void buttonAddDevice_Click(object sender, EventArgs e)
        {
            DBQuery.DBWright("insert into UoNDevices (Status, Location, Building, Device, ModelNumber, Serial, CleanMAC, ActualIP, LocalNetPort, SwitchPort, Location1, PlanonRef, Notes, UONAsset) values ('Active','','','','','','','','','','','','','')");
            String NewID = DBQuery.DBSingleRead("select MAX(DeviceID) from UoNDevices");
            DGVUoNDevices.DataSource = DBQuery.DBGetDataSet("Select * From UoNDevices where DeviceID='"+ NewID +"'");
        }

        private void DGVUoNDevices_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           

            string UoNDeviceID = DGVUoNDevices.Rows[e.RowIndex].Cells[0].Value.ToString();

            string NewValue = DGVUoNDevices.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            string ColumnHeader = DGVUoNDevices.Columns[e.ColumnIndex].HeaderText.ToString();

            string OldValue = DBQuery.DBSingleRead("Select " + ColumnHeader + " from UoNDevices Where DeviceID = '"+ LastUoNDeviceID + "'");

            string CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            string Date = DateTime.Today.ToString();

            string NewMac = string.Empty;

            string NewMAC = string.Empty;

            if (NewValue == OldValue)
            {
                return;
            }

            if (NewValue == "NOT UNIQUE NOT SAVED" || NewValue.Contains(") - Incorrect"))
            {
                return;
            }

            //MessageBox.Show(LastCellValue);
            int IPCount = 0;

            if (ColumnHeader == "PlannedIP")
            {
                IPCount = DBQuery.DBCount("select COUNT(PlannedIP) from UoNDevices where plannedIp = '"+ LastCellValue + "'");

            }
            int MACCount = 0;
            if (ColumnHeader == "MAC")
            {

                //Value being changed stored in NewValue
                string MAC = NewValue;

                MAC = MAC.Replace(":", "");
                MAC = MAC.Replace("-", "");
                MAC = MAC.ToUpper();

                string regex = "(.{2})(.{2})(.{2})(.{2})(.{2})(.{2})";
                string replace = "$1:$2:$3:$4:$5:$6";
                NewMAC = Regex.Replace(MAC, regex, replace);

                MACCount = DBQuery.DBCount("select COUNT(MAC) from UoNDevices where MAC = '" + NewMAC + "'");
                if (NewMAC.Length != 17 && NewValue.Length != 0)
                {
                    DGVUoNDevices.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "(" + NewValue + ") - Incorrect";
                    return;
                }

                char[] ch1 = { 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ';'};
 
                if (NewValue.IndexOfAny(ch1) > 0)
                {
                    DGVUoNDevices.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Check Characters (" + NewValue + ") - Incorrect";
                    return;
                }

                NewValue = DGVUoNDevices.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();


            }



            DBQuery.DBWright("Insert into Changes (DeviceID, ColumnName, OldValue, NewValue, User, Date) values ('"+ LastUoNDeviceID + "', '"+ ColumnHeader + "','"+ OldValue + "','"+ LastCellValue + "','"+ CurrentUser + "','"+ Date + "')");

            if (IPCount != 0 || MACCount != 0)
            {
                DGVUoNDevices.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "NOT UNIQUE NOT SAVED";
                return;
            }


            if ((ColumnHeader == "PlannedIP" || ColumnHeader == "MAC") && NewValue == "")
            {
                DBQuery.DBWright("Update UoNDevices set " + ColumnHeader + "= null where DeviceID = '" + LastUoNDeviceID + "'");
            }
            else
            {
                if (ColumnHeader == "MAC")
                {
                    

                    DBQuery.DBWright("Update UoNDevices set MAC ='" + NewMAC + "' where DeviceID = '" + LastUoNDeviceID + "'");

                }
                else
                {
                    DBQuery.DBWright("Update UoNDevices set " + ColumnHeader + "='"+ LastCellValue + "' where DeviceID = '"+ LastUoNDeviceID + "'");
                }
                
            }

                

            String Empty = "";

            if (ColumnHeader == "MAC")
            {
                string CleanMac = NewValue;

                CleanMac = CleanMac.Replace(":", "");
                CleanMac = CleanMac.Replace("-", "");
                CleanMac = CleanMac.ToLower();

                DBQuery.DBWright("Update UoNDevices set CleanMAC='" + CleanMac + "' where DeviceID = '" + UoNDeviceID + "'");

                var macadres = CleanMac.ToLower();

                var regex = "(.{2})(.{2})(.{2})(.{2})(.{2})(.{2})";
                var replace = "$1$2.$3$4.$5$6";
                var NetworksMAC = Regex.Replace(macadres, regex, replace);

                //NetworksMAC = "0018.103A.B839"

                DBQuery.DBWright("Update UoNDevices set NetworksMAC='" + NetworksMAC + "' where DeviceID = '" + UoNDeviceID + "'");

            }

        }

        private void DGVUoNDevices_KeyPress(object sender, KeyPressEventArgs e)
        {

            //MessageBox.Show(e.KeyChar.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //select * from UoNDevices where plannedip != actualip and actualip != '' and plannedip != ''
            //select * from UoNDevices where plannedip != actualip and actualip != ''
            DGVUoNDevices.DataSource = DBQuery.DBGetDataSet("select * from UoNDevices where plannedip != actualip and actualip != '' and plannedip != ''");
        }


        private void DGVUoNDevices_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            LastCellValue = DGVUoNDevices.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            LastUoNDeviceID = DGVUoNDevices.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void buttonANDSearch_Click(object sender, EventArgs e)
        {
            //buttonANDSearch.Enabled = false;
            textBoxSearchBox.Text = textBoxSearchBox.Text + " *AND* ";
            textBoxSearchBox.SelectionStart = textBoxSearchBox.TextLength;
            textBoxSearchBox.Focus();
        }
    }
}
