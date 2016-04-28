<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="AddressManage_EmploueeList" Codebehind="EmploueeList.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        员工列表</h1>
                    <div class="input-group">
                        请输入员工姓名：<asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>&nbsp;
                        所在部门：<asp:DropDownList ID="DropDownList1" runat="server" >
                        </asp:DropDownList>
                        <asp:Button ID="Button1" runat="server" CssClass="BnCss" Text="查　询" OnClick="Button1_Click1" />
                    </div>
                </div>
                <asp:GridView ID="GridView1" runat="server" Height="71px" CssClass="table table-hover table-striped"
                    AutoGenerateColumns="False" DataKeyNames="Employeeid" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                    OnRowDataBound="GridView1_RowDataBound1" OnRowDeleting="GridView1_RowDeleting1"
                    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="name" HeaderText="员工姓名" />
                        <asp:BoundField DataField="Branch" HeaderText="职位" />
                        <asp:BoundField DataField="sex" HeaderText="性别" />
                        <asp:BoundField DataField="movePhone" HeaderText="电话" />
                        <asp:CommandField EditText="查看" HeaderText="查看" SelectText="查看" ShowSelectButton="True" />
                        <asp:CommandField EditText="修改" HeaderText="修改" ShowEditButton="True" />
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
