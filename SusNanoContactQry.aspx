<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SusNanoContactQry.aspx.cs" Inherits="ForSusNano.frmSusNanoFront" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 16px;
            width: 199px;
        }
        #TextArea1 {
            z-index: 1;
            left: 19px;
            top: 530px;
            position: absolute;
            width: 1292px;
            height: 387px;
        }

    </style>
</head>
<body style="z-index: 1; left: 80px; top: 10px; position: absolute; height: 481px; width: 1601px">
    <center><h1 style="font-family: 'Sitka Heading';">CONTACT QUERY PAGE</h1>
        <h2 style="font-family: Calibri;">Sustainable Nanotechnology Organization</h2>
    </center><br >
    <form id="form1" runat="server">
        <asp:TextBox ID="txtAddress" runat="server" style="z-index: 1; left: 171px; top: 253px; position: absolute; width: 994px; margin-top: 4px; height: 29px;" TabIndex="2" BorderStyle="Ridge"></asp:TextBox>
        <br ><br >
            <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 9px; top: 307px; position: absolute; width: 140px; height: 27px; right: 1452px;" Text="City:" Font-Bold="True" Font-Names="Candara"></asp:Label>
            <br >
        <div>
        </div>
        <p style="margin-top: 19px">
            &nbsp;</p>
        <p style="margin-top: 19px">
            <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 9px; top: 251px; position: absolute; margin-bottom: 0px; height: 32px; width: 112px; right: 1480px;" Text="Address:" Font-Bold="True" Font-Names="Candara"></asp:Label>
            </p>
            <asp:Button ID="btnSubmitQuery" runat="server" OnClick="btnSubmitQuery_Click" style="z-index: 1; left: 185px; top: 469px; position: absolute; width: 360px" Text="SUBMIT QUERY" TabIndex="8" />
        <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 721px; top: 312px; position: absolute; height: 32px; right: 879px;" Text="State:" Font-Bold="True" Font-Names="Candara"></asp:Label>
        <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 950px; top: 307px; position: absolute; height: 19px; width: 59px;" Text="Zip:" Font-Bold="True" Font-Names="Candara"></asp:Label>
        <p style="z-index: 1; left: -1px; top: -5px; position: absolute; height: 28px; width: 1535px">
            <asp:TextBox ID="txtCity" runat="server" style="z-index: 1; left: 173px; top: 312px; position: absolute; width: 471px; height: 36px; right: 883px;" TabIndex="3" BorderStyle="Ridge"></asp:TextBox>
            <asp:TextBox ID="txtState" runat="server" style="z-index: 1; left: 809px; top: 309px; position: absolute; height: 40px; width: 84px" TabIndex="4" BorderStyle="Ridge"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" style="z-index: 1; left: 10px; top: 368px; position: absolute; height: 1px;" Text="Email:" Font-Bold="True" Font-Names="Candara"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 171px; top: 418px; position: absolute; width: 661px; height: 32px;" TabIndex="7" BorderStyle="Ridge"></asp:TextBox>
            <asp:Label ID="Label10" runat="server" style="z-index: 1; left: 10px; top: 202px; position: absolute; width: 154px" Text="Contact Name:" Font-Bold="True" Font-Names="Candara"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" style="z-index: 1; left: 172px; top: 370px; position: absolute; width: 985px; height: 31px" TabIndex="6" BorderStyle="Ridge"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" style="z-index: 1; left: 10px; top: 429px; position: absolute; height: 1px; width: 63px;" Text="Phone:" Font-Bold="True" Font-Names="Candara"></asp:Label>
            <asp:TextBox ID="txtContact" runat="server" style="z-index: 1; left: 172px; top: 193px; position: absolute; height: 35px; width: 993px" BorderStyle="Ridge" TabIndex="1"></asp:TextBox>
        </p>
        <asp:TextBox ID="txtZip" runat="server" style="z-index: 1; left: 1000px; top: 306px; position: absolute; height: 42px; width: 156px; right: 437px;" TabIndex="5" BorderStyle="Ridge"></asp:TextBox>
        <p style="z-index: 1; left: -1px; top: -5px; position: absolute; height: 28px; width: 1535px">
            &nbsp;</p>
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" CaptionAlign="Top" Font-Size="X-Small" GridLines="Both" HorizontalAlign="Left" style="z-index: 1; left: -39px; top: 619px; position: absolute; height: 348px; width: 1045px" Width="100px">
        </asp:Table>
        <p>
            &nbsp;</p>
        <p>
        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" style="z-index: 1; left: 180px; top: 516px; position: absolute; width: 363px; right: 1058px;" Text="RESET" />
        </p>
    </form>
</body>
</html>
