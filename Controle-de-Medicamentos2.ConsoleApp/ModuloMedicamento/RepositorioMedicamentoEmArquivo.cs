using Controle_de_Medicamentos2.ConsoleApp.Compartilhado;

namespace Controle_de_Medicamentos2.ConsoleApp.ModuloMedicamento;

public class RepositorioMedicamentoEmArquivo : RepositorioBaseEmArquivo<Medicamento>, IRepositorioMedicamento
{
    public RepositorioMedicamentoEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Medicamento> ObterRegistros()
    {
        return contexto.Medicamentos;
    }
}