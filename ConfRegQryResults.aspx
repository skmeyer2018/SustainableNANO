<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfRegQryResults.aspx.cs" Inherits="ForSusNano.ConfRegQryResults" %>
<%@ Import Namespace="System.Data.OleDb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" name="viewport" content="width=device-width,initial-scale=1" />
    <title>CONFERENCE REGISTRATION QUERY RESULTS</title>
    <style>
         body {
             font-size:17px;
         }     
        p {
            font-family:MicroFLF;
            line-height:85%;
        }
        a {
            font-size: 20px;
            font-family:MicroFLF;
            font-weight:bold;
            position: fixed;
            background-color:lightgreen;
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
</head>
<body>
    
 
    
  
           <center>
        <H1 style="font-family: 'Sitka Heading'; font-size:60px;">CONFERENCE REGISTRATION QUERY RESULTS</H1>
        <h2 style="font-family:MicroFLF;">Sustainable Nanotechnology Organization</h2>
               </center>
        <div>
            <asp:Table ID="tblQueryResults" runat="server" Height="760px" style="z-index: 1; left: 26px; top: 206px; position: absolute; height: 760px; width: 1521px; margin-right: 0px;">
            </asp:Table>
        </div>
    
</body>
</html>
