namespace Blackjack.BlackjackObjects
{
  using WPF.ViewModels;

  public class Card : ViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the Card class
    /// </summary>
    /// <param name="cardValue">The value we want to set the card as</param>
    public Card(uint cardValue)
    {
      this.CardValue = cardValue;
    }

    /// <summary>
    /// Initializes a new instance of the Card class
    /// </summary>
    /// <param name="card">The card we are duplicating</param>
    public Card(Card card)
    {
      this.ImageSource = card.ImageSource;
      this.CardValue = card.CardValue;
    }

    public string ImageSource
    {
      get;
      private set;
    }

    public uint CardValue
    {
      get;
      private set;
    }
  }
}
