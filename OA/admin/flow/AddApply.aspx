<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Inherits="OA.admin.flow.Flow_AddApply" Codebehind="AddApply.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading">
            <div class="asd" id="asd" runat="server">
                </div>
            <div id="warning" runat="server" class="alert alert-warning alert-dismissible float-rt" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <strong>Warning!</strong> 重新选择流程类型
                </div>
                <h1 class="h1">
                    起草新申请</h1>
            </div>
            <div class="panel-body">
                <div class="row martop">
                    <div class="col-md-2">
                        流程选择</div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="drpFltype" runat="server" OnSelectedIndexChanged="drpFltype_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:DropDownList ID="drpFlow" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row martop">
                    <div class="col-md-2">
                        紧急程度</div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="drpUrgent" runat="server">
                            <asp:ListItem>一般</asp:ListItem>
                            <asp:ListItem>紧急</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row martop">
                    <div class="col-md-2">
                        主题</div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row martop">
                    <div class="col-md-2">
                        附件</div>
                    <div class="col-md-10">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                </div>
                <div class="row martop">
                    <div class="col-md-2">
                        内容</div>
                    <div class="col-md-10">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="textarea width_100 height100"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="row martop">
                    <div class=" col-md-12 btn-group btn-group-justified" role="group" aria-label="...">
                        <div class="btn-group" role="group">
                            <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="保存" OnClick="Button1_Click" />
                        </div>
                        <div class="btn-group" role="group">
                            <asp:Button ID="Button2" CssClass="btn btn-default" runat="server" Text="发送" OnClick="Button2_Click" />
                        </div>
                        <div class="btn-group" role="group">
                            <asp:Button ID="Button3" CssClass="btn btn-default" runat="server" Text="重置" OnClick="Button3_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
