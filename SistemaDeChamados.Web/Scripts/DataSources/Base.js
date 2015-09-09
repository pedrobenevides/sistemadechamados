function baseDataSource() {
    this.get = function (url, parameter, success, error) {
        $.ajax({
            url: url + parameter,
            type: 'GET',
            dataType: 'json',
            statusCode: {
                200: success(data),
                500: error
            }});
    }
};