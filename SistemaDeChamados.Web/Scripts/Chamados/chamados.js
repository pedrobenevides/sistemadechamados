
$(function () {
    var self = this;
    var bs = new baseDataSource();
    debugger;

    var dropdownCategorias = $('.ddl-categorias');
    var dropdownSetores = $('.ddl-setores');
    var divInformativa = $('.categoria-label-listagem');
    var divLoading = $('.div-loading-categorias');

    function refreshDropDown(div, dropdown) {
        dropdown.empty();
        div.hide();
        dropdown.show();
        div.show('slow');
    }

    function configuraLabelInformativa(text, color) {
        divInformativa.show('slow');
        divInformativa.text(text);
        divInformativa.css('color', color);
        dropdownCategorias.hide();
    }

    divLoading.hide();

    dropdownSetores.change(function() {
        var valorSelecionado = dropdownSetores.find(":selected").text();

        if (valorSelecionado === 'Selecione...') {
            configuraLabelInformativa('Selecione um setor para listar as categorias', 'black');
            return;
        }

        $('.div-label-info').hide();
        divLoading.show();

        bs.get('http://localhost:6084/api/Categorias/Listar?setorId=', this.value,
            function(data) {

                divLoading.hide();

                var resultadoVazio = data.length === 0;

                if (resultadoVazio) {
                    configuraLabelInformativa('O setor {0} não possui categoria cadastrada'.format(valorSelecionado), '#E68A00');
                    return;
                }

                $('.categoria-label-listagem').hide('slow');
                refreshDropDown($('.categorias-div'), dropdownCategorias);
                $.each(data, function(key, value) {
                    dropdownCategorias.append($("<option />").val(value.Id).text(value.Nome));
                });
            });

        //$.ajax({
        //    url: 'http://localhost:6084/api/Categorias/Listar?setorId=' + this.value,
        //    type: 'GET',
        //    dataType: 'json',
        //    statusCode: {
        //        200: function (data) {
                    
        //            divLoading.hide();

        //            var resultadoVazio = data.length === 0;

        //            if (resultadoVazio) {
        //                configuraLabelInformativa('O setor {0} não possui categoria cadastrada'.format(valorSelecionado), '#E68A00');
        //                return;
        //            }

        //            $('.categoria-label-listagem').hide('slow');
        //            refreshDropDown($('.categorias-div'), dropdownCategorias);
        //            $.each(data, function (key, value) {
        //                dropdownCategorias.append($("<option />").val(value.Id).text(value.Nome));
        //            });
        //        }
        //    }
        //});
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