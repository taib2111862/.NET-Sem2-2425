<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillingForm.aspx.cs" Inherits="Register.FillingForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký khách hàng</title>
    <style type="text/css">
        .auto-style1 {
            width: 135px;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Đăng ký khách hàng</h2>
            <table>
                <tr>
                    <td class="auto-style1"><strong>Thông tin đăng nhập</strong></td>
                </tr>
                <tr>
                    <td class="auto-style1">Tên đăng nhập:</td>
                    <td>
                        <asp:TextBox ID="txtTenDN" runat="server" OnTextChanged="txtTenDN_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf_TenDN" runat="server" ControlToValidate="txtTenDN"
                            ErrorMessage="Tên đăng nhập không được rỗng" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Mật khẩu:</td>
                    <td>
                        <asp:TextBox ID="txtMK" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf_MK" runat="server" ControlToValidate="txtMK"
                            ErrorMessage="Mật khẩu không được rỗng" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Nhập lại mật khẩu:</td>
                    <td>
                        <asp:TextBox ID="txtNhaplaiMK" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf_Nhaplai" runat="server" ControlToValidate="txtNhaplaiMK"
                            ErrorMessage="Nhập lại mật khẩu không được rỗng" Display="Dynamic">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_Nhaplai" runat="server" ControlToValidate="txtNhaplaiMK"
                            ControlToCompare="txtMK" ErrorMessage="Mật khẩu nhập lại chưa đúng" Display="Dynamic">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><strong>Thông tin cá nhân</strong></td>
                </tr>
                <tr>
                    <td class="auto-style1">Họ tên:</td>
                    <td>
                        <asp:TextBox ID="txtKH" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rf_KH" runat="server" ControlToValidate="txtKH"
                            ErrorMessage="Họ tên không được rỗng" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Ngày sinh:</td>
                    <td>
                        <asp:TextBox ID="txtNgaySinh" runat="server" TextMode="Date"></asp:TextBox>
                        <asp:CompareValidator ID="cv_Ngaysinh" runat="server" ControlToValidate="txtNgaySinh"
                            Type="Date" Operator="DataTypeCheck" ErrorMessage="Ngày sinh không hợp lệ" Display="Dynamic">*</asp:CompareValidator>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Giới tính:</td>
                    <td>
                        <asp:RadioButton ID="radNam" runat="server" Text="Nam" GroupName="GioiTinh"></asp:RadioButton>
                        <asp:RadioButton ID="radNu" runat="server" Text="Nữ" GroupName="GioiTinh"></asp:RadioButton>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="128px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ErrorMessage="Email không hợp lệ" Display="Dynamic">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Thu nhập:</td>
                    <td>
                        <asp:TextBox ID="txtThuNhap" runat="server"></asp:TextBox>
                        <asp:RangeValidator ID="rvThuNhap" runat="server" ControlToValidate="txtThuNhap"
                            MinimumValue="1000000" MaximumValue="50000000" ErrorMessage="Thu nhập từ 1 triệu đến 50 triệu" Display="Dynamic">*</asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnDangky" runat="server" Text="Đăng ký" OnClick="btnDangky_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblThongBao" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="vsTonghop" runat="server" HeaderText="Danh sách các lỗi" />
        </div>
    </form>
</body>
</html>