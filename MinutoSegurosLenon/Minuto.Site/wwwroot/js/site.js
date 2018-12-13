// Write your Javascript code.
$(function () {

    Consultar();

    function Consultar() {

    
        $.ajax({
            url: 'http://localhost:56263/api/artigo/',
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            crossDomain: true,
            success: function (data) {
                $.each(data, function (i, item) {
                    var tbl = $("#template").clone();
                    tbl.show();
                    tbl.find("#artigo").text(item.titulo);
                    tbl.find('#tblLista').find('tbody').children().remove();
                    $.each(item.palavra, function (key, value) {
                        tbl.find('#tblLista tbody').append(
                            $('<tr>')
                                .append($('<td>').append(key))
                                .append($('<td>').append(value))
                                );
                    });
                    $("#tabela").append(tbl);
                });
            },
            error: function (jqXHR, exception) {
                alert('Ocorreu o seguinte erro: \n' + 'Status: ' + jqXHR.status +'\n Erro: ' + jqXHR.responseText);
            }
        });
    }
})