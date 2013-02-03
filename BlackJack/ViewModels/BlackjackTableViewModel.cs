namespace Blackjack.ViewModels
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using WPF.ViewModels;
  using WPF.AttachedCommandBehavior;

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

    public SimpleCommand HitMeCommand;

    public BlackjackTableViewModel()
    {
      HitMeCommand = new SimpleCommand();

      this.CommandSink.RegisterCommand(HitMeCommand, CanHit, HitMe);
    }

    public bool CanHit(object o)
    {
      return true;
    }

    public void HitMe(object o)
    {
      this.Cards.Add(new CardControlViewModel(1));
      this.OnPropertyChanged("Cards");
    }
  }
}
