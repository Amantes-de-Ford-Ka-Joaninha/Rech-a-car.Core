﻿using Dominio.PessoaModule;
using Dominio.PessoaModule.ClienteModule;
using Dominio.Shared;
using System;
using System.Linq;

namespace Infra.DAO.ORM.Repositories
{
    public class ClientePJORM : BaseORM<ClientePJ>, IClientePJRepository
    {
        public IRepository<Motorista> MotoristaRepository => new BaseORM<Motorista>();

        public bool ExisteDocumento(string documento, Type type)
        {
            return Context.Set<ClientePJ>().Where(c=>c.Documento== documento).Count() != 0;
        }
    }
}