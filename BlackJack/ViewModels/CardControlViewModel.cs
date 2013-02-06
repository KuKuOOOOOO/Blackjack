namespace Blackjack.ViewModels
{
  using Blackjack.DataObjects;

  using WPF.ViewModels;

  public class CardControlViewModel : ViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the Card class
    /// </summary>
    /// <param name="cardValue">The value we want to set the card as</param>
    public CardControlViewModel(uint cardValue)
    {
      this.Card = new Card(cardValue);
    }

    public Card Card
    {
      get;
      private set;
    }
  }
}
