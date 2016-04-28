<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewPwd.aspx.cs" Inherits="OA.admin.personal.NewPwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="input-group mar" runat="server" id="div1">
  <span class="input-group-addon" id="oldpwd">旧密码</span>
  <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" 
        placeholder="old password" aria-describedby="oldpwd" TextMode="Password"></asp:TextBox>
</div>
<div class="input-group mar" runat="server" id="div2">
  <span class="input-group-addon" id="newpwd">新密码</span>
  <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="new password" TextMode="Password" aria-describedby="newpwd"></asp:TextBox>
</div>
<div class="input-group mar" runat="server" id="div3">
  <span class="input-group-addon" id="confirmpwd">确认密码</span>
  <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="confirm password" TextMode="Password" aria-describedby="confirmpwd"></asp:TextBox>
</div>
    <asp:Button ID="Button1" CssClass="btn btn-default btn-lg btn-block" 
        runat="server" Text="Button" onclick="Button1_Click" />
</asp:Content>
