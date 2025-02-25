<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfrStudent.aspx.cs" Inherits="code.wfrStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        Danh sách sinh viên
        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" AllowSorting="True" HorizontalAlign="Center" Width="1220px" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="MaSV">
            <AlternatingRowStyle BackColor="#99CCFF" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            </Columns>
            <RowStyle BackColor="White" />
        </asp:GridView>
        </form>
</body>
</html>
