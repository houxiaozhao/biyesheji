<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="System_GoOut" Codebehind="GoOutInfo.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        外出信息</h1>
                </div>
                <asp:GridView ID="GridView1" runat="server" Height="71px" CssClass="table table-hover table-striped"
                    AutoGenerateColumns="False" DataKeyNames="OutRegisterid" >
                        <Columns>
                            <asp:BoundField DataField="username" HeaderText="员工姓名" />
                            <asp:BoundField DataField="outtime" HeaderText="外出时间" />
                            <asp:BoundField DataField="returntime" HeaderText="返回时间" />
                            <asp:BoundField DataField="why" HeaderText="原因" />
                            <asp:BoundField DataField="datetime" HeaderText="外出日期" />
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

