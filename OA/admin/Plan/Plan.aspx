<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Plan.aspx.cs" Inherits="OA.admin.Plan.Plan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-datepicker/css/datepicker-custom.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-timepicker/css/timepicker.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-colorpicker/css/colorpicker.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-daterangepicker/daterangepicker-bs3.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-datetimepicker/css/datetimepicker-custom.css" />

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container-fluid">
        <div class="row-fluid">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
               
            <div class="span12 panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        我的计划
                    </h1>
                </div>
                <div class="panel-body">
                    <div class="input-group input-large custom-date-range" data-date="13/07/2013" data-date-format="mm/dd/yyyy">
                        <asp:TextBox ID="calendar1" CssClass="form-control dpd1" name="from" runat="server"></asp:TextBox>
                        <span class="input-group-addon">To</span>
                        <asp:TextBox ID="calendar2" CssClass="form-control dpd2 " name="to" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" Text="查询"
                        OnClick="Button3_Click" />
                </div>
                <div class="table-responsive">
                    <asp:DataList ID="dtlst" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                        <HeaderTemplate>
                            <table class="table table-hover list_table">
                                <tr>
                                    <td class="td_left">
                                        <h4 class="h4 width160">
                                            时间</h4>
                                        <h4 class="h4 width105">
                                            概要</h4>
                                    </td>
                                    <td class="td_right">
                                        <h4 class="h4 td_center">
                                            操作</h4>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table class="table table-hover list_table">
                                <tr>
                                    <td class="td_left" data-title="<%#Eval("topic")%>" data-whatever="<%#Eval("content")%>"
                                        data-toggle="modal" data-target="#myModal">
                                        <a>
                                            <%#Eval("addtime")%></a>&nbsp;&nbsp;&nbsp;&nbsp;<a>
                                                <%#Eval("topic")%></a>
                                        
                                    </td>
                                    <td class="td_right">
                                        <asp:Button ID="Button1" runat="server" Text="删除" CommandName="btndel" CssClass="btn btn-default"
                                            OnCommand="Button1_Command" CommandArgument='<%#Eval("PlanID")%>' data-toggle="tooltip"
                                            data-placement="left" title="删除后不可恢复！！！" />
                                        <a href="PlanMessage.aspx?planid=<%#Eval("planid")%>" class="btn btn-default">
                                            查看详细</a>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
             </ContentTemplate>
            </asp:UpdatePanel>
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
