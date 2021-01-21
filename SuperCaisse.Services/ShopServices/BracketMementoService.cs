using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperCaisse.Services
{
    public class BracketMementoService
    {
        public List<Bracket> SavedBrackets { get; }

        public BracketMementoService()
        {
            SavedBrackets = new List<Bracket>();
        }

        public void SaveBracket(Bracket bracket)
        {
            SavedBrackets.Add(bracket);
        }

        public Bracket GetSavedBracket(Guid id)
        {
            var savedBracket = SavedBrackets.Find(
                bracket => bracket.Id == id   
            );

            SavedBrackets.Remove(savedBracket);

            return savedBracket;
        }
    }
}
