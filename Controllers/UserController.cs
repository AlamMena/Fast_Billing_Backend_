using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("api/[Controller]")]
public class UsersController : ControllerBase
{
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
}