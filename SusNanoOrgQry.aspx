<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SusNanoOrgQry.aspx.cs" Inherits="ForSusNano.SusNanoOrgQry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
 <h1 style="font-family: 'Sitka Heading';">ORGANIZATION QUERY PAGE</h1>
    <h2 style="font-family: Calibri;">Sustainable Nanotechnology Organization</h2>
</center>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 142px; top: 197px; position: absolute; margin-top: 0px" Text="Organization Name:"></asp:Label>
        <asp:TextBox ID="txtOrgName" runat="server" height="33px" style="z-index: 1; left: 405px; top: 190px; position: absolute; width: 713px" BorderStyle="Ridge"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 144px; top: 246px; position: absolute" Text="Category:"></asp:Label>
        <p>
            &nbsp;</p>
        <p>
            <asp:DropDownList ID="ddlOrgCat" runat="server" style="z-index: 1; left: 406px; top: 251px; position: absolute; height: 31px; width: 710px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Technology Research</asp:ListItem>
                <asp:ListItem>Education</asp:ListItem>
                <asp:ListItem>Hotels</asp:ListItem>
                <asp:ListItem>Law Firm</asp:ListItem>
                <asp:ListItem>Medical Services</asp:ListItem>
                <asp:ListItem>Government Agency</asp:ListItem>
            </asp:DropDownList>
        </p>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 146px; top: 301px; position: absolute; height: 15px" Text="Role:"></asp:Label>
        <asp:TextBox ID="txtRole" runat="server" style="z-index: 1; left: 404px; top: 305px; position: absolute; width: 713px; height: 33px" BorderStyle="Ridge"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 144px; top: 352px; position: absolute; height: 9px; width: 94px" Text="Department:"></asp:Label>
        <asp:TextBox ID="txtDepartment" runat="server" height="33px" style="z-index: 1; left: 403px; top: 360px; position: absolute; width: 713px" BorderStyle="Ridge"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 144px; top: 402px; position: absolute; height: 20px; width: 131px; bottom: 298px" Text="Position:"></asp:Label>
        <asp:TextBox ID="txtPosition" runat="server" height="33px" style="z-index: 1; left: 403px; top: 408px; position: absolute; width: 713px" BorderStyle="Ridge"></asp:TextBox>
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" CaptionAlign="Top" Font-Size="X-Small" GridLines="Both" HorizontalAlign="Left" style="z-index: 1; left: 29px; top: 615px; position: absolute; height: 252px; width: 788px">
        </asp:Table>
        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" style="z-index: 1; left: 622px; top: 518px; position: absolute; width: 291px; height: 37px; margin-top: 22px;" Text="RESET" />
        <p>
            &nbsp;</p>
        <asp:Button ID="btnSubmitQuery" runat="server" OnClick="btnSubmitQuery_Click" style="z-index: 1; left: 628px; top: 478px; position: absolute; width: 284px; height: 37px;" Text="SUBMIT QUERY" />
    </form>
</body>
</html>
