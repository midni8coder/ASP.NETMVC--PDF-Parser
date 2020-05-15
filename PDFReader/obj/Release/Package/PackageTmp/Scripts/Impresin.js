

jQuery("form").submit(function (e) {
    e.preventDefault();
    var formData = new FormData(this);

    jQuery.ajax({
        url: 'https://localhost:44328/home/FileUploaderAjax',
        type: 'POST',
        data: formData,
        success: function (data) {
            console.log(data)
            jQuery('[name="total"]').val(data.Total);
            jQuery('[name="color"]').val(data.Colored);
            jQuery('[name="BW"]').val(data.BlackAndWhite);
        },
        cache: false,
        contentType: false,
        processData: false
    });
});

function SubmitAJAX() {
    jQuery("form").submit();
}

jQuery('[name="tmcp_upload_12"]').on('change', function (e) {
    SubmitAJAX();
})