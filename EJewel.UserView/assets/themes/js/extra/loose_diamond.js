$(function () {
    $('#centerStone-shape i, #centerStone-color i, #centerStone-clarity i, #centerStone-cut i').each(function () {
        var curItem = $(this);
        $(curItem).on('click mouseover', function (e) {
            if (e.type == 'click') {
                curItem.toggleClass('selected');
                //trigger event on selected
                if (curItem.hasClass('selected')) {
                    $(curItem).trigger('active')
                }
                else {
                    $(curItem).trigger('inactive')
                }
                $('#sel-filter dd').text(curItem.text());
            }
            if (e.type == 'mouseover') {
                $('#static-popover .popover-content').text(curItem.text());
            }
        });
    });

    $('.icon-reset').on('click', function (e) {
        e.preventDefault();
        $('#centerStone-shape i').removeClass('selected');
        $('#centerStone-color i').removeClass('selected');
        $('#centerStone-clarity i').removeClass('selected');
        $('#centerStone-cut i').removeClass('selected');
    });
});