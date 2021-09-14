﻿using Dominio.ServicoModule;
using System;
using System.Collections.Generic;
using ConfigurationManager.Combustivel;

namespace Dominio.AluguelModule
{
    public class AluguelFechado : Aluguel
    {
        public AluguelFechado(Aluguel aluguel, int kmRodados, double tanqueUtilizado, List<Servico> servicosNecessarios, DateTime dataDevolvida) : base(aluguel)
        {
            Veiculo = aluguel.Veiculo;
            Servicos = aluguel.Servicos;
            Cliente = aluguel.Cliente;
            Condutor = aluguel.Condutor;
            TipoPlano = aluguel.TipoPlano;
            DataAluguel = aluguel.DataAluguel;
            KmRodados = kmRodados;
            TanqueUtilizado = tanqueUtilizado;
            ServicosNecessarios = servicosNecessarios;
            DataDevolvida = dataDevolvida;
            DataDevolucao = aluguel.DataDevolucao;
        }
        public int KmRodados { get; set; }
        public double TanqueUtilizado { get; set; }
        public List<Servico> ServicosNecessarios { get; set; }
        public DateTime DataDevolvida { get; set; }
        public override double CalcularTotal()
        {
            double PrecoFinal = base.CalcularTotal();
          
            int diasAtraso = (DataDevolucao - DateTime.Today).Days;

            PrecoFinal += diasAtraso * 50;

            PrecoFinal += CalcularCombustivel();

            ServicosNecessarios.ForEach(x => PrecoFinal += x.Taxa);

            return PrecoFinal;
        }
        private double CalcularCombustivel()
        {
            switch (Veiculo.TipoDeCombustivel)
            {
                case VeiculoModule.TipoCombustivel.Diesel:
                    return TanqueUtilizado * Configuracoes.Configs.ValorDiesel;
                case VeiculoModule.TipoCombustivel.Etanol:
                    return TanqueUtilizado * Configuracoes.Configs.ValorEtanol;
                case VeiculoModule.TipoCombustivel.Gasolina:
                    return TanqueUtilizado * Configuracoes.Configs.ValorGasolina;
                default: return 0;
            }
        }
        public override string Validar()
        {
            string validacao = base.Validar();

            if (KmRodados < 0)
                validacao += "Quilometros rodados necessita ser pelo menos 0\n";

            if (TanqueUtilizado < 0)
                validacao += "Tanque utilizado tem que ser pelo menos 0\n";

            return validacao;
        }
    }
}
