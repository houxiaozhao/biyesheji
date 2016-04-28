<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Evection.aspx.cs" Inherits="OA.admin.Check.Evection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                    <div class="btn-group" role="group">
                        <asp:Button ID="goout" CssClass="btn btn-default" runat="server" Text="出差登记" OnClick="goout_Click" />
                    </div>
                    <div class="btn-group" role="group">
                        <asp:Button ID="comeback" CssClass="btn btn-default" runat="server" Text="回来登记" OnClick="comeback_Click" />
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
                            出差备注</h3>
                    </div>
                    <div class="text-center">
                        <h3 class="h3 txt">地点</h3><asp:TextBox ID="add" runat="server"  placeholder="输入地点"></asp:TextBox>
                    </div>
                    <textarea runat="server" class="textarea width_100 height100" id="TextArea1" cols="20"
                        name="S1"></textarea>
                </span>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:DataList ID="dt1" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                    <HeaderTemplate>
                        <table class="table table-hover list_table">
                            <tr>
                                <td class="width_20">
                                    地点
                                </td>
                                <td class="width_20">
                                    出差时间
                                </td>
                                <td class="width_20">
                                    回来时间
                                </td>
                                <td class="width_40">
                                    出差备注
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table class="table table-hover list_table" data-toggle="modal" data-target="#myModal">
                            <tr>
                                <td class="width_20">
                                    <a>
                                        <%#Eval("address")%></a>
                                </td>
                                <td class="width_20">
                                    <a>
                                        <%#Eval("outtime")%></a>
                                </td>
                                <td class="width_20">
                                    <a>
                                        <%#Eval("rtime")%></a>
                                </td>
                                <td class="width_40">
                                    <a>
                                        <%#Eval("content")%></a>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function loadProvince(regionId) {
            $("#id_provSelect").html("");
            $("#id_provSelect").append("<option value=''>请选择省份</option>");
            var jsonStr = getAddress(regionId, 0);
            for (var k in jsonStr) {
                $("#id_provSelect").append("<option value='" + k + "'>" + jsonStr[k] + "</option>");
            }
            if (regionId.length != 6) {
                $("#id_citySelect").html("");
                $("#id_citySelect").append("<option value=''>请选择城市</option>");
            } else {
                $("#id_provSelect").val(regionId.substring(0, 2) + "0000");
                loadCity(regionId);
            }
        }

        function loadCity(regionId) {
            $("#id_citySelect").html("");
            $("#id_citySelect").append("<option value=''>请选择城市</option>");
            if (regionId.length == 6) {
                var jsonStr = getAddress(regionId, 1);
                for (var k in jsonStr) {
                    $("#id_citySelect").append("<option value='" + k + "'>" + jsonStr[k] + "</option>");
                }
                var str = regionId.substring(0, 2); //四个直辖市
                if (str == "11" || str == "12" || str == "31" || str == "50") {
                    $("#id_citySelect").val(regionId);
                } else {
                    $("#id_citySelect").val(regionId.substring(0, 4) + "00");
                }
            }
        }
        
    </script>
    <script type="text/javascript">
        loadProvince('110101');
    </script>
</asp:Content>
