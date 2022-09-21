using System.Text;
using API.DbModels.Contexts;
using API.Dtos.Users;
using API.Services.Firebase;
using API.Services.Users;
using AutoMapper;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("api/[Controller]")]
public class UsersController : ControllerBase
{
    private readonly FbContext _context;
    private readonly IMapper _mapper;
    private readonly IUserManagement _userManagement;
    public UsersController(FbContext context, IUserManagement userManagement, IMapper mapper)
    {
        _context = context;
        _userManagement = userManagement;
        _mapper = mapper;
    }
    [AllowAnonymous]
    [HttpPost("GetToken")]
    public async Task<IActionResult> GetToken(string mail, string password)
    {
        HttpClient client = new();
        var test = new { email = mail, password, returnSecureToken = true };
        var usuario = JsonConvert.SerializeObject(test);
        var Url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyDwFKPD4xvIbD1huSnbQG44GTXP2h5_kYM";
        var data = new StringContent(usuario, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(Url, data);

        var result = response.Content.ReadAsStringAsync().Result;

        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(UserDto request)
    {
        var user = await _userManagement.CreateUserAsync(request);

        var userResponse = _mapper.Map<UserDto>(request);

        return Ok(userResponse);

    }
}