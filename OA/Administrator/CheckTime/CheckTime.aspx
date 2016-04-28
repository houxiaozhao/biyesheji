<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true"
    CodeBehind="CheckTime.aspx.cs" Inherits="OA.Administrator.CheckTime.CheckTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <!--pickers css-->
  <link rel="stylesheet" type="text/css" href="../../js/bootstrap-datepicker/css/datepicker-custom.css" />
  <link rel="stylesheet" type="text/css" href="../../js/bootstrap-timepicker/css/timepicker.css" />
  <link rel="stylesheet" type="text/css" href="../../js/bootstrap-colorpicker/css/colorpicker.css" />
  <link rel="stylesheet" type="text/css" href="../../js/bootstrap-daterangepicker/daterangepicker-bs3.css" />
  <link rel="stylesheet" type="text/css" href="../../js/bootstrap-datetimepicker/css/datetimepicker-custom.css" />
    <div class="form-group">
        <label class="control-label col-md-4">
            上班时间</label>
        <div class="col-md-6">
            <div class="input-group bootstrap-timepicker">
                <input type="text" class="form-control timepicker-24" readonly="true" id="shang" runat="server">
                <span class="input-group-btn">
                    <button class="btn btn-default" type="button">
                        <i class="fa fa-clock-o"></i>
                    </button>
                </span>
            </div>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-4">
            下班时间</label>
        <div class="col-md-6">
            <div class="input-group bootstrap-timepicker">
                <input type="text" class="form-control timepicker-24" readonly="true" id="xia" runat="server">
                <span class="input-group-btn">
                    <button class="btn btn-default" type="button">
                        <i class="fa fa-clock-o"></i>
                    </button>
                </span>
            </div>
        </div>
    </div>
    <asp:Button Text="确定" CssClass="btn btn-block btn-default" runat="server" 
        onclick="Unnamed1_Click" />
    <!--pickers plugins-->
<script type="text/javascript" src="../../js/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
<script type="text/javascript" src="../../js/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js"></script>
<script type="text/javascript" src="../../js/bootstrap-daterangepicker/moment.min.js"></script>
<script type="text/javascript" src="../../js/bootstrap-daterangepicker/daterangepicker.js"></script>
<script type="text/javascript" src="../../js/bootstrap-colorpicker/js/bootstrap-colorpicker.js"></script>
<script type="text/javascript" src="../../js/bootstrap-timepicker/js/bootstrap-timepicker.js"></script>

<!--pickers initialization-->
<script src="../../js/pickers-init.js"></script>
</asp:Content>
