﻿function baseDataSource() {
    this.getRequest = function (url, parameter, success, error) {
        $.ajax({
            url: url + parameter,
            type: 'GET',
            dataType: 'json',
            statusCode: {
                200: function (data) { success(data); },
                500: function (erro) { error(erro); }
            }});
    }

    this.postRequest = function(url, model, success, error) {
        $.ajax({
            url: url,
            type: 'POST',
            data: model,
            statusCode: {
                200: function (data) { success(data); },
                500: function (erro) { error(erro); }
            }
        });
    }

    this.deleteRequest = function (url, id, success, error) {
        $.ajax({
            url: url + id,
            type: 'DELETE',
            statusCode: {
                200: function (data) { success(data); },
                500: function (erro) { error(erro); }
            }
        });
    }

    this.putRequest = function (url, model, success, error) {
        $.ajax({
            url: url,
            type: 'PUT',
            data: model,
            statusCode: {
                200: function (data) { success(data); },
                500: function (erro) { error(erro); }
            }
        });
    }
};