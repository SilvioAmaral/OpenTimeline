<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<OpenTimeline.Core.ViewModel.MemberTimelineViewModel>" %>

<%@ Import Namespace="OpenTimeline.Core.ViewModel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    MyTimeline
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% using(Html.BeginForm("mytimeline","account", FormMethod.Get)) { %>
  <%= Html.Hidden("accountId", "1") %>
  <%= Html.DropDownList("timelineId", Model.Timelines) %>
  <%--<%= Html.DropDownList("timelineId", Model.Timelines, new { onchange = "this.form.submit();"}) %>--%>
<% } %>
    <h2>
        <%= Model.TimelineName %></h2>
    <% foreach (var eventViewModel in Model.Events)
       { %>
       <span><%= eventViewModel.EventName %> | <%= eventViewModel.Date %></span><br />
    <% } %>

    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#timelineId").change(function () {
                var element = $(this);
                window.location = '<%= Url.Content(@"~/account/mytimeline/") %>' + element.val() + '/1';
            });
        });
</script>
</asp:Content>

