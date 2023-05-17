using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForSusNano
{
    public partial class CallAbstrQryResults : System.Web.UI.Page
    {
        public string pathDbFile, fNameDb;
        public OleDbConnection cnn;
        public OleDbCommand strCmd;
        public OleDbDataAdapter da;
        public DataSet dsSusNanoCallAbstr;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strQueryResult = (string)Session["CurrentQuery"];
            pathDbFile = "~/App_Data/SNOMbrDB011_20141026B.mdb";
            fNameDb = Server.MapPath(pathDbFile);
            cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb);
            strCmd = new OleDbCommand(strQueryResult);
            da = new OleDbDataAdapter(strCmd.CommandText, cnn);

            dsSusNanoCallAbstr = new DataSet();
            dsSusNanoCallAbstr.Clear();
            try
            {
                da.Fill(dsSusNanoCallAbstr);
            }

            catch (Exception excp)
            {
                Server.Transfer("SusNanoCallAbstrQry.aspx");
            }

            int rowCount = dsSusNanoCallAbstr.Tables[0].Rows.Count;
            int colCount = dsSusNanoCallAbstr.Tables[0].Columns.Count;

            Response.Output.Write("<center><div style='position:relative;'><a  href='SusNanoCallAbstrQry.aspx'>Call for Abstracts Query Page</a><br><a  href='Index.html'>Query Options Page</a></div></center>");
            TableRow trRes = new TableRow();
            trRes.BackColor = System.Drawing.Color.LightGreen;
            for (int c = 0; c < colCount - 1; c++)
            {
                //   if (c == 4 || c == 5 || c == 7 || (c >= 9 && c <= 13) || c==18 || c==20 || c==21 || c==22 || c>=24  )continue;
                // sbResults.Append(dsSusNanoConfReg.Tables[0].Columns[c].ColumnName.ToUpper().PadRight(20) );
                // if (dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactNameLFM" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactIsPublic" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactEntryFKUserID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactEditFKUserID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "AddrID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "PhoneID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "PhoneFKContactID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "AddrFKContactID") continue;

                TableCell tcFieldName = new TableCell();
                tcFieldName.Text = dsSusNanoCallAbstr.Tables[0].Columns[c].ColumnName.ToUpper();
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
                    tcRes.Text = dsSusNanoCallAbstr.Tables[0].Rows[r][c].ToString();
                    trRes.Cells.Add(tcRes);
                    //sbResults.Append(dsSusNanoConfReg.Tables[0].Rows[r][c].ToString().PadRight(10));

                }
                tblQueryResults.Rows.Add(trRes);

            }
            for (int r = 0; r < rowCount; r++)
            {
                /*
                Response.Output.Write("<b><u>TITLE:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["TitleOfPaper"] + "</p><br>");
                Response.Output.Write("<b><u>PREFERRED SESSION:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["PreferredSession"] + "</p><br>");
                Response.Output.Write("<b><u>ORAL OR POSTER:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["SelectOne"] + "</p><br>");
                Response.Output.Write("<b><u>PRESENTATION AUTHOR:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["PresentationAuthor"] + "</p><br>");
                Response.Output.Write("<b><u>GENDER:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["Gender"] + "</p><br>");
                Response.Output.Write("<b><u>PHONE:</u></b><p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["PhoneNumber"] + " </p><br>");
                Response.Output.Write("<b><u>WRITER NAME:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["WriterName"] + " </p><br>");
                Response.Output.Write("<b><u>AFFILIATION:</u></b> <p> " + dsSusNanoCallAbstr.Tables[0].Rows[r]["Affiliation"] + " </p><br>");
                Response.Output.Write("<b><u>EMAIL:</u></b><p> " + dsSusNanoCallAbstr.Tables[0].Rows[r]["Email"] + "</p><br>");
                Response.Output.Write("<b><u>SUBMISSION DATE:</u></b><p> " + dsSusNanoCallAbstr.Tables[0].Rows[r]["SubmissionDate"] + "</p><br>");
                Response.Output.Write("<b><u>NAME2:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["Name2"] + " </p><br>");
                Response.Output.Write("<b><u>GENDER2:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["Gender2"] + "</p><br>");
                Response.Output.Write("<b><u>AFFILIATION2:</u></b> <p> " + dsSusNanoCallAbstr.Tables[0].Rows[r]["Affiliation2"] + " </p><br>");
                Response.Output.Write("<b><u>EMAIL2:</u></b><p> " + dsSusNanoCallAbstr.Tables[0].Rows[r]["Email2"] + "</p><br>");
                Response.Output.Write("<b><u>PRESENTING AUTHOR:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["PresentingAuthor"] + "</p><br>");
                Response.Output.Write("<b><u>NAME3:</u></b> <p> " + dsSusNanoCallAbstr.Tables[0].Rows[r]["Name3"] + " </p><br> ");
                Response.Output.Write("<b><u>GENDER3:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["Gender3"] + "</p><br>");
                Response.Output.Write("<b><u>AFFILIATION3:</u></b> <p> " + dsSusNanoCallAbstr.Tables[0].Rows[r]["Affiliation3"] + " </p><br>");
                Response.Output.Write("<b><u>EMAIL3:</u></b><p> " + dsSusNanoCallAbstr.Tables[0].Rows[r]["Email3"] + "</p><br>");
                Response.Output.Write("<b><u>PRESENTING AUTHOR2:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["PresentingAuthor2"] + "</p><br>");
                Response.Output.Write("<b><u>OTHER AUTHORS:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["OtherAuthors"] + "</p><br>");
                Response.Output.Write("<b><u>SUSTAINABILITY:</u></b> <p>" + dsSusNanoCallAbstr.Tables[0].Rows[r]["Sustainability"] + "</p><br>");
                Response.Output.Write("<b><u>ABSTRACT:</u></b><p> " + dsSusNanoCallAbstr.Tables[0].Rows[r]["Abstract(250words)"] + "</p><br>");
                Response.Output.Write("<HR style='height:3px; background-color:black'>");
                */
            }
     
            
            
            
  
        
        }
    }
}