// wwwroot/js/standardMajor.js
var dataTable;

$(document).ready(function () {
    loadDataTable();
    initializeFilters();
});

function loadDataTable() {
    dataTable = $('#tblStandardMajor').DataTable({
        responsive: true,
        processing: true,
        serverSide: false,
        pageLength: 10,

        ajax: {
            url: '/Admin/StandardMajor/GetAll',
            type: 'GET',
            dataType: 'json',
            error: function (xhr, error, thrown) {
                toastr.error('Error loading data. Please try again.');
                console.error('Error:', error);
            }
        },

        columns: [
            { data: 'name', width: '30%' },
            { data: 'facultyName', width: '25%' },
            {
                data: 'studyDuration',
                width: '15%',
                render: function (data) {
                    return `${data} ${data === 1 ? 'year' : 'years'}`;
                }
            },
            {
                data: 'highSchoolPath',
                width: '15%',
                render: function (data) {
                    return `<span class="badge bg-${data === 'Scientific' ? 'primary' : 'info'}">${data}</span>`;
                }
            },
            {
                data: 'id',
                width: '15%',
                orderable: false,
                render: function (data) {
                    return `
                        <div class="btn-group" role="group">
                            <a href="/Admin/StandardMajor/Upsert/${data}" 
                               class="btn btn-primary btn-sm"
                               data-bs-toggle="tooltip" 
                               title="Edit Major">
                                <i class="bi bi-pencil-square"></i>
                            </a>
                            <button onClick="deleteMajor(${data})" 
                                    class="btn btn-danger btn-sm"
                                    data-bs-toggle="tooltip" 
                                    title="Delete Major">
                                <i class="bi bi-trash"></i>
                            </button>
                        </div>`;
                }
            }
        ],

        order: [[0, 'asc']], // Sort by name by default
    });

    initializeTooltips();
}

function initializeFilters() {
    $('#applyFilters').on('click', function () {
        applyFilters();
    });

    $('#clearFilters').on('click', function () {
        clearFilters();
    });

    $('#entriesPerPage').on('change', function () {
        dataTable.page.len($(this).val()).draw();
    });
}

function applyFilters() {
    $.fn.dataTable.ext.search.push(function (settings, data, dataIndex) {
        var valid = true;

        // Text filters
        var name = $('.filter-input[data-column="name"]').val().toLowerCase();
        var faculty = $('.filter-input[data-column="faculty"]').val().toLowerCase();
        var highSchoolPath = $('.filter-input[data-column="highSchoolPath"]').val();

        // Duration range
        var durationMin = parseInt($('#durationMin').val()) || 1;
        var durationMax = parseInt($('#durationMax').val()) || 7;

        // Apply filters
        if (name && !data[0].toLowerCase().includes(name)) valid = false;
        if (faculty && !data[1].toLowerCase().includes(faculty)) valid = false;

        var duration = parseInt(data[2]) || 0;
        if (duration < durationMin || duration > durationMax) valid = false;

        if (highSchoolPath && !data[3].includes(highSchoolPath)) valid = false;

        return valid;
    });

    dataTable.draw();
    toastr.success('Filters applied successfully');
}

function clearFilters() {
    $('.filter-input').val('');
    $('#durationMin, #durationMax').val('');
    $.fn.dataTable.ext.search.pop();
    dataTable.search('').draw();
    toastr.info('Filters cleared');
}

function deleteMajor(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "This will delete the major. This action cannot be undone!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#dc3545',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `/Admin/StandardMajor/Delete/${id}`;
        }
    });
}

function initializeTooltips() {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
}