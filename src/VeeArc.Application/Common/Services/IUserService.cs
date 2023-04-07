using VeeArc.Application.Common.Interfaces;
using VeeArc.Domain.Entities;

namespace VeeArc.Application.Common.Services;

public interface IUserService
{
    public Task<User> CreateUser()
    {
        return null;
    }
}