
namespace App;

interface IUser
{
  string Name { get; }
  string Email { get; }
  string _password { get; }
  public bool TryLogin(string email, string password);
}