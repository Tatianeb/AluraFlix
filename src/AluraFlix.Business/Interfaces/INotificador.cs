using System.Collections.Generic;
using AluraFlix.Business.Notificacoes;

namespace AluraFlix.Business.Interfaces
{
    public interface INotificador
    {
       List<Notificacao> ObterNotificacoes();
       bool TemNotificacao();
       void Handle(Notificacao notificacao);
    }
}