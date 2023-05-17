<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SusNanoConfRegQry.aspx.cs" Inherits="ForSusNano.SusNanoConfRegQry" %>

<%@ Import Namespace="System.Data.OleDb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" name="viewport" content="width=device-width,initial-scale=1" />
    <style>
    .column {
      width: 100%;
    }

        @media (min-width: 600px) {
            .column {
                width: 50%;
            }
        }
        .phone-screen {
  width: 100%;
  max-width: 450px;
  height: 90vh;
  border: 10px solid blue;
  margin: 5vh auto;
  border-radius: 5px;
  display: flex;
  flex-direction: column;
  color: #f6f6f6;
  background-color: #121212;
}

.header, .content, .footer {
  padding: 15px;
}
        #form1 {
            height: 1214px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <center>
 <h1 style="font-family: 'Sitka Heading';">CONFERENCE REGISTRATION QUERY PAGE</h1>
    <h2 style="font-family: Calibri;">Sustainable Nanotechnology Organization
        </h2>
</center>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 18px; top: 662px; position: absolute; height: 23px; bottom: 412px; right: 1219px;" Text="Submission year:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:DropDownList ID="ddlMembershipType" runat="server" style="z-index: 1; left: 824px; top: 679px; position: absolute; height: 30px; width: 229px" TabIndex="22" AutoPostBack="True">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Academic</asp:ListItem>
            <asp:ListItem>Government</asp:ListItem>
            <asp:ListItem>Student</asp:ListItem>
            <asp:ListItem>Industry</asp:ListItem>
            <asp:ListItem>Retired</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtSubmissionDate" runat="server" BorderStyle="Groove" style="z-index: 1; left: 202px; top: 669px; position: absolute; width: 377px; height: 29px" TabIndex="21" TextMode="DateTime" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 39px; top: 171px; position: absolute; width: 124px; height: 28px" Text="First Name:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtFName" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 202px; top: 166px; position: absolute; width: 328px; height: 26px; " TabIndex="1" AutoPostBack="True"></asp:TextBox>
        <asp:TextBox ID="txtLName" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 728px; top: 164px; position: absolute; width: 401px; height: 26px" TabIndex="2" AutoPostBack="True"></asp:TextBox>
        <asp:RadioButtonList ID="rblGender" runat="server" BackColor="#99FFCC" BorderStyle="Inset" Font-Names="MicroFLF" Font-Size="Small" OnSelectedIndexChanged="rblGender_SelectedIndexChanged" style="z-index: 1; left: 1280px; top: 190px; position: absolute; height: 103px; width: 102px; margin-top: 1px" AutoPostBack="True" TabIndex="3">
            <asp:ListItem>M</asp:ListItem>
            <asp:ListItem>F</asp:ListItem>
            <asp:ListItem>n/a</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 1179px; top: 157px; position: absolute; width: 85px; height: 30px; right: 285px; margin-right: 0px" Text="Gender:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 598px; top: 168px; position: absolute; width: 132px; height: 27px" Text="Last Name:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtGender" runat="server" BorderColor="#009933" BorderWidth="6px" ReadOnly="True" style="z-index: 1; left: 1280px; top: 145px; position: absolute; width: 92px; margin-top: 11px"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 35px; top: 224px; position: absolute; height: 27px; margin-top: 0px" Text="Organization:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtOrganization" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 202px; top: 224px; position: absolute; width: 937px; height: 26px; bottom: 467px; margin-top: 0px" TabIndex="4" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" style="z-index: 1; left: 32px; top: 275px; position: absolute; height: 27px; width: 158px" Text="Address Line 1:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtSpecificInt" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 194px; top: 558px; position: absolute; width: 331px; height: 30px" TabIndex="17" AutoPostBack="True"></asp:TextBox>
        <asp:TextBox ID="txtAddr1" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 198px; top: 276px; position: absolute; width: 941px; height: 26px" TabIndex="5" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label9" runat="server" style="z-index: 1; left: 35px; top: 324px; position: absolute" Text="Address Line 2:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtAddr2" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 200px; top: 329px; position: absolute; width: 937px; height: 26px" TabIndex="6" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label10" runat="server" style="z-index: 1; left: 38px; top: 378px; position: absolute; height: 29px; width: 47px" Text="City:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtCity" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 197px; top: 382px; position: absolute; width: 417px; height: 33px; right: 962px;" TabIndex="7" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label11" runat="server" style="z-index: 1; left: 651px; top: 390px; position: absolute; height: 26px" Text="State:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtState" runat="server" BorderStyle="Ridge" style="z-index: 1; top: 380px; position: absolute; width: 159px; height: 33px; margin-bottom: 18px; right: 698px; left: 728px;" TabIndex="8" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label12" runat="server" style="z-index: 1; left: 915px; top: 386px; position: absolute; width: 39px; bottom: 362px; right: 819px" Text="Zip:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtZip" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 959px; top: 379px; position: absolute; height: 37px; width: 175px; margin-top: 1px" TabIndex="9" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label13" runat="server" style="z-index: 1; left: 39px; top: 423px; position: absolute" Text="Country:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:Label ID="lblUpdateSuccess" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#00CC00" style="z-index: 2; left: 213px; top: 866px; position: absolute" Text="**Record updated sucessfully!" Visible="False"></asp:Label>
        <asp:TextBox ID="txtCountry" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 200px; top: 432px; position: absolute; width: 231px; height: 28px; right: 1200px;" TabIndex="10" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label14" runat="server" style="z-index: 1; left: 457px; top: 432px; position: absolute; width: 66px; height: 29px;" Text="Email:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 531px; top: 433px; position: absolute; width: 261px; height: 28px; right: 729px;" TabIndex="11" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label15" runat="server" style="z-index: 1; left: 819px; top: 432px; position: absolute; height: 33px" Text="Phone:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 926px; top: 431px; position: absolute; height: 32px; width: 217px" TabIndex="12" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label16" runat="server" style="z-index: 1; left: 38px; top: 472px; position: absolute; width: 98px" Text="Position:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtPosition" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 197px; top: 476px; position: absolute; height: 27px; width: 292px; " TabIndex="13" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label17" runat="server" style="z-index: 1; left: 523px; top: 480px; position: absolute; width: 53px" Text="Dept:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtDept" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 588px; top: 477px; position: absolute; width: 258px; height: 27px; right: 675px;" TabIndex="14" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label18" runat="server" style="z-index: 1; left: 881px; top: 480px; position: absolute; width: 216px" Text="Main General Focus:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:DropDownList ID="ddlMainGeneralFocus" runat="server" style="z-index: 1; left: 1119px; top: 480px; position: absolute; width: 298px; height: 37px;" TabIndex="15" AutoPostBack="True">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Applications</asp:ListItem>
            <asp:ListItem>Synthesis/Characterization</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtOtherFocus" runat="server" BorderColor="#66CCFF" BorderWidth="6px" style="z-index: 1; left: 1114px; top: 519px; position: absolute; width: 300px; margin-bottom: 0px" TabIndex="16" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label19" runat="server" style="z-index: 1; left: 888px; top: 518px; position: absolute; height: 27px" Text="Other focus: " Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 19px; top: 552px; position: absolute; width: 167px; right: 1401px" Text="Specific Interests in SNO: "></asp:Label>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 580px; top: 561px; position: absolute" Text="Other Specific Interest: "></asp:Label>
        <asp:TextBox ID="txtOtherSpecificInterest" runat="server" BorderStyle="Ridge" style="z-index: 1; left: 825px; top: 562px; position: absolute; width: 399px; height: 34px;" TabIndex="18" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 17px; top: 616px; position: absolute; width: 176px" Text="Interest In SNO: "></asp:Label>
        <asp:DropDownList ID="ddlPaymentAmount" runat="server" style="z-index: 1; left: 827px; top: 611px; position: absolute; width: 229px" TabIndex="20" AutoPostBack="True">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>125</asp:ListItem>
            <asp:ListItem>175</asp:ListItem>
            <asp:ListItem>250</asp:ListItem>
            <asp:ListItem>300</asp:ListItem>
        </asp:DropDownList>
        <div style="margin-left: 80px">
            <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 631px; top: 616px; position: absolute" Text="Payment Amount:"></asp:Label>
        </div>
        <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 1102px; top: 613px; position: absolute; right: 142px; height: 29px;" Text="Payment Type:"></asp:Label>
        <asp:TextBox ID="txtPaymentType" runat="server" BorderColor="#FF9933" BorderWidth="6px" ReadOnly="True" style="z-index: 1; left: 1099px; top: 642px; position: absolute; width: 183px" AutoPostBack="True"></asp:TextBox>
        <asp:RadioButtonList ID="rblPaymentType" runat="server" BackColor="#FF9933" Font-Names="MicroFLF" Font-Size="Small" OnSelectedIndexChanged="rblPaymentType_SelectedIndexChanged" style="z-index: 1; left: 1101px; top: 684px; position: absolute; height: 74px; width: 189px" BorderStyle="Inset" AutoPostBack="True" TabIndex="23">
            <asp:ListItem>Student</asp:ListItem>
            <asp:ListItem>Regular</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="btnSubmitQuery" runat="server" Font-Bold="True" Font-Size="15pt" style="z-index: 1; left: 714px; top: 747px; position: absolute; width: 242px; height: 47px" Text="SUBMIT QUERY" OnClick="btnSubmitQuery_Click" TabIndex="24" />
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Ridge" style="z-index: 1; left: 19px; top: 1069px; position: absolute; height: 336px; width: 742px">
        </asp:Table>
        <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 629px; top: 677px; position: absolute" Text="Membership Type:"></asp:Label>
        <p>
            &nbsp;</p>
            <asp:Button ID="btnReset" runat="server" Font-Bold="True" Font-Size="Large" OnClick="btnReset_Click" style="z-index: 1; left: 715px; top: 799px; position: absolute; height: 46px; width: 242px" Text="RESET" />
        <p>
            &nbsp;&nbsp;</p>
        <asp:Panel ID="Panel2" runat="server" BackColor="#FFFF99" style="z-index: 1; left: 20px; top: 739px; position: absolute; height: 220px; width: 580px" Height="200px">
            <asp:CheckBox ID="chkEditData" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Large" OnCheckedChanged="chkEditData_CheckedChanged" style="z-index: 1; left: 13px; top: 23px; position: absolute; margin-bottom: 1px" Text="EDIT DATA" AutoPostBack="True" />
            <asp:Label ID="lblEditMode" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="#FF0066" style="z-index: 1; left: 17px; top: 79px; position: absolute; height: 30px; width: 570px;" Text="***EDIT MODE- search First Name or Last Name" Visible="False"></asp:Label>
        </asp:Panel>
        <asp:Button ID="btnQueryField" runat="server" style="z-index: 2; left: 270px; top: 766px; position: absolute; height: 47px;" Text="QUERY" Font-Bold="True" Font-Names="Arial" OnClick="btnQueryField_Click" Visible="False" Width="100px" />
        <asp:Button ID="btnUpdateRecord" runat="server" Font-Bold="True" style="z-index: 1; left: 396px; top: 764px; position: absolute; width: 99px; height: 48px;" Text="UPDATE" Visible="False" Enabled="False" OnClick="btnUpdateRecord_Click" Width="100px" />
        <asp:Button ID="btnPrev" runat="server" BackColor="#66CCFF" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 43px; top: 870px; position: absolute; height: 48px; width: 53px; right: 1518px;" Text="&lt;&lt;" Visible="False" Enabled="False" OnClick="btnPrev_Click" />
        <asp:Label ID="lblPrev" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="#3399FF" style="z-index: 1; left: 44px; top: 929px; position: absolute; height: 24px;" Text="PREV" Visible="False"></asp:Label>
        <asp:Button ID="btnNext" runat="server" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 112px; top: 870px; position: absolute; height: 47px; width: 53px; bottom: 135px;" Text="&gt;&gt;" BackColor="#66CCFF" Visible="False" Enabled="False" OnClick="btnNext_Click" />
        <asp:Label ID="lblNext" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="#3399FF" style="z-index: 1; left: 112px; top: 928px; position: absolute; height: 26px" Text="NEXT" Visible="False"></asp:Label>
        <asp:TextBox ID="txtInterestInSNO" runat="server" style="z-index: 1; left: 207px; top: 620px; position: absolute; width: 369px" AutoPostBack="True"></asp:TextBox>
    </form>
    </body>
</html>
