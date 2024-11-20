/*
var dataTable;

$(document).ready(function () {
    loadDataTable();
    initializeFilters();
});

function loadDataTable() {
    dataTable = $('#tblUniversity').DataTable({
        responsive: true,
        processing: true,
        serverSide: false,
        pageLength: 10,

        ajax: {
            url: '/Admin/University/GetAll',
            type: 'GET',
            dataType: 'json',
            error: function (xhr, error, thrown) {
                toastr.error('Error loading data. Please try again.');
                console.error('Error:', error);
            }
        },

        columns: [
            { data: 'name', width: '20%' },
            { data: 'type', width: '15%' },
            { data: 'location', width: '20%' },
            {
                data: 'kuwaitRank',
                width: '15%',
                render: function (data) {
                    return `${data}${getOrdinalSuffix(data)}`;
                }
            },
            {
                data: 'budget',
                width: '15%',
                render: function (data) {
                    return new Intl.NumberFormat('en-US', {
                        style: 'currency',
                        currency: 'KWD'
                    }).format(data);
                }
            },
            {
                data: 'id',
                width: '15%',
                orderable: false,
                render: function (data) {
                    return `
                        <div class="btn-group" role="group">
                            <a href="/Admin/Faculty/Index/${data}" 
                               class="btn btn-primary btn-sm" 
                               data-bs-toggle="tooltip" 
                               title="Manage Faculties">
                                <i class="bi bi-building"></i>
                            </a>
                            <a href="/Admin/University/Upsert/${data}" 
                               class="btn btn-warning btn-sm"
                               data-bs-toggle="tooltip" 
                               title="Edit University">
                                <i class="bi bi-pencil-square"></i>
                            </a>
                            <button onClick="deleteUniversity(${data})" 
                                    class="btn btn-danger btn-sm"
                                    data-bs-toggle="tooltip" 
                                    title="Delete University">
                                <i class="bi bi-trash"></i>
                            </button>
                        </div>`;
                }
            }
        ],

        order: [[3, 'asc']], // Sort by Kuwait Rank by default

        // Initialize with custom classes
        dom: '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6"f>>' +
            '<"row"<"col-sm-12"tr>>' +
            '<"row"<"col-sm-12 col-md-5"i><"col-sm-12 col-md-7"p>>',
    });

    // Initialize tooltips
    initializeTooltips();
}

function initializeFilters() {
    // Apply filters button click
    $('#applyFilters').on('click', function () {
        applyFilters();
    });

    // Clear filters button click
    $('#clearFilters').on('click', function () {
        clearFilters();
    });

    // Entries per page change
    $('#entriesPerPage').on('change', function () {
        dataTable.page.len($(this).val()).draw();
    });
}

function applyFilters() {
    $.fn.dataTable.ext.search.push(function (settings, data, dataIndex) {
        var valid = true;

        // Text filters
        var name = $('.filter-input[data-column="name"]').val().toLowerCase();
        var type = $('.filter-input[data-column="type"]').val().toLowerCase();
        var location = $('.filter-input[data-column="location"]').val().toLowerCase();

        // Range filters
        var rankMin = parseInt($('#rankMin').val()) || 0;
        var rankMax = parseInt($('#rankMax').val()) || 100;
        var budgetMin = parseFloat($('#budgetMin').val()) || 0;
        var budgetMax = parseFloat($('#budgetMax').val()) || Infinity;

        // Apply text filters
        if (name && !data[0].toLowerCase().includes(name)) valid = false;
        if (type && type !== 'all' && !data[1].toLowerCase().includes(type)) valid = false;
        if (location && !data[2].toLowerCase().includes(location)) valid = false;

        // Apply range filters
        var rank = parseInt(data[3]) || 0;
        var budget = parseFloat(data[4].replace(/[^0-9.-]+/g, "")) || 0;

        if (rank < rankMin || rank > rankMax) valid = false;
        if (budget < budgetMin || budget > budgetMax) valid = false;

        return valid;
    });

    dataTable.draw();
    toastr.success('Filters applied successfully');
}

function clearFilters() {
    // Clear all input fields
    $('.filter-input').val('');
    $('#rankMin, #rankMax, #budgetMin, #budgetMax').val('');

    // Remove custom filtering function
    $.fn.dataTable.ext.search.pop();
    dataTable.search('').draw();

    toastr.info('Filters cleared');
}

function deleteUniversity(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "This will delete the university and all associated faculties. This action cannot be undone!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#dc3545',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `/Admin/University/Delete/${id}`,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success('University deleted successfully');
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function () {
                    toastr.error('An error occurred while deleting the university');
                }
            });
        }
    });
}

function initializeTooltips() {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
}

function getOrdinalSuffix(number) {
    const j = number % 10;
    const k = number % 100;
    if (j == 1 && k != 11) return "st";
    if (j == 2 && k != 12) return "nd";
    if (j == 3 && k != 13) return "rd";
    return "th";
}*/
