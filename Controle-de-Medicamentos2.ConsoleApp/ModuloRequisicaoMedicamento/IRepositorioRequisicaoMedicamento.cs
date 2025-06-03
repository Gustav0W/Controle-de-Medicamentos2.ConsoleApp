namespace Controle_de_Medicamentos2.ConsoleApp.ModuloRequisicaoMedicamento;

public interface IRepositorioRequisicaoMedicamento
{
    public void CadastrarRequisicaoEntrada(RequisicaoEntrada requisicao);
    public void CadastrarRequisicaoSaida(RequisicaoSaida requisicao);
    public List<RequisicaoSaida> SelecionarRequisicoesSaida();
}