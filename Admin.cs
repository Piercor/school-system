
namespace App;

class Admin : IUser
{
  public string Name { get; set; }
  public string Username { get; set; }
  public string _password { get; set; }
  public string IsType { get; set; }

  public Admin(string n, string u, string p, string it)
  {
    Name = n;
    Username = u;
    _password = p;
    IsType = it;
  }

  public bool TryLogin(string username, string password)
  {
    return username == Username && password == _password;
  }
}