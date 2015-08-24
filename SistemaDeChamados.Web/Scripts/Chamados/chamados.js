
$(function () {
    var self = this;

    var dropdownCategorias = $('.ddl-categorias');
    var dropdownSetores = $('.ddl-setores');
    var labelInformativa = $('.categoria-label-listagem');

    function refreshDropDown(div, dropdown) {
        dropdown.empty();
        div.hide();
        dropdown.show();
        div.show('slow');
    }

    function configuraLabelInformativa(text, color) {
        labelInformativa.show('slow');
        labelInformativa.text(text);
        labelInformativa.css('color', color);
        dropdownCategorias.hide();
    }

    dropdownSetores.change(function () {
        var valorSelecionado = dropdownSetores.find(":selected").text();

        if (valorSelecionado === 'Selecione...') {
            configuraLabelInformativa('Selecione um setor para listar as categorias', 'black');
            return;
        }

        $.ajax({
            url: 'http://localhost:6084/api/Categorias/Listar?setorId=' + this.value,
            type: 'GET',
            dataType: 'json',
            statusCode: {
                200: function (data) {

                    var resultadoVazio = data.length === 0;

                    if (resultadoVazio) {
                        configuraLabelInformativa('O setor {0} não possui categoria cadastrada'.format(valorSelecionado), '#E68A00');
                        return;
                    }

                    $('.categoria-label-listagem').hide('slow');
                    refreshDropDown($('.categorias-div'), dropdownCategorias);
                    $.each(data, function (key, value) {
                        dropdownCategorias.append($("<option />").val(value.Id).text(value.Nome));
                    });
                }
            }
        });
    });

    //TODO: Exportar para um arquivo a parte
    String.prototype.format = function () {
        var str = this;
        for (var i = 0; i < arguments.length; i++) {
            var reg = new RegExp("\\{" + i + "\\}", "gm");
            str = str.replace(reg, arguments[i]);
        }
        return str;
    }

})