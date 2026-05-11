using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AppCore.Models;
using AppCore.Security; 

namespace Operations.Services
{
    public class AuthService
    {
        private readonly IConfiguration _c;
        private readonly IPasswordHasher _passwordHasher; // Inyectamos el encriptador

        public AuthService(IConfiguration c, IPasswordHasher passwordHasher)
        {
            _c = c;
            _passwordHasher = passwordHasher; 
        }

      public Usuario ValidarUsuario(string u, string p)
{
    using var cn = new SqlConnection(
        _c.GetConnectionString("DefaultConnection")
    );

    using var cmd = new SqlCommand(
        "SELECT Id, Username, PasswordHash, Rol FROM Usuarios WHERE Username = @User AND Estado = 1",
        cn
    );

    cmd.Parameters.AddWithValue("@User", u.Trim());

    cn.Open();

    using var r = cmd.ExecuteReader();

    if (r.Read())
    {
        string hash = r["PasswordHash"]?.ToString()?.Trim();

        System.Console.WriteLine("Usuario encontrado: " + r["Username"]);
        System.Console.WriteLine("Password recibido: [" + p + "]");
        System.Console.WriteLine("Hash BD: [" + hash + "]");
        System.Console.WriteLine("Longitud hash: " + hash.Length);

        bool ok = _passwordHasher.VerifyPassword(
            p.Trim(),
            hash
        );

        System.Console.WriteLine("Resultado BCrypt: " + ok);

        if (ok)
        {
            return new Usuario
            {
                Id = (int)r["Id"],
                Username = r["Username"].ToString(),
                Rol = r["Rol"].ToString()
            };
        }
    }

    return null;
       }
    }
}