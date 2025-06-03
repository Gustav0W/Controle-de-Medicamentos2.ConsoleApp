using Controle_de_Medicamentos2.ConsoleApp.Compartilhado;
using Controle_de_Medicamentos2.ConsoleApp.Extensions;
using Controle_de_Medicamentos2.ConsoleApp.Model;
using Controle_de_Medicamentos2.ConsoleApp.ModuloPaciente;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_Medicamentos2.ConsoleApp.Controllers;

[Route("/pacientes")]
public class ControladorPaciente : Controller
{
    private readonly ContextoDados contextoDados;
    private readonly IRepositorioPaciente repositorioPaciente;

    public ControladorPaciente()
    {
        contextoDados = new ContextoDados(true);
        repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarPacienteViewModel();
        return View("Cadastrar", cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarPacienteViewModel cadastrarVM)
    {
        var novoPaciente = cadastrarVM.ParaEntidade();

        repositorioPaciente.CadastrarRegistro(novoPaciente);

        NotificacaoViewModels notificacaoVM = new NotificacaoViewModels(
            "Paciente Cadastrado!",
            $"O registro \"{novoPaciente.Nome}\" foi cadastrado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:guid}")]
    public IActionResult Editar([FromRoute] Guid id)
    {
        var registroSelecionado = repositorioPaciente.SelecionarRegistroPorId(id);

        var editarVM = new EditarPacienteViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Telefone,
            registroSelecionado.CartaoSus
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    public IActionResult Editar([FromRoute] Guid id, EditarPacienteViewModel editarVM)
    {
        var registroEditado = editarVM.ParaEntidade();

        repositorioPaciente.EditarRegistro(id, registroEditado);

        NotificacaoViewModels notificacaoVM = new NotificacaoViewModels(
            "Paciente Editado!",
            $"O registro \"{registroEditado.Nome}\" foi editado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir([FromRoute] Guid id)
    {
        var registroSelecionado = repositorioPaciente.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirPacienteViewModel(
            registroSelecionado.Id,
            registroSelecionado.Nome
        );

        return View("Excluir", excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    public IActionResult ExcluirConfirmado([FromRoute] Guid id)
    {
        repositorioPaciente.ExcluirRegistro(id);

        NotificacaoViewModels notificacaoVM = new NotificacaoViewModels(
            "Paciente Excluído!",
            "O registro foi excluído com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var registros = repositorioPaciente.SelecionarRegistros();

        var visualizarVM = new VisualizarPacientesViewModel(registros);

        return View(visualizarVM);
    }
}