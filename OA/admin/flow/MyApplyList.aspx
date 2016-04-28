<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Inherits="OA.admin.flow.Flow_MyApplyList" Codebehind="MyApplyList.aspx.cs" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h1 class="h1">我的申请列表</h1>
            </div>
            <div class="panel-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped" DataKeyNames="ID" >
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="主题" />
                        <asp:TemplateField HeaderText="工作流程">
                            <ItemTemplate>
                                <asp:Label ID="lblFlow" runat="server"><%# getFlow(DataBinder.Eval(Container.DataItem,"FlowID").ToString()) %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="步骤">
                            <ItemTemplate>
                                <asp:Label ID="lblStep" runat="server"><%# getStep(DataBinder.Eval(Container.DataItem,"ID").ToString()) %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PubDate" HeaderText="申请时间" />
                        <asp:TemplateField HeaderText="查看">
                            <ItemTemplate>
                                <a href="ArchivesInfo.aspx?id=<%# DataBinder.Eval(Container.DataItem,"ID")%>"><%# DataBinder.Eval(Container.DataItem,"IsSave").ToString().Equals("0")?"查看":"" %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发送">
                            <ItemTemplate>
                                <a href="MyApplyList.aspx?id=<%# DataBinder.Eval(Container.DataItem,"ID")%>&flowid=<%# DataBinder.Eval(Container.DataItem,"FlowID")%>"><%# DataBinder.Eval(Container.DataItem,"IsSave").ToString().Equals("1")?"发送":"" %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="修改">
                            <ItemTemplate>
                                <a href="AddApply.aspx?id=<%# DataBinder.Eval(Container.DataItem,"ID")%>"><%# DataBinder.Eval(Container.DataItem, "IsSave").ToString().Equals("1") ? "修改":""%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <a href="MyApply.aspx?fdid=<%# DataBinder.Eval(Container.DataItem,"ID") %>"><%# DataBinder.Eval(Container.DataItem, "IsSave").ToString().Equals("1") ? "删除":""%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
                runat="server" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                PageSize="10" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never"
                OnPageChanged="AspNetPager1_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table">
            </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
</asp:Content>

