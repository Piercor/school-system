
namespace App;

class Teacher : IUser
{
  public string Username { get; set; }
  public string _password { get; set; }

  public Teacher(string u, string p)
  {
    Username = u;
    _password = p;
  }

  public bool TryLogin(string username, string password)
  {
    return username == Username && password == _password;
  }
}