$(function () {

    var dataSource = new baseDataSource();

    $('.btn-status').each(function () {
        if (this.innerText === 'Ativo') {
            $(this).removeClass('btn-default').addClass('btn-primary');
        } else {
            $(this).removeClass('btn-primary').addClass('btn-default');
        }
    });
    
    var alterarStatus = function (statusAntigo) {
        return statusAntigo === 'Ativo' ? 'Desativado' : 'Ativo';
    };

    var alterarCssClassStatus = function (statusAntigo, elemHtml) {
        if (statusAntigo === 'Desativado') {
            $(elemHtml).removeClass('btn-default').addClass('btn-primary');
        } else {
            $(elemHtml).removeClass('btn-primary').addClass('btn-default');
        }
    }

    $('.btn-status').click(function () {
        var self = this;
        var statusAntigo = this.innerText;

        dataSource.getRequest('http://localhost:6084/api/Usuarios/AlterarStatus/', this.name, function (result) {
            self.innerText = alterarStatus(statusAntigo);
            alterarCssClassStatus(statusAntigo, self);
        });

        //$.ajax({
        //    url: 'http://localhost:6084/api/Usuarios/AlterarStatus/' + this.name,
        //    type: 'GET',
        //    success: function (result) {
        //        self.innerText = alterarStatus(statusAntigo);
        //        alterarCssClassStatus(statusAntigo, self);
        //    }
        //});
    });
});