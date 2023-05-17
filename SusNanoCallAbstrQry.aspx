<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SusNanoCallAbstrQry.aspx.cs" Inherits="ForSusNano.SusNanoCallAbstrQry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    </style>
    <center>
    <title>CALL FOR ABSTRACTS QUERY</title>
 
       
 <h1 style="font-family: 'Sitka Heading'; width: 859px;">CALL FOR ABSTRACTS QUERY PAGE</h1>
    <h2 style="font-family: Calibri;">Sustainable Nanotechnology Organization
        </h2>
</center>

 
       


 
</head>
<body>
    <form id="form1" runat="server">
<asp:Panel  ID="Panel1" runat="server" BackColor="#FFFFCC" style="z-index: 1; left: 602px; top: 746px; position: absolute; height: 100px; width: 889px">
    <asp:Label ID="lblUpdateSuccess" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#00CC00" style="z-index: 2; left: 227px; top: 65px; position: absolute; height: 29px;" Text="**Record updated sucessfully!" Visible="False"></asp:Label>
          </asp:Panel>
        <asp:CheckBox ID="chkEditData" runat="server" AutoPostBack="True" Font-Bold="True" Font-Names="Arial" Font-Size="Larger" OnCheckedChanged="chkEditData_CheckedChanged" style="z-index: 2; left: 617px; top: 755px; position: absolute; height: 36px; width: 221px; right: 775px" Text="EDIT DATA" />
        <asp:Label ID="lblEditMode" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="Red" style="z-index: 1; left: 1230px; top: 766px; position: absolute; height: 25px; width: 205px;" Text="***EDIT MODE" Visible="False"></asp:Label>
        <asp:Button ID="btnQueryField" runat="server" Font-Bold="True" Font-Names="Arial" style="z-index: 1; left: 845px; top: 753px; position: absolute; height: 40px;" Text="QUERY" Visible="False" Height="50px" Width="100px" OnClick="btnQueryField_Click" />
        <asp:Button ID="btnUpdateRecord" runat="server" Font-Bold="True" style="z-index: 1; left: 955px; top: 751px; position: absolute; width: 112px; height: 42px;" Text="UPDATE" Visible="False" Width="100px" Enabled="False" Height="50px" OnClick="btnUpdateRecord_Click" />
        <p>
            &nbsp;</p>
        <asp:Label ID="lblPrev" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" style="z-index: 1; left: 1080px; top: 787px; position: absolute; height: 24px; right: 471px;" Text="PREV" ForeColor="#33CCFF" Visible="False"></asp:Label>
            <asp:Button ID="btnPrev" runat="server" Text="&lt;&lt;" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 1079px; top: 754px; position: absolute; width: 65px; height: 31px" BackColor="#33CCFF" Visible="False" Enabled="False" OnClick="btnPrev_Click" />
        <asp:Label ID="lblNext" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="#66CCFF" style="z-index: 1; left: 1157px; top: 788px; position: absolute; height: 23px; margin-bottom: 0px;" Text="NEXT" Visible="False"></asp:Label>


        <div>
            <asp:TextBox ID="txtTitle" runat="server" style="z-index: 1; left: 1044px; top: 281px; position: absolute; width: 327px" BorderStyle="Groove" BorderWidth="4px" height="33px" TabIndex="1"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 739px; top: 190px; position: absolute; width: 181px" Text="Oral or Poster:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
            <asp:RadioButtonList ID="rblOralPoster" runat="server" BackColor="#99CCFF" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" style="z-index: 1; left: 911px; top: 180px; position: absolute; height: 33px; width: 116px" OnSelectedIndexChanged="rblOralPoster_SelectedIndexChanged" TabIndex="2" AutoPostBack="True">
                <asp:ListItem>Oral</asp:ListItem>
                <asp:ListItem>Poster</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="txtOralPoster" runat="server" ReadOnly="True" style="z-index: 1; left: 1045px; top: 189px; position: absolute; width: 306px; height: 33px;" BorderStyle="Groove" BorderWidth="4px"></asp:TextBox>
        </div>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 741px; top: 292px; position: absolute; right: 515px;" Text="Title of Paper:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 12px; top: 240px; position: absolute; height: 27px" Text="Preferred Session:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtPreferredSession" runat="server" style="z-index: 1; left: 204px; top: 241px; position: absolute; width: 491px; " BorderStyle="Groove" BorderWidth="4px" height="33px" TabIndex="3"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 740px; top: 243px; position: absolute; width: 215px; bottom: 738px; margin-top: 1px" Text="Presentation Author:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtPresentationAuthor" runat="server" style="z-index: 1; left: 1045px; top: 236px; position: absolute; width: 326px" BorderStyle="Groove" BorderWidth="4px" height="33px" TabIndex="4"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 12px; top: 286px; position: absolute; height: 23px" Text="Phone:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtGender" runat="server" ReadOnly="True" style="z-index: 1; left: 296px; top: 336px; position: absolute; width: 396px" BorderStyle="Groove" BorderWidth="4px" height="33px"></asp:TextBox>
        <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 202px; top: 287px; position: absolute; width: 490px" BorderStyle="Groove" BorderWidth="4px" height="33px" TabIndex="5"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 12px; top: 209px; position: absolute; height: 25px; width: 153px" Text="Writer Name:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtWriterName" runat="server" style="z-index: 1; left: 207px; top: 183px; position: absolute; width: 472px" BorderStyle="Groove" BorderWidth="4px" height="33px" TabIndex="6"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 10px; top: 333px; position: absolute; height: 26px" Text="Gender:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:RadioButtonList ID="rblGender" runat="server" BackColor="#99CCFF" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" style="z-index: 1; left: 201px; top: 336px; position: absolute; height: 33px; width: 83px" OnSelectedIndexChanged="rblGender_SelectedIndexChanged" TabIndex="7" AutoPostBack="True">
            <asp:ListItem>M</asp:ListItem>
            <asp:ListItem>F</asp:ListItem>
            <asp:ListItem>n/a</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="Label8" runat="server" style="z-index: 1; left: 745px; top: 333px; position: absolute; width: 147px; height: 31px;" Text="Affiliation:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtAffiliation" runat="server" style="z-index: 1; left: 1045px; top: 328px; position: absolute; height: 33px; width: 327px" BorderStyle="Groove" BorderWidth="4px" TabIndex="7"></asp:TextBox>
        <p>
            <asp:Label ID="Label9" runat="server" style="z-index: 1; left: 744px; top: 366px; position: absolute; height: 26px; width: 73px;" Text="Email:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        </p>
        <asp:TextBox ID="txtEmail" runat="server" style="z-index: 1; left: 1045px; top: 374px; position: absolute; width: 328px" BorderStyle="Groove" BorderWidth="4px" height="33px" TabIndex="8"></asp:TextBox>
        <asp:Label ID="Label10" runat="server" style="z-index: 1; left: 15px; top: 456px; position: absolute; width: 110px" Text="2nd Name:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtName2" runat="server" style="z-index: 1; left: 190px; top: 456px; position: absolute; width: 394px; height: 32px;" BorderStyle="Groove" BorderWidth="4px" TabIndex="9"></asp:TextBox>
        <asp:Label ID="Label11" runat="server" style="z-index: 1; left: 638px; top: 450px; position: absolute" Text="2nd Gender:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:RadioButtonList ID="rblGender2" runat="server" BackColor="#99CCFF" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" style="z-index: 1; left: 774px; top: 445px; position: absolute; height: 33px; width: 87px" OnSelectedIndexChanged="rblGender2_SelectedIndexChanged" TabIndex="10" AutoPostBack="True">
            <asp:ListItem>M</asp:ListItem>
            <asp:ListItem>F</asp:ListItem>
            <asp:ListItem>n/a</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="txtGender2" runat="server" style="z-index: 1; left: 867px; top: 448px; position: absolute; width: 150px; height: 34px;" BorderStyle="Groove" BorderWidth="4px"></asp:TextBox>
        <asp:Label ID="Label12" runat="server" style="z-index: 1; left: 1054px; top: 453px; position: absolute; width: 103px" Text="2nd Affiliation:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:TextBox ID="txtAffiliation2" runat="server" style="z-index: 1; left: 1207px; top: 455px; position: absolute; width: 202px; height: 33px;" BorderStyle="Groove" BorderWidth="4px" TabIndex="11"></asp:TextBox>
        <p>
            <asp:Label ID="Label13" runat="server" style="z-index: 1; left: 15px; top: 516px; position: absolute; height: 25px; width: 94px" Text="Email 2:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        </p>
        <asp:TextBox ID="txtEmail2" runat="server" style="z-index: 1; left: 190px; top: 503px; position: absolute; width: 394px; height: 27px;" BorderStyle="Groove" BorderWidth="4px" TabIndex="12"></asp:TextBox>
        <asp:TextBox ID="txtAffiliation3" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 1205px; top: 583px; position: absolute; width: 205px; height: 34px" TabIndex="16"></asp:TextBox>
        <asp:TextBox ID="txtAuthor2" runat="server" style="z-index: 1; left: 1207px; top: 525px; position: absolute; width: 205px; height: 33px;" BorderStyle="Groove" BorderWidth="4px" TabIndex="13"></asp:TextBox>
        <p>
            <asp:Button ID="btnSubmitQuery" runat="server" Font-Bold="True" Font-Size="Medium" OnClick="btnSubmitQuery_Click" style="z-index: 1; left: 658px; top: 665px; position: absolute; height: 53px; width: 192px" Text="SUBMIT QUERY" TabIndex="23" />
            <asp:Button ID="btnNext" runat="server" style="z-index: 2; left: 1152px; top: 755px; position: absolute; width: 62px; height: 31px; margin-right: 1px;" Text="&gt;&gt;" Font-Bold="True" Font-Size="Large" BackColor="#33CCFF" Visible="False" Enabled="False" OnClick="btnNext_Click" />
        </p>
        <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 11px; top: 560px; position: absolute; height: 24px" Text="3rd Name:"></asp:Label>
        <asp:TextBox ID="txtName3" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 190px; top: 555px; position: absolute; width: 394px; height: 25px; bottom: 419px;" TabIndex="14"></asp:TextBox>
        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 637px; top: 548px; position: absolute" Text="3rd Gender:"></asp:Label>
        <asp:RadioButtonList ID="rblGender3" runat="server" BackColor="#99CCFF" BorderColor="Black" BorderWidth="3px" style="z-index: 1; left: 776px; top: 554px; position: absolute; height: 1px; width: 83px; right: 800px;" TabIndex="15" AutoPostBack="True">
            <asp:ListItem>M</asp:ListItem>
            <asp:ListItem>F</asp:ListItem>
            <asp:ListItem>n/a</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="txtGender3" runat="server" BorderStyle="Groove" BorderWidth="4px" height="34px" ReadOnly="True" style="z-index: 1; left: 870px; top: 557px; position: absolute; width: 150px; bottom: 336px"></asp:TextBox>
        <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 8px; top: 599px; position: absolute; height: 48px; bottom: 362px; width: 173px" Text="2nd Presenting Author:"></asp:Label>
        <asp:TextBox ID="txtPresAuth2" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 192px; top: 602px; position: absolute; width: 394px; height: 26px;" TabIndex="17"></asp:TextBox>
        <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 1058px; top: 633px; position: absolute; width: 106px; margin-right: 0px; height: 44px;" Text="Other Authors: " Font-Size="Small"></asp:Label>
        <asp:TextBox ID="txtOtherAuthors" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 1206px; top: 644px; position: absolute; width: 207px; height: 35px" TabIndex="19"></asp:TextBox>
        <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 14px; top: 695px; position: absolute; height: 28px; width: 140px" Text="Sustainability: "></asp:Label>
        <asp:TextBox ID="txtSustainability" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 195px; top: 698px; position: absolute; width: 394px; height: 23px; bottom: 178px" TabIndex="20"></asp:TextBox>
        <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 18px; top: 746px; position: absolute; width: 143px" Text="Abstract text:"></asp:Label>
        <asp:TextBox ID="txtAbstractText" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 195px; top: 737px; position: absolute; width: 392px; height: 21px" TabIndex="22"></asp:TextBox>
        <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 1056px; top: 694px; position: absolute; width: 142px" Text="Submission year:" Font-Size="Small"></asp:Label>
        <asp:TextBox ID="txtSubmissionDate" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 1205px; top: 711px; position: absolute; width: 211px; height: 29px" TabIndex="21"></asp:TextBox>
        <asp:Button ID="btnReset" runat="server" Font-Bold="True" Font-Size="Medium" OnClick="btnReset_Click" style="z-index: 1; left: 862px; top: 673px; position: absolute; width: 196px; height: 44px;" Text="RESET" TabIndex="22" Width="90px" />
        <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small" style="z-index: 1; left: 1058px; top: 590px; position: absolute; height: 24px;" Text="3rd Affiliation"></asp:Label>
        <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Names="Calibri" style="z-index: 1; left: 14px; top: 663px; position: absolute; height: 27px;" Text="Email 3:"></asp:Label>
        <asp:TextBox ID="txtEmail3" runat="server" BorderStyle="Groove" BorderWidth="4px" style="z-index: 1; left: 193px; top: 652px; position: absolute; height: 28px; width: 390px" TabIndex="18"></asp:TextBox>
        <p>
        <asp:Label ID="Label14" runat="server" style="z-index: 1; left: 1057px; top: 529px; position: absolute" Text="Author 2:" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        </p>
 
 
            </form>
</body>
</html>
