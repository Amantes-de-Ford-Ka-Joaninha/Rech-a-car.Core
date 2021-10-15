﻿using Dominio.AluguelModule;
using Dominio.Repositories;

namespace Infra.DAO.ORM.Repositories
{
    public class AluguelFechadoORM : BaseORM<AluguelFechado>, IAluguelFechadoRepository
    {
        public AluguelFechadoORM(rech_a_carDbContext context) : base(context)
        {
        }
    }
}
