
namespace App;

interface IUser
{
  string Username { get; }
  string _password { get; }
  public bool TryLogin(string username, string password);
}