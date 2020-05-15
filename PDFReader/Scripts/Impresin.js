jQuery("form.cart").submit(function (e) {
    debugger
    jQuery('#process_img').show();
    e.preventDefault();
    var formData = new FormData(this);

    jQuery.ajax({
        url: 'https://midni8coder.somee.com/home/FileUploaderAjax',
        type: 'POST',
        data: formData,
        success: function (data) {
            jQuery('#process_img').hide();
            console.log(data)
            jQuery('[name="tmcp_textfield_2"]').val(data.Total).trigger("change");;
            jQuery('[name="tmcp_textfield_7"]').val(data.Colored).trigger("change");;
            jQuery('[name="tmcp_textfield_3"]').val(data.Colored).trigger("change");;
            jQuery('[name="tmcp_textfield_8"]').val(data.BlackAndWhite).trigger("change");;
        }, error: function (xhr, status, error) {
            jQuery('#process_img').hide();
            var acc = []
            jQuery.each(xhr, function (index, value) {
                acc.push(index + ': ' + value);
            });
            //    alert(JSON.stringify(acc));
            console.log(acc);
        },
        cache: false,
        contentType: false,
        processData: false
    });
});

function SubmitAJAX() {
    jQuery("form.cart").submit();
}

jQuery('[name="tmcp_upload_12"]').on('change', function (e) {
    SubmitAJAX();
})