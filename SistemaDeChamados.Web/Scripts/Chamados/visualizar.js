$(function () {

    var dataSource = new baseDataSource();
    var modalMensagem = $('#mensagemModal');
    var btnLoadingSpinner = $('.fa-spinner');
    var listadeMsg = $('.list-group');

    var novaMensagem = {
        ChamadoId: $('#chamadoID').val(),
        Texto: "",
        NomeUsuario: "",
        DataDeCriacao: ""
    };

    btnLoadingSpinner.hide();

    modalMensagem.on('shown.bs.modal', function () {
        $('#myInput').focus();
    });

    function fecharModal() {
        modalMensagem.modal('hide');
        $('#mensagemModal textarea').val('');
        btnLoadingSpinner.hide();
    }

    function exibirLoading() {
        $('.btn-send').prop('disabled', true);
        btnLoadingSpinner.show();
    }

    function montagemInicialListaDeMensagens() {
        $('.text-center').first().remove();
        $('#panelMsg').append('<ul class=\"list-group\">');
    }

    function prepararDivDeMensagens() {
        $('.panel-body').css('background-color', 'white');
        $('.spinning-div').hide();
    }

    (function carregarMensagens() {
        dataSource.getRequest('http://' + window.location.hostname + ':6084/api/Mensagens/ObterCinco/?chamadoId=', novaMensagem.ChamadoId, function (mensagens) {

            prepararDivDeMensagens();
            montagemInicialListaDeMensagens();
            mensagens.forEach(function(data) {
                listadeMsg.append('<li class=\"list-group-item\">' + data.Texto + '<ul class=\"list-inline\"> <li class=\"identificacao-usuario\">Por: <span>' + data.NomeUsuario + ' - ' + data.DataDeCriacao + '</span></li></ul></li>');
            });

        });
    })();

    $('.btn-send').click(function () {
        exibirLoading();

        novaMensagem.ChamadoId = $('#chamadoID').val();
        novaMensagem.Texto = $('.textarea-mensagem').val();

        dataSource.postRequest(window.location.origin + "/Chamados/NovaMensagem", novaMensagem, function (data) {
            if (listadeMsg.length === 0) {
                montagemInicialListaDeMensagens();
            }
            listadeMsg.before('<li class=\"list-group-item\">' + data.Texto + '<ul class=\"list-inline\"> <li class=\"identificacao-usuario\">Por: <span>' + data.NomeUsuario + ' - ' + data.DataDeCriacao + '</span></li></ul></li>');
            fecharModal();
        });
    });
});