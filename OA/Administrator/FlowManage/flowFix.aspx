<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="Flow_flowFix" Codebehind="flowFix.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        固定流程管理</h1>
                        <asp:DropDownList ID="drpType" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="btnFind" runat="server" Text="查找" OnClick="btnFind_Click" CssClass="btn btn-default"/>
                        
                              <asp:Button ID="Button3" runat="server" Text="添加新项" CssClass="btn btn-default float-rt" 
                                  onclick="Button3_Click"/>
                        
                </div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped"
                    DataKeyNames="ID" OnRowDeleting="GridView1_RowDeleting" 
                    AutoGenerateSelectButton="True" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="流程名称" />
                        <asp:TemplateField HeaderText="流程设计">
                            <ItemTemplate>
                                <a href="flowStep.aspx?id=<%# DataBinder.Eval(Container.DataItem,"ID") %>" target="_blank">流程设计</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
        <div class="panel panel-default" id="panel2" runat="server">
            <div class="panel-heading">
                <h1 class="h1">
                    固定流程添加</h1>
            </div>
            <div class="row martop">
        
            <div class="col-md-2">
                流程名称</div>
            <div class="col-md-10">
                <asp:TextBox ID="flowname" runat="server"></asp:TextBox>
            </div>
            </div>
            <div class="row martop">
            <div class="col-md-2">
                流程类型</div>
            <div class="col-md-10">
                <asp:DropDownList ID="flowtype" CssClass="width160" runat="server">
                </asp:DropDownList>
            </div>
            </div>
            <div class="row martop">
            <div class="col-md-2">
                流程说明</div>
            <div class="col-md-10">
                <asp:TextBox ID="flowcontent" runat="server" CssClass="textarea width_100 height100"
                    TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="col-md-12">
                <asp:Button ID="Button1" runat="server" Text="保存修改"  
                    CssClass="btn btn-default btn-block " onclick="Button1_Click"/>
            </div>
            <div class="col-md-12">
                <asp:Button ID="Button2" runat="server" Text="添加新项"  
                    CssClass="btn btn-default btn-block " onclick="Button2_Click"/>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
