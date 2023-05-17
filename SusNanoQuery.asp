<%@ LANGUAGE = VBScript %>
<HTML>
<head>
    <style type="text/css">
        #fName {
            width: 444px;
        }
        #lName {
            width: 381px;
            margin-left: 0px;
        }
        #address {
            width: 762px;
        }
        #Text1 {
            width: 382px;
        }
    </style>
</head>
<BODY>
<CENTER><h1>QUERY PAGE</h1></CENTER>
    <form method="post">
    <table style="width:100%;">
        <tr>
            <td>FIRST NAME:&nbsp;&nbsp;<input id="fName" type="text" name="fName" /></td>
            <td>LAST NAME:<input id="lName" type="text" name="lName" /></td>
        </tr>
        <tr>
            <td>ADDRESS:&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<input id="address" type="text" name="address" /></td>
            
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>CITY:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="Text1" type="text" /></td>
            
            <td>STATE:<input id="state" type="text" name="state" /> ZIP: <input id="zip" type="text"  name="zip"/> </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
            PHONE: <input id="phne" type="text" name="phone" />
            </td>
            <td>
            EMAIL: <input id="email" type="text" name="email"/>
            </td>
        </tr>
    </table>
    </form>
<%
response.write("I'm another classy ASP page.")
   Set adoCon = Server.CreateObject("ADODB.Connection")
    
'Set an active connection to the Connection object using a DSN-less connection
adoCon.Open  "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & "C:\SusNano\Program\ForSusNano\ForSusNano\SNOMbrDB011_20141026B.mdb" ' Server.MapPath("SNOMbrDB011_20141026B.mdb")

Set rsMembers = Server.CreateObject("ADODB.Recordset")
 strSQL="SELECT  City FROM Address"
 rsMembers.CursorType=2
    rsMembers.LockType=3
' rsMembers.Open(  strSQL, adoCon)
 adoCon.Execute strSQL,20
'Loop through the recordset
Do While not rsMembers.EOF

    'Write the HTML to display the current record in the recordset
    Response.Write ("<br>")
    Response.Write rsMembers.City.Value
 '   Response.Write ("<br>")
 '  Response.Write (rsMembers("Members"))
 '   Response.Write ("<br>")
    'Move to the next record in the recordset
    rsMembers.MoveNext
Loop
 rsMembers.Close
%>
</BODY>
</HTML>