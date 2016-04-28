<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Inherits="OA.admin.flow.Flow_History" Codebehind="History.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h1 class="h1">审批意见列表</h1>
            </div>
            <div class="panel-body">
                <div id="warn" runat="server" class="alert alert-warning" role="alert">还没有人对此申请进行审批</div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped">
                    <Columns>
                        <asp:TemplateField HeaderText="审阅人">
                            <ItemTemplate>
                                <asp:Label ID="lblUser" runat="server"><%# getUser(DataBinder.Eval(Container.DataItem,"UserID").ToString()) %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Comment" HeaderText="审阅意见" />
                        <asp:BoundField DataField="Pubdate" HeaderText="审阅时间" />
                        <asp:BoundField DataField="Atteachment" HeaderText="附件" />
                    </Columns>
                </asp:GridView>
                
            </div>
            <div class="panel-footer">
                <a href="javascript :;" class="btn btn-block btn-default" onClick="javascript :history.back(-1);">返回上一页</a>
            </div>
        </div>
    </div>
</asp:Content>

