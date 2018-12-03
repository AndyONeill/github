<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="People1.aspx.cs" Inherits="web_People.People1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="PeopleGrid" runat="server"
            SelectMethod="GetPeople"
            UpdateMethod="UpdatePerson"
            ItemType="PeopleData.Person"
            AutoGenerateColumns="true"
            DataKeyNames="ID">
            <Columns>
                <asp:CommandField ShowEditButton="True"/>
            </Columns>
        </asp:GridView>
     </form>
</body>
</html>
