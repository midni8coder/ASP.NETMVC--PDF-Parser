

$("form").submit(function (e) {
    $('#processingLabel').val('Processing Data... Please wait').show();
    $('[name="total"]').val(0);
    $('[name="color"]').val(0);
    $('[name="BW"]').val(0);
    e.preventDefault();
    var formData = new FormData(this);
    
    $.ajax({
        url: 'https://localhost:44328/home/FileUploaderAjax',
        type: 'POST',
        data: formData,
        success: function (data) {
            $('#processingLabel').hide();
            console.log(data)
            $('[name="total"]').val(data.Total);
            $('[name="color"]').val(data.Colored);
            $('[name="BW"]').val(data.BlackAndWhite);
        }, error: function (xhr, status, error) {
            $('#processingLabel').text('Error Occurred');
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