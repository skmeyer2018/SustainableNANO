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
    public partial class StudAwardApplQryRes : System.Web.UI.Page
    {
           public string pathDbFile, fNameDb;
            public OleDbConnection cnn;
            public OleDbCommand strCmd;
            public OleDbDataAdapter da;
            public DataSet dsSusNanoStudAwrd;
        protected void Page_Load(object sender, EventArgs e)
        {

            string strQueryResult = (string)Session["CurrentQuery"];
            pathDbFile = "~/App_Data/SNOMbrDB011_20141026B.mdb";
            fNameDb = Server.MapPath(pathDbFile);
            cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb);
            strCmd = new OleDbCommand(strQueryResult);
            da = new OleDbDataAdapter(strCmd.CommandText, cnn);

            dsSusNanoStudAwrd = new DataSet();
            dsSusNanoStudAwrd.Clear();
            try
            {
                da.Fill(dsSusNanoStudAwrd);
            }

            catch (Exception excp)
            {
                Server.Transfer("SusNanoStudentAwardAppl.aspx");
            }
            int colCount= dsSusNanoStudAwrd.Tables[0].Columns.Count;
            int rowCount = dsSusNanoStudAwrd.Tables[0].Rows.Count;
            Response.Output.Write("<center><div style='position:relative;'><a  href='SusNanoStudentAwardAppl.aspx'>Student Awards Application Query Page</a><br><a  href='Index.html'>Query Options Page</a></div></center>");
            TableRow trRes = new TableRow();
            trRes.BackColor = System.Drawing.Color.LightGreen;
            for (int c = 0; c < colCount - 1; c++)
            {
                //   if (c == 4 || c == 5 || c == 7 || (c >= 9 && c <= 13) || c==18 || c==20 || c==21 || c==22 || c>=24  )continue;
                // sbResults.Append(dsSusNanoConfReg.Tables[0].Columns[c].ColumnName.ToUpper().PadRight(20) );
                // if (dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactNameLFM" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactIsPublic" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactEntryFKUserID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "ContactEditFKUserID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "AddrID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "PhoneID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "PhoneFKContactID" || dsSusNanoConfReg.Tables[0].Columns[c].ColumnName == "AddrFKContactID") continue;

                TableCell tcFieldName = new TableCell();
                tcFieldName.Text = dsSusNanoStudAwrd.Tables[0].Columns[c].ColumnName.ToUpper();
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
                    tcRes.Text = dsSusNanoStudAwrd.Tables[0].Rows[r][c].ToString();
                    trRes.Cells.Add(tcRes);
                    //sbResults.Append(dsSusNanoConfReg.Tables[0].Rows[r][c].ToString().PadRight(10));

                }
                tblQueryResults.Rows.Add(trRes);

            }
            /*
            for (int r = 0; r < rowCount; r++)
            {
                Response.Output.Write("<b><u>NAME:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["FirstName"] + Convert.ToChar(32) + dsSusNanoStudAwrd.Tables[0].Rows[r]["MiddleInitial"] + Convert.ToChar(32) + dsSusNanoStudAwrd.Tables[0].Rows[r]["LastName"] + "</p><br>");
                Response.Output.Write("<b><u>POSTER:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["Poster"] + "</p><br>");
                Response.Output.Write("<b><u>REGISTERED:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["Registered"] + "</p><br>");
                Response.Output.Write("<b><u>AMOUNT OWED:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["AmountOwed"] + "</p><br>");
                Response.Output.Write("<b><u>ACCEPTED:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["Accepted"] + "</p><br>");
                Response.Output.Write("<b><u>REGISTERED:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["Registered"] + "</p><br>");
                Response.Output.Write("<b><u>INSTITUTION:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["Institution"] + "</p><br>");
                Response.Output.Write("<b><u>EMAIL:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["Email"] + "</p><br>");
                Response.Output.Write("<b><u>DEPARTMENT:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["Department"] + "</p><br>");
                Response.Output.Write("<b><u>STUDENT STATUS:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["StudentStatus"] + "</p><br>");
                Response.Output.Write("<b><u>TITLE OF POSTER:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["TitleOfPoster"] + "</p><br>");
                Response.Output.Write("<b><u>PREFERRED TOPIC:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["PreferredTopic"] + "</p><br>");
                Response.Output.Write("<b><u>RESUME:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["Resume"] + "</p><br>");
                Response.Output.Write("<b><u>SUBMISSION DATE:</u></b><p> " + dsSusNanoStudAwrd.Tables[0].Rows[r]["SubmissionDate"] + "</p><br>");
                string strResume = dsSusNanoStudAwrd.Tables[0].Rows[r]["UploadURL"].ToString();
                
                HyperLink hlResume = new HyperLink();
                hlResume.NavigateUrl = strResume;
                hlResume.Text = strResume;
        
                Response.Output.Write("<b><u>UPLOAD URL:</u></b>");
                Response.Output.Write("<button onclick='window.location = \"" + hlResume.Text + "\"'>" + strResume + "</button>");
         
                Response.Output.Write("<HR style='height:3px; background-color:black'>");
            
            }
            */
        }
    }
    }
