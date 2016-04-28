<%@ Page Title="main" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="main.aspx.cs" Inherits="OA.main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/clndr.css" rel="stylesheet">
    <!--C3 Chart-->
    <link href="js/c3-chart/c3.css" rel="stylesheet" />
    <div class="row">
        <div class="col-md-5">
            <div class="panel">
                <div class="panel-body">
                    <div class="calendar-block ">
                        <div class="cal1">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-5">
            <div class="panel">
                <div class="panel-heading">
                    <div class="row ">
                        <div class="col-md-9">
                            最新评论
                        </div>
                        <div class="col-md-3 more">
                            <span class="tools pull-right"><a href="javascript:;" class="fa fa-chevron-down"></a>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <ul class="chats cool-chat">
                        <%=getRemark() %>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-2">
            <iframe src="http://www.thinkpage.cn/weather/weather.aspx?uid=U5AAAADDA2&cid=CHBJ000000&l=&p=SMART&a=1&u=C&s=12&m=2&x=1&d=3&fc=&bgc=&bc=&ti=0&in=0&li=" frameborder="0" scrolling="no" width="200" height="300" allowTransparency="true"></iframe>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <section class="panel">
                <header class="panel-heading">
                            近七天上下班时间
                       
<span class="tools pull-right"><a href="javascript:;" class="fa fa-chevron-down"></a>
    <a href="javascript:;" class="fa fa-times"></a></span>
                        </header>
                <div class="panel-body">
                    <div class="chart">
                        <div id="chart">
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="panel">
                <div class=" panel-heading">
                    <div class="row ">
                        <div class="col-md-9">
                            公司日程
                        </div>
                        <div class="col-md-3 more">
                            <span class="tools pull-right"><a href="javascript:;" class="fa fa-chevron-down"></a>
                                <a href="admin/CalendarManage/HavingCalendar.aspx" class="fa  fa-ellipsis-h"></a>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive ">
                        <asp:DataList ID="DataList1" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                            <ItemTemplate>
                                <table class="table table-hover list_table">
                                    <tr>
                                        <td class="td_left">
                                            <a href="admin/CalendarManage/CalenderMessage.aspx?id=<%#Eval("CalendarID")%>">
                                                <%#Eval("Motif") %>
                                        </td>
                                        <td class="td_right">
                                            <a href="admin/CalendarManage/CalenderMessage.aspx?id=<%#Eval("CalendarID")%>">
                                                <%#Eval("AddTime") %></a>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel">
                <div class=" panel-heading">
                    <div class="row">
                        <div class="col-md-9">
                            我的邮件
                        </div>
                        <div class="col-md-3 more">
                            <span class="tools pull-right"><a href="javascript:;" class="fa fa-chevron-down"></a>
                                <a href="admin/Email/Email.aspx" class="fa  fa-ellipsis-h"></a></span>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:DataList ID="DataList2" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                            <ItemTemplate>
                                <table class="table table-hover list_table">
                                    <tr>
                                        <td class="td_left">
                                            <a href="admin/Email/EmailMessage.aspx?sid=<%#Eval("sid") %>">
                                                <%#Eval("Title")%></a>
                                        </td>
                                        <td class="td_right">
                                            <a href="admin/Email/EmailMessage.aspx?sid=<%#Eval("sid") %>">
                                                <%#Eval("Pubdate")%></a>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="panel">
                <div class=" panel-heading">
                    <div class="row ">
                        <div class="col-md-9">
                            公司新闻
                        </div>
                        <div class="col-md-3 more">
                            <span class="tools pull-right"><a href="javascript:;" class="fa fa-chevron-down"></a>
                                <a runat="server" href="~/admin/News/News.aspx" class="fa  fa-ellipsis-h"></a>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:DataList ID="DataList3" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                            <ItemTemplate>
                                <table class="table table-hover list_table">
                                    <tr>
                                        <td class="td_left">
                                            <a href="admin/News/NewsMessage.aspx?NewsID=<%#Eval("NewsID")%>">
                                                <%#Eval("title")%></a>
                                        </td>
                                        <td class="td_right">
                                            <a href="admin/News/NewsMessage.aspx?NewsID=<%#Eval("NewsID")%>">
                                                <%#Eval("pubdate")%></a>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel">
                <div class=" panel-heading">
                    <div class="row">
                        <div class="col-md-9">
                            我的计划
                        </div>
                        <div class="col-md-3 more">
                            <span class="tools pull-right"><a href="javascript:;" class="fa fa-chevron-down"></a>
                                <a runat="server" href="~/admin/Plan/Plan.aspx" class="fa  fa-ellipsis-h"></a>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:DataList ID="DataList4" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                            <ItemTemplate>
                                <table class="table table-hover list_table">
                                    <tr>
                                        <td class="td_left">
                                            <a href="admin/Plan/PlanMessage.aspx?planid=<%#Eval("planid")%>">
                                                <%#Eval("topic")%></a>
                                        </td>
                                        <td class="td_right">
                                            <a href="admin/Plan/PlanMessage.aspx?planid=<%#Eval("planid")%>">
                                                <%#Eval("addtime")%></a>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <!--collapse start-->
            <div class="panel-group " id="accordion" runat="server">
                <div class="panel">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-9">
                                <h4 class="panel-title">
                                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                                        Collapsible Group Item #1 </a>
                                </h4>
                            </div>
                            <div class="col-md-3 more">
                                <span class="tools pull-right"><a id="A1" runat="server" href="" class="fa  fa-ellipsis-h"
                                    target="_blank"></a></span>
                            </div>
                        </div>
                    </div>
                    <div id="collapseOne" class="panel-collapse collapse in">
                        <div class="panel-body">
                            <div class=" video item ">
                                <a href="#myModal" data-toggle="modal">
                                    <img src="images/gallery/image3.jpg" alt="" class="float-lt img-rounded img-thumbnail newimg" />
                                </a>
                            </div>
                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson
                            ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food
                            truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put
                            a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim
                            keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                            Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table,
                            raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus
                            labore sustainable VHS.
                        </div>
                    </div>
                </div>
            </div>
            <!--collapse end-->
        </div>
    </div>
    <script type="text/javascript" src="js/calendar/clndr.js"></script>
    <script type="text/javascript" src="js/calendar/evnt.calendar.init.js"></script>
    <script type="text/javascript" src="js/calendar/moment-2.2.1.js"></script>
    <script type="text/javascript" src="js/underscore-min.js"></script>
    <script type="text/javascript" src="http://d3js.org/d3.v3.min.js"></script>
    <script type="text/javascript" src="js/c3-chart/c3.js"></script>
    <script type="text/javascript">
    $(function () {
        var chart = c3.generate({

            bindto: '#chart',

            data: {
            columns: [
            ['上班时间', <%=gettime("上")%>],
            ['下班时间', <%=gettime("下")%>]
            ],
            types: {
            data1: 'line',
            data2: 'line'
            }
        },

        axis: {
            x: {
            type: 'categorized'
            }
        }

        });

});
    </script>
</asp:Content>
