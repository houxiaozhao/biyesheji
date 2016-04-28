<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="Thing_ThingClass" Codebehind="ThingClass.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        办公用品分类</h1>
                    <div class="input-group">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="输入类别名称"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" Text="添加" OnClick="Button1_Click" />
                        </span>
                    </div>
                </div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped"
                    DataKeyNames="sid" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                    OnRowUpdating="GridView1_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="name" HeaderText="分类名称" />
                        <asp:CommandField EditText="修改" HeaderText="修改" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
