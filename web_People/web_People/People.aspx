<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="People.aspx.cs" Inherits="web_People.People" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  </head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="PeopleGrid" 
            runat="server"
            SelectMethod="GetPeople"
            ItemType="PeopleData.Person"
            AutoGenerateColumns="false"
            DataKeyNames="ID">
            <Columns>
               <asp:BoundField DataField="FirstName" HeaderText="FirstName"  />
               <asp:BoundField DataField="SurName" HeaderText="SurName"  />
               <asp:BoundField DataField="HouseNumber" HeaderText="House Number"/>
               <asp:BoundField DataField="Road"  HeaderText="Road" />
               <asp:BoundField DataField="PostCode" HeaderText="Post Code" />
               <asp:BoundField 
                   DataField="ID" 
                   HtmlEncode="False" 
                   DataFormatString="<a target='_blank' href='EditPerson.aspx?id={0}'>Edit</a>" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnInsert"
                    runat="server" 
                    OnClick="btnInsert_Click"
                    Text="Add Person"
        />
     </form>
</body>
</html>
