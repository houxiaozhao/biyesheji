<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="NewsMessage.aspx.cs" Inherits="OA.admin.News.NewsMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row-fluid">
        <div class="col-md-12">
            <div class="panel">
                <div class="panel-body">
                    <div class="profile-desk">
                        <h1 id="title" runat="server" class="h1">
                        </h1>
                        <span class="designation" id="pudate" runat="server"></span>
                        <a class="float-rt" id="name" runat="server">发布：</a>
                        <p class="lead" id="content" runat="server">
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row-fluid">
                <div class="col-md-12 marbtm">
                    <div>
                        发表评论</div>
                    <textarea placeholder="输入你的评论" id="textcontent" runat="server" class="form-control textarea"></textarea>
                    <div>
                        <asp:Button ID="btnpub" Text="发表" CssClass="float-rt btn btn-default" runat="server"
                            OnClick="btnpub_Click" />
                    </div>
                </div>
            </div>
            <div class="row-fluid">
                <div class="col-md-12">
                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="panel">
                            <div class="panel-heading">
                                评论 <span class="tools pull-right"><a class="fa fa-chevron-down" href="javascript:;">
                                </a><a class="fa fa-times" href="javascript:;"></a></span>
                            </div>
                            <div class="panel-body">
                                <ul class="activity-list">
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <div class="activity-desk">
                                                    <h5>
                                                        <a href="#">
                                                            <%#Eval("name") %></a>
                                                    说：
                                                    <p>
                                                        <%#Eval("content") %></p>
                                                    <p class="text-muted">
                                                        <%#Eval("pubdate") %></p>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
