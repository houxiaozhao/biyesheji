<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="System_OperationLog" Codebehind="OperationLog.aspx.cs" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container-fluid">
        <div class="row-fluid">
            <div class="span12 panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        操作信息</h1>
                </div> 
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="WorkLogId" CssClass="table table-hover table-striped">
                        <Columns>
                            <asp:BoundField DataField="number" HeaderText="序号" />
                            <asp:BoundField DataField="WorkLogId" HeaderText="用户编号" />
                            <asp:BoundField DataField="UserName" HeaderText="用户姓名" />
                            <asp:BoundField DataField="WorkTime" HeaderText="操作时间" />
                            <asp:BoundField DataField="WorkInfo" HeaderText="操作描述" />
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

