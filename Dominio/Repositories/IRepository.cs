﻿using System;
using System.Collections.Generic;

namespace Dominio.Shared
{
    public interface IRepository<T> where T : IEntidade
    {
        void Inserir(T entidade);
        void Editar(int id, T entidade);
        bool Excluir(int id, Type tipo = null);
        bool Existe(int id, Type tipo = null);
        T GetById(int id, Type tipo = null);
        List<T> Registros { get; }
        List<T> FiltroGenerico(string filtro);
    }
}
