<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MeetingMessage.aspx.cs" Inherits="OA.admin.Meeting.MeetingMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
        <div class="row">
            <div class="col-md-3">
                <h3 class="h3">
                    主题</h3>
            </div>
            <div class="col-md-9">
                <h3 class="h3"><%=Titles%></h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <h3 class="h3">
                    会议室</h3>
            </div>
            <div class="col-md-9">
                <h3 class="h3"><%=BoardroomName%></h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <h3 class="h3">
                    级别</h3>
            </div>
            <div class="col-md-9">
                <h3 class="h3"><%=Types%></h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <h3 class="h3">
                    费用预算</h3>
            </div>
            <div class="col-md-9">
                <h3 class="h3"><%=Expenditure%></h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <h3 class="h3">
                    开始时间</h3>
            </div>
            <div class="col-md-9">
                <h3 class="h3"><%=StartTime%></h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <h3 class="h3">
                    结束时间</h3>
            </div>
            <div class="col-md-9">
                <h3 class="h3"><%=FinishTime%></h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <h3 class="h3">
                    会议内容</h3>
            </div>
            <div class="col-md-9">
                <h3 class="h3"><%=MeetingContent%></h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <h3 class="h3">
                    发布时间</h3>
            </div>
            <div class="col-md-9">
               <h3 class="h3"> <%=addTime%></h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <h3 class="h3">
                    发布人</h3>
            </div>
            <div class="col-md-9">
                <h3 class="h3"><%=UserName%></h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                
            </div>
            <div class="col-md-9">
                <a href="MyMeetingList.aspx" class="btn btn-default">返回</a>
                </div>
        </div>
    </div>
</asp:Content>
