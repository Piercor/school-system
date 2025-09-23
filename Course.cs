
namespace App;

class Course
{
  public string Name;
  public string StartDate;
  public string EndDate;
  public string Teacher;
  public int Points;
  public bool Active;
  public List<string> Students;

  public Course(string n, string sd, string ed, string t, int p, bool a, List<string> s)
  {
    Name = n;
    StartDate = sd;
    EndDate = ed;
    Teacher = t;
    Points = p;
    Active = a;
    Students = s;
  }
}