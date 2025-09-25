
namespace App;

interface IUser
{
  string Name { get; set; }
  string Email { get; set; }
  string _password { get; set; }
  string IsType { get; set; }
  public bool TryLogin(string email, string password);
}