namespace Blackjack.BlackjackObjects
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  public class Player
  {
    public Player()
    {
      this.Hands = new List<BlackjackHand>();
    }

    public List<BlackjackHand> Hands
    {
      get;
      private set;
    }
  }
}
