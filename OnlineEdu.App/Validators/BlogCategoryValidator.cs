using FluentValidation;
using OnlineEdu.App.DTOs.BlogCategoryDtos;

namespace OnlineEdu.App.Validators
{
    public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Blog Kategori adı boş bırakılamaz!");
            RuleFor(x => x.Name).MaximumLength(35).WithMessage("Blog Kategori adı en fazla 35 karakter olabilir");
        }
    }
}
