

$("form").submit(function (e) {
    e.preventDefault();
    var formData = new FormData(this);

    $.ajax({
        url: 'https://localhost:44328/home/FileUploaderAjax',
        type: 'POST',
        data: formData,
        success: function (data) {
            console.log(data)
            $('[name="total"]').val(data.Total);
            $('[name="color"]').val(data.Colored);
            $('[name="BW"]').val(data.BlackAndWhite);
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