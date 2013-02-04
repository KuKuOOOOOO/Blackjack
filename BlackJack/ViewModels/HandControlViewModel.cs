namespace Blackjack.ViewModels
{
  using System.Collections.Generic;

  public class HandControlViewModel : ViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the BlackjackHand class
    /// </summary>
    public HandControlViewModel()
    {
      this.Hand = new List<CardControlViewModel>();
    }

    /// <summary>
    /// Initializes a new instance of the BlackjackHand class
    /// Begins the hand with a preset card - this should be used for splitting
    /// </summary>
    public HandControlViewModel(CardControlViewModel card)
    {
      this.Hand = new List<CardControlViewModel>();
      this.Hand.Add(card);
    }

    /// <summary>
    /// Gets the current list of cards associated with this hand
    /// </summary>
    public List<CardControlViewModel> Hand
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
