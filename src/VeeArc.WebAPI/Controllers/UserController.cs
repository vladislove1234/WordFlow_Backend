using Microsoft.AspNetCore.Mvc;
using VeeArc.Application.Common.Interfaces;

namespace VeeArc.WebAPI.Controllers;

[Route("@controller")]

public class UserController : ApiControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpPost] 
    public async Task<IActionResult> CreateUser()
    {
        return null;
    }
    
    [HttpPatch] 
    public Task<IActionResult> UpdateUser(){
        throw new NotImplementedException();
    }
    
    [HttpDelete] 
    public Task<IActionResult> DeleteUser(){
        throw new NotImplementedException();
    }
    
    [HttpGet] 
    public async Task<IActionResult> GetUser(int id){
        await _userRepository.GetByIdAsync(2);

        return Ok();
    }
}