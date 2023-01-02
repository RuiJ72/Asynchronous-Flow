// Fluxo Síncrono
using ExemploFluxoAssincrono;
using System.Diagnostics;

// Inicialização de um contador de tempo
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

Console.WriteLine("\nBem Vindo à calculadora de Hipotécas Síncrona");

var anosVidaLaboral = CalculadoraHipotecaSincrona.ObterAnosVida();
Console.WriteLine($"Anos de vida laboral: {anosVidaLaboral}");

var etipoContratoIndefinido = CalculadoraHipotecaSincrona.EContratoIndefinido();
Console.WriteLine($"\nTipo de contrato indefinido: {etipoContratoIndefinido}");

var saldoBruto = CalculadoraHipotecaSincrona.ObterSaldoBruto();
Console.WriteLine($"\nSaldo Bruto: {saldoBruto}");

var gastosMensais = CalculadoraHipotecaSincrona.ObterGastosMensais();
Console.WriteLine($"\nGastos Mensais: {gastosMensais}");


var hipotecaConcedida = CalculadoraHipotecaSincrona.AnalizarConcederHipoteca(
    anosVidaLaboral,
    etipoContratoIndefinido,
    saldoBruto,
    gastosMensais,
    quantidadeSolicitada: 50000,
    anosPagar: 30
            
    );

var resultado = hipotecaConcedida ? "Aprovada!" : "recusada";

Console.WriteLine($"\nAnálise fnalizada. A sua solicitação foi {resultado}");

stopwatch.Stop();
Console.WriteLine($"\n A operação demorou {stopwatch.Elapsed}");

// Reinicialização para Fluxo Assíncrono
stopwatch.Restart();
Console.WriteLine("\n------------Fluxo Assíncrono-------------");
Console.WriteLine("\nBem - Vindo à calculadora de Hipoteca Assíncrona");
Console.WriteLine("\n-------------------------------------------");


Task<int> anosVidaLaboralTask = CalculadoraHipotecaAssincrona.ObterAnosVida();
Task<bool> etipoContratoIndefinidoTask = CalculadoraHipotecaAssincrona.EContratoIndefinido();
Task<int> saldoBrutoTask = CalculadoraHipotecaAssincrona.ObterSaldoBruto();
Task<int> gastosMensaisTask = CalculadoraHipotecaAssincrona.ObterGastosMensais();

var analiseHipotecaTasks = new List<Task>
{
    anosVidaLaboralTask,
    etipoContratoIndefinidoTask,
    saldoBrutoTask,
    gastosMensaisTask
};


while (analiseHipotecaTasks.Any())
{
    Task tarefaTerminada = await Task.WhenAny(analiseHipotecaTasks);

    if (tarefaTerminada == anosVidaLaboralTask)
    {
        Console.WriteLine($"Anos de vida laboral: {anosVidaLaboralTask.Result}");
    }
    else if(tarefaTerminada == etipoContratoIndefinidoTask)
    {
        Console.WriteLine($"\nTipo de contrato indefinido: {etipoContratoIndefinidoTask.Result}");
    }
    else if (tarefaTerminada == saldoBrutoTask)
    {
        Console.WriteLine($"\nSaldo Bruto: {saldoBrutoTask.Result}");
    }
    else if (tarefaTerminada == gastosMensaisTask)
    {
        Console.WriteLine($"\nGastos Mensais: {gastosMensaisTask.Result}");
    }

    analiseHipotecaTasks.Remove(tarefaTerminada); // Removemos da lista de tarefas
}

var hipotecaAssincronaConcedida = CalculadoraHipotecaAssincrona.AnalizarConcederHipoteca(
    anosVidaLaboralTask.Result,
    etipoContratoIndefinidoTask.Result,
    saldoBrutoTask.Result,
    gastosMensaisTask.Result,
    quantidadeSolicitada: 50000,
    anosPagar: 30

    );

var resultadoAssincrono = hipotecaAssincronaConcedida ? "Aprovada!" : "recusada";

Console.WriteLine($"\nAnálise fnalizada. A sua solicitação foi {resultadoAssincrono}");

stopwatch.Stop();

Console.WriteLine($"A operação Assíncrona durou: {stopwatch.Elapsed}");
Console.Read();





