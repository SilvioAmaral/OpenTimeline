<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<OpenTimeline.Core.ViewModel.EventForm>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script language="javascript" type="text/javascript">
    $(function () {
        $("form[action$='create']").submit(function () {
            $.post($(this).attr("action"), $(this).serialize(), function (response) {
                $("#timelineEvents").html(response);
            });
            return false;
        });
    });
</script>
    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                Timelines
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.TimelineId, Model.Timelines) %>
            </div>

            <div class="editor-label">
                <%= Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Description) %>
                <%= Html.ValidationMessageFor(model => model.Description) %>
            </div>
                       
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>
    <% Html.RenderPartial("EventList", Model.Events); %>
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

