<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Inherits="OA.admin.flow.Flow_CustomList" Codebehind="CustomList.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container-fluid">
        <div class="row-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        自定义流程管理</h1>
                        <asp:DropDownList ID="drpType" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="btnFind" runat="server" Text="查找" OnClick="btnFind_Click" CssClass="btn btn-default"/>
                </div>
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped"
                    DataKeyNames="ID" OnRowDeleting="GridView1_RowDeleting" 
                    AutoGenerateSelectButton="True" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="流程名称" />
                       <asp:TemplateField HeaderText="流程设计">
                            <ItemTemplate>
                                <a href="FlowStep.aspx?id=<%#DataBinder.Eval(Container.DataItem,"ID") %>" target="_blank">流程设计</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                <div class="col-md-12">
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-default btn-block" Text="新建自定义流程"
                        OnClick="Button2_Click" />
                </div>
                <div class="panel-body" id="panel" runat="server">
                    <div class="row martop">
                        <div class="col-md-2">
                            流程类型</div>
                        <div class="col-md-10">
                            <asp:DropDownList ID="drpFlowType" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row martop">
                        <div class="col-md-2">
                            流程名称</div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                    
                    
                    <div class="row martop">
                        <div class="col-md-2">
                            流程说明</div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtContent" runat="server" CssClass="textarea width_100 height100" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row martop">
                        <div class="col-md-12">
                            <asp:Button ID="Button1" CssClass="btn btn-default btn-block" runat="server" Text="保存"
                                OnClick="Button1_Click" />
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="Button3" CssClass="btn btn-default btn-block" runat="server" Text="修改"
                                OnClick="Button3_Click" />
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>

