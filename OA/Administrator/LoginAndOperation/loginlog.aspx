<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="System_loginlog" Codebehind="loginlog.aspx.cs" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span12 panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        登录信息</h1>
                </div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="LoginID" CssClass="table table-hover table-striped"
                    Height="145px">
                    <Columns>
                        <asp:BoundField DataField="number" HeaderText="序号" />
                        <asp:BoundField DataField="UserName" HeaderText="用户账号" />
                        <asp:BoundField DataField="LoginTime" HeaderText="登录时间" />
                        <asp:BoundField DataField="IP" HeaderText="登录地址" />
                        <asp:BoundField DataField="State" HeaderText="状态" />
                    </Columns>
                </asp:GridView>
            </div>
            <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
                runat="server" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                PageSize="10" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never"
                OnPageChanged="AspNetPager1_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
