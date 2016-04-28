<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="AddressManage_AddEmployee" Codebehind="AddEmployee.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <asp:Label ID="Label1" CssClass="h3" runat="server" Text="增加员工"></asp:Label>
        <div class="row-fluid">
            <div class="col-md-12">
                <span id="user" runat="server">
                    <div class="input-group marbtm">
                        <span class="input-group-addon" id="Span8">用户名：</span>
                        <asp:TextBox ID="username" CssClass="form-control" runat="server" placeholder="输入姓名..."></asp:TextBox>
                    </div>
                    <div class="input-group marbtm">
                        <span class="input-group-addon" id="Span9">密码：</span>
                        <asp:TextBox ID="pwd" CssClass="form-control" runat="server" placeholder="输入姓名..."></asp:TextBox>
                    </div>
                </span>
            </div>
            <div class="col-md-6">
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="sizing-addon1">姓名：</span>
                    <asp:TextBox ID="name" CssClass="form-control" runat="server" placeholder="输入姓名..."></asp:TextBox>
                </div>
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span2">婚姻：</span>
                    <asp:DropDownList ID="marry" CssClass="form-control" runat="server">
                        <asp:ListItem>未婚</asp:ListItem>
                        <asp:ListItem>已婚</asp:ListItem>
                        <asp:ListItem>未知</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span4">地址：</span>
                    <asp:TextBox ID="address" CssClass="form-control" runat="server" placeholder="输入电话..."></asp:TextBox>
                </div>
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span6">QQ：</span>
                    <asp:TextBox ID="QQ" CssClass="form-control" runat="server" placeholder="输入QQ..."></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span1">性别：</span>
                    <asp:DropDownList ID="sex" CssClass="form-control" runat="server">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span3">身份：</span>
                    <asp:DropDownList ID="Branch" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="input-group marbtm">
                    <span class="input-group-addon" id="Span5">手机：</span>
                    <asp:TextBox ID="phone" CssClass="form-control" runat="server" placeholder="输入手机..."></asp:TextBox>
                </div>
                <div class="input-group marbtm">
                    <span class="input-group-addon">
                        <asp:DropDownList ID="cardtype" runat="server">
                            <asp:ListItem Enabled="true">身份证</asp:ListItem>
                            <asp:ListItem>军官证</asp:ListItem>
                        </asp:DropDownList>
                    </span>
                    <asp:TextBox ID="cardid" CssClass="form-control" runat="server" placeholder="输入证件号..."></asp:TextBox>
                </div>
            </div>
            <div class="col-md-12">
                <span id="upspan" runat="server">
                    <div class="h5">
                        上传照片</div>
                    <span id="shangchuan" runat="server">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-default" />
                        <asp:Button ID="up" runat="server" CssClass="btn btn-default" Text="上传" OnClick="up_Click" />
                    </span></span>
            </div>
            <hr />
            <asp:Button ID="save" CssClass="btn btn-default btn-block" runat="server" Text="保存"
                OnClick="save_Click" />
            <asp:Button ID="edit" CssClass="btn btn-default btn-block" runat="server" Text="修改"
                OnClick="edit_Click" />
        </div>
    </div>
</asp:Content>
