namespace Blackjack.ViewModels
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using WPF.ViewModels;

  public class PlayerControlViewModel : ViewModelBase
  {
    public PlayerControlViewModel()
    {
      this.Hands = new List<HandControlViewModel>();
    }

    public List<HandControlViewModel> Hands
    {
      get;
      private set;
    }
  }
}
