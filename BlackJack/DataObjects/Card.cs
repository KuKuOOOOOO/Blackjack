// -----------------------------------------------------------------------
// <copyright file="Card.cs" company="BLIZZARD ENTERTAINMENT">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Blackjack.DataObjects
{
  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class Card
  {
    /// <summary>
    /// Initializes a new instance of the Card class
    /// </summary>
    /// <param name="cardValue">The value we want to set the card as</param>
    public Card(uint cardValue)
    {
      this.CardValue = cardValue > 9 ? 10 : cardValue;
      this.ImageSource = string.Format("..\\Images\\{0}.png", cardValue);
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
