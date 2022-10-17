var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#Program_load').DataTable({
        "ajax": {
            "url": "/api/programs",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            { "data": "title", "width": "20%" },
           { "data": "startDate", "width": "20%" },
            { "data": "endDate", "width": "20%" },
            { "data": "maxCapacity", "width": "20%" },
            {"data": "description"},
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Programs/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:70px;" >
                            View
                        </a>
                        &nbsp;
                        <a  class="btn btn-danger text-white" style="cursor:pointer; width:70px;"
                                onclick=Delete('/api/programs?id='+${data})>
                                    
                            Delete
                        </a>
                        </div>
                    `
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "no data found",
        }, "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    }
    );
}