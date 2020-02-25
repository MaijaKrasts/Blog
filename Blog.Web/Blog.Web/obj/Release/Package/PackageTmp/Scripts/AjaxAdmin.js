$(document).ready(function () {

    $('#buttonWrite').click(function () {
        var Email = $('#emailWrite').val();
        $.ajax({
            url: "/Admin/GrantWriteAccess/",
            type: "POST",
            datatype: "JSON",
            data: { email: Email },
            success: function (result) {
                $('#result1').html(result);
            }
        });
        location.reload();
    });

    $('#buttonComment').click(function () {
        var Email = $('#emailComment').val();
        $.ajax({
            url: '/Admin/GrantCommentAccess/',
            type: 'POST',
            datatype: "JSON",
            data: { email: Email },
            success: function (result) {
                $('#result1').html(result);
            }
        });
        location.reload();
    });

    $('#buttonRate').click(function () {
        var Email = $('#emailRate').val();
        $.ajax({
            url: '/Admin/GrantRateAccess/',
            type: 'POST',
            datatype: "JSON",
            data: { email: Email },
            success: function (result) {
                $('#result1').html(result);
            }
        });
        location.reload();
    });
});