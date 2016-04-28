<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="System_leaveInfo" Codebehind="leaveInfo.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        请假信息</h1>
                </div>
               <asp:GridView ID="GridView1" runat="server" Height="71px" CssClass="table table-hover table-striped"
                    AutoGenerateColumns="False" DataKeyNames="leaveID" >
                        <Columns>
                            <asp:BoundField DataField="username" HeaderText="员工姓名" />
                            <asp:BoundField DataField="leaveDate" HeaderText="请假时间" />
                            <asp:BoundField DataField="retrue" HeaderText="返回时间" />
                            <asp:BoundField DataField="Content" HeaderText="原因" />
                        </Columns>
                    </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

