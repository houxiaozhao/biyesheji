<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmploueeAddress.aspx.cs" Inherits="OA.admin.AddressManage.EmploueeAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
        <div class="row-fluid">
            <div class="span12 panel panel-default">
                <div class="panel-heading"><h1 class="h1">员工通讯录</h1>
                </div>
                <asp:DropDownList ID="DropDownList1" runat="server" >
                </asp:DropDownList>
                <asp:TextBox ID="TextBox1" runat="server" placeholder="输入姓名"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" />
                <div class="table-responsive">
                    <asp:DataList ID="dt1" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                    <HeaderTemplate>
                    <table class="table table-hover list_table">
                                <tr>
                                    <td class="width_30" >
                                          <h4 class="h4">姓名</h4>
                                              
                                    </td>
                                    <td class="width_30" >
                                          <h4 class="h4">身份</h4>
                                              
                                    </td>
                                    <td class=" width_30">
                                        <h4 class="h4 text-left width128">电话</h4>
                                    </td>
                                </tr>
                            </table>
                    </HeaderTemplate>
                        <ItemTemplate>
                            <table class="table table-hover list_table">
                                <tr>
                                    <td class="td_left" data-title="<%#Eval("name")%>" data-whatever="<%#Eval("workphone")%>"
                                        data-toggle="modal" data-target="#myModal">
                                           
                                                <a class="width_30"><%#Eval("name")%></a>
                                                <a class="width_30"><%#Eval("branch") %></a>
                                   
                                        <a class="width_30"><%#Eval("workphone")%></a> 
                                        

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
