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
        fixedColumns: true,        
        lengthMenu: [[10, 25, 50, 100, 500, 1000, -1], [10, 25, 50, 100, 500, 1000, "All"]],
        pageLength: 50
    });

    // Filter event handler
    $(table.table().container()).on('keyup', 'tfoot input', function () {
        table
            .column($(this).data('index'))
            .search(this.value)
            .draw();
    });
});