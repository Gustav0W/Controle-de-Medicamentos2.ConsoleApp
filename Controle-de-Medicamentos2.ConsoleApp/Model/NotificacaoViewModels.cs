namespace Controle_de_Medicamentos2.ConsoleApp.Model;

public class NotificacaoViewModels
{
    public string Titulo { get; set; }
    public string Mensagem { get; set; }

    public NotificacaoViewModels(string titulo, string mensagem)
    {
        Titulo = titulo;
        Mensagem = mensagem;
    }
}