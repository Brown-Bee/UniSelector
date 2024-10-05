var dataTable;
$(document).ready(function () { 
    dataTable = $('#tblDataU').DataTable({
        responsive: true,
        columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 }
        ],
        "ajax": {
            url: "/" + "@Constants.AreaAdmin" + "/" + "@Constants.ControllerUniversity" + "/GetAll",
            type: "GET",
            dataType: "json",
            error: function (xhr, error, thrown) {
                console.log('Error:', error);
            }
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "type", "width": "10%" },
            { "data": "description", "width": "15%" },
            { "data": "location", "width": "10%" },
            { "data": "kuwaitRank", "width": "10%" },
            { "data": "budget", "width": "10%" },
            { "data": "imageUrl", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="btn-group" role="group">
                            <a href="/admin/university/upsert?id=${data}" class="btn btn-primary btn-sm">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a onClick=Delete('/admin/university/delete/${data}') class="btn btn-danger btn-sm">
                                <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>`;
                },
                "width": "25%"
            },
        ]
    });
    
});

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.masssage);
                }
            })
        }
    });
}
