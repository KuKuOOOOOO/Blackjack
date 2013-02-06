namespace Blackjack.ViewModels
{
  using System.Collections.Generic;

  using Blackjack.DataObjects;

  using WPF.ViewModels;

  /// <summary>
  /// Contains data relevant to a player's hand
  /// </summary>
  public class HandControlViewModel : ViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the HandControlViewModel class
    /// </summary>
    public HandControlViewModel()
    {
      this.Hand = new List<Card>();
    }


    /// <summary>
    /// Initializes a new instance of the HandControlViewModel class
    /// Begins the hand with a preset card - this should be used for splitting
    /// </summary>
    /// <param name="card">The card we wish to start the hand with</param>
    public HandControlViewModel(Card card)
    {
      this.Hand = new List<Card>
        {
          card
        };
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
