<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="meetingManage_MeetingPub" ClientIDMode="Static" Codebehind="MeetingPub.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/bootstrap-datetimepicker.zh-CN.js"></script>
    <script type="text/javascript" src="../js/bootstrap-datetimepicker.js"></script>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3">
                主题
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="title" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                会议室
            </div>
            <div class="col-md-9">
                <asp:DropDownList ID="BoardroomName" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                参会人员
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtOtherMan" runat="server" onclick="javascript:otherman();"></asp:TextBox>
                <%--<input id="txtOtherMan" name="txtOtherMan" class="other" value="as" type="text" />--%>
                <button id="cmdScheOMan" class="btn btn-default" onclick="javascript:otherman();"
                    type="button" runat="server">
                    选择</button>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                级别
            </div>
            <div class="col-md-9">
                <asp:DropDownList ID="type" runat="server">
                    <asp:ListItem>一般</asp:ListItem>
                    <asp:ListItem>紧急</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                费用预算
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="Expenditure" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                开始时间
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="calendar1" CssClass="calendar form_datetime form-control" placeholder="输入起始时间"
                    runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                结束时间
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="calendar2" CssClass="calendar form_datetime form-control" placeholder="输入结束时间"
                    runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                会议内容
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="MeetingContent" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-9">
                <asp:Button ID="Button1" runat="server" Text="修改" CssClass="btn btn-default" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="发布" CssClass="btn btn-default" OnClick="Button2_Click" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(".form_datetime").datetimepicker({ format: 'yyyy-mm-dd hh:ii' });
        function otherman() {
            window.open("../UserWork/PersonnelSelection.aspx", null, "height=350,width=1000,directories = no,status=no,toolbar=no,menubar=no,location=no,titlebar = no,scrollbars = no");
        }
    </script>
</asp:Content>
