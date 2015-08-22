
$(function () {
    var self = this;

    function refreshDropDown(div, dropdown) {
        dropdown.empty();
        div.hide();
        div.show('slow');
    }

    $('.ddl-setores').change(function () {
        var dropdownCategorias = $('.ddl-categorias');
        
        $.ajax({
            url: 'http://localhost:6084/api/Categorias/Listar?setorId=' + this.value,
            type: 'GET',
            dataType: 'json',
            statusCode: {
                200: function (data) {
                    $('.categoria-label-listagem').hide('slow');
                    refreshDropDown($('.categorias-div'), dropdownCategorias);
                    $.each(data, function (key, value) {
                        dropdownCategorias.append($("<option />").val(value.Id).text(value.Nome));
                    });
                }
            }
        });
    });


})