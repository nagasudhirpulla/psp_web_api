$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#checkResultsDiv tfoot th').each(function (i) {
        var title = $('#checkResultsDiv thead th').eq($(this).index()).text();
        $(this).html('<input placeholder="Search ' + title + '" data-index="' + i + '" type="text" />');
    });

    // DataTable
    var table = $('#checkResultsDiv').DataTable({
        scrollY: "1000px",
        scrollX: true,
        scrollCollapse: true,
        fixedColumns: true
    });

    // Filter event handler
    $(table.table().container()).on('keyup', 'tfoot input', function () {
        table
            .column($(this).data('index'))
            .search(this.value)
            .draw();
    });
});