<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Register.CustomerList" %>
<%-- Định nghĩa trang web sử dụng C#, tự động liên kết sự kiện và tham chiếu file code-behind --%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Danh sách khách hàng</title>
</head>
<body>
    <%-- Form ASP.NET Web Forms --%>
    <form id="form1" runat="server">
        <div>
            <h1>Danh sách khách hàng</h1> <%-- Tiêu đề trang --%>
        </div>
        <div>
            <%-- GridView hiển thị danh sách khách hàng --%>
            <asp:GridView ID="grvKH" runat="server" AutoGenerateColumns="False" 
                AllowPaging="True" Width="100%" 
                OnPageIndexChanging="grvKH_PageIndexChanging" 
                OnRowCancelingEdit="grvKH_RowCancelingEdit" 
                OnRowDeleting="grvKH_RowDeleting" 
                OnRowEditing="grvKH_RowEditing" 
                OnRowUpdating="grvKH_RowUpdating" 
                OnSelectedIndexChanging="grvKH_SelectedIndexChanging" 
                DataKeyNames="TenDN"> 
                <%-- Định nghĩa khóa chính của GridView là "TenDN" --%>
                
                <%-- Định dạng giao diện của GridView --%>
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

                <%-- Định nghĩa các cột hiển thị trong GridView --%>
                <Columns>
                    <%-- Cột hiển thị Tên đăng nhập (không thể chỉnh sửa) --%>
                    <asp:BoundField DataField="TenDN" HeaderText="Tên đăng nhập" ItemStyle-Width="20%" ReadOnly="True" />

                    <%-- Cột hiển thị Họ tên --%>
                    <asp:BoundField DataField="HoTen" HeaderText="Họ tên" ItemStyle-Width="20%" />

                    <%-- Cột hiển thị Ngày sinh --%>
                    <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" ItemStyle-Width="15%" />

                    <%-- Cột hiển thị Giới tính dưới dạng checkbox --%>
                    <asp:TemplateField HeaderText="Phái" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <%-- CheckBox chỉ hiển thị, không cho phép chỉnh sửa --%>
                            <asp:CheckBox ID="chkGender" runat="server" Enabled="false"
                                Checked='<%# Eval("GioiTinh").ToString().ToLower() == "1" %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <%-- CheckBox cho phép chỉnh sửa khi vào chế độ edit --%>
                            <asp:CheckBox ID="chkGenderEdit" runat="server"
                                Checked='<%# Eval("GioiTinh").ToString() == "1" %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <%-- Cột hiển thị Email --%>
                    <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-Width="15%" />

                    <%-- Cột chứa các nút Edit, Delete và Select --%>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" ItemStyle-Width="25%" />
                </Columns>
            </asp:GridView>

            <%-- Hiển thị danh sách lỗi nếu có lỗi nhập liệu --%>
            <asp:ValidationSummary ID="vsTonghop" runat="server" HeaderText="Danh sách các lỗi" />
            
        </div>
    </form>
</body>
</html>
