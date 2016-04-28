<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Email.aspx.cs" Inherits="OA.admin.Email.Email" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-datepicker/css/datepicker-custom.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-timepicker/css/timepicker.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-colorpicker/css/colorpicker.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-daterangepicker/daterangepicker-bs3.css" />
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-datetimepicker/css/datetimepicker-custom.css" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mail-box">
        <aside class="mail-nav mail-nav-bg-color">
            <header class="header">
                <h4>
                    我的邮件<small id="sma" runat="server"></small></h4>
            </header>
            <div class="mail-nav-body">
                <h5>
                    根据时间搜索</h5>
                <div class="input-group input-large custom-date-range" data-date="13/07/2013" data-date-format="mm/dd/yyyy">
                    <asp:TextBox ID="calendar1" CssClass="form-control dpd1" name="from" runat="server"></asp:TextBox>
                    <span class="input-group-addon">To</span>
                    <asp:TextBox ID="calendar2" CssClass="form-control dpd2 " name="to" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" Text="查询" OnClick="Button3_Click" />
                <ul class="nav nav-pills nav-stacked labels-info ">
                    <li>
                        <h5>
                            通讯录</h5>
                    </li>
                    <li><a href="#"><i class="fa fa-comments text-success"></i>员工通讯录</a></li>
                    <li><a href="#"><i class="fa fa-comments text-danger"></i>我的联系人</a></li>
                </ul>
                <ul class="nav nav-pills nav-stacked labels-info ">
                    <li>
                        <h5>
                            最近联系</h5>
                    </li>
                    <li><a href="#"><i class="fa fa-comments text-success"></i>于国民</a></li>
                    <li><a href="#"><i class="fa fa-comments text-danger"></i>admin</a></li>
                </ul>
            </div>
            <footer class="text-center">
                <h4>
                    呵呵复呵呵</h4>
            </footer>
        </aside>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <section class="mail-box-info">
                    <header class="header">
                        <div class="btn-toolbar">
                            <div class="btn-group select">
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AutoPostBack="True"
                                    Width="106px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    <asp:ListItem Text="收件箱" />
                                    <asp:ListItem Text="发件箱" />
                                    <asp:ListItem Text="草稿箱" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </header>
                    <section class="mail-list">
                        <ul class="nav nav-pills nav-stacked mail-navigation">
                            <li>
                                <div class="table-responsive">
                                    <asp:DataList ID="DataList2" runat="server" Width="100%" CellSpacing="0" CssClass="table table-hover table-striped">
                                        <ItemTemplate>
                                            <table>
                                                <tr onclick='window.location.href="EmailMessage.aspx?sid=<%#Eval("Sid")%>"; ' class="width_100">
                                                    <td>
                                                        <a class=" width105">
                                                            <%#Eval("sendname")%></a> <a class="width430">
                                                                <%#Eval("Title")%></a> <a>
                                                                    <%#Eval("type")%></a> <a class="pull-right text-muted">
                                                                        <%#Eval("pubdate")%></a>
                                                        <asp:Button ID="Button1" runat="server" Text="删除" CommandName="btndel" CssClass="btn btn-default td_right"
                                                            OnCommand="Button1_Command" CommandArgument='<%#Eval("Sid")%>' data-toggle="tooltip"
                                                            data-placement="left" title="删除后不可恢复！！！" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <asp:DataList ID="DataList1" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                                        <ItemTemplate>
                                            <table class="table table-hover">
                                                <tr onclick='window.location.href="Draft.aspx?DraftId=<%#Eval("DraftId")%>" '>
                                                    <td>
                                                        <a class="width105 ">
                                                            <%#Eval("Title")%></a> <a>
                                                                <%#Eval("type")%></a> <a>
                                                                    <%#Eval("addDate")%></a>
                                                        <asp:Button ID="Button2" runat="server" Text="删除" CommandName="btndel" CssClass="btn btn-default"
                                                            OnCommand="Button1_Command" CommandArgument='<%#Eval("DraftId")%>' data-toggle="tooltip"
                                                            data-placement="left" title="删除后不可恢复！！！" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </li>
                        </ul>
                    </section>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        function tdclick() {
            $('#myModal').on('show.bs.modal', function (event) {
                var button = $(event.relatedTarget);
                var recipient = button.data('whatever');
                var title = button.data('title');
                var smail = button.data('smail')
                var sid = button.data('sid');
                //PageMethods.tb_ServerClick1(sid);
                $.post("Email.aspx", { sid: sid });
                var a = '<%=tb_ServerClick1(Request["sid"]) %>';
                //$('[data-sid=sid]:last').text("已查看");
            })
        }

    </script>
    <script type="text/javascript" src="../../js/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-timepicker/js/bootstrap-timepicker.js"></script>
    <script type="text/javascript" src="../../js/pickers-init.js"></script>
</asp:Content>
