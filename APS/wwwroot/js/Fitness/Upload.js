$(document).ready(function () {
    $("#tabstrip").kendoTabStrip({
        animation: { open: { effects: "fadeIn" } }
    });
});

var Upload = {
    OnComplete: function() {
        $("#pivotgrid").data("kendoPivotGrid").dataSource.read();
        $("#Grid").data("kendoGrid").dataSource.read();
    },
    ClearData: function () {
        var url = $('#urlClearData').data('url');
        $.ajax({
            url: url,
            //data: { },
            type: "POST",
            //dataType: 'json',
            success: function (result) {
                notification("Santé", "Données effacées", "info");
                Upload.OnComplete();
                kendo.ui.progress($("body"), false);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                notification("Santé", xhr.status + " " + thrownError, "error");
            }
        });
    }
};
