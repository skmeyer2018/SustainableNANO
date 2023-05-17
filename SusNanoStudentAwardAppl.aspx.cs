using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ForSusNano
{
    public partial class SusNanoStudentAwardAppl : System.Web.UI.Page
    {
        public string strQueryResult = "";
        public static OleDbConnection cnn;
        public static OleDbCommand strCmd, strCmdUpdate;
        public static  OleDbDataAdapter da;
        public static DataSet dsSusNanoStudAwrd;
        public string strFName, strLName, strPoster, strReg, strAmount, strAccpt, strInst, strEmail, strDept, strStatus, strTitle, strTopic, strResume, strUploadURL, strSubmitDate;
        public static string strPrevFName, strPrevLName;
        protected void btnUpdateRecord_Click(object sender, EventArgs e)
        {
            StringBuilder sbUpdateQuery = new StringBuilder("UPDATE StudentAwardApplication SET ");
            sbUpdateQuery.Append("FirstName = '" + txtFName.Text.Trim() + "', ");
            sbUpdateQuery.Append("LastName = '" + txtLName.Text.Trim() + "', ");
            sbUpdateQuery.Append("Institution = '" + txtInstitution.Text.Trim() + "', ");
            sbUpdateQuery.Append("Email = '" + txtEmail.Text.Trim() + "', ");
            sbUpdateQuery.Append("Department = '" + txtDept.Text.Trim() + "', ");
            sbUpdateQuery.Append("TitleOfPoster = '" + txtTitle.Text.Trim() + "', ");
            sbUpdateQuery.Append("Resume = '" + txtResume.Text.Trim() + "', ");
            sbUpdateQuery.Append("UploadURL = '" + txtUploadURL.Text.Trim() + "', ");
            sbUpdateQuery.Append("PreferredTopic = '" + ddlTopic.Text.Trim() + "', ");
            sbUpdateQuery.Append("StudentStatus = '" + ddlAmountOwed.Text.Trim() + "', ");
            sbUpdateQuery.Append("Poster = '" + txtPoster.Text.Trim() + "', ");
            sbUpdateQuery.Append("SubmissionDate = '" + txtSubmitDate.Text.Trim() + "', ");
            sbUpdateQuery.Append("Registered = '" + chkRegistered.Checked + "', ");
            sbUpdateQuery.Append("Accepted = '" + chkAccepted.Checked + "' ");
            sbUpdateQuery.Append(" WHERE (FirstName = '" + strPrevFName + "') AND (LastName = '" + strPrevLName + "')");
            try
            {
                cnn.Open();
                strCmdUpdate = new OleDbCommand(sbUpdateQuery.ToString(), cnn);

                da.UpdateCommand = strCmdUpdate;
                da.UpdateCommand.CommandText = strCmdUpdate.CommandText;
                da.UpdateCommand.ExecuteNonQuery();
                da.Update(dsSusNanoStudAwrd);
                cnn.Close();
                // MessageBox.Show("Record updated successfully!", "CONGRATULATIONS", MessageBoxButtons.OK);
                lblUpdateSuccess.Visible = true;
            }
            catch (SystemException excp)
            {
               // MessageBox.Show(excp.Message);
            }
            //dsSusNanoStudAwrd
        }

        
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (nCurrRec - 1 < 0) return;
            --nCurrRec;
            DisplayQueryInfo(dsSusNanoStudAwrd, nCurrRec);
        }

        public static int nQueryRecCount, nCurrRec;
        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (nCurrRec + 1 >= nQueryRecCount) return;
            ++nCurrRec;
            DisplayQueryInfo(dsSusNanoStudAwrd, nCurrRec);

        }

        
        protected void btnQueryField_Click(object sender, EventArgs e)
        {
            string strSelectFName = txtFName.Text.Trim();
            string strSelectLName = txtLName.Text.Trim();
            if (strSelectFName == "" && strSelectLName == "")
            {
                //MessageBox.Show("Please enter text for first name and/or last name field.", "SEARCH BY NAME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string strNameQuery="SELECT * FROM StudentAwardApplication WHERE FirstName LIKE '" + strSelectFName + "%' AND LastName LIKE '" + strSelectLName + "%' ORDER BY LastName, FirstName";
            dsSusNanoStudAwrd = new DataSet();
            cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb);
            strCmd = new OleDbCommand(strNameQuery);
            da = new OleDbDataAdapter(strCmd.CommandText, cnn);
            dsSusNanoStudAwrd.Clear();
            try
            {
                da.Fill(dsSusNanoStudAwrd);
            }

            catch (Exception excp)
            {
               // MessageBox.Show(excp.Message);
                return;
            }
            nQueryRecCount = dsSusNanoStudAwrd.Tables[0].Rows.Count;
            nCurrRec = 0;
            DisplayQueryInfo(dsSusNanoStudAwrd, nCurrRec);
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            strPrevFName = txtFName.Text.Trim();
            strPrevLName = txtLName.Text.Trim();
            btnUpdateRecord.Enabled = true;
        }

        protected void DisplayQueryInfo(DataSet dsQuery, int nRec)
        {
            txtFName.Text = dsQuery.Tables[0].Rows[nRec]["FirstName"].ToString();
            txtLName.Text = dsQuery.Tables[0].Rows[nRec]["LastName"].ToString();
            ddlAmountOwed.Text= dsQuery.Tables[0].Rows[nRec]["AmountOwed"].ToString();
            txtInstitution.Text= dsQuery.Tables[0].Rows[nRec]["Institution"].ToString();
            txtEmail.Text= dsQuery.Tables[0].Rows[nRec]["Email"].ToString();
            txtDept.Text = dsQuery.Tables[0].Rows[nRec]["Department"].ToString();
            txtTitle.Text = dsQuery.Tables[0].Rows[nRec]["TitleOfPoster"].ToString();
            txtResume.Text = dsQuery.Tables[0].Rows[nRec]["Resume"].ToString();
            txtUploadURL.Text = dsQuery.Tables[0].Rows[nRec]["UploadURL"].ToString();
            ddlTopic.Text = dsQuery.Tables[0].Rows[nRec]["PreferredTopic"].ToString();
            ddlStatus.Text = dsQuery.Tables[0].Rows[nRec]["StudentStatus"].ToString();
            txtPoster.Text = dsQuery.Tables[0].Rows[nRec]["Poster"].ToString();
            txtSubmitDate.Text = dsQuery.Tables[0].Rows[nRec]["SubmissionDate"].ToString();
            if (dsQuery.Tables[0].Rows[nRec]["Accepted"].ToString() == chkAccepted.Text)
                chkAccepted.Checked = true;
            else
                chkAccepted.Checked = false;
            chkRegistered.Checked = (dsQuery.Tables[0].Rows[nRec]["Registered"].ToString() == chkRegistered.Text) ? true : false;
            strPrevFName = txtFName.Text.Trim();
            strPrevLName = txtLName.Text.Trim();
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
                btnPrevious.Visible = true;
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
                btnPrevious.Visible = false;
                btnPrevious.Enabled = false;
                btnQueryField.Visible = false;
                btnUpdateRecord.Visible = false;
                btnUpdateRecord.Enabled = false;
                btnSubmitQuery.Enabled = true;
                lblUpdateSuccess.Visible = false;
                btnReset_Click(sender, e);
            }
        }

        protected void rblPoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPoster.Text = rblPoster.SelectedValue;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (System.Web.UI.Control ctrl in this.Form.Controls)
                {
                    if (ctrl is System.Web.UI.WebControls.TextBox)

                    {
                        System.Web.UI.WebControls.TextBox newBox = new System.Web.UI.WebControls.TextBox();
                        newBox = (System.Web.UI.WebControls.TextBox)ctrl;
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

        public bool blFName, blLName, blPoster, blReg, blAmount, blAccpt, blInst, blEmail, blDept, blStatus, blTitle, blTopic, blResume, blUploadURL, blSubmitDate;
        public string pathDbFile, fNameDb;
        protected void Page_Load(object sender, EventArgs e)
        {
            pathDbFile = "~/App_Data/SNOMbrDB011_20141026B.mdb";
            fNameDb = Server.MapPath(pathDbFile);
            Response.Output.Write("<center><div style='position:relative; background-color:lightgreen; font-family:MicroFLF; font-size:25px;'><a  href='Index.html'>Back to Query Options Page</a></div></center>");
            
        }

    
        protected void btnSubmitQuery_Click(object sender, EventArgs e)
        {
 
            StringBuilder sbQuery = new StringBuilder("SELECT * FROM StudentAwardApplication WHERE ");
            strSubmitDate = txtSubmitDate.Text;
  
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
            if (txtPoster.Text.Trim() != "")
            {
                strPoster = txtLName.Text.Trim();
                blPoster = true;
                if (blLName || blFName) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Poster", strPoster);
            }
            if (chkRegistered.Checked)
            {
                strReg = chkRegistered.Text.Trim();
                blReg = true;
                if (blLName || blFName || blPoster) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Registered", strReg);
            }
            if (ddlAmountOwed.Text.Trim() != "")
            {
                strAmount = ddlAmountOwed.Text.Trim();
                blAmount = true;
                if (blLName || blFName || blPoster || blReg) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "AmountOwed", strAmount);
            }
            if (chkAccepted.Checked)
            {
                strAccpt = chkAccepted.Text.Trim();
                blAccpt = true;
                if (blLName || blFName || blPoster || blReg || blAmount) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Accepted", strAccpt);
            }

            if (txtInstitution.Text.Trim() != "")
            {
                strInst = txtInstitution.Text.Trim();
                blInst = true;
                if (blLName || blFName || blPoster || blReg || blAmount || blAccpt) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Institution", strInst);
            }
            if (txtEmail.Text.Trim() != "")
            {
                strEmail = txtEmail.Text.Trim();
                blEmail = true;
                if (blLName || blFName || blPoster || blReg || blAmount || blAccpt || blInst) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Email", strEmail);
            }
            if (txtDept.Text.Trim() != "")
            {
                strDept = txtDept.Text.Trim();
                blDept = true;
                if (blLName || blFName || blPoster || blReg || blAmount || blAccpt || blInst || blEmail) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Department", strDept);
            }
            if (ddlStatus.Text.Trim() != "")
            {
                strStatus = ddlStatus.Text.Trim();
                blStatus = true;
                if (blLName || blFName || blPoster || blReg || blAmount || blAccpt || blInst || blEmail || blDept ) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "StudentStatus", strStatus);
            }
            if (txtTitle.Text.Trim() != "")
            {
                strTitle = txtTitle.Text.Trim();
                blTitle = true;
                if (blLName || blFName || blPoster || blReg || blAmount || blAccpt || blInst || blEmail || blDept || blStatus) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "TitleOfPoster", strTitle);
            }
            if (ddlTopic.Text.Trim() != "")
            {
                strTopic = ddlTopic.Text.Trim();
                blTopic = true;
                if (blLName || blFName || blPoster || blReg || blAmount || blAccpt || blInst || blEmail || blDept || blStatus || blTitle ) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "PreferredTopic", strTopic);
            }
            if (txtResume.Text.Trim() != "")
            {
                strResume = txtResume.Text.Trim();
                blResume = true;
                if (blLName || blFName || blPoster || blReg || blAmount || blAccpt || blInst || blEmail || blDept || blStatus || blTitle || blTopic ) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Resume", strResume);
            }
            if (txtUploadURL.Text.Trim() != "")
            {
                strUploadURL= txtUploadURL.Text.Trim();
                blUploadURL = true;
                if (blLName || blFName || blPoster || blReg || blAmount || blAccpt || blInst || blEmail || blDept || blStatus ||  blTitle || blTopic || blResume) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "UploadURL", strUploadURL);
            }
            if (txtSubmitDate.Text.Trim() != "")
            {
                strSubmitDate = txtSubmitDate.Text.Trim();
                blSubmitDate = true;
                if (blLName || blFName || blPoster || blReg || blAmount || blAccpt || blInst || blEmail || blDept || blStatus || blTitle || blTopic || blResume || blUploadURL) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "SubmissionDate", strSubmitDate);
            }

            strQueryResult = sbQuery.ToString();
            Session["CurrentQuery"] = strQueryResult;
            Server.Transfer("StudAwardApplQryResults.aspx");
            cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb);
            strCmd = new OleDbCommand(strQueryResult);
            da = new OleDbDataAdapter(strCmd.CommandText, cnn);
            Session["CurrentQuery"] = strQueryResult;
            Server.Transfer("StudAwardApplQryResults.aspx");
        }
        void queryBuild(StringBuilder sbQry, string strFieldName, string strFieldVal)
        {
            sbQry.Append("[" + strFieldName + "] LIKE '%" + strFieldVal + "%' ");
        }
    }
}