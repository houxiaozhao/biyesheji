<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    Inherits="OA.admin.flow.Flow_ArchivesRead" CodeBehind="ArchivesRead.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h1 class="h1">
                            公文批阅</h1>
                    </div>
                    <div class="panel-body">
                        <div class="row martop">
                            <div class="col-md-6">
                                <dl class="dl-horizontal">
                                    <dt>主题</dt>
                                    <dd>
                                        <asp:Label ID="lblTitle" runat="server"></asp:Label></dd>
                                </dl>
                            </div>
                            <div class="col-md-6">
                                <dl class="dl-horizontal">
                                    <dt>流程</dt>
                                    <dd>
                                        <asp:Label ID="lblFlow" runat="server"></asp:Label></dd>
                                </dl>
                            </div>
                        </div>
                        <div class="row martop">
                            <div class="col-md-6">
                                <dl class="dl-horizontal">
                                    <dt>申请人</dt>
                                    <dd>
                                        <asp:Label ID="lblUser" runat="server"></asp:Label></dd>
                                </dl>
                            </div>
                            <div class="col-md-6">
                                <dl class="dl-horizontal">
                                    <dt>日期</dt>
                                    <dd>
                                        <asp:Label ID="lblPubDate" runat="server"></asp:Label></dd>
                                </dl>
                            </div>
                        </div>
                        <div class="row martop">
                            <div class="col-md-6">
                                <dl class="dl-horizontal">
                                    <dt>紧急程度</dt>
                                    <dd>
                                        <asp:Label ID="lblUrgent" runat="server"></asp:Label></dd>
                                </dl>
                            </div>
                            <div class="col-md-6">
                                <dl class="dl-horizontal">
                                    <dt>附件</dt>
                                    <dd>
                                        <asp:Label ID="lblAr" runat="server"></asp:Label></dd>
                                </dl>
                            </div>
                        </div>
                        <hr />
                        <div class="row martop">
                            <div class="col-md-2">
                                公文流程
                            </div>
                            <div class="col-md-10">
                                <asp:Label ID="lblStep" runat="server"></asp:Label>&nbsp; <a href="History.aspx?id=<%=id %>">
                                    【历史审批意见】</a>
                            </div>
                        </div>
                        <div class="row martop">
                            <div class="col-md-2">
                                审批意见
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txComment" runat="server" CssClass="textarea width_100 height100"
                                    TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row martop">
                            <div class="col-md-2">
                                附件
                            </div>
                            <div class="col-md-10">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                        </div>
                        <div class="row martop">
                            <div class="col-md-2">
                                内容
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtcontent" runat="server" CssClass="textarea width_100 height100"
                                    TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row martop">
                            <div class="col-md-6">
                                <asp:Button ID="btnRefer" CssClass="btn btn-block btn-default" runat="server" Text="提交"
                                    OnClick="btnRefer_Click" />
                            </div>
                            <div class="col-md-6">
                                <a href="MyApprove.aspx" class="btn btn-block btn-default">返回</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
