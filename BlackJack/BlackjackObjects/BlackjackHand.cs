namespace Blackjack.BlackjackObjects
{
  using System.Collections.Generic;

  public class BlackjackHand
  {
    /// <summary>
    /// Initializes a new instance of the BlackjackHand class
    /// </summary>
    public BlackjackHand()
    {
      this.Hand = new List<Card>();
    }

    /// <summary>
    /// Initializes a new instance of the BlackjackHand class
    /// Begins the hand with a preset card - this should be used for splitting
    /// </summary>
    public BlackjackHand(Card card)
    {
      this.Hand = new List<Card>();
      this.Hand.Add(card);
    }

    /// <summary>
    /// Gets the current list of cards associated with this hand
    /// </summary>
    public List<Card> Hand
    {
      get;
      private set;
    }

    /// <summary>
    /// Determines the value of the hand based on the current cards
    /// </summary>
    /// <returns>The value of the hand</returns>
    public uint ComputeHandValue()
    {
      return 0;
    }
  }
}
