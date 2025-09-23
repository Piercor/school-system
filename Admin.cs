
namespace App;

class Admin : IUser
{
  public string Name { get; set; }
  public string Username { get; set; }
  public string _password { get; set; }

  public Admin(string n, string u, string p)
  {
    Name = n;
    Username = u;
    _password = p;
  }

  public bool TryLogin(string username, string password)
  {
    return username == Username && password == _password;
  }
}