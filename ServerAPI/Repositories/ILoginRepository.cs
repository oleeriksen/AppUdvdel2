using Core;

namespace ServerAPI.Repositories;

public interface ILoginRepository
{
    bool IsValid(User user);
}