using Controle_de_Medicamentos2.ConsoleApp.Model;
using Controle_de_Medicamentos2.ConsoleApp.ModuloFuncionario;
using Controle_de_Medicamentos2.ConsoleApp.ModuloPrescricao;
using Controle_de_Medicamentos2.ConsoleApp.ModuloRequisicaoMedicamento;

namespace Controle_de_Medicamentos2.ConsoleApp.Extensions;

public static class RequisicaoSaidaExtensions
{
    public static RequisicaoSaida ParaEntidade(
         this CadastrarRequisicaoSaidaCompletaViewModel formularioVM,
         List<Funcionario> funcionarios,
         List<Prescricao> prescricoes
     )
    {
        Funcionario funcionarioSelecionado = null;

        foreach (var f in funcionarios)
        {
            if (f.Id == formularioVM.FuncionarioId)
                funcionarioSelecionado = f;
        }

        Prescricao prescricaoSelecionada = null;

        foreach (var p in prescricoes)
        {
            if (p.Id == formularioVM.PrescricaoId)
                prescricaoSelecionada = p;
        }

        return new RequisicaoSaida(funcionarioSelecionado, prescricaoSelecionada);
    }

    public static DetalhesRequisicaoSaidaViewModel ParaDetalhesVM(this RequisicaoSaida requisicao)
    {
        return new DetalhesRequisicaoSaidaViewModel(
            requisicao.Id,
            requisicao.Funcionario.Nome,
            requisicao.Prescricao.Paciente.Nome,
            requisicao.DataOcorrencia,
            requisicao.Prescricao.MedicamentoPrescritos
        );
    }
}