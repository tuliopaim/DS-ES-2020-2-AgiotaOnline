$(function() {
    aplicarMascaras();
});

function aplicarMascaras() {
    $("#Telefone").mask("(00) 0 0000-0000");
    $("#Cpf").mask("000.000.000-00");
    $("#Tomador_Endereco_Cep").mask("00.000-000");
    $(".money").mask('###.###.###.##0,00', { reverse: true });
}
