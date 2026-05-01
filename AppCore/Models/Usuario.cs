using System;
namespace AppCore.Models {
 public class Usuario {
  public int Id { get; set; }
  public string Username { get; set; }
  public string Password { get; set; }
  public string Rol { get; set; }
  public DateTime FechaCreacion { get; set; }
  public bool Estado { get; set; }
 }}