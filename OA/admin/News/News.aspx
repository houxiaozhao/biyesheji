<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="News.aspx.cs" Inherits="OA.admin.News.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" col-md-pull-12 panel panel-default">
        <div class="panel-heading">
            <h1 class="h1">
                公司新闻
            </h1>
        </div>
        <div class="panel-body">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="106px">
            </asp:DropDownList>
        </div>
        <div class="table-responsive">
            <asp:DataList ID="dt1" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                <HeaderTemplate>
                    <table class="table table-hover list_table">
                        <tr>
                            <td class="td_left width_50">
                                <h4 class="h4">
                                    标题</h4>
                            </td>
                            <td class="td_center">
                                <h4 class="h4 txt-lt">
                                    类型</h4>
                            </td>
                            <td class="td_right">
                                <h4 class="h4">
                                    时间</h4>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table class="table table-hover list_table" data-title="<%#Eval("title")%>----<%#Eval("type")%>"
                        data-whatever="<%#Eval("content")%>" data-toggle="modal" data-target="#myModal">
                        <tr>
                            <td class="td_left width_50">
                                <a>
                                    <%#Eval("title")%></a>
                            </td>
                            <td class="td_center">
                                <a>
                                    <%#Eval("type")%></a>
                            </td>
                            <td class="td_right">
                                <a>
                                    <%#Eval("pubdate")%></a> <a href="<%= Request.ApplicationPath %>/UserWork/NewsMessage.aspx?NewsID=<%#Eval("NewsID")%>"
                                        class="btn btn-default">查看详细</a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
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
