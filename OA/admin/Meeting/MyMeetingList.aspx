<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="MyMeetingList.aspx.cs" Inherits="OA.admin.Meeting.MyMeetingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span12 panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        会议列表
                    </h1>
                </div>
                <div class="panel-body">
                    <div class="input-group input-large custom-date-range" data-date="13/07/2013" data-date-format="mm/dd/yyyy">
                        <asp:TextBox ID="calendar1" CssClass="form-control dpd1" name="from" runat="server"></asp:TextBox>
                        <span class="input-group-addon">To</span>
                        <asp:TextBox ID="calendar2" CssClass="form-control dpd2 " name="to" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" Text="Button"
                        OnClick="Button3_Click" />
                </div>
                <div class="table-responsive">
                    <asp:DataList ID="dtlst" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                        <HeaderTemplate>
                            <table class="table table-hover list_table">
                                <tr>
                                    <td class="td_left">
                                        <h4 class="h4 width_50 inline">
                                            主题</h4>
                                        <h4 class="h4 width_30">
                                            级别</h4>
                                        <h4 class="h4 width_17">
                                            时间</h4>
                                    </td>
                                    <td class="td_right">
                                        <h4 >
                                            详细信息</h4>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table class="table table-hover list_table">
                                <tr>
                                    <td class="td_left" data-title="<%#Eval("title")%>" data-whatever="<%#Eval("meetingcontent")%>"
                                        data-toggle="modal" data-target="#myModal">
                                        <a class="width_50 inline">
                                            <%#Eval("title")%></a> <a class="width_30">
                                                <%#Eval("type")%></a> <a class="width_17">
                                                    <%#Eval("starttime")%></a>
                                    </td>
                                    <td class="td_right">
                                        <a href="MeetingMessage.aspx?MeetingID=<%#Eval("MeetingID")%>" class="btn btn-default">
                                            查看详细</a>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
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
</asp:Content>
