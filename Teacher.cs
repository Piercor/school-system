
namespace App;

class Teacher : IUser
{
  public string Username { get; set; }
  public string _password { get; set; }
  public string IsType { get; set; }

  public Teacher(string u, string p, string it)
  {
    Username = u;
    _password = p;
    IsType = it;
  }

  public bool TryLogin(string username, string password)
  {
    return username == Username && password == _password;
  }
}