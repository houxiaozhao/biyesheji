<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Inherits="OA.admin.flow.Flow_StepBind" Codebehind="StepBind.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="panel panel-default">
            <div class="page-header">
                <h1 class="h1">
                    步骤绑定人员</h1>
            </div>
            <div class="panel-body" id="panel1" runat="server">
                <div class="row-fluid">
                    <div class="col-md-12">
                        <asp:DropDownList ID="DropDownList1" CssClass="form-control width_39" runat="server"
                            AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="col-md-5">
                        <asp:ListBox ID="ListBox1" runat="server" CssClass="width_100" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"
                            AutoPostBack="True"></asp:ListBox>
                    </div>
                    <div class="col-md-2">
                        <ul class="text-center">
                            <%--<li>
                                    <button id="addbtn" type="button" class="btn btn-default" runat="server" onserverclick="addbtn_onserverclick">
                                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                    </button>
                                </li>
                                <li>
                                    <button id="delbtn" type="button" class="btn btn-default" runat="server" onserverclick="delbtn_onserverclick">
                                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                    </button>
                                </li>--%>
                        </ul>
                    </div>
                    <div class="col-md-5">
                        <asp:ListBox ID="ListBox2" runat="server" CssClass="width_100" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged"
                            AutoPostBack="True"></asp:ListBox>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="col-md-12">
                        <asp:Button CssClass="btn btn-default btn-block" ID="Button5" runat="server" Text="确定"
                            OnClick="Button5_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
