﻿using ApiOneCore.Infraestructure.Data;
using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.Entites;
using ApOneCore.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace ApiOneCore.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        #region Constructor
        public UsuarioRepository(OneCoreContext baseDeDatos)
        {
            this.baseDeDatos = baseDeDatos;
        }
        #endregion

        #region Atributos
        private readonly OneCoreContext baseDeDatos;
        #endregion

        #region Métodos
        public async Task<SimpleResponse> AltaUsuario(Usuario usuario)
        {
            SimpleResponse simpleResponseAltaUsuario = new SimpleResponse();
            await baseDeDatos.Database.OpenConnectionAsync();
            var dbCommand = baseDeDatos.Database.GetDbConnection().CreateCommand();
            try
            {
                #region Paramethers

                DbParameter CorreoParameter = dbCommand.CreateParameter();
                CorreoParameter.ParameterName = "Correo";
                CorreoParameter.Value = usuario.Correo;
                dbCommand.Parameters.Add(CorreoParameter);

                DbParameter NombreUsuarioParameter = dbCommand.CreateParameter();
                NombreUsuarioParameter.ParameterName = "NombreUsuario";
                NombreUsuarioParameter.Value = usuario.NombreUsuario;
                dbCommand.Parameters.Add(NombreUsuarioParameter);

                DbParameter passWordParameter = dbCommand.CreateParameter();
                passWordParameter.ParameterName = "Password";
                passWordParameter.Value = usuario.Password;
                dbCommand.Parameters.Add(passWordParameter);

                DbParameter SexoParameter = dbCommand.CreateParameter();
                SexoParameter.ParameterName = "Sexo";
                SexoParameter.Value = usuario.Sexo;
                dbCommand.Parameters.Add(SexoParameter);
                #endregion

                dbCommand.CommandText = "[dbo].[IngresarUsuario]";
                dbCommand.CommandType = System.Data.CommandType.StoredProcedure;

                DbDataReader resultadoDb = await dbCommand.ExecuteReaderAsync();
                if (resultadoDb.HasRows)
                {
                    if (resultadoDb.Read())
                    {
                        simpleResponseAltaUsuario.Exito = resultadoDb.GetBoolean(0);
                        simpleResponseAltaUsuario.Mensaje = resultadoDb.GetString(1);
                    }
                }

            }
            catch (Exception ex)
            {
                simpleResponseAltaUsuario.Mensaje = ex.ToString();
            }
            await baseDeDatos.Database.CloseConnectionAsync();
            return simpleResponseAltaUsuario;
        } 
        #endregion
    }
}
