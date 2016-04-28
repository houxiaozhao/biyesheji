<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="System_NewsAdd" Codebehind="NewsAdd.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="form-group">
        <label for="exampleInputEmail1">
            类型</label>
        <asp:DropDownList ID="DropDownList1" CssClass="form-control width200" runat="server"
            AutoPostBack="True">
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label>
            主题</label>
        <asp:TextBox ID="titel" runat="server" placeholder="输入标题" class="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>
            内容</label>
        <asp:TextBox ID="content" runat="server" TextMode="MultiLine" CssClass="form-control textarea"></asp:TextBox>
    </div>
    <asp:Button ID="Button1" CssClass="btn-default btn" runat="server" Text="发布" OnClick="Button1_Click" />
    <asp:Button ID="Button2" CssClass="btn-default btn" runat="server" Text="取消" OnClick="Button2_Click" />
</asp:Content>

