<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="suggest.aspx.cs" Inherits="OA.admin.suggest" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
       
    <div class="container-fluid">
        
        <div class="row-fluid">
            <div class="col-md-12 marbtm">
                <div>
                    
                    投诉建议</div>
                
                <textarea placeholder="输入建议" id="textcontent" runat="server" class="form-control textarea"></textarea>
                <div>
                    <asp:Button ID="btnpub" Text="发表" CssClass="float-rt btn btn-default" runat="server"
                        OnClick="btnpub_Click" />
                    <asp:TextBox runat="server" CssClass="float-rt" Text="" ID="txtname"/>
                </div>
            </div>
        </div>
        
        <div class="row-fluid">
            <div class="col-md-12">
                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                 
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="panel">
                                <div class="panel-heading">
                                    <h4 class="panel-title h4">
                                        <a>
                                            <%#Eval("name") %>
                                        </a><a class="float-rt">
                                            <%#Eval("time") %></a>
                                    </h4>
                                </div>
                                <div class="panel-body">
                                    <%#Eval("contents") %>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </div>
                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
                runat="server" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                PageSize="10" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never"
                OnPageChanged="AspNetPager1_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table">
            </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
