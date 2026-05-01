using Microsoft.AspNetCore.Mvc;
using Operations.DTOs;
using Operations.Services;

namespace Operations.Controllers {
[ApiController]
[Route("api/auth")]
public class AuthController:ControllerBase{
 private readonly AuthService _auth;
 public AuthController(AuthService a){_auth=a;}
 [HttpPost("login")]
 public IActionResult Login([FromBody]LoginRequestDTO r){
  var u=_auth.ValidarUsuario(r.Username,r.Password);
  if(u==null)return Unauthorized();
  return Ok(new LoginResponseDTO{Username=u.Username,Rol=u.Rol});
 }}}
