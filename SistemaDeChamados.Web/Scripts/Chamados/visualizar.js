$(function () {

    var dataSource = new baseDataSource();
    var modalMensagem = $('#mensagemModal');
    var btnLoadingSpinner = $('.fa-spinner');
    var listadeMsg = $('.list-group');
    
    var chamadoId = $('#chamadoID').val();
    var statusDoChamado = $('.label-status').text();

    var novaMensagem = {
        ChamadoId: chamadoId,
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
        $('.btn-send').prop('disabled', false);
    }

    function exibirLoading(cssClass) {
        $(cssClass).prop('disabled', true);
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

    function incrementarNumero(valor, classElementoHtml) {
        var numeroDeMensagens = parseInt(valor);
        numeroDeMensagens = ++numeroDeMensagens;

        $(classElementoHtml).text(numeroDeMensagens);
    }

    //OnLoad
    (function carregarMensagens() {
        dataSource.getRequest('http://' + window.location.hostname + ':6084/api/Mensagens/ObterCinco/?chamadoId=', novaMensagem.ChamadoId, function (mensagens) {

            prepararDivDeMensagens();
            montagemInicialListaDeMensagens();
            mensagens.forEach(function(data) {
                listadeMsg.append('<li class=\"list-group-item\">' + data.Texto + '<ul class=\"list-inline\"> <li class=\"identificacao-usuario\">Por: <span>' + data.NomeUsuario + ' - ' + data.DataDeCriacao + '</span></li></ul></li>');
            });

        });

        $('.chamado-status').each(function() {
            if (this.text === statusDoChamado) {
                $(this).append('<i class="glyphicon glyphicon-ok icon-chamado-status"></i>');
            }
        });

    })();

    $('.btn-send').click(function () {
        exibirLoading('.btn-send');

        novaMensagem.ChamadoId = $('#chamadoID').val();
        novaMensagem.Texto = $('.textarea-mensagem').val();

        dataSource.postRequest(window.location.origin + "/Chamados/NovaMensagem", novaMensagem, function (data) {
            if (listadeMsg.length === 0) {
                montagemInicialListaDeMensagens();
            }
            listadeMsg.before('<li class=\"list-group-item\">' + data.Texto + '<ul class=\"list-inline\"> <li class=\"identificacao-usuario\">Por: <span>' + data.NomeUsuario + ' - ' + data.DataDeCriacao + '</span></li></ul></li>');

            fecharModal();
            incrementarNumero($('.numero-mensagens').text(), '.numero-mensagens');
        });
    });

    $('.btn-excluir').click(function() {
        exibirLoading('.btn-send');
        
        dataSource.deleteRequest('http://' + window.location.hostname + ':6084/api/Chamados/Excluir?id=', chamadoId, function() {
            window.location.href = window.location.origin + "/Chamados";
        });

    });

    $('.chamado-status').click(function() {

        $('.btn-custom-dropdown > i').remove();
        $('.btn-custom-dropdown').append('<i class="fa fa-spinner fa-spin"></i>');

        var status = this.text;
        var key = $('#key').val();
        
        var novoStatus = {
            Id: chamadoId,
            UsuarioId: key,
            Status: status
        }

        dataSource.putRequest('http://' + window.location.hostname + ':6084/api/Chamados/AlterarStatusAsync/', novoStatus, function () {

            $('i').remove('.icon-chamado-status');
            $('a[id="' + novoStatus.Status + '"]:last').append('<i class="glyphicon glyphicon-ok icon-chamado-status"></i>');

            $('.btn-custom-dropdown > i').remove();
            $('.btn-custom-dropdown').append('<i class="fa fa-pencil-square-o"></i>');

            $('.label-status').text(novoStatus.Status);
        });
    });
});