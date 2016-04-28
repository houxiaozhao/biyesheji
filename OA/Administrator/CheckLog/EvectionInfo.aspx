<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="System_EvectionInfo" Codebehind="EvectionInfo.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="panel">
                <div class="panel-heading">
                    <h1 class="h1">
                        出差信息</h1>
                </div>
               <asp:GridView ID="GridView1" runat="server" Height="71px" CssClass="table table-hover table-striped"
                    AutoGenerateColumns="False" DataKeyNames="Evectionid"  >
                        <Columns>
                            <asp:BoundField DataField="username" HeaderText="员工姓名" />
                            <asp:BoundField DataField="address" HeaderText="出差地址" />
                            <asp:BoundField DataField="outtime" HeaderText="出差时间" />
                            <asp:BoundField DataField="rtime" HeaderText="返回时间" />
                            <asp:BoundField DataField="Content" HeaderText="内容" />
                        </Columns>
                    </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

