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
            <asp:GridView ID="grvStudent" runat="server" AllowPaging="True" AllowSorting="True" DataKeyNames="MaSV" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="grvStudent_PageIndexChanging" OnRowDeleting="grvStudent_RowDeleting" OnRowEditing="grvStudent_RowEditing" OnRowUpdating="grvStudent_RowUpdating" OnSelectedIndexChanging="grvStudent_SelectedIndexChanging" OnRowCancelingEdit="grvStudent_RowCancelingEdit" >
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" Font-Size="Larger" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Font-Size="Medium" />
                <RowStyle BackColor="#EFF3FB" Font-Size="12" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                <Columns>
                    <asp:BoundField DataField="MaSV" HeaderText="Mã sinh viên" ItemStyle-Width="15%" />
                    <asp:BoundField DataField="TenSV" HeaderText="Họ tên" ItemStyle-Width="30%" />
                    <asp:TemplateField HeaderText="Phái">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkGender" runat="server" Enabled="false"
                                Checked='<%# Eval("Phai").ToString().ToLower() == "1" %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkGenderEdit" runat="server"
                                Checked='<%# Eval("Phai").ToString() == "1" %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Lop" HeaderText="Lớp" ItemStyle-Width="15%" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" ItemStyle-Width="35%" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
