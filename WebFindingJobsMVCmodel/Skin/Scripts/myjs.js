$(function () {
    $('#show-more-langs').click(function () {
        var $link = $(this);
        $('#more-langs').slideToggle(function () {
            $link.slideToggle();
        })
    });
});