<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="SendEmail.aspx.cs" Inherits="OA.admin.Email.SendEmail"  ClientIDMode="Static" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="../../js/bootstrap-wysihtml5/bootstrap-wysihtml5.css" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                    <li><a href="../AddressManage/EmploueeAddress.aspx"><i class="fa fa-comments text-success"></i>员工通讯录</a></li>
                    <li><a href="../AddressManage/ContactsList.aspx"><i class="fa fa-comments text-danger"></i>我的联系人</a></li>
                </ul>
                <ul class="nav nav-pills nav-stacked labels-info " id="zuijin" runat="server">
                <%=getzuijin() %>
                </ul>
            </div>
            <footer class="text-center">
                <h4>
                    呵呵复呵呵</h4>
            </footer>
        </aside>
        <section class="mail-box-info">
            <header class="header">
                <div class="compose-btn pull-right">
                    <button class="btn btn-primary btn-sm">
                        <i class="fa fa-check"></i>Send</button>
                    <button class="btn btn-sm btn-default">
                        <i class="fa fa-times"></i>Discard</button>
                    <button class="btn btn-sm btn-default">
                        Draft</button>
                </div>
                <div class="btn-toolbar">
                    <h4 class="pull-left">
                        Compose Mail
                    </h4>
                </div>
            </header>
            <section class="mail-list">
                <div class="compose-mail">
                    <div class="form-group">
                        <label for="to" class="">
                            To:</label>
                    <asp:TextBox ID="txtOtherMan" tabindex="1" runat="server" onclick="javascript:otherman();" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="subject" class="">
                            Subject:</label>
                        <input name="txTitle" type="text" tabindex="1" id="txTitle" class="form-control" runat="server">
                    </div>
                    <div class="form-group">
                        <label for="type" class="">
                            Type:</label>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>一般</asp:ListItem>
                            <asp:ListItem>紧急</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="compose-editor">
                        <textarea class="wysihtml5 form-control" rows="9" name="textarea"></textarea>
                        <input name="FileUpload1" type="file" id="FileUpload1" runat="server" />&nbsp;
                    </div>
                    <input type="submit" name="bnUpload" value="上  传" id="bnUpload" runat="server" 
                            onserverclick="bnUpload_ServerClick" style="width: 70px; float: none;"  />
                        <asp:Label ID="Label1" Text="" runat="server" />
                    <div class="row">
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                
                
                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Appurtenanceid" AutoGenerateColumns="False"
                        CaptionAlign="Left" CellPadding="0" GridLines="None" ShowHeader="False" 
                        onrowdeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="AppurtenanceName" HeaderText="文件名" />
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                            <asp:BoundField DataField="Appurtenanceid" HeaderText="Appurtenanceid" Visible="False" />
                        </Columns>
                    </asp:GridView>
                
                </asp:Panel>
            </div>
                    <hr />
                    
                        <asp:Button ID="Button1" runat="server" Text="Send" Width="70px" CssClass="btn btn-primary btn-sm" onclick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Draft" Width="70px" CssClass="btn btn-primary btn-sm "  />
                    
                </div>
            </section>
        </section>
    </div>
    <script type="text/javascript" src="../../js/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            $('.wysihtml5').wysihtml5();
        });
    </script>
    <script type="text/javascript">
        function otherman() {
            window.open("PersonnelSelection.aspx", null, "height=350,width=1000,directories = no,status=no,toolbar=no,menubar=no,location=no,titlebar = no,scrollbars = no");
        }

    </script>
</asp:Content>
