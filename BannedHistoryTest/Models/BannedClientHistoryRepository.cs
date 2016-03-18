using BannedHistoryTest.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BannedHistoryTest.Models
{
    public class BannedClientHistoryRepository : IBannedClientHistory
    {
        private DbEntitiesContext context;
        private DbSet<BannedClientHistory> clients;
        public BannedClientHistoryRepository(DbEntitiesContext context)
        {
            this.context = context;
            clients = context.BannedClientsHistory;
        }
        public void Add(BannedClientHistory bannedClient)
        {
            clients.Add(bannedClient);
        }

        public void Delete(BannedClientHistory client)
        {
            clients.Remove(client);
        }

        public Task<List<BannedClientHistory>> FindAllAsync()
        {
            
            return clients.ToListAsync();
        }
        public List<BannedClientHistory> FindExact(int from, int to)
        {
            return clients.OrderBy(w => w.ID).Skip(from).Take(Math.Abs(to - from)).ToList();
        }
        public int GetTotalBans()
        {
            return clients.Count();
        }
        public BannedClientHistory GetLastBan()
        {
            return clients.OrderByDescending(w => w.ID).First();
        }
        public BannedClientHistory FindBy(int banned_id)
        {
            return clients.Find(banned_id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

       public  IQueryable<BannedClientHistory> FindAll()
        {
            return clients;
        }
    }
}