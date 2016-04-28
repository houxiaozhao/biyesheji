<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GoOutRegist.aspx.cs" Inherits="OA.admin.Check.GoOutRegist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                    <div class="btn-group" role="group">
                        <asp:Button ID="goout" CssClass="btn btn-default" runat="server" Text="外出登记" onclick="goout_Click"  
                            />
                    </div>
                    <div class="btn-group" role="group">
                        <asp:Button ID="comeback" CssClass="btn btn-default" runat="server" Text="回来登记" onclick="comeback_Click" 
                           
                             />
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
                        外出登记备注</h3>
                </div>
                <textarea runat="server" class="textarea width_100 height100" id="TextArea1" cols="20" name="S1"></textarea>
                </span>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:DataList ID="dt1" runat="server" Width="100%" CellSpacing="0" CssClass="table-striped">
                    <HeaderTemplate>
                    <table class="table table-hover list_table" >
                                <tr>
                                    <td class="width_17">
                                           日期
                                                
                                    </td>
                                    <td class="width_20">
                                           外出时间
                                                
                                    </td>
                                    <td class="width_20">
                                        
                                        回来时间
                                    </td>
                                    
                                    <td class=" width_40">
                                           外出备注
                                                
                                    </td>
                                    
                                </tr>
                            </table>
                    </HeaderTemplate>
                        <ItemTemplate>
                            <table class="table table-hover list_table" data-toggle="modal" data-target="#myModal">
                                <tr>
                                    <td class="width_17">
                                           <a><%#Eval("datetime")%></a>
                                                
                                    </td>
                                    <td class="width_20">
                                           <a><%#Eval("Outtime")%></a> 
                                                
                                    </td>
                                    <td class="width_20">
                                        
                                        <a><%#Eval("returnTime")%></a> 
                                    </td>
                                    
                                    <td class=" width_40">
                                           <a><%#Eval("Why")%></a>
                                                
                                    </td>
                                    
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                
            </div>
        </div>
    </div>
</asp:Content>
