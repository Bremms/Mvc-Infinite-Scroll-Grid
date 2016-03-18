using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannedHistoryTest.Models
{
    public interface IBannedClientHistory
    {
    BannedClientHistory FindBy(int banned_id);
    IQueryable<BannedClientHistory> FindAll();
    void Add(BannedClientHistory bannedClient);
    void Delete(BannedClientHistory client);
    void SaveChanges();
    }

}