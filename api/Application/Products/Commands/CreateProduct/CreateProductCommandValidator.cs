using FluentValidation;

namespace Api.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand.Command>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.CreateProductDto.Name)
            .MaximumLength(250)
            .NotEmpty();

        RuleFor(x => x.CreateProductDto.Description)
            .NotEmpty();

        RuleFor(x => x.CreateProductDto.PictureUrl)
            .Empty();

        RuleFor(x => x.CreateProductDto.Price)
            .GreaterThan(0);

        RuleFor(x => x.CreateProductDto.InitialQuantityOnStock)
            .GreaterThan(0);
    }
}
