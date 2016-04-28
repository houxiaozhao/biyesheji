<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="PlanMessage.aspx.cs" Inherits="OA.admin.Plan.PlanMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--gritter css-->
  <link rel="stylesheet" type="text/css" href="../../js/gritter/css/jquery.gritter.css" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>      
    <section>
    <p id="planID" class="planID" runat="server" hidden="hidden">
    </p>   
    <div class="row">
        <div class="col-md-2 h3">
            主题
        </div>
        <div class="col-md-10 h3">
            <div>
                <p id="topic" class="topic" runat="server" >
                </p>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2 h3">
            时间
        </div>
        <div class="col-md-10 h3">
            <div>
                <p id="addtime" class="addtime" runat="server" >
                </p>
            </div>
        </div>
    </div>
    <hr />
    <div class="row bg-info">
        <div class="col-md-2 h3">
            内容
        </div>
        <div class="col-md-10 h3">
            <div>
                <p id="content" class="content" runat="server" >
                </p>
            </div>
        </div>
    </div>
    </section>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
        
    <%--<div class="row">
        <div class="col-lg-12" runat="server" id="div">
            <button id="Button" class="btn btn-default btn-lg float-rt" runat="server" data-toggle="tooltip"
                data-placement="left" title="hhehe" onclick="sad()">
                确定</button>
        </div>
    </div>--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    <!--gritter script-->
<script type="text/javascript" src="../../js/gritter/js/jquery.gritter.js"></script>
<script src="../../js/gritter/js/gritter-init.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
        function sad() {
            var topic = $('.topic').text();
            var addtime = $('.addtime').text();
            var content = $('.content').text();
            var planID = $('.planID').text();
            $.post("PlanMessage.aspx?id=" + planID,
            {
                planID: planID,
                topic: topic,
                addtime: addtime,
                content: content
            },
            function (result) {
                console.log(result)
            });
            var a = '<%=qwe(Request["planID"],Request["topic"],Request["addtime"],Request["content"]) %>';
            //haha('提示', a);
        }
        function haha(txttitle,txttext) {
            $.gritter.add({
                // (string | mandatory) the heading of the notification
                title: txttitle,
                // (string | mandatory) the text inside the notification
                text: txttext,
                class_name: 'gritter-light'
            });
        }
    </script>
</asp:Content>
