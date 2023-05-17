<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ForSusNano._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="C:\SusNano\Program\ForSusNano\ForSusNano\SNOMbrDB011_20141026B.mdb" SelectCommand="SELECT `Submission Date` AS Submission_Date, `Membership Type` AS Membership_Type, `Other`, `Title`, `First Name` AS First_Name, `Middle Initial` AS Middle_Initial, `Last Name` AS Last_Name, `Gender`, `Organization`, `Street Addres` AS Street_Addres, `Street Address Line 2` AS Street_Address_Line_2, `City`, `State / Province` AS column1, `Postal / Zip Code` AS column2, `Country`, `Phone`, `Fax`, `Email`, `Position`, `Department`, `Main general focus of nanotechnology research` AS Main_general_focus_of_nanotechnology_research, `OtherFocus`, `Specific interests in sustainable nanotechnology` AS Specific_interests_in_sustainable_nanotechnology, `OtherSpecificInterest`, `Interest in SNO` AS Interest_in_SNO, `Field26`, `PaymentAmount`, `PaymentType`, `Payment` FROM `ConferenceRegistration`"></asp:AccessDataSource>
    </div>

</asp:Content>
