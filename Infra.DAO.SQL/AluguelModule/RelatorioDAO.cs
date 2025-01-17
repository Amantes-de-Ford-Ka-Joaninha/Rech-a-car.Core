﻿using Dominio.AluguelModule;
using Infra.DAO.Shared;
using Infra.Extensions.Methods;
using System;
using System.Data;
using System.IO;

namespace Infra.DAO.AluguelModule
{
    public class RelatorioDAO : IRelatorioRepository
    {
        #region Queries
        private const string sqlInserirEmail =
            @"INSERT INTO [TBEMAIL]
              (
                [ID_ALUGUEL],       
                [PDF]            
              )
                VALUES
              (
                @ID_ALUGUEL,
                @PDF
              )";

        private const string sqlAlterarEmailEnviado =
            @"UPDATE [TBEMAIL]
                SET 
                    [DATA_ENVIADO] = @DATA_ENVIADO
                WHERE [ID] = @ID";

        private const string sqlGetProxEnvio =
            @"SELECT TOP 1 *
                FROM [TBEMAIL] 
              WHERE [DATA_ENVIADO] IS NULL
                ORDER BY [DATA_ENVIADO] DESC";

        private const string sqlExisteEmailPendente =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBEMAIL]
            WHERE 
                [DATA_ENVIADO] IS NULL";

        #endregion

        public void SalvarRelatorio(RelatorioAluguel envio)
        {
            var bytesPdf = envio.StreamAttachment.ToArray();
            Db.Insert(sqlInserirEmail, Db.AdicionarParametro("ID_ALUGUEL", envio.Aluguel.Id, Db.AdicionarParametro("PDF", bytesPdf)));
        }
        public void MarcarEnviado(int idEnvio)
        {
            Db.Update(sqlAlterarEmailEnviado, Db.AdicionarParametro("ID", idEnvio, Db.AdicionarParametro("DATA_ENVIADO", DateTime.Now)));
        }
        public RelatorioAluguel GetProxEnvio()
        {
            if (Db.Exists(sqlExisteEmailPendente))
                return Db.Get(sqlGetProxEnvio, ConverterEmEntidade);
            else
                return null;
        }
        private RelatorioAluguel ConverterEmEntidade(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var aluguel = new AluguelDAO().GetById(Convert.ToInt32(reader["ID_ALUGUEL"]));
            MemoryStream ms = ((byte[])reader["PDF"]).ToMemoryStream();
            //Document pdf = ms.ToPdf();

            return new RelatorioAluguel(aluguel, ms) { Id = id };
        }
    }
}
