
namespace App;

class Message
{
  public string Receiver;
  public string Text;
  public string Sender;
  public bool Read;

  public Message(string r, string t, string s, bool rd)
  {
    Receiver = r;
    Text = t;
    Sender = s;
    Read = rd;
  }
}