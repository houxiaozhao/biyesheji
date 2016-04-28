<%@ Page Title="公司日程" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="HavingCalendar.aspx.cs" ClientIDMode="Static" Inherits="OA.admin.CalendarManage.HavingCalendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-datepicker/css/datepicker-custom.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-timepicker/css/timepicker.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-colorpicker/css/colorpicker.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-daterangepicker/daterangepicker-bs3.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-datetimepicker/css/datetimepicker-custom.css" />
    <div class=" container-fluid">
        <div class="row">
            <div class=" panel">
                <div class="panel-heading">
                    <h1 class="h1 txt">
                        我的日程</h1>
                    <asp:Button ID="btnadd" Text="添加日程" CssClass="btn btn-default" runat="server" 
                        onclick="btnadd_Click" />
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:DataList ID="dt1" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                            <HeaderTemplate>
                                <table class="table table-hover list_table">
                                    <tr>
                                        <td class="td_left">
                                            <h4 class="h4">
                                                主题</h4>
                                        </td>
                                        <td class=" td_right">
                                            <h4 class="h4 text-left width128">
                                                时间</h4>
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table class="table table-hover list_table">
                                    <tr>
                                        <td class="td_left" data-title="<%#Eval("Motif")%>" data-whatever="<%#Eval("content")%>"
                                            data-toggle="modal" data-target="#myModal">
                                            <a>
                                                <%#Eval("Motif")%></a>
                                        </td>
                                        <td class="td_right">
                                            <a class="width210">
                                                <%#Eval("addtime")%></a>
                                            <asp:Button ID="Button1" runat="server" Text="删除" CommandName="btndel" CssClass="btn btn-default"
                                                OnCommand="Button1_Command" CommandArgument='<%#Eval("CalendarID")%>' data-toggle="tooltip"
                                                data-placement="left" title="删除后不可恢复！！！" />
                                            <a href="CalenderMessage.aspx?id=<%#Eval("CalendarID")%>" class="btn btn-default">查看详细</a>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" runat ="server" id="divadd">
            <div class="col-md-12">
                <div class="panel-heading">
                    <h1 class="h1 txt">
                        添加日程</h1>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">
                        时间</label>
                    
                        <asp:TextBox ID="addtime" name="addtime" runat="server" CssClass="form-control form_datetime width_50" ReadOnly="" size="16" />
  
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">
                        概要</label>
                    <asp:TextBox ID="Motif" runat="server" placeholder="输入概要" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">
                        内容</label>
                    <asp:TextBox ID="textcontent" runat="server" TextMode="MultiLine" CssClass="form-control textarea"></asp:TextBox>
                </div>
                <asp:Button ID="btnsave" CssClass="btn-default btn" runat="server" Text="保存" OnClick="btnsave_Click" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $('#myModal').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget);
            var recipient = button.data('whatever');
            var title = button.data('title');
            var modal = $(this);
            modal.find('.modal-title').text(title);
            modal.find('.content').text(recipient);
        })
        $(function () {
            $('[data-toggle="tooltip"]').tooltip();
        })
    </script>
    <script type="text/javascript" src="../../js/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-timepicker/js/bootstrap-timepicker.js"></script>
    <script type="text/javascript" src="../../js/pickers-init.js"></script>
</asp:Content>
