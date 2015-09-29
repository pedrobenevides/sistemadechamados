$(function () {

    var dataSource = new baseDataSource();
    var modalMensagem = $('#mensagemModal');
    var loadingSpinner = $('.fa-spinner');
    var listadeMsg = $('.list-group li:eq(0)');

    var novaMensagem = {
        ChamadoId: "",
        Texto: "",
        NomeUsuario: "",
        DataDeCriacao: ""
    };

    loadingSpinner.hide();

    modalMensagem.on('shown.bs.modal', function () {
        $('#myInput').focus();
    });

    function fecharModal() {
        modalMensagem.modal('hide');
        $('#mensagemModal textarea').val('');
        loadingSpinner.hide();
    }

    function exibirLoading() {
        $('.btn-send').prop('disabled', true);
        loadingSpinner.show();
    }

    function montagemInicialListaDeMensagens() {
        $('.text-center').first().remove();
        $('#panelMsg').append('<ul class=\"list-group\">');
    }

    (function carregarMensagens() {
        dataSource.getRequest('http://localhost:6084/api/Mensagens/ObterMensagens/', novaMensagem.ChamadoId, function(mensagens) {

            montagemInicialListaDeMensagens();
            mensagens.forEach(function(data) {
                listadeMsg.before('<li class=\"list-group-item\">' + data.Texto + '<ul class=\"list-inline\"> <li class=\"identificacao-usuario\">Por: <span>' + data.NomeUsuario + ' - ' + data.DataDeCriacao + '</span></li></ul></li>');
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