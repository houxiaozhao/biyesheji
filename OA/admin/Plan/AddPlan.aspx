<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddPlan.aspx.cs" Inherits="OA.admin.Plan.AddPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-datepicker/css/datepicker-custom.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-timepicker/css/timepicker.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-colorpicker/css/colorpicker.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-daterangepicker/daterangepicker-bs3.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-datetimepicker/css/datetimepicker-custom.css" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-group">
                <label>
                    主题</label>
                <asp:TextBox ID="titel" runat="server" placeholder="输入标题" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
            <label>时间</label>
                <div class="input-group input-large custom-date-range" data-date="13/07/2013" data-date-format="mm/dd/yyyy">
                        <asp:TextBox ID="calendar1" CssClass="form-control dpd1" name="from" runat="server"></asp:TextBox>
                    </div>
            
            </div>
            <div class="form-group">
                <label>
                    内容</label>
                <asp:TextBox ID="content" runat="server" TextMode="MultiLine" CssClass="form-control textarea"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" CssClass="btn-default btn" runat="server" Text="发布" OnClick="Button1_Click" />

        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript" src="../../js/bootstrap-inputmask/bootstrap-inputmask.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-timepicker/js/bootstrap-timepicker.js"></script>
    <script type="text/javascript" src="../../js/pickers-init.js"></script>
</asp:Content>
