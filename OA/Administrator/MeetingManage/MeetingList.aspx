<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" Inherits="meetingManage_MeetingList" Codebehind="MeetingList.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/bootstrap-datetimepicker.zh-CN.js"></script>
    <script type="text/javascript" src="../js/bootstrap-datetimepicker.js"></script>

    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span12 panel panel-default">
             <div class="panel-heading">
				<h1 class="h1">
					会议列表
				</h1>
			</div>
            <div class="panel-body">
            从<asp:TextBox ID="calendar1" CssClass="calendar form_datetime form-control" placeholder="输入起始日期" runat="server"></asp:TextBox>
            到<asp:TextBox ID="calendar2" CssClass="calendar form_datetime form-control" placeholder="输入结束日期" runat="server"></asp:TextBox>

                <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" 
                    Text="Button" onclick="Button3_Click" />
                    </div>
               <div class="table-responsive">
                    <asp:DataList ID="dtlst" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                    <HeaderTemplate>
                    <table class="table table-hover list_table">
                                <tr>
                                    <td class="">
                                        <h4 class="h4 width160">主题</h4>
                                        <h4 class="h4 width105">级别</h4>
                                        <h4 class="h4 width105">时间</h4>
                                    </td>
                                    
                                </tr>
                            </table>
                    </HeaderTemplate>
                        <ItemTemplate>
                            <table class="table table-hover list_table">
                                <tr>
                                    <td class="td_left" data-title="<%#Eval("title")%>" data-whatever="<%#Eval("meetingcontent")%>"
                                        data-toggle="modal" data-target="#myModal">
                                        <a>
                                            <%#Eval("title")%></a> <a>
                                                <%#Eval("type")%></a>
                                                <a><%#Eval("starttime")%></a>
                                    </td>
                                    <td class="td_right width160">
                                        <asp:Button ID="Button1" runat="server" Text="删除"  CssClass="btn btn-default"
                                            OnCommand="Button1_Command" CommandArgument='<%#Eval("MeetingID")%>' CommandName='<%#Eval("addtime")%>' data-toggle="tooltip"
                                            data-placement="left" title="删除后不可恢复！！！" />
                                       <a href="MeetingInfo.aspx?MeetingID=<%#Eval("MeetingID")%>" class="btn btn-default">查看详细</a>

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
        $(".form_datetime").datetimepicker({ format: 'yyyy-mm-dd hh:ii' });
    </script> 
</asp:Content>

