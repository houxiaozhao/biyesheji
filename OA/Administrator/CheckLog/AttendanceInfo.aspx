<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="System_AttendanceInfo" Codebehind="AttendanceInfo.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="panel">
                <div class="panel-heading">
                    <h1 class="h1">
                        考勤信息</h1>
                </div>
                <asp:GridView Style="font-size: 9pt" ID="GridView1" runat="server" CssClass="table table-hover table-striped"
                     Height="160px" AutoGenerateColumns="False"
                    DataKeyNames="OndutyId" >
                    <Columns>
                        <asp:BoundField DataField="username" HeaderText="员工姓名"></asp:BoundField>
                        <asp:BoundField DataField="CheckDate" HeaderText="日期"></asp:BoundField>
                        <asp:BoundField DataField="Ontutytime" HeaderText="上班时间"></asp:BoundField>
                        <asp:BoundField DataField="OffdutyTime" HeaderText="下班时间"></asp:BoundField>
                        <asp:BoundField DataField="OntutyState" HeaderText="上班状态"></asp:BoundField>
                        <asp:BoundField DataField="OffDutyState" HeaderText="下班状态"></asp:BoundField>
                        <asp:BoundField DataField="OndutyId" HeaderText="OndutyId" Visible="False"></asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
