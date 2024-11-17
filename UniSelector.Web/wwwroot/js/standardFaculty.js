var dataTable;

$(document).ready(function () {
    loadDataTable();
    initializeFilters();
});

function loadDataTable() {
    dataTable = $('#tblStandardFaculty').DataTable({
        responsive: true,
        processing: true,
        serverSide: false,
        pageLength: 10,

        ajax: {
            url: '/Admin/StandardFaculty/GetAll',
            type: 'GET',
            dataType: 'json',
            error: function (xhr, error, thrown) {
                toastr.error('Error loading data. Please try again.');
                console.error('Error:', error);
            }
        },

        columns: [
            { data: 'arabicName', width: '35%' },
            { data: 'englishName', width: '35%' },
            {
                data: 'id',
                width: '30%',
                orderable: false,
                render: function (data) {
                    return `
                        <div class="btn-group" role="group">
                            <a href="/Admin/StandardFaculty/Upsert/${data}" 
                               class="btn btn-primary btn-sm"
                               data-bs-toggle="tooltip" 
                               title="Edit Faculty">
                                <i class="bi bi-pencil-square"></i>
                            </a>
                            <button onClick="deleteFaculty(${data})" 
                                    class="btn btn-danger btn-sm"
                                    data-bs-toggle="tooltip" 
                                    title="Delete Faculty">
                                <i class="bi bi-trash"></i>
                            </button>
                        </div>`;
                }
            }
        ],

        order: [[1, 'asc']], // Sort by English name by default
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

        var arabicName = $('.filter-input[data-column="arabicName"]').val().toLowerCase();
        var englishName = $('.filter-input[data-column="englishName"]').val().toLowerCase();

        if (arabicName && !data[0].toLowerCase().includes(arabicName)) valid = false;
        if (englishName && !data[1].toLowerCase().includes(englishName)) valid = false;

        return valid;
    });

    dataTable.draw();
    toastr.success('Filters applied successfully');
}

function clearFilters() {
    $('.filter-input').val('');
    $.fn.dataTable.ext.search.pop();
    dataTable.search('').draw();
    toastr.info('Filters cleared');
}

function deleteFaculty(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "This will delete the faculty. This action cannot be undone!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#dc3545',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `/Admin/StandardFaculty/Delete/${id}`;
        }
    });
}

function initializeTooltips() {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
}