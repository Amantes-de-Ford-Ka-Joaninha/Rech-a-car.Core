﻿using Dominio.PessoaModule;
using Dominio.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DAO.ORM.Repositories
{
    class CnhORM : BaseRepository<CNH>, ICnhRepository

    {
        public void Excluir(int idCnh)
        {
            Context.Remove(GetById(idCnh));
            Context.SaveChanges();
        }

        public CNH GetById(int idCnh)
        {
            return Context.Set<CNH>().Find(idCnh);
        }
    }
}
