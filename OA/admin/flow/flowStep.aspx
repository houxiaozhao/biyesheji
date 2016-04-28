<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Inherits="OA.admin.flow.Flow_flowStep" Codebehind="flowStep.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="h1">
                        流程步骤管理</h1>
                </div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped"
                    OnRowDeleting="GridView1_RowDeleting" AutoGenerateSelectButton="True" DataKeyNames="ID"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Num" HeaderText="序号" />
                        <asp:TemplateField HeaderText="名称">
                            <ItemTemplate>
                                <asp:Label ID="lblAction" runat="server"><%# getAction(DataBinder.Eval(Container.DataItem,"ActionID").ToString())%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="相关人员">
                            <ItemTemplate>
                                <asp:Label ID="lblPerson" runat="server"><%# getPerson(DataBinder.Eval(Container.DataItem, "ID").ToString())%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否会签">
                            <ItemTemplate>
                                <asp:Label ID="lblJoin" runat="server"><%# DataBinder.Eval(Container.DataItem,"IsJoin").ToString().Equals("1")?"是":"否" %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否结束">
                            <ItemTemplate>
                                <asp:Label ID="lblEnd" runat="server"><%# DataBinder.Eval(Container.DataItem,"IsEnd").ToString().Equals("1")?"是":"否" %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="绑定">
                            <ItemTemplate>
                            
                                
                                <a href="StepBind.aspx?stepid=<%# DataBinder.Eval(Container.DataItem,"ID") %>&flowid=<%# DataBinder.Eval(Container.DataItem,"FlowID") %>">
                                    绑定</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                <div class="col-md-12">
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-default btn-block" Text="新建步骤"
                        OnClick="Button2_Click" />
                </div>
                <div class="panel-body" id="panel" runat="server">
                    <div class="row martop">
                        <div class="col-md-2">
                            步骤名称</div>
                        <div class="col-md-10">
                            <asp:DropDownList ID="drpAction" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row martop">
                        <div class="col-md-2">
                            排列序号</div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtNum" runat="server" style="ime-mode:disabled" onkeypress="if (event.keyCode<48 || event.keyCode>57) event.returnValue=false;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row martop">
                        <div class="col-md-2">
                            是否会签</div>
                        <div class="col-md-10">
                            <asp:DropDownList ID="drpJoin" runat="server">
                                <asp:ListItem Value="0">否</asp:ListItem>
                                <asp:ListItem Value="1">是</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row martop">
                        <div class="col-md-2">
                            是否结束</div>
                        <div class="col-md-10">
                            <asp:DropDownList ID="drpEnd" runat="server">
                                <asp:ListItem Value="0">否</asp:ListItem>
                                <asp:ListItem Value="1">是</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row martop">
                        <div class="col-md-2">
                            步骤说明</div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtDes" runat="server" CssClass="textarea width_100 height100" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row martop">
                        <div class="col-md-12">
                            <asp:Button ID="Button1" CssClass="btn btn-default btn-block" runat="server" Text="保存"
                                OnClick="Button1_Click" />
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="Button3" CssClass="btn btn-default btn-block" runat="server" Text="修改"
                                OnClick="Button3_Click" />
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>
