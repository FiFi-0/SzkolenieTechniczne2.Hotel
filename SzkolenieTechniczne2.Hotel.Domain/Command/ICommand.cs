using MediatR;

namespace SzkolenieTechniczne2.Hotel.Domain.Command
{
    public interface ICommand<TResult> : IRequest<TResult> { }
}
