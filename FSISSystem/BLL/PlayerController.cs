using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSISSystem.DAL;
using FSISSystem.ENTITIES;
using System.Data.SqlClient;
namespace FSISSystem.BLL
{
    public class PlayerController
    {
        public List<Player> Players_FindByID(int PlayerID)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results =
                   context.Database.SqlQuery<Player>("Player_GetByTeam @ID"
                       , new SqlParameter("ID", PlayerID));
                return results.ToList();
                //return context.Players.Find(PlayerID);
            }
        }

        
    }
}
