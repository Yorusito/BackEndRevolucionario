namespace VetCare.API.Advice.Domain.Repositories;

public interface IUnitOfWorkA
{
    Task CompleteAsync();
}