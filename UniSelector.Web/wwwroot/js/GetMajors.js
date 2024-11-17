$(document).ready(function () {
    $('#facultySelect').change(function () {
        let facultyId = $(this).val();
        if (facultyId) {
            get(facultyId);
        }
    });
    let init = $('#facultySelect').val();
    if (init) { 
        get(init);
    } else 
    function get(facultyId) {
        $.ajax({
            url: `/Admin/Major/GetStandardMajors/facultyId?facultyId=${facultyId}`,
            type: 'GET',
            success: function(data) {
                let standardMajorSelect = $('#standardMajorSelect');
                standardMajorSelect.empty();
                standardMajorSelect.append('<option value="" disabled selected>--Select Standard Major--</option>');
                $.each(data, function (index, item) {
                    standardMajorSelect.append($('<option></option>')
                        .val(item.id)
                        .text(item.combinedName));
                });
            },
            error: function () {
                alert('Failed to fetch customer details.');
            }
        });
    }
});
