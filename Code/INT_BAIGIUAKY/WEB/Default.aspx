<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Tuổi: "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label3" runat="server" Text="Giới tính: "></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><br />
    <asp:Label ID="Label4" runat="server" Text="Thu nhập: "></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label5" runat="server" Text="TRình độ học vấn: "></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList><br />
    <asp:Label ID="Label6" runat="server" Text="Vùng: "></asp:Label>
    <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList><br />
    <asp:Label ID="Label7" runat="server" Text="Tình trạng: "></asp:Label>
    <asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList><br />
    <asp:Label ID="Label8" runat="server" Text="Tần suất mua hàng: "></asp:Label>
    <asp:DropDownList ID="DropDownList5" runat="server"></asp:DropDownList><br />
    <asp:Label ID="Label9" runat="server" Text="Danh mục sản phẩm: "></asp:Label>
    <asp:DropDownList ID="DropDownList6" runat="server"></asp:DropDownList><br />
    <asp:Button ID="Button1" runat="server" Text="Kiểm tra" OnClick="Button1_Click" /><br />
    <asp:Label ID="Label10" runat="server" Text="Bạn thuộc cụm: "></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label11" runat="server" Text="Nhập cụm: "></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button2" runat="server" Text="Kiểm tra" OnClick="Button2_Click" /><br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
