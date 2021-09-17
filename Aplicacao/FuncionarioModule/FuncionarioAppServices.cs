﻿using Aplicacao.Shared;
using Dominio.PessoaModule;
using Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.FuncionarioModule
{
    public class FuncionarioAppServices : EntidadeAppServices<Funcionario>
    {
        public override IFuncionarioRepository Repositorio { get; }

        public FuncionarioAppServices(IFuncionarioRepository repositorio)
        {
            Repositorio = repositorio;
        }
    }
}
