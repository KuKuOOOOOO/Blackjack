namespace Blackjack.ViewModels
{
  using System.Collections.Generic;
  using System.Windows.Input;

  using Blackjack.DataObjects;

  using WPF.ViewModels;

  public class BlackjackTableViewModel : ViewModelBase
  {
    private List<Card> cards = new List<Card>();
    public List<Card> Cards
    {
      get
      {
        return this.cards;
      }
      set
      {
        if (value == this.cards)
        {
          return;
        }

        this.cards = value;
        this.OnPropertyChanged("Cards");
      }
    }

    public static readonly RoutedCommand HitMeCommand = new RoutedCommand();

    public BlackjackTableViewModel()
    {
      this.CommandSink.RegisterCommand(HitMeCommand, p => CanHit(), p => HitMe());
      this.Cards.Add(new Card(2));
    }

    public bool CanHit()
    {
      return true;
    }

    public void HitMe()
    {
      List<Card> newList = new List<Card>(this.cards)
        {
          new Card(1)
        };
      this.Cards = newList;
    }
  }
}
