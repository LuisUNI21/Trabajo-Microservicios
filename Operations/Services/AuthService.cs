using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AppCore.Models;

namespace Operations.Services{
public class AuthService{
 private readonly IConfiguration _c;
 public AuthService(IConfiguration c){_c=c;}
 public Usuario ValidarUsuario(string u,string p){
  using var cn=new SqlConnection(_c.GetConnectionString("DefaultConnection"));
  using var cmd=new SqlCommand("sp_ValidarAcceso",cn);
  cmd.CommandType=CommandType.StoredProcedure;
  cmd.Parameters.AddWithValue("@User",u);
  cmd.Parameters.AddWithValue("@Pass",p);
  cn.Open();
  using var r=cmd.ExecuteReader();
  if(r.Read()){
   return new Usuario{Id=(int)r["Id"],Username=r["Username"].ToString(),Rol=r["Rol"].ToString()};
  }
  return null;
 }}}
