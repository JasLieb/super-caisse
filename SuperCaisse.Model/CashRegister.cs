using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Model
{
    public class CashRegister
    {
        public Cashier Cashier { get; }
        public Bracket Bracket { get; private set; }

        public CashRegister(Cashier cashier)
        {
            Cashier = cashier;
        }

        public void AddArticle(Article selectedArticle)
        {
            if (Bracket == null)
                Bracket = new Bracket();

            Bracket.AddArticle(selectedArticle);
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
