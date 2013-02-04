namespace Blackjack.ViewModels
{
  using WPF.ViewModels;

  public class CardControlViewModel : ViewModelBase
  {
    private string imageSource = string.Empty;

    /// <summary>
    /// Initializes a new instance of the Card class
    /// </summary>
    /// <param name="cardValue">The value we want to set the card as</param>
    public CardControlViewModel(uint cardValue)
    {
      this.CardValue = cardValue > 9 ? 10 : cardValue;
      this.ImageSource = string.Format("..\\Images\\{0}.png", cardValue);
    }

    /// <summary>
    /// Initializes a new instance of the Card class
    /// </summary>
    /// <param name="card">The card we are duplicating</param>
    public CardControlViewModel(CardControlViewModel card)
    {
      this.ImageSource = card.ImageSource;
      this.CardValue = card.CardValue;
    }

    public string ImageSource
    {
      get
      {
        return this.imageSource;
      }
      private set
      {
        if (value == this.imageSource)
        {
          return;
        }

        this.imageSource = value;
        this.OnPropertyChanged("ImageSource");
      }
    }

    public uint CardValue
    {
      get;
      private set;
    }
  }
}
