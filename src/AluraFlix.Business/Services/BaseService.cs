using AluraFlix.Business.Interfaces;
using AluraFlix.Business.Models;
using AluraFlix.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace AluraFlix.Business.Services
{
    public class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }

        protected void Notificar(string menssagem)
        {
            _notificador.Handle(new Notificacao(menssagem));
        }
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }
    }
}