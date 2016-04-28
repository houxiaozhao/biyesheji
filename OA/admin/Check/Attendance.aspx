<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Attendance.aspx.cs" Inherits="OA.admin.Check.Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                <div class="btn-group" role="group">
                    <asp:Button ID="towork" CssClass="btn btn-default" runat="server" Text="上班登记" OnClick="towork_Click" />
                </div>
                <div class="btn-group" role="group">
                    <asp:Button ID="offwork" CssClass="btn btn-default" runat="server" Text="下班登记" OnClick="offwork_Click" />
                </div>
            </div>
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <span id="span1" runat="server">
                <div>
                    <h3 class="h3 text-center">
                        上班登记备注</h3>
                </div>
                <textarea runat="server" class="textarea width_100 height100" id="TextArea1" cols="20"
                    name="S1"></textarea>
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                    <div class="btn-group" role="group">
                        <asp:Button ID="ok" CssClass="btn btn-default" runat="server" Text="确定" OnClick="ok_Click" />
                    </div>
                    <div class="btn-group" role="group">
                        <asp:Button ID="cancel" CssClass="btn btn-default" runat="server" Text="取消" OnClick="cancel_Click" />
                    </div>
                </div>
            </span><span id="span2" runat="server">
                <div>
                    <h3 class="h3 text-center">
                        下班登记备注</h3>
                </div>
                <textarea class="textarea width_100 height100" runat="server" id="TextArea2" cols="20"
                    name="S1"></textarea>
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                    <div class="btn-group" role="group">
                        <asp:Button ID="ok1" CssClass="btn btn-default" runat="server" Text="确定" OnClick="ok1_Click" />
                    </div>
                    <div class="btn-group" role="group">
                        <asp:Button ID="cancel1" CssClass="btn btn-default" runat="server" Text="取消" OnClick="cancel1_Click" />
                    </div>
                </div>
            </span>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:DataList ID="dt1" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                <HeaderTemplate>
                    <table class="table table-hover list_table">
                        <tr>
                            <td class="width_13">
                                日期
                            </td>
                            <td class="width_17">
                                上班时间
                            </td>
                            <td class="width_17">
                                下班时间
                            </td>
                            <td class="width_7 ">
                                迟到
                            </td>
                            <td class="width_7 ">
                                早退
                            </td>
                            <td class="width_20">
                                上班备注
                            </td>
                            <td class="width_17 ">
                                下班备注
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table class="table table-hover list_table" data-toggle="modal" data-target="#myModal">
                        <tr>
                            <td class="width_13">
                                <a>
                                    <%#Eval("CheckDate")%></a>
                            </td>
                            <td class="width_17">
                                <a>
                                    <%#Eval("Ontutytime")%></a>
                            </td>
                            <td class="width_17">
                                <a>
                                    <%#Eval("OffdutyTime")%></a>
                            </td>
                            <td class="width_7 ">
                                <a>
                                    <%#Eval("OntutyState")%></a>
                            </td>
                            <td class="width_7 ">
                                <a>
                                    <%#Eval("OffDutyState")%></a>
                            </td>
                            <td class=" width_20">
                                <a>
                                    <%#Eval("OntutyWhys")%></a>
                            </td>
                            <td class="width_17 ">
                                <a>
                                    <%#Eval("OffWhys")%></a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
