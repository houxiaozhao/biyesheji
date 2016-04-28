<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonnelSelection.aspx.cs"
    Inherits="OA.admin.Email.PersonnelSelection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../../css/bootstrap.min.css" rel="stylesheet">
    <link href="../../css/default.css" rel="stylesheet" type="text/css" />
    <</head>
<body>
    <script type="text/javascript" src="../../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input id="hide" type="hidden" value="<%=pass()%>">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="col-md-12">
                <asp:DropDownList ID="DropDownList1" CssClass="form-control width_39" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row-fluid">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-md-5">
                        <asp:ListBox ID="ListBox1" runat="server" CssClass="width_100"></asp:ListBox>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="col-md-2">
                <ul class="text-center">
                    <li>
                        <button id="addbtn" type="button" class="btn btn-default" runat="server" onserverclick="addbtn_onserverclick">
                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        </button>
                    </li>
                    <li>
                        <button id="delbtn" type="button" class="btn btn-default" runat="server" onserverclick="delbtn_onserverclick">
                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        </button>
                    </li>
                </ul>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-md-5">
                        <asp:ListBox ID="ListBox2" runat="server" CssClass="width_100"></asp:ListBox>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row-fluid">
            <div class="col-md-12">
                <button id="ok" type="button" class="btn btn-default float-rt" onclick="javascript:Ok();">
                    确定</button>
                <button type="button" class="btn btn-default float-rt" onclick="Cancel()">
                    取消</button>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        function Ok() {


            window.close();
            opener.document.all.txtOtherMan.value = self.document.getElementById("hide").value;

        }
        function Cancel() {
            window.close();
        }
    </script>
</body>
</html>
