<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="AddressManage_BranchMessage" Codebehind="BranchMessage.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        部门管理</h1>
                    <div class="input-group">
                        <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="输入部门名称" runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" 
                            Text="新建部门" onclick="Button1_Click" />
                        </span>
                    </div>
                </div>
                <asp:GridView ID="GridView1" runat="server" Height="71px" CssClass="table table-hover table-striped"
                    AutoGenerateColumns="False" DataKeyNames="Dutyid" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound"
                    OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Branch" HeaderText="部门名称" />
                        <asp:BoundField DataField="addtime" HeaderText="创建日期" ReadOnly="True" />
                        <asp:CommandField HeaderText="修改" EditText="修改" ShowEditButton="True" UpdateText="修改" />
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                        <asp:BoundField DataField="Dutyid" HeaderText="Dutyid" Visible="False" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
