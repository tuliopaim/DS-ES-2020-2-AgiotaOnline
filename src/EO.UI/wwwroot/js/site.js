$(function() {
    aplicarMascaras();
});

function aplicarMascaras() {
    $("#Telefone").mask("(00) 0 0000-0000");
    $("#Cpf").mask("000.000.000-00");
    $("#Tomador_Endereco_Cep").mask("00.000-000");

    aplicarMascaraMonetaria();
}

var aplicarMascaraMonetaria = function () {
    $('.monetario').mask('000.000.000.000.000,00', {
        placeholder: "0,00",
        reverse: true,
        onChange: function (val, e, field) {
            // get only the numeric figures from the input value
            val = val.replace(/[^0-9]+/g, '');
            // strip leading zeros
            val = ("" + val).replace(/^0+/, '');
            // fill up leading zeros if its a cent value
            while (val.length <= 2) {
                val = "0" + val;
            }
            // mask the new value and set it for the input element
            $(field).val(field.masked(val));
        }
    });
}

$(document).on('mask-it', function () {
    aplicarMascaraMonetaria();
}).trigger('mask-it');
