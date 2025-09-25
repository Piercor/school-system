
namespace App;

class Teacher : IUser
{
  public string Name { get; set; }
  public string Email { get; set; }
  public string _password { get; set; }
  public string IsType { get; set; }

  public Teacher(string u, string e, string p, string it)
  {
    Name = u;
    Email = e;
    _password = p;
    IsType = it;
  }

  public bool TryLogin(string email, string password)
  {
    return email == Email && password == _password;
  }
}