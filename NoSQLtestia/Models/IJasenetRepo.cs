using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace NoSQLtestia.Models
{
    public interface IJasenetRepo
    {
        Task Add(Jasenet jasenet);
        Task Update(Jasenet jasenet);
        Task Delete(string id);
        Task<Jasenet> GetJasenet(string id);
        Task<IEnumerable<Jasenet>> GetJasenet();
    }
}