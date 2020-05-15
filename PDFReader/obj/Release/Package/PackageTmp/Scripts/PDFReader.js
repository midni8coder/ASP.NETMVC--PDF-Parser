

$("form").submit(function (e) {
    $('#process_img').show();
    e.preventDefault();
    var formData = new FormData(this);
    
    $.ajax({
        url: 'https://localhost:44328/home/FileUploaderAjax',
        type: 'POST',
        data: formData,
        success: function (data) {
            $('#process_img').hide();
            console.log(data)
            $('[name="total"]').val(data.Total);
            $('[name="color"]').val(data.Colored);
            $('[name="BW"]').val(data.BlackAndWhite);
        }, error: function (xhr, status, error) {
            $('#process_img').hide();
            var acc = []
            $.each(xhr, function (index, value) {
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
    $("form").submit();
}

$('[name="PDFFileName"]').on('change', function (e) {
    SubmitAJAX();
})