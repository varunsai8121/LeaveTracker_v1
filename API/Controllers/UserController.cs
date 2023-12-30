using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController:ControllerBase
{
    private readonly DataContext dataContext_;
    public UserController(DataContext dataContext)
    {
        dataContext_=dataContext;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers(){
        var users=await dataContext_.Users.ToListAsync();
        return users;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id){
        return await  dataContext_.Users.FindAsync(id);
    }



    
}