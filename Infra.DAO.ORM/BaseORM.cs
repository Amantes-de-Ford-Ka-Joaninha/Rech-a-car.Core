﻿using Dominio.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.DAO.ORM
{
    public class BaseORM<T> : IRepository<T> where T : Entidade
    {
        protected rech_a_carDbContext Context { get; init; }

        public BaseORM(rech_a_carDbContext context)
        {
            Context = context;
        }
        public List<T> Registros => Context.Set<T>().ToList();

        public T GetById(int id, Type tipo = null)
        {
            return Context.Set<T>().Find(id);
        }
        public void Inserir(T entidade)
        {
            Context.Set<T>().Add(entidade);
            Context.SaveChanges();
        }
        public void Editar(int id, T entidade)
        {
            Context.Update(entidade);
            Context.SaveChanges();
        }
        public void Excluir(int id, Type tipo = null)
        {
            var entidade = GetById(id);
            try
            {
                Context.Remove(entidade);
                Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Existe(int id, Type tipo = null)
        {
            return Context.Set<T>().Where(x => x.Id == id).Any();
        }
        public List<T> FiltroGenerico(string filtro)
        {
            var palavras = filtro.Split(' ');
            return Context.Set<T>().ToList().Where(i => palavras.Any(p => i.ToString().Contains(p, StringComparison.OrdinalIgnoreCase))).ToList();
        }
    }
}
