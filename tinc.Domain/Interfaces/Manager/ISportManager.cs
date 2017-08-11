using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinc.Domain.Interfaces.Manager
{
    public interface ISportManager
    {
        Guid Create(Dto.Sport sport);
        void Update(Dto.Sport sport);
        void Delete(Dto.Sport sport);
        Dto.Sport Get(Guid id);
        List<Dto.Sport> GetAll();
    }
}
