namespace Blackjack.ViewModels
{
  using System.Collections.Generic;

  public class BlackjackTableViewModel : ViewModelBase
  {
    private List<CardControlViewModel> cards;
    public List<CardControlViewModel> Cards
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

    public static readonly SimpleCommand HitMeCommand = new SimpleCommand();

    public BlackjackTableViewModel()
    {
      this.CommandSink.RegisterCommand(HitMeCommand, p => CanHit(), p => HitMe());
    }

    public bool CanHit()
    {
      return true;
    }

    public void HitMe()
    {
      this.Cards.Add(new CardControlViewModel(1));
      this.OnPropertyChanged("Cards");
    }
  }
}
