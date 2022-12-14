using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserMicroservice.Data;
using UserMicroservice.Models;

namespace UserMicroservice.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _dataContext;

    public UsersController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<ActionResult<UsersListResponseModel>> Get(int skip = 0, int take = 20)
    {
        var result = await _dataContext.Users.OrderByDescending(x => x.Created)
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return Ok(new UsersListResponseModel(result));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Add(UserRequestModel requestModel)
    {
        var user = new User(requestModel.FirstName, requestModel.LastName, requestModel.Patronymic);
        _dataContext.Add(user);
        await _dataContext.SaveChangesAsync();

        return Ok(new CreatedUserResponse(user.Id));
    }
}
