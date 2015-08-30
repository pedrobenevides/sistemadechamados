$(function() {

    function buscarItem(item) {
        $('ul li').each(function(i, elem) {
            var itemValue = $(elem).find('a').attr('href');

            if (itemValue == null) return false;

            if (item === itemValue.split('/')[1]) {
                $(elem).find('a:first').addClass('menu-active');
                return false; //return false para sair do loop
            }
        });
    }

    buscarItem(location.href.split('/')[3]);

})