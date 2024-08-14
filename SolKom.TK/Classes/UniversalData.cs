using SolKom.TK.Classes;
using System.Security.AccessControl;
using System.Linq;
using RandN;
using SolKom.TK.Classes.Data;

namespace SolKom.TK
{
    public class UniversalData
    {
        public static UniversalData Instance;

        private readonly Galaxy Galaxy;

        public UniversalData()
        {
            Instance = this;
            Galaxy = new Galaxy();
            FactionManager.ResetRelations();
        }



        /* public static bool IsHostile(Faction faction1, Faction faction2)
         {
             int index1 = (int)faction1;
             int index2 = (int)faction2;
             return relations[index1][index2];
         }*/
    }

}
