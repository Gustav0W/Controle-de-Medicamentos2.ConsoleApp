using Controle_de_Medicamentos2.ConsoleApp.Compartilhado;
using Controle_de_Medicamentos2.ConsoleApp.Extensions;
using Controle_de_Medicamentos2.ConsoleApp.Model;
using Controle_de_Medicamentos2.ConsoleApp.ModuloFornecedor;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_Medicamentos2.ConsoleApp.Controllers;

[Route("/fornecedores")]
public class ControladorFornecedor : Controller
{
    private readonly ContextoDados contextoDados;
    private readonly IRepositorioFornecedor repositorioFornecedor;

    public ControladorFornecedor()
    {
        contextoDados = new ContextoDados(true);
        repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarFornecedorViewModel();
        return View("Cadastrar", cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarFornecedorViewModel cadastrarVM)
    {
        var novoFornecedor = cadastrarVM.ParaEntidade();

        repositorioFornecedor.CadastrarRegistro(novoFornecedor);

        NotificacaoViewModels notificacaoVM = new NotificacaoViewModels(
            "Fornecedor Cadastrado!",
            $"O registro \"{novoFornecedor.Nome}\" foi cadastrado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:guid}")]
    public IActionResult Editar([FromRoute] Guid id)
    {
        var registroSelecionado = repositorioFornecedor.SelecionarRegistroPorId(id);

        var editarVM = new EditarFornecedorViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Telefone,
            registroSelecionado.CNPJ
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    public IActionResult Editar([FromRoute] Guid id, EditarFornecedorViewModel editarVM)
    {
        var registroEditado = editarVM.ParaEntidade();

        repositorioFornecedor.EditarRegistro(id, registroEditado);

        NotificacaoViewModels notificacaoVM = new NotificacaoViewModels(
            "Fornecedor Editado!",
            $"O registro \"{registroEditado.Nome}\" foi editado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir([FromRoute] Guid id)
    {
        var registroSelecionado = repositorioFornecedor.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirFornecedorViewModel(
            registroSelecionado.Id,
            registroSelecionado.Nome
        );

        return View("Excluir", excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    public IActionResult ExcluirConfirmado([FromRoute] Guid id)
    {
        repositorioFornecedor.ExcluirRegistro(id);

        NotificacaoViewModels notificacaoVM = new NotificacaoViewModels(
            "Fornecedor Excluído!",
            "O registro foi excluído com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var registros = repositorioFornecedor.SelecionarRegistros();

        var visualizarVM = new VisualizarFornecedoresViewModel(registros);

        return View(visualizarVM);
    }
}