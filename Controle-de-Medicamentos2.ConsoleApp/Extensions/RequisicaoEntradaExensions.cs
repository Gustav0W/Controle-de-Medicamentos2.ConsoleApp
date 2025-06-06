using Controle_de_Medicamentos2.ConsoleApp.Model;
using Controle_de_Medicamentos2.ConsoleApp.ModuloFuncionario;
using Controle_de_Medicamentos2.ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos2.ConsoleApp.ModuloRequisicaoMedicamento;

namespace Controle_de_Medicamentos2.ConsoleApp.Extensions;

public static class RequisicaoEntradaExtensions
{
    public static RequisicaoEntrada ParaEntidade(
        this CadastrarRequisicaoEntradaViewModel formularioVM,
        List<Funcionario> funcionarios,
        List<Medicamento> medicamentos
    )
    {
        Funcionario funcionarioSelecionado = null;

        foreach (var f in funcionarios)
        {
            if (f.Id == formularioVM.FuncionarioId)
                funcionarioSelecionado = f;
        }

        Medicamento medicamentoSelecionado = null;

        foreach (var m in medicamentos)
        {
            if (m.Id == formularioVM.MedicamentoId)
                medicamentoSelecionado = m;
        }

        return new RequisicaoEntrada(funcionarioSelecionado, medicamentoSelecionado, formularioVM.QuantidadeRequisitada);
    }
}
