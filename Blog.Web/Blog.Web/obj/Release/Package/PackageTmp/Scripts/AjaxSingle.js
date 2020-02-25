$(document).ready(function () {

    $('#buttonComment').click(function () {
        var ArticleId = $('#ArticleId').val();
        var UserId = $('#UserId').val();
        var Comment = $('#Comment').val();
        $.ajax({
            url: '/Article/WriteComment/',
            type: 'POST',
            datatype: "JSON",
            data: { articleId: ArticleId, userId: UserId, comment: Comment },
            success: function (result) {
                $('#result1').html(result);
            }
        });
    });
    //bug: grabs only the first comment to delete-->
    $('#buttonDeleteComment').click(function () {
        var CommentId = $('#CommentId').val();
        $.ajax({
            url: '/Article/DeleteComment/',
            type: 'POST',
            datatype: "JSON",
            data: { commentId: CommentId },
            success: function (result) {
                $('#result1').html(result);
            }
        });
    });

    $('#buttonRatePlus').click(function () {
        var ArticleId = $('#ArticleId').val();
        var RateValue = $('#RatePlus').val();

        $.ajax({
            url: '/Article/RateArticle/',
            type: 'POST',
            datatype: "JSON",
            data: { articleId: ArticleId, rateValue: RateValue },
            success: function (result) {
                $('#rating').html(result);
            }
        });
    });

    $('#buttonRateMinus').click(function () {
        var ArticleId = $('#ArticleId').val();
        var RateValue = $('#RateMinus').val();

        $.ajax({
            url: '/Article/RateArticle/',
            type: 'POST',
            datatype: "JSON",
            data: { articleId: ArticleId, rateValue: RateValue },
            success: function (result) {
                $('#rating').html(result);
            }
        });
    });

    //bug: grabs only the first comment to report-->
    $('#buttonReport').click(function () {
        var CommentId = $('#CommentId').val();
        $.ajax({
            url: '/Article/ReportComment/',
            type: 'POST',
            datatype: "JSON",
            data: { commentId: CommentId },
            success: function (result) {
                $('#result1').html(result);
            }
        });
    });

    //bug: grabs only the first comment to keep-->
    $('#buttonKeepReported').click(function () {
        var CommentId = $('#CommentId').val();
        $.ajax({
            url: '/Article/KeepReportedComment/',
            type: 'POST',
            datatype: "JSON",
            data: { commentId: CommentId },
            success: function (result) {
                $('#result1').html(result);
            }
        });
    });
});