var dataTable;

$(document).ready(function () {
    // Initialize DataTable with enhanced configuration
    dataTable = $('#tblDataUser').DataTable({
        responsive: true,
        processing: true, // Show processing indicator
        pageLength: 10,   // Default number of rows per page

        // Ajax configuration
        "ajax": {
            url: "/Admin/UserManagement/GetAll",
            type: "GET",
            dataType: "json",
            error: function (xhr, error, thrown) {
                toastr.error('Error loading data. Please try again.');
                console.error('Error:', error);
            }
        },

        // Column definitions
        "columns": [
            { "data": "email", "width": "15%" },
            { "data": "name", "width": "15%" },
            { "data": "address", "width": "15%" },
            {
                "data": "grade",
                "width": "10%",
                "render": function (data) {
                    return data ? data.toFixed(2) : '-';
                }
            },
            { "data": "nationality", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="btn-group" role="group">
                            <a href="/admin/usermanagement/upsert/${data}" 
                               class="btn btn-primary btn-sm" 
                               data-bs-toggle="tooltip" 
                               title="Edit User">
                                <i class="bi bi-pencil-square"></i>
                            </a>
                            <button onClick="Delete('/admin/usermanagement/delete/${data}')" 
                                    class="btn btn-danger btn-sm"
                                    data-bs-toggle="tooltip" 
                                    title="Delete User">
                                <i class="bi bi-trash-fill"></i>
                            </button>
                        </div>`;
                },
                "width": "10%"
            },
        ],

        // Initialize with custom classes and features
        "dom": '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6"f>>' +
            '<"row"<"col-sm-12"tr>>' +
            '<"row"<"col-sm-12 col-md-5"i><"col-sm-12 col-md-7"p>>',

        // Custom styling classes
        "classes": {
            "sTable": "table table-hover table-bordered",
            "sPageButton": "paginate_button page-item",
            "sPageButtonActive": "active"
        }
    });

    // Initialize tooltips
    initializeTooltips();

    // Handle filter application
    $('#applyFilters').on('click', function () {
        applyFilters();
    });

    // Handle filter clearing
    $('#clearFilters').on('click', function () {
        clearFilters();
    });
});

// Initialize Bootstrap tooltips
function initializeTooltips() {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
}

// Apply filters function
function applyFilters() {
    var filters = {
        email: $('.filter-input[data-column="email"]').val(),
        name: $('.filter-input[data-column="name"]').val(),
        nationality: $('.filter-input[data-column="nationality"]').val(),
        gradeMin: $('#gradeMin').val(),
        gradeMax: $('#gradeMax').val()
    };

    // Custom filtering function
    $.fn.dataTable.ext.search.push(function (settings, data, dataIndex) {
        var valid = true;

        // Text filters
        if (filters.email && !data[0].toLowerCase().includes(filters.email.toLowerCase())) valid = false;
        if (filters.name && !data[1].toLowerCase().includes(filters.name.toLowerCase())) valid = false;
        if (filters.nationality && !data[4].toLowerCase().includes(filters.nationality.toLowerCase())) valid = false;

        // Grade range filter
        var grade = parseFloat(data[3]) || 0;
        if (filters.gradeMin && grade < parseFloat(filters.gradeMin)) valid = false;
        if (filters.gradeMax && grade > parseFloat(filters.gradeMax)) valid = false;

        return valid;
    });

    dataTable.draw();
}

// Clear filters function
function clearFilters() {
    // Clear all input fields
    $('.filter-input').val('');
    $('#gradeMin, #gradeMax').val('');

    // Remove custom filtering function
    $.fn.dataTable.ext.search.pop();
    dataTable.draw();
}

// Delete function with improved UX
function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "This action cannot be undone.",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#dc3545",
        cancelButtonColor: "#6c757d",
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "Cancel"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function () {
                    toastr.error('An error occurred while deleting the user.');
                }
            });
        }
    });
}