<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfrStudent.aspx.cs" Inherits="Bai1.wfrStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý sinh viên</title>
    <style>
        td {
            margin:5px;
            padding:5px;
            font-family: Tahoma;
            font-size:14px;
            text-align:left;
            vertical-align:top;
        }
    </style>
</head>
<body>
    <form id="wfrStudent" runat="server">
        <div>
            <h1>Danh sách sinh viên</h1>
        </div>
        <div>
            <asp:GridView ID="grvStudent" runat="server" AllowPaging="True" AllowSorting="True" DataKeyNames="MaSV" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="grvStudent_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" Font-Size="Larger" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                <Columns>
                    <asp:BoundField DataField="MaSV" HeaderText="Mã sinh viên" />
                    <asp:BoundField DataField="TenSV" HeaderText="Họ tên" />
                    <asp:BoundField DataField="Phai" HeaderText="Phái" />
                    <asp:BoundField DataField="Lop" HeaderText="Lớp" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
