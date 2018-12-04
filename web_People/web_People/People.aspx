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
            DeleteMethod="DeletePerson"
            ItemType="PeopleData.Person"
            AutoGenerateColumns="false"
            DataKeyNames="ID">
            <Columns>
               <asp:BoundField DataField="FirstName" HeaderText="First Name"  />
               <asp:BoundField DataField="SurName" HeaderText="SurName"  />
               <asp:BoundField DataField="HouseNumber" HeaderText="House Number"/>
               <asp:BoundField DataField="Road"  HeaderText="Road" />
               <asp:BoundField DataField="PostCode" HeaderText="Post Code" />
               <asp:BoundField 
                   DataField="ID" 
                   HtmlEncode="False" 
                   DataFormatString="<a href='EditPerson.aspx?id={0}'>Edit</a>" />
                <asp:CommandField ShowDeleteButton="true" /> 
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
