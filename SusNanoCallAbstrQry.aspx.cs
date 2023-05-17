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
    public partial class SusNanoCallAbstrQry : System.Web.UI.Page
    {
        public string strQueryResult = "";
        public static OleDbConnection cnn;
        public static OleDbCommand strCmd, strCmdUpdate;
        public static OleDbDataAdapter da;
        public static DataSet dsSusNanoCallAbstr;
        public string strTitle, strOralPoster, strPrefSession, strAuthor, strPhone, strWriterName,  strGender, strAffil, strEmail,  strName2, strGender2, strAffil2, strEmail2, strAuthor2, strName3, strGender3, strAffil3, strAuthor3, strEmail3,strOtherAuth, strSustain, strAbstr, strSubmitDate;

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (nCurrRec + 1 >= nQueryRecCount) return;
            ++nCurrRec;
            DisplayQueryInfo(dsSusNanoCallAbstr, nCurrRec);
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if (nCurrRec - 1 < 0) return;
            --nCurrRec;
            DisplayQueryInfo(dsSusNanoCallAbstr, nCurrRec);
        }

        protected void btnUpdateRecord_Click(object sender, EventArgs e)
        {
            
            StringBuilder sbUpdateQuery = new StringBuilder("UPDATE CallForAbstracts SET ");
            sbUpdateQuery.Append("WriterName = '" + txtWriterName.Text.Trim() + "', ");
            sbUpdateQuery.Append("SelectOne = '" + txtOralPoster.Text.Trim() + "', ");
            sbUpdateQuery.Append("TitleOfPaper = '" + txtTitle.Text.Trim() + "', ");
            sbUpdateQuery.Append("PreferredSession = '" + txtPreferredSession.Text.Trim() + "', ");
            sbUpdateQuery.Append("PresentationAuthor = '" + txtPresentationAuthor.Text.Trim() + "', ");
            sbUpdateQuery.Append("PhoneNumber = '" + txtPhone.Text.Trim() + "', ");
            sbUpdateQuery.Append("Gender = '" + txtGender.Text.Trim() + "', ");
            
            sbUpdateQuery.Append("Affiliation = '" + txtAffiliation.Text.Trim() + "', ");
            sbUpdateQuery.Append("Email = '" + txtEmail.Text.Trim() + "', ");
            sbUpdateQuery.Append("Name2 = '" + txtName2.Text.Trim() + "', ");
            
            sbUpdateQuery.Append("Gender2 = '" + txtGender2.Text.Trim() + "', ");
            sbUpdateQuery.Append("Affiliation2 = '" + txtAffiliation2.Text.Trim() + "', ");
            sbUpdateQuery.Append("Email2 = '" + txtEmail2.Text.Trim() + "', ");
            

            sbUpdateQuery.Append("PresentingAuthor = '" + txtPresentationAuthor.Text.Trim() + "', ");
            sbUpdateQuery.Append("Name3 = '" + txtName3.Text.Trim() + "', ");
            sbUpdateQuery.Append("Gender3 = '" + txtGender3.Text.Trim() + "', ");
        
            sbUpdateQuery.Append("Affiliation3 = '" + txtAffiliation3.Text.Trim() + "', ");
            sbUpdateQuery.Append("Email3 = '" + txtEmail3.Text.Trim() + "', ");
            sbUpdateQuery.Append("PresentingAuthor2 = '" + txtPresAuth2.Text.Trim() + "', ");
          
            sbUpdateQuery.Append("OtherAuthors = '" + txtOtherAuthors.Text.Trim() + "', ");
            sbUpdateQuery.Append("Sustainability = '" + txtSustainability.Text.Trim() + "', ");
            string strAbstract = txtAbstractText.Text.Trim().Substring(0, 100);
            sbUpdateQuery.Append("Abstract250words = '" + txtAbstractText.Text.Trim() + "' ");

            sbUpdateQuery.Append(" WHERE WriterName = '" + strPrevWriterName + "'");


            try
            {
                cnn.Open();
                strCmdUpdate = new OleDbCommand(sbUpdateQuery.ToString(), cnn);

                da.UpdateCommand = strCmdUpdate;
                da.UpdateCommand.CommandText = strCmdUpdate.CommandText;
                da.UpdateCommand.ExecuteNonQuery();
                da.Update(dsSusNanoCallAbstr);
                cnn.Close();
                //MessageBox.Show("Record updated successfully!", "CONGRATULATIONS", MessageBoxButtons.OK);
                lblUpdateSuccess.Visible = true;
            }
            catch (SystemException excp)
            {
               //MessageBox.Show(excp.Message);
            }
        }

        public static string strPrevWriterName;
        public static int nQueryRecCount, nCurrRec;
        protected void btnQueryField_Click(object sender, EventArgs e)
        {
            string strSelectWriterName = txtWriterName.Text.Trim();
            
            if (strSelectWriterName == "" )
            {
              //  MessageBox.Show("Please enter text for writer name field.", "SEARCH BY NAME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string strNameQuery = "SELECT * FROM CallForAbstracts WHERE WriterName LIKE '%" + strSelectWriterName + "%'  ORDER BY WriterName";
            dsSusNanoCallAbstr = new DataSet();
            cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb);
            strCmd = new OleDbCommand(strNameQuery);
            da = new OleDbDataAdapter(strCmd.CommandText, cnn);
            dsSusNanoCallAbstr.Clear();
            try
            {
                da.Fill(dsSusNanoCallAbstr);
            }

            catch (Exception excp)
            {
               // MessageBox.Show(excp.Message);
                return;
            }
            nQueryRecCount = dsSusNanoCallAbstr.Tables[0].Rows.Count;
            nCurrRec = 0;
            DisplayQueryInfo(dsSusNanoCallAbstr, nCurrRec);
            btnPrev.Enabled = true;
            btnNext.Enabled = true;
            strPrevWriterName = txtWriterName.Text.Trim();

            btnUpdateRecord.Enabled = true;
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

        protected void rblGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGender.Text = rblGender.SelectedValue;
        }

        protected void rblGender3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGender3.Text = rblGender3.SelectedValue;
        }
        protected void rblGender2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGender2.Text = rblGender2.SelectedValue;
        }

       

        protected void rblOralPoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOralPoster.Text = rblOralPoster.SelectedValue;
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

        public bool blTitle, blOralPoster, blPrefSession, blAuthor, blPhone, blWriterName, blGender, blAffil, blEmail, blName2, blGender2, blAffil2, blEmail2, blAuthor2, blName3, blGender3, blAffil3, blEmail3, blAuthor3, blOtherAuth, blSustain, blAbstr, blSubmitDate;
        public string pathDbFile, fNameDb;
        protected void Page_Load(object sender, EventArgs e)
        {
            pathDbFile = "~/App_Data/SNOMbrDB011_20141026B.mdb";
            fNameDb = Server.MapPath(pathDbFile);
            Response.Output.Write("<center><div style='position:relative; background-color:lightgreen; font-family:MicroFLF; font-size:25px;'><a  href='Index.html'>Back to Query Options Page</a></div></center>");
          
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
            StringBuilder sbQuery = new StringBuilder("SELECT * FROM CallForAbstracts WHERE ");
            if (txtTitle.Text.Trim() != "")
            {
                strTitle = txtTitle.Text.Trim();
                blTitle = true;
                queryBuild(sbQuery, "TitleOfPaper", strTitle);
            }

            if (txtOralPoster.Text.Trim() != "")
            {
                strOralPoster = txtOralPoster.Text.Trim();
                blOralPoster = true;
                if (blTitle) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "SelectOne", strOralPoster);
            }
            if (txtPreferredSession.Text.Trim() != "")
            {
                strPrefSession = txtPreferredSession.Text.Trim();
                blPrefSession = true;
                if (blTitle || blOralPoster) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "PreferredSession", strPrefSession);
            }
            if (txtPresentationAuthor.Text.Trim() != "")
            {
                strAuthor = txtPresentationAuthor.Text.Trim();
                blAuthor = true;
                if (blTitle || blOralPoster || blPrefSession) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "PresentationAuthor", strAuthor);
            }
            if (txtPhone.Text.Trim() != "")
            {
                strPhone = txtPhone.Text.Trim();
                blPhone = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "PhoneNumber", strPhone);
            }
            if (txtWriterName.Text.Trim() != "")
            {
                strWriterName = txtWriterName.Text.Trim();
                blWriterName = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "WriterName", strWriterName);
            }

            if (txtGender.Text.Trim() != "")
            {
                strGender = txtGender.Text.Trim();
                blGender = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Gender", strGender);
            }
            if (txtAffiliation.Text.Trim() != "")
            {
                strAffil = txtAffiliation.Text.Trim();
                blAffil = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Affiliation", strAffil);
            }
            if (txtEmail.Text.Trim() != "")
            {
                strEmail = txtEmail.Text.Trim();
                blEmail = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Email", strEmail);
            }
            if (txtName2.Text.Trim() != "")
            {
                strName2 = txtName2.Text.Trim();
                blName2 = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Name2", strName2);
            }
            if (txtGender2.Text.Trim() != "")
            {
                strGender2 = txtGender2.Text.Trim();
                blGender2 = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Gender2", strGender2);
            }
            if (txtAffiliation2.Text.Trim() != "")
            {
                strAffil2 = txtAffiliation2.Text.Trim();
                blAffil2 = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Affiliation2", strAffil2);
            }
            if (txtEmail2.Text.Trim() != "")
            {
                strEmail2 = txtEmail2.Text.Trim();
                blEmail2 = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2 || blAffil2) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Email2", strEmail2);
            }
            if (txtAuthor2.Text.Trim() != "")
            {
                strAuthor2 = txtAuthor2.Text.Trim();
                blAuthor2 = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2 || blAffil2 || blEmail2) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "PresentingAuthor", strAuthor2);
            }
            if (txtName3.Text.Trim() != "")
            {
                strName3 = txtName3.Text.Trim();
                blName3 = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2 || blAffil2 || blEmail2 || blAuthor2) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Name3", strName3);
            }
            if (txtGender3.Text.Trim() != "")
            {
                strGender3 = txtGender3.Text.Trim();
                blGender3 = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2 || blAffil2 || blEmail2 || blAuthor2 || blName3) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Gender3", strName3);
            }
            if (txtAffiliation3.Text.Trim() != "")
            {
                strAffil3 = txtAffiliation3.Text.Trim();
                blAffil3 = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2 || blAffil2 || blEmail2 || blAuthor2 || blName3 || blGender3) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Affiliation3", strName3);
            }
            if (txtEmail3.Text.Trim() != "")
            {
                strEmail3 = txtAffiliation3.Text.Trim();
                blEmail3 = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2 || blAffil2 || blEmail2 || blAuthor2 || blName3 || blGender3 || blAffil3) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Email3", strName3);
            }
            if (txtPresAuth2.Text.Trim() != "")
            {
                strAuthor3 = txtPresAuth2.Text.Trim();
                blAuthor3 = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2 || blAffil2 || blEmail2 || blAuthor2 || blName3 || blGender3 || blAffil3 || blEmail3) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "PresentingAuthor2", strAuthor3);
            }
            if (txtOtherAuthors.Text.Trim() != "")
            {
                strOtherAuth = txtOtherAuthors.Text.Trim();
                blOtherAuth = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2 || blAffil2 || blEmail2 || blAuthor2 || blName3 || blGender3 || blAffil3 || blEmail3 || blAuthor3) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "OtherAuthors", strOtherAuth);
            }
            if (txtSustainability.Text.Trim() != "")
            {
                strSustain = txtSustainability.Text.Trim();
                blSustain = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2 || blAffil2 || blEmail2 || blAuthor2 || blName3 || blGender3 || blAffil3 || blEmail3 || blAuthor3 || blOtherAuth) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Sustainability", strSustain);
            }
            if (txtAbstractText.Text.Trim() != "")
            {
                strAbstr = txtAbstractText.Text.Trim();
                blAbstr = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2 || blAffil2 || blEmail2 || blAuthor2 || blName3 || blGender3 || blAffil3 || blEmail3 || blAuthor3 || blOtherAuth || blSustain) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "Abstract250words", strAbstr);
            }
            if (txtSubmissionDate.Text.Trim() != "")
            {
                strSubmitDate = txtSubmissionDate.Text.Trim();
                blSubmitDate = true;
                if (blTitle || blOralPoster || blPrefSession || blAuthor || blPhone || blWriterName || blGender || blAffil || blEmail || blName2 || blGender2 || blAffil2 || blEmail2 || blAuthor2 || blName3 || blGender3 || blAffil3 || blEmail3 || blAuthor3 || blOtherAuth || blSustain || blAbstr) sbQuery.Append(" AND ");
                queryBuild(sbQuery, "SubmissionDate", strSubmitDate);
            }
            strQueryResult = sbQuery.ToString();
            Session["CurrentQuery"] = strQueryResult;
            Server.Transfer("CallAbstrQryResults.aspx");
            cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb);
            strCmd = new OleDbCommand(strQueryResult);
            da = new OleDbDataAdapter(strCmd.CommandText, cnn);
            Session["CurrentQuery"] = strQueryResult;
            Server.Transfer("CallAbstrQryResults.aspx");

            void queryBuild(StringBuilder sbQry, string strFieldName, string strFieldVal)
            {
                sbQry.Append("[" + strFieldName + "] LIKE '%" + strFieldVal + "%' ");
            }
        }

        protected void DisplayQueryInfo(DataSet dsQuery, int nRec)
        {

            txtWriterName.Text = dsQuery.Tables[0].Rows[nRec]["WriterName"].ToString();
            txtOralPoster.Text = dsQuery.Tables[0].Rows[nRec]["SelectOne"].ToString();
            txtTitle.Text = dsQuery.Tables[0].Rows[nRec]["TitleOfPaper"].ToString();
            txtPreferredSession.Text = dsQuery.Tables[0].Rows[nRec]["PreferredSession"].ToString();
            txtPresentationAuthor.Text = dsQuery.Tables[0].Rows[nRec]["PresentationAuthor"].ToString();
            txtPhone.Text = dsQuery.Tables[0].Rows[nRec]["PhoneNumber"].ToString();
            txtGender.Text = dsQuery.Tables[0].Rows[nRec]["Gender"].ToString();
            txtAffiliation.Text = dsQuery.Tables[0].Rows[nRec]["Affiliation"].ToString();
            txtEmail.Text = dsQuery.Tables[0].Rows[nRec]["Email"].ToString();
            txtName2.Text = dsQuery.Tables[0].Rows[nRec]["Name2"].ToString();
            txtGender2.Text = dsQuery.Tables[0].Rows[nRec]["Gender2"].ToString();
            txtAffiliation2.Text = dsQuery.Tables[0].Rows[nRec]["Affiliation2"].ToString();
            txtEmail2.Text = dsQuery.Tables[0].Rows[nRec]["Email2"].ToString();
            txtAuthor2.Text = dsQuery.Tables[0].Rows[nRec]["PresentingAuthor"].ToString();
            txtName3.Text = dsQuery.Tables[0].Rows[nRec]["Name3"].ToString();
            txtGender3.Text = dsQuery.Tables[0].Rows[nRec]["Gender3"].ToString();
            txtAffiliation3.Text = dsQuery.Tables[0].Rows[nRec]["Affiliation3"].ToString();
            txtEmail3.Text = dsQuery.Tables[0].Rows[nRec]["Email3"].ToString();
            txtPresAuth2.Text = dsQuery.Tables[0].Rows[nRec]["PresentingAuthor2"].ToString();
            txtOtherAuthors.Text = dsQuery.Tables[0].Rows[nRec]["OtherAuthors"].ToString();
   
            txtSustainability.Text = dsQuery.Tables[0].Rows[nRec]["Sustainability"].ToString().Trim();
            txtAbstractText.Text = dsQuery.Tables[0].Rows[nRec]["Abstract250words"].ToString();
            txtSubmissionDate.Text = dsQuery.Tables[0].Rows[nRec]["SubmissionDate"].ToString();


            strPrevWriterName = txtWriterName.Text.Trim();
        

        }
    }
}