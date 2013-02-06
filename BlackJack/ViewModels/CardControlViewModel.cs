namespace Blackjack.ViewModels
{
  using Blackjack.DataObjects;

  using WPF.ViewModels;

  /// <summary>
  /// The view model for the CardControlView
  /// </summary>
  public class CardControlViewModel : ViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the CardControlViewModel class
    /// </summary>
    public CardControlViewModel()
    {
    }

    /// <summary>
    /// Initializes a new instance of the CardControlViewModel class
    /// </summary>
    /// <param name="cardValue">The value we want to set the card as</param>
    public CardControlViewModel(uint cardValue)
    {
      this.Card = new Card(cardValue);
    }

    /// <summary>
    /// Gets or sets the card data
    /// </summary>
    public Card Card
    {
      get;
      set;
    }
  }
}
