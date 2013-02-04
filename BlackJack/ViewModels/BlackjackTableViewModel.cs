namespace Blackjack.ViewModels
{
  using System.Collections.Generic;
  using System.Windows.Input;
  using WPF.ViewModels;
  using WPF.AttachedCommandBehavior;

  public class BlackjackTableViewModel : ViewModelBase
  {
    private List<CardControlViewModel> cards = new List<CardControlViewModel>();
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

    public static readonly RoutedCommand HitMeCommand = new RoutedCommand();

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
