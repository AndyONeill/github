<%@ Page Language="C#" 
    Async="true"
    AutoEventWireup="true" CodeBehind="EditPerson.aspx.cs" Inherits="web_People.EditPerson" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Person</title>
</head>
<body>
    <form id="form1" runat="server">
 <asp:FormView ID="fvPerson"
               runat="server"
               DataMember="PeopleData.Person" 
               DataKeyNames="ID"
               SelectMethod="fvPerson_GetItem"
               UpdateMethod="fvPerson_UpdateItem"
               DefaultMode="Edit" 
       >
    <EditItemTemplate>
         <table>
            <tr><td><b>FirstName:</b></td>       
                <td><asp:TextBox id="tbFirstName" runat="server" Text='<%# Bind("FirstName") %>' /></td>
            </tr>
            <tr><td><b>Surame:</b></td>     
                <td><asp:TextBox id="tbSurName"  runat="server" Text='<%# Bind("SurName") %>' /></td>
            </tr>
            <tr><td ><b>House Number:</b></td>      
                <td><asp:TextBox  runat="server" id="tbHouseNumber" Text='<%# Bind("HouseNumber") %>' /></td>
            </tr>
            <tr><td ><b>Road:</b></td>
                <td><asp:TextBox  runat="server" id="tbRoad" Text='<%# Bind("Road") %>' /></td>
            </tr>
            <tr><td ><b>Post Code:</b></td>      
                <td><asp:TextBox  runat="server" id="tbPostCode" Text='<%# Bind("PostCode") %>' /></td>
            </tr>
         </table>  
               
         <asp:Button CommandName="Update" runat="server" ID="btnUpdate" Text="Save" />
    </EditItemTemplate> 
 </asp:FormView>
    </form>
</body>
</html>
