<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddContacts.aspx.cs" Inherits="OA.admin.AddressManage.AddContacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container-fluid">
 <asp:Label ID="Label1" CssClass="h3" runat="server" Text="增加联系人"></asp:Label>
        <div class="row-fluid">
            
            <div class="col-md-6">
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="sizing-addon1">姓名：</span>
                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="输入姓名..."></asp:TextBox>
                </div>
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span2">婚姻：</span>
                    <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server">
                        <asp:ListItem>未婚</asp:ListItem>
                        <asp:ListItem>已婚</asp:ListItem>
                        <asp:ListItem>未知</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span4">电话：</span>
                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="输入电话..."></asp:TextBox>
                </div>
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span6">QQ：</span>
                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="输入QQ..."></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span1">性别：</span>
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span3">所属分组：</span>
                    <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                 <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span5">手机：</span>
                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" placeholder="输入手机..."></asp:TextBox>
                </div>
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span7">简介：</span>
                    <asp:TextBox ID="TextBox5" CssClass="form-control textarea" runat="server" 
                        placeholder="输入简介..." TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <hr />
            <asp:Button ID="Button1" CssClass="btn btn-default btn-lg btn-block" 
                runat="server" Text="保存" onclick="Button1_Click" />
        </div>
    </div>
</asp:Content>
