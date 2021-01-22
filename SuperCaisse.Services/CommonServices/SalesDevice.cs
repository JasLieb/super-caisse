using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Services
{
    public abstract class SalesDevice
    {
        public Bracket Bracket { get; protected set; }
        public virtual bool CanCompleteTransaction => GetRemainsDependent() == 0;

        public void AddArticle(Article selectedArticle)
        {
            if (Bracket == null)
                Bracket = new Bracket();

            Bracket.AddArticle(selectedArticle);
        }

        public double GetRemainsDependent()
        {
            return Bracket.GetTotalPrice() - Bracket.GetTotalPaid();
        }

        public Bracket MakeBracketMemento()
        {
            var bracketMemento = Bracket;
            Bracket = null;
            return bracketMemento;
        }

        public void RestoreBracket(Bracket savedBracket)
        {
            if (Bracket != null)
                throw new InvalidOperationException();

            Bracket = savedBracket;
        }
    }
}
