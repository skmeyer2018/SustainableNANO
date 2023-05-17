using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ADODB;
using System.Text;
using System.Threading;

namespace ForSusNano
{
    public partial class frmSusNanoFront : System.Web.UI.Page
    {
        public string strContact, strAddress, strCity, strState, strZip, strEmail, strPhone;
        public string strQueryResult = "";
        public OleDbConnection cnn;

        protected void btnReset_Click(object sender, EventArgs e)
        {

            txtAddress.Text = "";
            txtContact.Text = "";
            txtCity.Text = "";
            txtContact.Text = "";
            txtPhone.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtEmail.Text = "";
  
        }

       

        public OleDbCommand strCmd;
        public OleDbDataAdapter da;
        public DataSet dsSusNano;
        public string pathDbFile, fNameDb;
        protected void Page_Load(object sender, EventArgs e)
        {

              pathDbFile = "~/SNOMbrDB011_20141026B.mdb";
            fNameDb = Server.MapPath(pathDbFile);
            Response.Output.Write("<center><div style='position:relative; background-color:lightgreen; font-family:MicroFLF; font-size:25px;'><a  href='Index.html'>Back to Query Options Page</a></div></center>");

            Connection con = new Connection();
 
            
            con.ConnectionString= "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb; //C:\\SusNano\\Program\\ForSusNano\\ForSusNano\\bin\\
            con.Open(con.ConnectionString, "", "");     
           DataSet ds = new DataSet("Recordset");
            OleDbDataAdapter da = new OleDbDataAdapter();
            // txtResults.Text = dsSusNano.Tables[0].Rows[3][3].ToString();
            //dsSusNano.Tables[0].TableName = "Address";
            /*
  
            object objAffected;
            string strQuery = "SELECT * FROM Address";
            Recordset rs = con.Execute(strQuery, out objAffected, 0);
 
            */
            //da.Fill(dsSusNano, rs, "Address");
           // cnn.Close();



        }

        protected void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            bool blPersonTable = false;
            bool blFirstName = false;
            bool blLastName = false;
            bool blContactName = false;
            bool blAddress = false;
            bool blStreet = false;
            bool blCity = false;
            bool blState = false;
            bool blZip = false;
            bool blPhone = false;
            bool blEmail = false;
            int recordsSpecified;
            strContact = txtContact.Text.Trim();
            strAddress = txtAddress.Text.Trim();
            strCity = txtCity.Text.Trim();
            strState = txtState.Text.Trim();
            strZip = txtZip.Text.Trim();
            strEmail = txtEmail.Text.Trim();
            strPhone = txtPhone.Text.Trim();
            strQueryResult = "";
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("SELECT * FROM Contact,  ");

            if (strPhone != "")
            {
                sbQuery.Append(" ContactPhone ");
                blPhone = true;
            }

            if (strEmail != "")
            {
                if (blPhone) sbQuery.Append(", ");
                sbQuery.Append(" ContactEmail ");
                blEmail = true;
            }

            if (strAddress.Trim() != "") blAddress = true;
            if (strContact.Trim() != "") blContactName = true;
            if (strCity.Trim() != "") blCity = true;
            if (strState.Trim() != "") blState = true;
            if (strZip.Trim() != "") blZip = true;
            if (blEmail || blPhone) sbQuery.Append(", ");
            sbQuery.Append(" ContactAddress ");
  
            sbQuery.Append(" WHERE  ");
            if (strPhone != "")
            {
                sbQuery.Append(" ContactPhone.PhoneFKContactID =Contact.ContactID AND  ContactPhone.PhoneNumber LIKE '%" + strPhone + "%'");
                blPhone = true;
            }
            if (strEmail != "")
            {
                if (blPhone ) sbQuery.Append(" AND ");
                sbQuery.Append(" ContactEmail.EmailFKContactID=Contact.ContactID AND ContactEmail.EmailAddress LIKE '%" + strEmail + "%'");
                blEmail = true;
            }
            if (strContact != "")
            {
               if (blPhone || blEmail) sbQuery.Append(" AND ");
                sbQuery.Append(" Contact.ContactName LIKE '%" + strContact + "%'");
               blContactName = true;

            }
            if ( blAddress || blCity || blState || blZip)
            {
                if (blPhone || blEmail) sbQuery.Append(" AND ");
                //if (blContactName)
               // {
                   // sbQuery.Append(" Contact.ContactName LIKE '%" + strContact + "%'");
                    if (blPhone || blEmail) sbQuery.Append(" AND ");
               // }

                sbQuery.Append(" Contact.ContactID = ContactAddress.AddrFKContactID ");

                if (blAddress) sbQuery.Append("  AND  ContactAddress.AddrLine1 LIKE '%" + strAddress + "%'");
                if (blCity) sbQuery.Append(" AND  ContactAddress.AddrCity LIKE '%" + strCity + "%'");
                if (blState) sbQuery.Append("  AND  ContactAddress.AddrStateAbbr = '" + strState + "'");
                if (blZip) sbQuery.Append("  AND   ContactAddress.AddrZip  LIKE  '%" + strZip + "%'");
            }

            strQueryResult = sbQuery.ToString().Trim();
            OleDbConnection cnn;
            cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fNameDb);
            OleDbDataAdapter da;
            strQueryResult = sbQuery.ToString();
            OleDbCommand strCmd = new OleDbCommand(strQueryResult);
            da = new OleDbDataAdapter(strQueryResult, cnn);
   
            dsSusNano = new DataSet();
            dsSusNano.Clear();
            da.Fill(dsSusNano);
            int colCount = dsSusNano.Tables[0].Columns.Count;
            int rowCount = dsSusNano.Tables[0].Rows.Count;
            
          
            StringBuilder sbResults = new StringBuilder();
   

  
            
            TableRow trRes = new TableRow();
            trRes.BackColor = System.Drawing.Color.LightGreen;

            for (int c = 3; c < colCount; c++)
            {
                //   if (c == 4 || c == 5 || c == 7 || (c >= 9 && c <= 13) || c==18 || c==20 || c==21 || c==22 || c>=24  )continue;
                // sbResults.Append(dsSusNano.Tables[0].Columns[c].ColumnName.ToUpper().PadRight(20) );
                if (dsSusNano.Tables[0].Columns[c].ColumnName == "ContactNameLFM" || dsSusNano.Tables[0].Columns[c].ColumnName == "ContactIsPublic" || dsSusNano.Tables[0].Columns[c].ColumnName == "ContactEntryFKUserID" || dsSusNano.Tables[0].Columns[c].ColumnName == "ContactEditFKUserID" || dsSusNano.Tables[0].Columns[c].ColumnName == "AddrID" || dsSusNano.Tables[0].Columns[c].ColumnName == "PhoneID" || dsSusNano.Tables[0].Columns[c].ColumnName == "PhoneFKContactID" || dsSusNano.Tables[0].Columns[c].ColumnName == "AddrFKContactID") continue;
                TableCell tcFieldName = new TableCell();
                tcFieldName.Text = dsSusNano.Tables[0].Columns[c].ColumnName.ToUpper();
                tcFieldName.Font.Bold = true;
                tcFieldName.Font.Size = FontUnit.Medium;
                trRes.Cells.Add(tcFieldName);
            }
            Table1.Rows.Add(trRes);
        
            sbResults.Clear();
                for (int r=0; r<rowCount; r++)
                {
                    trRes = new TableRow();
                    if (r % 2 == 0) trRes.BackColor = System.Drawing.Color.Lavender;
                    for (int c=3; c<colCount; c++)
                    {
                        // if (c == 4 || c == 5 || c == 7 || (c >= 9 && c <= 13) || c == 18 || c == 20 || c == 21 || c == 22 || c >= 24) continue;
                        if (dsSusNano.Tables[0].Columns[c].ColumnName == "ContactNameLFM" || dsSusNano.Tables[0].Columns[c].ColumnName == "ContactIsPublic" || dsSusNano.Tables[0].Columns[c].ColumnName == "ContactEntryFKUserID" || dsSusNano.Tables[0].Columns[c].ColumnName == "ContactEditFKUserID" || dsSusNano.Tables[0].Columns[c].ColumnName == "AddrID" || dsSusNano.Tables[0].Columns[c].ColumnName == "PhoneID" || dsSusNano.Tables[0].Columns[c].ColumnName == "PhoneFKContactID" || dsSusNano.Tables[0].Columns[c].ColumnName == "AddrFKContactID") continue;
                        Thread.Sleep(0);
                        TableCell tcRes = new TableCell();
                        tcRes.Font.Size = FontUnit.Small;
                        tcRes.Text = dsSusNano.Tables[0].Rows[r][c].ToString();
                            trRes.Cells.Add(tcRes);
                            //sbResults.Append(dsSusNano.Tables[0].Rows[r][c].ToString().PadRight(10));

                    }
                    Table1.Rows.Add(trRes);
   
                sbResults.Clear();
            }
            
        }
    }
}