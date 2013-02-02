namespace Blackjack
{
  using System;

  public class BlackjackController
  {
    private static readonly Lazy<BlackjackController> instance =
      new Lazy<BlackjackController>(() => new BlackjackController());

    private BlackjackController()
    {
    }

    public static BlackjackController Controller
    {
      get
      {
        return instance.Value;
      }
    }
  }
}
