using FluentValidation;

namespace AluraFlix.Business.Models.Validations
{
    public class VideoValidation:AbstractValidator<Video>
    {
        public VideoValidation()
        {
            RuleFor(f => f.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}