using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Threading;

namespace ForSusNano
{
    public partial class ConfRegQryResults : System.Web.UI.Page
    {
        public string pathDbFile, fNameDb;
        public OleDbConnection cnn;
        public OleDbCommand strCmd;
        public OleDbDataAdapter da;

        public DataSet dsSusNanoConfReg;
        protected void Page_Load(object sender, EventArgs e)
        {
           // Response.Output.Write(Session["CurrentQuery"]);
            string strQueryResult = (string)Session["CurrentQuery"];
            pathDbFile = "~\\App_Data\\SNOMbrDB011_20141026B.mdb";
            fNameDb = Server.MapPath(pathDbFile);
            //  pathDbFile = "D:\\Inetpub\\vhosts\\snoquerysite.com\\httpdocs\\SNOdb\\SNOdbSNOMbrDB011_20141026B.mdb";
           
            Response.Output.Write("<center><div style='position:relative; background-color:lightgreen; font-family:MicroFLF; font-size:25px;'><a  href='Index.html'>Back to Query Options Page </a></div></center>");
            cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb);
           // OdbcConnection myODBC = new OdbcConnection();
           // var strODBCString = @"Driver={Microsoft Access Driver (*.mdb)};Dbq=" + fNameDb + ";Uid=Admin; Pwd=;";
           // myODBC.ConnectionString = strODBCString;
             strCmd = new OleDbCommand(strQueryResult);
           // OdbcCommand strCmd = new OdbcCommand("SELECT * FROM ConferenceRegistration", myODBC);

             da = new OleDbDataAdapter(strCmd.CommandText, cnn);
          // OdbcDataAdapter da = new OdbcDataAdapter(strCmd.CommandText, myODBC);
          // myODBC.Open();
            // cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb);
            // strCmd = new OleDbCommand(strQueryResult);
           // OdbcDataAdapter da = new OdbcDataAdapter(strCmd.CommandText, myODBC);


            // da = new OleDbDataAdapter(strCmd.CommandText, cnn);
           // OdbcDataAdapter da = new OdbcDataAdapter(strCmd.CommandText, myODBC);
            dsSusNanoConfReg = new DataSet();
            dsSusNanoConfReg.Clear();
            try
            {
                da.Fill(dsSusNanoConfReg);
            }
            
            catch (Exception excp)
            {
                  Server.Transfer("SusNanoConfRegQry.aspx");
               // Response.Output.Write(excp.Message);
            }
            int rowCount = dsSusNanoConfReg.Tables[0].Rows.Count;
            int colCount = dsSusNanoConfReg.Tables[0].Columns.Count;
            Response.Output.Write("<center><div style='position:relative;'><a  href='SusNanoConfRegQry.aspx'>Conference Registration Query Page</a><br><a  href='Index.html'>Query Options Page</a></div></center>");
            TableRow trRes = new TableRow();
            trRes.BackColor = System.Drawing.Color.LightGreen;
            for (int c = 0; c < colCount - 1; c++)
            {
                //   if (c == 4 || c == 5 || c == 7 || (c >= 9 && c <= 13) || c==18 || c==20 || c==21 || c==22 || c>=24  )continue;
                // sbResults.Append(dsSusNanoConfReg.Tables[0].Columns[c].ColumnName.ToUpper().PadRight(20) );
                // if (dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactNameLFM" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactIsPublic" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactEntryFKUserID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactEditFKUserID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "AddrID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "PhoneID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "PhoneFKContactID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "AddrFKContactID") continue;

                TableCell tcFieldName = new TableCell();
                tcFieldName.Text = dsSusNanoConfReg.Tables[0].Columns[c].ColumnName.ToUpper();
                tcFieldName.Font.Bold = true;
                tcFieldName.Font.Underline = true;
                tcFieldName.Font.Size = FontUnit.Small;
                tcFieldName.Font.Name = "MicroFLF";
                trRes.Cells.Add(tcFieldName);

                // docReport.Content.Underline = WdUnderline.wdUnderlineSingle;
                // sbReport.Append(tcFieldName.Text.PadRight(tcFieldName.Text.Length + 2));
                // docPara.Range.Text= tcFieldName.Text;
                //docReport.Content.Text = tcFieldName.Text; 
                //contCol += tcFieldName.Text.Trim().Length + 1;
                // docReport.Content.InsertAfter("       ");

            }
            tblQueryResults.Rows.Add(trRes);
            for (int r = 0; r < rowCount; r++)
            {
                trRes = new TableRow();
                if (r % 2 == 0) trRes.BackColor = System.Drawing.Color.Lavender;
                for (int c = 0; c < colCount - 1; c++)
                {
                    // if (c == 4 || c == 5 || c == 7 || (c >= 9 && c <= 13) || c == 18 || c == 20 || c == 21 || c == 22 || c >= 24) continue;
                    // if (dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactNameLFM" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactIsPublic" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactEntryFKUserID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactEditFKUserID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "AddrID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "PhoneID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "PhoneFKContactID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "AddrFKContactID") continue;
                    Thread.Sleep(0);
                    TableCell tcRes = new TableCell();
                    tcRes.Font.Size = FontUnit.Small;
                    tcRes.Font.Name = "Candara";
                    tcRes.Text = dsSusNanoConfReg.Tables[0].Rows[r][c].ToString();
                    trRes.Cells.Add(tcRes);
                    //sbResults.Append(dsSusNanoConfReg.Tables[0].Rows[r][c].ToString().PadRight(10));

                }
                tblQueryResults.Rows.Add(trRes);

            }
                /*
                for (int r=0; r<rowCount; r++)
                {
                    Response.Output.Write("<b><u>NAME:</u></b><p> " + dsSusNanoConfReg.Tables[0].Rows[r]["FirstName"] + Convert.ToChar(32) + dsSusNanoConfReg.Tables[0].Rows[r]["MiddleInitial"] + Convert.ToChar(32) + dsSusNanoConfReg.Tables[0].Rows[r]["LastName"] + "</p><br>");
                    Response.Output.Write("<b><u>GENDER:</u></b><p> " + dsSusNanoConfReg.Tables[0].Rows[r]["Gender"] + "</p><br>");
                    Response.Output.Write("<b><u>ORGANIZATION:</u></b><p> " + dsSusNanoConfReg.Tables[0].Rows[r]["Organization"] + "," + Convert.ToChar(32) + dsSusNanoConfReg.Tables[0].Rows[r]["MembershipType"]  + "</p><br>");
                    Response.Output.Write("<b><u>ADDRESS:</u></b><p> " + dsSusNanoConfReg.Tables[0].Rows[r]["StreetAddress"] + "   " + dsSusNanoConfReg.Tables[0].Rows[r]["StreetAddressLine2"] + "," + Convert.ToChar(32));
                    Response.Output.Write(dsSusNanoConfReg.Tables[0].Rows[r]["City"] + "," + Convert.ToChar(32));
                    Response.Output.Write(dsSusNanoConfReg.Tables[0].Rows[r]["State"] + "," + Convert.ToChar(32));
                    Response.Output.Write(dsSusNanoConfReg.Tables[0].Rows[r]["ZipCode"] + "," + Convert.ToChar(32));
                    Response.Output.Write(dsSusNanoConfReg.Tables[0].Rows[r]["Country"] + "</p><br>");
                    Response.Output.Write("<b><u>PHONE:</u></b><p> " + dsSusNanoConfReg.Tables[0].Rows[r]["Phone"] + "</p><br>");
                    Response.Output.Write("<b><u>EMAIL:</u></b><p> " + dsSusNanoConfReg.Tables[0].Rows[r]["Email"] + "</p><br>");
                    Response.Output.Write("<b><u>POSITION:</u></b><p> " + dsSusNanoConfReg.Tables[0].Rows[r]["Position"] + "," + Convert.ToChar(32) + dsSusNanoConfReg.Tables[0].Rows[r]["Department"] + "</p><br>");
                    Response.Output.Write("<b><u>MAIN GENERAL FOCUS OF NANOTECHNOLOGY RESEARCH:</u></b><p> " + dsSusNanoConfReg.Tables[0].Rows[r]["Maingeneralfocusofnanotechnologyresearch"] + "</p><br>");
                    Response.Output.Write("<b><u>SPECIFIC INTERESTS IN SUSTAINABLE NANOTECHNOLOGY:</u></b><p> " + dsSusNanoConfReg.Tables[0].Rows[r]["Specificinterestsinsustainablenanotechnology"] + "</p><br>");
                    Response.Output.Write("<b><u>INTEREST IN SNO:</u></b><p> " + dsSusNanoConfReg.Tables[0].Rows[r]["InterestinSNO"] + "</p><br>");
                    Response.Output.Write("<b><u>PAYMENT:</u></b><p> " + dsSusNanoConfReg.Tables[0].Rows[r]["PaymentAmount"] + "," + Convert.ToChar(32) + dsSusNanoConfReg.Tables[0].Rows[r]["PaymentType"] + "</p><br>");
                    Response.Output.Write("<HR style='height:3px; background-color:black'>");
                }
    */
            }
    }
}