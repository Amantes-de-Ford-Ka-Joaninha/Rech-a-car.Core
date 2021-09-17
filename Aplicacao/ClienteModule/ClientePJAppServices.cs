﻿using Aplicacao.Shared;
using Dominio.PessoaModule;
using Dominio.PessoaModule.ClienteModule;
using Dominio.Shared;

namespace Aplicacao.ClienteModule
{
    public class ClientePJAppServices : EntidadeAppServices<ClientePJ>
    {
        public IEntidadeRepository<MotoristaEmpresa> RepositorioMotorista { get; }
        public ClientePJAppServices(IEntidadeRepository<ClientePJ> repositorio, IEntidadeRepository<MotoristaEmpresa> repositorioMotorista)
        {
            RepositorioMotorista = repositorioMotorista;
            Repositorio = repositorio;
        }
        public override IEntidadeRepository<ClientePJ> Repositorio { get; }
    }
}
