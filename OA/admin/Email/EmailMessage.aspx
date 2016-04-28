<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="EmailMessage.aspx.cs" Inherits="OA.admin.Email.EmailMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mail-box">
        <aside class="mail-nav mail-nav-bg-color">
            <header class="header">
                <h4>
                    我的邮件<small id="sma" runat="server"></small></h4>
            </header>
            <div class="mail-nav-body">
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
        <section class="mail-box-info">
            <header class="header">
                <div class="btn-toolbar">
                    <div class="btn-group select">
                        <h4 id="title" runat="server" class="pull-left">
                        </h4>
                    </div>
                </div>
            </header>
            <section class="mail-list">
                <div class="mail-sender">
                    <div class="row">
                        <div class="col-md-8">
                            发件人:<strong id="sendname" runat="server"></strong> 收件人:<strong id="meetname" runat="server"></strong>
                        </div>
                        <div class="col-md-4">
                            <p class="date" id="pubdate" runat="server">
                            </p>
                        </div>
                    </div>
                </div>
                <div class="view-mail">
                    <p class="lead" id="Contents" runat="server"></p>
                </div>
                <div class="attachment-mail">
                    <p class="h5" id="appurtenance" runat="server">
                    </p>
                </div>
                <div class="compose-btn pull-left">
                    <a href="mail_compose.html" class="btn btn-sm btn-primary"><i class="fa fa-reply"></i>
                        回复</a>
                    <button class="btn  btn-sm btn-default tooltips" data-original-title="Print" type="button"
                        data-toggle="tooltip" data-placement="top" title="">
                        <i class="fa fa-print"></i>
                    </button>
                    <button class="btn btn-sm btn-default tooltips" data-original-title="Trash" data-toggle="tooltip"
                        data-placement="top" title="">
                        <i class="fa fa-trash-o"></i>
                    </button>
                </div>
            </section>
        </section>
    </div>
</asp:Content>
