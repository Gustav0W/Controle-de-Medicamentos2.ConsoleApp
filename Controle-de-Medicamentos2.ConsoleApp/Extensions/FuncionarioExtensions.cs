using Controle_de_Medicamentos2.ConsoleApp.Model;
using Controle_de_Medicamentos2.ConsoleApp.ModuloFuncionario;

namespace Controle_de_Medicamentos2.ConsoleApp.Extensions;

public static class FuncionarioExtensions
{
    public static Funcionario ParaEntidade(this FormularioFuncionarioViewModel formularioVM)
    {
        return new Funcionario(formularioVM.Nome, formularioVM.Telefone, formularioVM.Cpf);
    }

    public static DetalhesFuncionarioViewModel ParaDetalhesVM(this Funcionario funcionario)
    {
        return new DetalhesFuncionarioViewModel(
                funcionario.Id,
                funcionario.Nome,
                funcionario.Telefone,
                funcionario.Cpf
        );
    }
}