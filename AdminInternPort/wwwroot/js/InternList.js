var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#Program_load').DataTable({
        "ajax": {
            "url": "/api/interns",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            { "data": "fullName", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "major", "width": "15%" },
            { "data": "university", "width": "15%" },
            { "data": "graduationDate", "width": "15%" },
            {"data": "title", "width":"15%"},
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        &nbsp;
                        <a  class="btn btn-danger text-white" style="cursor:pointer; width:70px;"
                                onclick=Delete('/api/interns?id='+${data})>
                                    
                            Delete
                        </a>
                        </div>
                    `
                }, "width": "10%"
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