function Delete(url) {
    Swal.fire({
        title: "You won't be able to revert this!",
        text: "Warning",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = url;
            /*$.ajax({
                url: url,
                type: 'DELETE',
                success: function(data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            });*/
        }
    });
}
