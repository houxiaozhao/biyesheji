<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyGroup.aspx.cs" Inherits="OA.admin.AddressManage.MyGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
        <div class="row-fluid">
            <div class="span12 panel panel-default">
                <div class="panel-heading"><h1 class="h1">我的分组</h1>
                </div>
                <div class="table-responsive">
                    <asp:DataList ID="dt1" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                    <HeaderTemplate>
                    <table class="table table-hover list_table">
                                <tr>
                                    <td class="td_left" >
                                          <h4 class="h4">分组名称</h4>
                                              
                                    </td>
                                    
                                    <td class=" td_right">
                                        <h4 class="h4  width128">删除</h4>
                                    </td>
                                </tr>
                            </table>
                    </HeaderTemplate>
                        <ItemTemplate>
                            <table class="table table-hover list_table">
                                <tr>
                                    <td class="td_left">
                                           
                                                <a><%#Eval("Type")%></a>
                                               
                                    </td>
                                    <td class="td_right width380">
                                   
                                        <asp:Button ID="Button1" runat="server" Text="删除" CommandName="btndel" CssClass="btn btn-default"
                                            OnCommand="Button1_Command" CommandArgument='<%#Eval("groupingid")%>' data-toggle="tooltip"
                                            data-placement="left" title="删除后不可恢复！！！" />

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
        $(function () {
            $('[data-toggle="tooltip"]').tooltip();
        })
    </script>
</asp:Content>
