<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CalenderMessage.aspx.cs" Inherits="OA.admin.CalendarManage.CalenderMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p id="CalendarID" class="CalendarID" runat="server" hidden="hidden">
                        </p>
    <div class="container">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2 h3">
                    主题
                </div>
                <div class="col-md-10 h3">
                    <div>
                        <p id="title" class="title" runat="server">
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
                        <p id="time" class="time" runat="server">
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

                        <p id="content" class="conten" runat="server">
                        </p>
                    </div>
                </div>
            </div>
            
            <div class="row">
            <div class="col-lg-12" runat="server" id ="div">
             
            </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
          
        
    </script>
</asp:Content>
