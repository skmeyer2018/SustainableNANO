using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using TextBox = System.Web.UI.WebControls.TextBox;
using System.Text.RegularExpressions;

namespace ForSusNano
{
    public partial class SusNanoConfRegQry : System.Web.UI.Page
    {
        public string strQueryResult = "";
        public static OleDbConnection cnn;
        public static OleDbCommand strCmd, strCmdUpdate;
        public static OleDbDataAdapter da;
        public static DataSet dsSusNanoConfReg;
        public string strFName, strLName, strGender, strOrg, strAddr1, strAddr2, strCity, strState, strZip, strCountry, strEmail, strPhone, strPosition, strDept, strMainGeneralFocus, strOtherFocus, strSpecInt, strIntInSNO, strOtherSpecInt, strPaymentAmt, strPaymentType, strMemberType, strSubmitDate;
        public static string strPrevFName, strPrevLName;
        public static int nQueryRecCount, nCurrRec;
        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (nCurrRec + 1 >= nQueryRecCount) return;
            ++nCurrRec;
            DisplayQueryInfo(dsSusNanoConfReg, nCurrRec);
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if (nCurrRec - 1 <0) return;
            --nCurrRec;
            DisplayQueryInfo(dsSusNanoConfReg, nCurrRec);
        }

        protected void btnUpdateRecord_Click(object sender, EventArgs e)
        {
            StringBuilder sbUpdateQuery = new StringBuilder("UPDATE ConferenceRegistration SET ");
            sbUpdateQuery.Append("FirstName = '" + txtFName.Text.Trim() + "', ");
            sbUpdateQuery.Append("LastName = '" + txtLName.Text.Trim() + "', ");
            sbUpdateQuery.Append("Organization = '" + txtOrganization.Text.Trim() + "', ");
            sbUpdateQuery.Append("StreetAddress = '" + txtAddr1.Text.Trim() + "', ");
            sbUpdateQuery.Append("StreetAddressLine2 = '" + txtAddr2.Text.Trim() + "', ");
            sbUpdateQuery.Append("City = '" + txtCity.Text.Trim() + "', ");
            sbUpdateQuery.Append("State = '" + txtState.Text.Trim() + "', ");
            sbUpdateQuery.Append("ZipCode = '" + txtZip.Text.Trim() + "', ");
          
           sbUpdateQuery.Append("Country = '" + txtCountry.Text.Trim() + "', ");
           sbUpdateQuery.Append("Phone = '" + txtPhone.Text.Trim() + "', ");
          
         sbUpdateQuery.Append("Email = '" + txtEmail.Text.Trim() + "', ");
 
         sbUpdateQuery.Append("[Position] = '" + txtPosition.Text.Trim() + "', ");

    
         sbUpdateQuery.Append("Department = '" + txtDept.Text.Trim() + "', ");

         sbUpdateQuery.Append("Maingeneralfocusofnanotechnologyresearch = '" + ddlMainGeneralFocus.Text.Trim() + "', ");
         sbUpdateQuery.Append("OtherFocus = '" + txtOtherFocus.Text.Trim() + "', ");
         sbUpdateQuery.Append("Specificinterestsinsustainablenanotechnology = '" + txtSpecificInt.Text.Trim() + "', ");
         sbUpdateQuery.Append("OtherSpecificInterest = '" + txtOtherSpecificInterest.Text.Trim() + "', ");
         sbUpdateQuery.Append("InterestinSNO = '" + txtInterestInSNO.Text.Trim() + "', ");
         sbUpdateQuery.Append("PaymentAmount = '" + ddlPaymentAmount.Text + "', ");
         sbUpdateQuery.Append("PaymentType = '" + txtPaymentType.Text + "', ");
         sbUpdateQuery.Append("MembershipType = '" + ddlMembershipType.Text + "' ");
         
            sbUpdateQuery.Append(" WHERE (FirstName = '" + strPrevFName + "') AND (LastName = '" + strPrevLName + "')");

            try
            {
                cnn.Open();
                strCmdUpdate = new OleDbCommand(sbUpdateQuery.ToString(), cnn);

                da.UpdateCommand = strCmdUpdate;
                da.UpdateCommand.CommandText = strCmdUpdate.CommandText;
                da.UpdateCommand.ExecuteNonQuery();
                da.Update(dsSusNanoConfReg);
                cnn.Close();
                // MessageBox.Show("Record updated successfully!", "CONGRATULATIONS", MessageBoxButtons.OK);
                lblUpdateSuccess.Visible = true;
            }
            catch (SystemException excp)
            {
               // MessageBox.Show(excp.Message);
            }
        }

  
      

        protected void chkEditData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditData.Checked)
            {
                btnReset_Click(sender, e);
                lblEditMode.Visible = true;
                lblPrev.Visible = true;
                lblNext.Visible = true;
                btnNext.Visible = true;
                btnPrev.Visible = true;
                btnQueryField.Visible = true;
                btnUpdateRecord.Visible = true;
                btnSubmitQuery.Enabled = false;
                return;
            }
            else
            {
                lblEditMode.Visible = false;
                lblPrev.Visible = false;
                lblNext.Visible = false;
                btnNext.Visible = false;
                btnNext.Enabled = false;
                btnPrev.Visible = false;
                btnPrev.Enabled = false;
                btnQueryField.Visible = false;
                btnUpdateRecord.Visible = false;
                btnUpdateRecord.Enabled = false;
                btnSubmitQuery.Enabled = true;
                lblUpdateSuccess.Visible = false;
                btnReset_Click(sender, e);
            }
        }

        protected void btnQueryField_Click(object sender, EventArgs e)
        {

            string strSelectFName = txtFName.Text.Trim();
            string strSelectLName = txtLName.Text.Trim();
            if (strSelectFName == "" && strSelectLName == "")
            {
               // MessageBox.Show("Please enter text for first name and/or last name field.", "SEARCH BY NAME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string strNameQuery = "SELECT * FROM ConferenceRegistration WHERE FirstName LIKE '" + strSelectFName + "%' AND LastName LIKE '" + strSelectLName + "%' ORDER BY LastName, FirstName";
            dsSusNanoConfReg = new DataSet();
          pathDbFile = "~/App_Data/SNOMbrDB011_20141026B.mdb";
            fNameDb = Server.MapPath(pathDbFile);
            cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb);




          //  strCmd = new OleDbCommand(strNameQuery);
          //  da = new OleDbDataAdapter(strCmd.CommandText, cnn);
  
         //   OdbcConnection myODBC = new OdbcConnection();
          // var strODBCString = @"Driver={Microsoft Access Driver (*.mdb)};Dbq=" + fNameDb + ";Uid=Admin; Pwd=;";
           // myODBC.ConnectionString = strODBCString;
             strCmd = new OleDbCommand(strNameQuery);
           // OdbcCommand strCmd = new OdbcCommand(strNameQuery, myODBC);

           // OdbcDataAdapter da = new OdbcDataAdapter(strNameQuery, myODBC);
           // myODBC.Open();
            // cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb);
           //  strCmd = new OleDbCommand(strQueryResult);
            // OdbcDataAdapter da = new OdbcDataAdapter(strCmd.CommandText, myODBC);


             da = new OleDbDataAdapter(strCmd.CommandText, cnn);
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
                //Response.Output.Write(excp.Message);
            }
         //   dsSusNanoConfReg.Clear();
         /*
            try
            {
                da.Fill(dsSusNanoConfReg);
            }

            catch (Exception excp)
            {
               // MessageBox.Show(excp.Message);
                return;
            }*/
            nQueryRecCount = dsSusNanoConfReg.Tables[0].Rows.Count;
            nCurrRec = 0;
            DisplayQueryInfo(dsSusNanoConfReg, nCurrRec);
            btnPrev.Enabled = true;
            btnNext.Enabled = true;
            strPrevFName = txtFName.Text.Trim();
            strPrevLName = txtLName.Text.Trim();
            btnUpdateRecord.Enabled = true;
        }
        /*
                protected void chkEditData_CheckedChanged(object sender, EventArgs e)
                {
                    if (chkEditData.Checked)
                    {
                        btnReset_Click(sender, e);
                        lblEditMode.Visible = true;
                        lblPrev.Visible = true;
                        lblNext.Visible = true;
                        btnNext.Visible = true;
                        btnPrev.Visible = true;
                        btnQueryField.Visible = true;
                        btnUpdateRecord.Visible = true;
                        btnSubmitQuery.Enabled = false;
                        return;
                    }
                    else
                    {
                        lblEditMode.Visible = false;
                        lblPrev.Visible = false;
                        lblNext.Visible = false;
                        btnNext.Visible = false;
                        btnNext.Enabled = false;
                        btnPrev.Visible = false;
                        btnPrev.Enabled = false;
                        btnQueryField.Visible = false;
                        btnUpdateRecord.Visible = false;
                        btnUpdateRecord.Enabled = false;
                        btnSubmitQuery.Enabled = true;
                        btnReset_Click(sender, e);
                    }
                }
        */
        protected void btnReset_Click(object sender, EventArgs e)
        {




            try
            {

                foreach (System.Web.UI.Control ctrl in this.Form.Controls)
                {
                    if (ctrl is  TextBox )
  
                    {
                        TextBox newBox = new TextBox();
                        newBox = (TextBox)ctrl;
                        newBox.Text = "";
                        continue;
                    }
                    if (ctrl is DropDownList)
                    {
                        DropDownList newDrop = new DropDownList();
                        newDrop = (DropDownList)ctrl;
                        newDrop.SelectedIndex = 0;
                        continue;
                    }
                    if (ctrl is RadioButtonList)
                    {
                        RadioButtonList newRadio = new RadioButtonList();
                        newRadio = (RadioButtonList)ctrl;
                        newRadio.ClearSelection();
                    }
                        
                }
            }
            catch (Exception excp)
            {

            }
                    
         
        }

        protected void rblGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGender.Text = rblGender.SelectedValue;
        }

        public bool blFName, blLName, blGender, blOrg, blAddr1, blAddr2, blCity, blState, blZip, blCountry, blEmail, blPhone, blPosition, blDept, blMainGeneralFocus, blOtherFocus, blSpecInt, blIntInSNO, blOtherSpecInt, blPaymentAmt, blPaymentType, blMemberType, blSubmitDate=false;
        public static string pathDbFile, fNameDb;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //  pathDbFile = "D:\\Inetpub\\vhosts\\snoquerysite.com\\httpdocs\\SNOdb\\SNOdbSNOMbrDB011_20141026B.mdb";
                  pathDbFile= "~\\App_Data\\SNOMbrDB011_20141026B.mdb";
               
                fNameDb = Server.MapPath(pathDbFile);
                Response.Output.Write("<center><div style='position:relative; background-color:lightgreen; font-family:MicroFLF; font-size:25px;'><a  href='Index.html'>Back to Query Options Page </a></div></center>");
                cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb + ";");
              //  cnn = new OleDbConnection("SNODbConnect");

                // OdbcConnection myODBC = new OdbcConnection();
                //  var strODBCString = @"Driver={Microsoft Access Driver (*.mdb)};Dbq=" + fNameDb + ";Uid=Admin; Pwd=;";
                //   myODBC.ConnectionString = strODBCString;
                OleDbCommand strCmd = new OleDbCommand();

                strCmd.CommandText = "SELECT * FROM ConferenceRegistration";
               // OdbcCommand strCmd = new OdbcCommand("SELECT * FROM ConferenceRegistration",myODBC);
                
                da = new OleDbDataAdapter(strCmd.CommandText, cnn);
              //  OdbcDataAdapter da = new OdbcDataAdapter(strCmd.CommandText,  myODBC);
              // myODBC.Open();
               // myODBC.Close();
                
               dsSusNanoConfReg = new DataSet();
                dsSusNanoConfReg.Clear();
                da.Fill(dsSusNanoConfReg);
                
 
                int colCount = dsSusNanoConfReg.Tables[0].Columns.Count;
                int rowCount = dsSusNanoConfReg.Tables[0].Rows.Count;
               // Response.Output.Write(rowCount.ToString() + " records");
              //  Response.Output.Write(dsSusNanoConfReg.Tables[0].Rows[3][4].ToString());
                /*
                dsConfReg dsConf = new dsConfReg();
                */
            }
            catch (Exception ex)
            {
                Response.Output.Write(ex.Message);
            }
        }








        protected void rblPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPaymentType.Text = rblPaymentType.SelectedValue;
        }

        protected void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            strSubmitDate = txtSubmissionDate.Text;
            string yearPattern = @"\d{4}$";
            Regex rgxYear = new Regex(yearPattern);
            if (strSubmitDate != "")
            { 
                 if (!rgxYear.IsMatch(strSubmitDate))
                    {
                  //  MessageBox.Show("Please enter a four-digit year.", "INCORRECT INPUT!");
                    return;
                    }
            } 

            StringBuilder sbQuery = new StringBuilder("SELECT * FROM ConferenceRegistration WHERE ");
            if (txtFName.Text.Trim() != "")
            {
                strFName = txtFName.Text.Trim();
                blFName = true;
                queryBuild(sbQuery, "FirstName", strFName);
            }

            if (txtLName.Text.Trim() != "")
            {
                strLName = txtLName.Text.Trim();
                blLName = true;
                if (blFName) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "LastName", strLName);
            }
            if (txtGender.Text.Trim() != "")
            {
                strGender = txtGender.Text.Trim();
                blGender = true;
                if (blFName || blLName) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Gender", strGender);
            }
            if (txtOrganization.Text.Trim() != "")
            {
                strOrg = txtOrganization.Text.Trim();
                blOrg = true;
                if (blFName || blLName || blGender) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Organization", strOrg);
            }
            if (txtAddr1.Text.Trim() != "")
            {
                strAddr1 = txtAddr1.Text.Trim();
                blAddr1 = true;
                if (blFName || blLName || blGender || blOrg) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "StreetAddress", strAddr1);
            }
            if (txtAddr2.Text.Trim() != "")
            {
                strAddr2 = txtAddr2.Text.Trim();
                blAddr2 = true;
                if (blFName || blLName || blGender || blOrg || blAddr1) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "StreetAddressLine2", strAddr2);
            }
            if (txtCity.Text.Trim() != "")
            {
                strCity = txtCity.Text.Trim();
                blCity = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "City", strCity);
            }
            if (txtState.Text.Trim() != "")
            {
                strState = txtState.Text.Trim();
                blState = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "State", strState);
            }
            if (txtZip.Text.Trim() != "")
            {
                strZip = txtZip.Text.Trim();
                blZip = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "ZipCode", strZip);
            }
            if (txtCountry.Text.Trim() != "")
            {
                strCountry = txtCountry.Text.Trim();
                blCountry = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Country", strCountry);
            }
            if (txtPhone.Text.Trim() != "")
            {
                strPhone = txtPhone.Text.Trim();
                blPhone = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip || blCountry) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Phone", strPhone);
            }
            if (txtEmail.Text.Trim() != "")
            {
                strEmail = txtEmail.Text.Trim();
                blEmail = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip  || blCountry || blPhone) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Email", strEmail);
            }
            if (txtPosition.Text.Trim() != "")
            {
                strPosition = txtPosition.Text.Trim();
                blPosition = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip || blCountry || blPhone || blEmail) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Position", strPosition);
            }
            if (txtDept.Text.Trim() != "")
            {
                strDept = txtDept.Text.Trim();
                blDept = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip || blCountry || blPhone || blEmail || blPosition) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Department", strDept);
            }
            if (ddlMainGeneralFocus.Text.Trim() != "")
            {
                strMainGeneralFocus = ddlMainGeneralFocus.Text.Trim();
                blMainGeneralFocus = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip || blCountry || blPhone || blEmail || blPosition || blDept) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Maingeneralfocusofnanotechnologyresearch", strMainGeneralFocus );
            }
            if (txtOtherFocus.Text.Trim() != "")
            {
                strOtherFocus = txtOtherFocus.Text.Trim();
                blOtherFocus = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip || blCountry || blPhone || blEmail || blPosition || blDept || blMainGeneralFocus) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "OtherFocus", strOtherFocus);
            }
        
            if (txtSpecificInt.Text.Trim() != "")
            {
                strSpecInt = txtSpecificInt.Text.Trim();
                blSpecInt = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip || blCountry || blPhone || blEmail || blPosition || blDept || blMainGeneralFocus || blOtherFocus) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Specificinterestsinsustainablenanotechnology", strSpecInt);
            }
            if (txtInterestInSNO.Text.Trim() != "")
            {
                strIntInSNO = txtInterestInSNO.Text.Trim();
                blIntInSNO = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip || blCountry || blPhone || blEmail || blPosition || blDept || blMainGeneralFocus || blOtherFocus || blSpecInt) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "InterestinSNO", strIntInSNO);
            }
            if (ddlPaymentAmount.Text.Trim() != "")
            {
                strPaymentAmt = ddlPaymentAmount.Text.Trim();
                blPaymentAmt = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip || blCountry || blPhone || blEmail || blPosition || blDept || blMainGeneralFocus || blOtherFocus || blSpecInt || blIntInSNO) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "PaymentAmount", strPaymentAmt);
            }
            if (txtPaymentType.Text.Trim() != "")
            {
                strPaymentType = txtPaymentType.Text.Trim();
                blPaymentType = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip || blCountry || blPhone || blEmail || blPosition || blDept || blMainGeneralFocus || blOtherFocus || blSpecInt || blIntInSNO || blPaymentAmt) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "PaymentType", strPaymentType);
            }
            if (ddlMembershipType.Text.Trim() != "")
            {
                strMemberType = ddlMembershipType.Text.Trim();
                blMemberType = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip || blCountry || blPhone || blEmail || blPosition || blDept || blMainGeneralFocus || blOtherFocus || blSpecInt || blIntInSNO || blPaymentAmt || blPaymentType) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "MembershipType", strMemberType);
            }
            if (txtSubmissionDate.Text.Trim() != "")
            {
                strSubmitDate = txtSubmissionDate.Text.Trim();
                blSubmitDate = true;
                if (blFName || blLName || blGender || blOrg || blAddr1 || blAddr2 || blCity || blState || blZip || blCountry || blPhone || blEmail || blPosition || blDept || blMainGeneralFocus || blOtherFocus || blSpecInt || blIntInSNO || blPaymentAmt || blPaymentType || blMemberType) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "SubmissionDate", strSubmitDate);
            }
            strQueryResult = sbQuery.ToString();
            Session["CurrentQuery"] = strQueryResult;
             Server.Transfer("ConfRegQryResults.aspx");
             /*
            try
            {
                cnn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + fNameDb);
                OleDbCommand strCmd = new OleDbCommand(strQueryResult);
                OleDbDataAdapter da = new OleDbDataAdapter(strCmd.CommandText, cnn);

                dsSusNanoConfReg = new DataSet();
                dsSusNanoConfReg.Clear();
                da.Fill(dsSusNanoConfReg);
            }
            catch (Exception ex)
            {
                Response.Output.Write(ex.Message);
            }
             */
            int colCount = dsSusNanoConfReg.Tables[0].Columns.Count;
            int rowCount = dsSusNanoConfReg.Tables[0].Rows.Count;
            dsConfReg dsConf = new dsConfReg();
            
            TableRow trRes = new TableRow();
            trRes.BackColor = System.Drawing.Color.LightGreen;
           // Application docApp = new Application();
         //   docApp.Documents.Add();
            Document docReport = new Document();
            docReport.Activate();
            int contRow = 0;
            int contCol = 0;
            var docPara = docReport.Paragraphs.Add();
            StringBuilder sbReport = new StringBuilder();
            // docPara.Range.Text = "HERE IS MY DATA REPORT" + Environment.NewLine;
            //docReport.Content.SetRange(0, 200);
            // docReport.Content.Paragraphs.Add(docPara);
            /*
            for (int r=0; r<rowCount; r++)
             {
                 sbReport.Append("NAME: " + dsSusNanoConfReg.Tables[0].Rows[r]["FirstName"] + Convert.ToChar(32)  + dsSusNanoConfReg.Tables[0].Rows[r]["MiddleInitial"] + Convert.ToChar(32) + dsSusNanoConfReg.Tables[0].Rows[r]["LastName"] + Convert.ToChar(32));
                 sbReport.Append("ORGANIZATION: " + dsSusNanoConfReg.Tables[0].Rows[r]["Organization"] + "," + Convert.ToChar(32) + dsSusNanoConfReg.Tables[0].Rows[r]["MembershipType"] + Environment.NewLine);
                 sbReport.Append("ADDRESS: " + dsSusNanoConfReg.Tables[0].Rows[r]["StreetAddress"] + "   " + dsSusNanoConfReg.Tables[0].Rows[r]["StreetAddressLine2"] + "," + Convert.ToChar(32));
                 sbReport.Append( dsSusNanoConfReg.Tables[0].Rows[r]["City"] + "," + Convert.ToChar(32));
                 sbReport.Append( dsSusNanoConfReg.Tables[0].Rows[r]["State"] + "," + Convert.ToChar(32));
                 sbReport.Append( dsSusNanoConfReg.Tables[0].Rows[r]["ZipCode"] + "," + Convert.ToChar(32));
                 sbReport.Append( dsSusNanoConfReg.Tables[0].Rows[r]["Country"] + Environment.NewLine);
                 sbReport.Append("PHONE: " + dsSusNanoConfReg.Tables[0].Rows[r]["Phone"] + Environment.NewLine);
                 sbReport.Append("EMAIL: " + dsSusNanoConfReg.Tables[0].Rows[r]["Email"] + Environment.NewLine);
                 sbReport.Append("POSITION: " + dsSusNanoConfReg.Tables[0].Rows[r]["Position"] + "," + Convert.ToChar(32) + dsSusNanoConfReg.Tables[0].Rows[r]["Department"] + Environment.NewLine);
                 sbReport.Append("MAIN GENERAL FOCUS OF NANOTECHNOLOGY RESEARCH: " + dsSusNanoConfReg.Tables[0].Rows[r]["Maingeneralfocusofnanotechnologyresearch"] + Environment.NewLine);
                 sbReport.Append("SPECIFIC INTERESTS IN SUSTAINABLE NANOTECHNOLOGY: " + dsSusNanoConfReg.Tables[0].Rows[r]["Specificinterestsinsustainablenanotechnology"] + Environment.NewLine);
                 sbReport.Append("INTEREST IN SNO: " + dsSusNanoConfReg.Tables[0].Rows[r]["InterestinSNO"] + Environment.NewLine);
                 sbReport.Append("PAYMENT: " + dsSusNanoConfReg.Tables[0].Rows[r]["PaymentAmount"] + "," + Convert.ToChar(32) + dsSusNanoConfReg.Tables[0].Rows[r]["PaymentType"] + Environment.NewLine);
                 sbReport.AppendLine(string.Concat(Enumerable.Repeat("_", 160)));
             }
             docPara.Range.Text = sbReport.ToString();
            */
            pathDbFile = "~/App_Data/SNOMbrDB011_20141026B.mdb";
            fNameDb = Server.MapPath(pathDbFile);
            OdbcConnection myODBC = new OdbcConnection();
            var strODBCString = @"Driver={Microsoft Access Driver (*.mdb)};Dbq=" + fNameDb + ";Uid=Admin; Pwd=;";
            myODBC.ConnectionString = strODBCString;
            // strCmd = new OleDbCommand(strQueryResult);
            OdbcCommand strCmd = new OdbcCommand(strQueryResult, myODBC);

            // da = new OleDbDataAdapter(strCmd.CommandText, cnn);
            OdbcDataAdapter da = new OdbcDataAdapter(strCmd.CommandText, myODBC);
            myODBC.Open();
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
                Response.Output.Write(excp.Message);
            }
             colCount = dsSusNanoConfReg.Tables[0].Columns.Count;
             rowCount = dsSusNanoConfReg.Tables[0].Rows.Count;
            for (int c = 0; c < colCount-1; c++)
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
            myODBC.Close();
            //  docPara.Range.Text = sbReport.ToString();
            //  docReport.SaveAs2("DataReport.docx");
         
            Table1.Rows.Add(trRes);
            StringBuilder sbResults = new StringBuilder();
            sbResults.Clear();
            for (int r = 0; r < rowCount; r++)
            {
                trRes = new TableRow();
                if (r % 2 == 0) trRes.BackColor = System.Drawing.Color.Lavender;
                for (int c = 0; c < colCount-1; c++)
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
                Table1.Rows.Add(trRes);
                
                sbResults.Clear();
            }

        }

         void queryBuild (StringBuilder sbQry, string strFieldName, string strFieldVal)
        {
            sbQry.Append("[" + strFieldName + "] LIKE '%" + strFieldVal + "%' ");
        }

        protected void DisplayQueryInfo(DataSet dsQuery, int nRec)
        {
           
            txtFName.Text = dsQuery.Tables[0].Rows[nRec]["FirstName"].ToString();
            txtLName.Text = dsQuery.Tables[0].Rows[nRec]["LastName"].ToString();
            txtOrganization.Text = dsQuery.Tables[0].Rows[nRec]["Organization"].ToString();
            txtEmail.Text = dsQuery.Tables[0].Rows[nRec]["Email"].ToString();
            txtDept.Text = dsQuery.Tables[0].Rows[nRec]["Department"].ToString();
            txtPosition.Text = dsQuery.Tables[0].Rows[nRec]["Position"].ToString();
            txtAddr1.Text = dsQuery.Tables[0].Rows[nRec]["StreetAddress"].ToString();
            txtAddr2.Text = dsQuery.Tables[0].Rows[nRec]["StreetAddressLine2"].ToString();
            txtCity.Text = dsQuery.Tables[0].Rows[nRec]["City"].ToString();
            txtState.Text= dsQuery.Tables[0].Rows[nRec]["State"].ToString();
            txtZip.Text = dsQuery.Tables[0].Rows[nRec]["ZipCode"].ToString();
            txtCountry.Text = dsQuery.Tables[0].Rows[nRec]["Country"].ToString();
            txtPhone.Text = dsQuery.Tables[0].Rows[nRec]["Phone"].ToString();
            txtDept.Text = dsQuery.Tables[0].Rows[nRec]["Department"].ToString();
            ddlMainGeneralFocus.Text = dsQuery.Tables[0].Rows[nRec]["Maingeneralfocusofnanotechnologyresearch"].ToString();
            txtOtherFocus.Text = dsQuery.Tables[0].Rows[nRec]["OtherFocus"].ToString();
            txtSpecificInt.Text = dsQuery.Tables[0].Rows[nRec]["Specificinterestsinsustainablenanotechnology"].ToString();
            txtOtherSpecificInterest.Text = dsQuery.Tables[0].Rows[nRec]["OtherSpecificInterest"].ToString();
           // MessageBox.Show(dsQuery.Tables[0].Rows[nRec]["InterestinSNO"].ToString());
            txtInterestInSNO.Text = dsQuery.Tables[0].Rows[nRec]["InterestinSNO"].ToString().Trim();
            ddlPaymentAmount.Text = dsQuery.Tables[0].Rows[nRec]["PaymentAmount"].ToString();
            txtPaymentType.Text = dsQuery.Tables[0].Rows[nRec]["PaymentType"].ToString();
            txtSubmissionDate.Text = dsQuery.Tables[0].Rows[nRec]["SubmissionDate"].ToString();
            ddlMembershipType.Text = dsQuery.Tables[0].Rows[nRec]["MembershipType"].ToString();
 
            strPrevFName = txtFName.Text.Trim();
            strPrevLName = txtLName.Text.Trim();
  
        }
    }
    }
