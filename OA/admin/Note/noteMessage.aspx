<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="noteMessage.aspx.cs" Inherits="OA.admin.Note.noteMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p id="NotepaperID" class="NotepaperID" runat="server" hidden="hidden"></p>
    <div class="container">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2 h3">
                    主题
                </div>
                <div class="col-md-10 h3">
                    <div>
                        <p id="title" class="title" runat="server" >
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

                        <p id="message" class="message" runat="server">
                        </p>
                    </div>
                </div>
            </div>
            
           <%-- <div class="row">
            <div class="col-lg-12" runat="server" id ="div">
                <button ID="Button" class="btn btn-default btn-lg float-rt" 
                    runat="server" data-toggle="tooltip" data-placement="left" 
                    title="可在网页上直接修改，点击确定修改" onclick="sad()">确定</button>
            </div>
            </div>--%>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
        function sad() {
            var title = $('.title').text();
            var addtime = $('.addtime').text();
            var message = $('.message').text();
            var NotepaperID = $('.NotepaperID').text();
            $.post("noteMessage.aspx?id=" + NotepaperID,
            {
                NotepaperID: NotepaperID,
                title: title,
                addtime: addtime,
                message: message
            },
            function (result) {
                console.log(result)
            });
            var a = '<%=qwe(Request["NotepaperID"],Request["title"],Request["addtime"],Request["message"]) %>';
        }
        
    </script>
</asp:Content>
