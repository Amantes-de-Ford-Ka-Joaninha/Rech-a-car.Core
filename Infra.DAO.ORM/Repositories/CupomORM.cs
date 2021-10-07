﻿using Dominio.CupomModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DAO.ORM.Repositories
{
    class CupomORM : BaseRepository<Cupom>, ICupomRepository
    {
        public Cupom GetByName(string nomeCupom)
        {
            return Set<Cupom>().Where(x=> x.Nome == nomeCupom).FirstOrDefault<Cupom>();
        }
    }
}
