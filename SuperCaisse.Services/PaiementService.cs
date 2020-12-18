using SuperCaisse.Model;
using System.Linq;

namespace SuperCaisse.Services
{
    public class PaiementService
    {
        // TODO Extract value as new class
        public bool PayerPanierByUser(Article[] articles, User user)
        {
            var facture = new Facture(articles, user, "")
        }
    }
}
