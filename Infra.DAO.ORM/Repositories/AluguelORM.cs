﻿using Dominio.AluguelModule;

namespace Infra.DAO.ORM.Repositories
{
    public class AluguelORM : BaseORM<Aluguel>, IAluguelRepository
    {
        public AluguelORM(rech_a_carDbContext context) : base(context)
        {
        }
    }
}
