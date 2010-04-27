<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<OpenTimeline.Core.ViewModel.EventForm.EventViewModel>>" %>
<script language="javascript" type="text/javascript">
    $(function () {
        $("#timelineEvents form[action$='/DeleteEvent']").submit(function () {
            var itemText = $("input[name='item']", this).val();
            return confirm("Are you sure you want to delete '" + itemText + "'?");

        });
    });
    $(function () {
        $("form[action$='DeleteEvent']").submit(function () {
            $.post($(this).attr("action"), $(this).serialize(), function (response) {
                $("#timelineEvents").html(response);
            });
            return false;
        });
    });
</script>
<div id="timelineEvents">
    <ul>
        <% foreach (var @event in Model)
           {%>
        <li>
            <%= @event.Name %>
            <% using (Html.BeginForm("DeleteEvent", "Event"))
               { %>
                <%= Html.Hidden("id", @event.Id) %>
                <%= Html.Hidden("item", @event.Name) %>
                <input type="submit" value="Delete" />
            <% } %>
        </li>
        <%} %>
    </ul>
</div>
