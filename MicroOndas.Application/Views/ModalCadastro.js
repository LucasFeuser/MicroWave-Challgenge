$(document).ready(function () {
    var $tempo = $('#TempoDTO');
    var $potencia = $('#PotenciaDTO');

    $tempo.on('blur', function () {
        var tempo = parseInt($(this).val(), 10);

        if (isNaN(tempo) || tempo < 1 || tempo > 120) {
            alert('Digite um tempo válido entre 1 e 120 segundos.');
            $(this).val('');
            return;
        }

        if (tempo > 60) {
            var minutos = Math.floor(tempo / 60);
            var segundos = tempo % 60;
            $(this).val(minutos.toString().padStart(2, '0') + ':' + segundos.toString().padStart(2, '0'));
        }
    });

    $potencia.on('blur', function () {
        var potencia = parseInt($(this).val(), 10);

        if (isNaN(potencia) || potencia < 1 || potencia > 10) {
            alert('Digite uma potência válida entre 1 e 10.');
            $(this).val('10');
            return;
        }
    });
});