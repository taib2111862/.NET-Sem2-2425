<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Register.CustomerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Danh sách khách hàng</h1>
        </div>
        <div>
            <asp:GridView ID="grvKH" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%" OnPageIndexChanging="grvKH_PageIndexChanging" OnRowCancelingEdit="grvKH_RowCancelingEdit" OnRowDeleting="grvKH_RowDeleting" OnRowEditing="grvKH_RowEditing" OnRowUpdating="grvKH_RowUpdating" OnSelectedIndexChanging="grvKH_SelectedIndexChanging" DataKeyNames="TenDN">
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
                    <asp:BoundField DataField="TenDN" HeaderText="Tên đăng nhập" ItemStyle-Width="20%" ReadOnly="True" />
                    <asp:BoundField DataField="HoTen" HeaderText="Họ tên" ItemStyle-Width="20%" />
                    <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" ItemStyle-Width="15%" />
                    <asp:TemplateField HeaderText="Phái" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkGender" runat="server" Enabled="false"
                                Checked='<%# Eval("GioiTinh").ToString().ToLower() == "1" %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkGenderEdit" runat="server"
                                Checked='<%# Eval("GioiTinh").ToString() == "1" %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-Width="15%" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" ItemStyle-Width="25%" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
