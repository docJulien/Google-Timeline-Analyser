using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APS.Helpers
{
    public class CommStatus
    {
        public static Dictionary<string, string> CommStatusDictionary =
        new Dictionary<string, string>
        {
            { "MiseEnCommande", "Mise en commande" },
            { "Planification", "Planification" },
            { "ProductionCustom", "Production \"Custom\"" },
            { "ProductionsStandard", "Productions standard" },
            { "Commande", "Commande" },
            { "Shipping", "Shipping" },
            { "Sablage", "Sablage" },
            { "Finition", "Finition" },
            { "EmballageControle", "Emballage/Contrôle" },
            { "Livraison", "Livraison" },
            { "Installation", "Installation" },
            { "EntrepotPourRamassage", "Entrepôt(Pour ramassage)" },
            { "Facturation", "Facturation" }
        };
    }
}
