
namespace App;

class SDocument
{
  public string Author;
  public string Name;
  public string Course;
  public string Grade;
  public string Feedback;
  public string Signed;

  public SDocument(string a, string n, string c, string g, string f, string s)
  {
    Author = a;
    Name = n;
    Course = c;
    Grade = g;
    Feedback = f;
    Signed = s;
  }
}