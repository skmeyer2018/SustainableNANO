<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SusNanoStudentAwardAppl.aspx.cs" Inherits="ForSusNano.SusNanoStudentAwardAppl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>STUDENT AWARDS APPLICATION QUERY</title>
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
  
  flex-direction: column;
  color: #f6f6f6;
  background-color: #121212;
}

.header, .content, .footer {
  padding: 15px;
}
    </style>
          <center>
 <h1 style="font-family: 'Sitka Heading';">STUDENT AWARDS APPLICATION QUERY PAGE</h1>
    <h2 style="font-family: Calibri;">Sustainable Nanotechnology Organization
        </h2>
</center>
</head>
<body>
    
    <form id="form1" runat="server">
      
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 30px; top: 244px; position: absolute; height: 21px" Text="First Name:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:TextBox ID="txtFName" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 205px; top: 229px; position: absolute; width: 292px; right: 831px; height: 39px" TabIndex="1"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 529px; top: 232px; position: absolute" Text="Last Name:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:TextBox ID="txtLName" runat="server" BorderStyle="Groove" BorderWidth="4px" height="39px" style="z-index: 1; left: 665px; top: 231px; position: absolute; width: 252px" TabIndex="2"></asp:TextBox>
        <asp:RadioButtonList ID="rblPoster" runat="server" AutoPostBack="True" BackColor="#99CCFF" BorderStyle="Groove" style="z-index: 1; left: 1038px; top: 269px; position: absolute; height: 33px; width: 115px" TabIndex="3" OnSelectedIndexChanged="rblPoster_SelectedIndexChanged">
            <asp:ListItem>y</asp:ListItem>
            <asp:ListItem Value="n">n</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 941px; top: 235px; position: absolute" Text="Poster:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:TextBox ID="txtPoster" runat="server" BorderStyle="Groove" BorderWidth="3px" height="39px" ReadOnly="True" style="z-index: 1; left: 1037px; top: 227px; position: absolute; width: 107px"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 1200px; top: 234px; position: absolute" Text="Registered:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 23px; top: 339px; position: absolute" Text="Amount Owed:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:DropDownList ID="ddlAmountOwed" runat="server" style="z-index: 1; left: 205px; top: 330px; position: absolute; width: 287px; height: 31px" TabIndex="5">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>400</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 529px; top: 335px; position: absolute; height: 24px" Text="Accepted:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:CheckBox ID="chkAccepted" runat="server" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 667px; top: 335px; position: absolute; height: 29px; bottom: 383px" Text="y" TabIndex="6" Font-Names="Calibri" />
        <p>
            <asp:CheckBox ID="chkRegistered" runat="server" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 1325px; top: 232px; position: absolute; height: 24px; width: 50px" Text="y" TabIndex="4" Font-Names="Calibri" />
        </p>
        <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 923px; top: 352px; position: absolute; margin-top: 0px" Text="Institution:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:TextBox ID="txtInstitution" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 1055px; top: 349px; position: absolute; width: 362px; height: 40px" TabIndex="7"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" style="z-index: 1; left: 27px; top: 417px; position: absolute; height: 25px;" Text="Email:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 204px; top: 415px; position: absolute; width: 273px; height: 35px" TabIndex="8"></asp:TextBox>
        <asp:Label ID="Label9" runat="server" style="z-index: 1; left: 518px; top: 421px; position: absolute; height: 27px; margin-top: 0px" Text="Department:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:TextBox ID="txtDept" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 662px; top: 423px; position: absolute; width: 237px; height: 31px; right: 518px" TabIndex="9"></asp:TextBox>
        <asp:Label ID="Label10" runat="server" style="z-index: 1; left: 929px; top: 420px; position: absolute; height: 27px" Text="Status:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:Label ID="Label11" runat="server" style="z-index: 1; left: 26px; top: 485px; position: absolute; height: 26px" Text="Title:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 204px; top: 481px; position: absolute; width: 266px; height: 32px; margin-top: 0px" TabIndex="11"></asp:TextBox>
        <asp:DropDownList ID="ddlStatus" runat="server" style="z-index: 1; left: 1055px; top: 425px; position: absolute; width: 378px" TabIndex="10">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Undergrad Jr.</asp:ListItem>
            <asp:ListItem>Undergrad Sr.</asp:ListItem>
            <asp:ListItem>Grad MS</asp:ListItem>
            <asp:ListItem>Grad PhD</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label12" runat="server" style="z-index: 1; left: 525px; top: 481px; position: absolute" Text="Topic:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:DropDownList ID="ddlTopic" runat="server" style="z-index: 1; left: 663px; top: 485px; position: absolute; width: 254px; height: 26px; right: 605px; margin-top: 0px" TabIndex="12">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Water, air, soil treatment and remediation</asp:ListItem>
            <asp:ListItem>Fate and transport</asp:ListItem>
            <asp:ListItem>Ecotoxicology and Human toxicology</asp:ListItem>
            <asp:ListItem>Green/Sustainable nanomaterials</asp:ListItem>
            <asp:ListItem>Food and Agriculture</asp:ListItem>
            <asp:ListItem>Nanomedicine</asp:ListItem>
            <asp:ListItem>Nanosensors</asp:ListItem>
            <asp:ListItem>Water</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label13" runat="server" style="z-index: 1; left: 930px; top: 476px; position: absolute" Text="Resume:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtResume" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 1052px; top: 472px; position: absolute; width: 367px; height: 35px" TabIndex="13"></asp:TextBox>
        <asp:Label ID="Label14" runat="server" style="z-index: 1; left: 26px; top: 545px; position: absolute; height: 50px; width: 161px;" Text="Resume Upload URL:" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Label>
        <asp:TextBox ID="txtUploadURL" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 201px; top: 544px; position: absolute; width: 492px; height: 40px" TabIndex="14"></asp:TextBox>
        <asp:Button ID="btnSubmitQuery" runat="server" Font-Bold="True" Font-Size="Large" OnClick="btnSubmitQuery_Click" style="z-index: 1; left: 1121px; top: 628px; position: absolute; height: 62px; width: 281px" Text="SUBMIT QUERY" />
        <asp:Button ID="btnReset" runat="server" Font-Bold="True" Font-Size="Large" OnClick="btnReset_Click" style="z-index: 1; left: 1122px; top: 705px; position: absolute; width: 279px; height: 49px" Text="RESET" />
        <asp:Label ID="Label15" runat="server" style="z-index: 1; left: 914px; top: 540px; position: absolute; height: 84px; width: 133px" Text="Submission year:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtSubmitDate" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 1054px; top: 547px; position: absolute; width: 380px; height: 38px"></asp:TextBox>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
          <div>
             
        </div>
        <asp:CheckBox ID="chkEditData" runat="server" AutoPostBack="True" Font-Bold="True" Font-Names="Arial" Font-Size="Larger" OnCheckedChanged="chkEditData_CheckedChanged" style="z-index: 2; left: 37px; top: 664px; position: absolute; width: 243px; " Text="EDIT DATA" />
        <asp:Label ID="lblEditMode" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="#FF0066" style="z-index: 2; left: 42px; top: 723px; position: absolute; width: 557px; margin-top: 0px;" Text="***EDIT MODE - search First Name or Last Name" Visible="False"></asp:Label>
        <asp:Button ID="btnPrevious" runat="server" BackColor="#66CCFF" Font-Bold="True" Font-Size="Large" style="z-index: 2; left: 45px; top: 757px; position: absolute; height: 33px; width: 53px; right: 1745px; " Text="&lt;&lt;" Visible="False" Enabled="False" OnClick="btnPrevious_Click" />
        <asp:Button ID="btnNext" runat="server" BackColor="#66CCFF" Font-Bold="True" Font-Size="Large" style="width: 53px; height: 33px; z-index: 2; left: 119px; top: 756px; position: absolute; bottom: 155px;" Text="&gt;&gt;" Visible="False" Enabled="False" OnClick="btnNext_Click" />
        <asp:Label ID="lblPrev" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="#3399FF" style="z-index: 2; left: 49px; top: 798px; position: absolute; right: 1505px; height: 23px;" Text="PREV" Visible="False"></asp:Label>
        <asp:Label ID="lblNext" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="#3399FF" style="z-index: 2; left: 123px; top: 798px; position: absolute; height: 20px" Text="NEXT" Visible="False"></asp:Label>
        <asp:Button ID="btnQueryField" runat="server" Font-Bold="True" OnClick="btnQueryField_Click" style="z-index: 2; left: 273px; top: 669px; position: absolute; width: 117px; height: 34px; right: 1097px;" Text="QUERY" Visible="False" />
        <asp:Button ID="btnUpdateRecord" runat="server" Font-Bold="True" OnClick="btnUpdateRecord_Click" style="z-index: 2; left: 403px; top: 669px; position: absolute; height: 33px;" Text="UPDATE" Visible="False" width="117px" Enabled="False" />
        <asp:Panel ID="Panel1" runat="server" BackColor="#FFFF99" style="z-index: 1; left: 26px; top: 644px; position: absolute; height: 183px; width: 586px" Height="200px">
            <asp:Label ID="lblUpdateSuccess" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#00CC00" style="z-index: 2; left: 207px; top: 138px; position: absolute" Text="**Record updated sucessfully!" Visible="False"></asp:Label>
        </asp:Panel>
    </form>

</body>
</html>
