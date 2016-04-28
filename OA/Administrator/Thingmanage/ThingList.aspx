<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="Thing_ThingList" Codebehind="ThingList.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        办公用品列表</h1>
                    <div class="input-group">
                        <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Button"
                            OnClick="Button1_Click" />
                    </div>
                </div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped"
                    DataKeyNames="sid" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="sortsName" HeaderText="用品名称" />
                        <asp:BoundField DataField="number" HeaderText="数量" />
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="panel panel-default">
            <div class="panel-heading">
            <h1 class="h1">
                        添加办公用品</h1>
            </div>
                <div class="panel-body">
                    <div class="input-group">
                        <span class="input-group-addon" id="Span">名称</span>
                        <asp:TextBox ID="TextBox1" CssClass="form-control"  runat="server"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon" id="Span3">类别</span>
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon" id="Span1">数量</span>
                        <asp:TextBox ID="TextBox2" CssClass="form-control"  runat="server"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon" id="Span2">描述</span>
                        <asp:TextBox ID="TextBox3" CssClass="form-control"  runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-block btn-default" 
                        Text="添加" onclick="Button2_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
