namespace App;

class Student : IUser
{
  public string Username { get; set; }
  public string Email { get; set; }
  public string _password { get; set; }

  public Student(string u, string e, string p)
  {
    Username = u;
    Email = e;
    _password = p;
  }

  public bool TryLogin(string username, string password)
  {
    return username == Email && password == _password;
  }

}