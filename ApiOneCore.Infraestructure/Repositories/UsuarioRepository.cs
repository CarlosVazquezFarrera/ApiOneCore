﻿using ApiOneCore.Infraestructure.Data;
using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.Entites;
using ApOneCore.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Ejecuta el Procedimiento almacneado de la base de datos que realizar el 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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

                DbParameter EstadoParameter = dbCommand.CreateParameter();
                EstadoParameter.ParameterName = "Estatus";
                EstadoParameter.Value = usuario.Estatus;
                dbCommand.Parameters.Add(EstadoParameter);
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
            finally
            {
                await baseDeDatos.Database.CloseConnectionAsync();
            }
            return simpleResponseAltaUsuario;
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado de la base de datos que realiza la actualización de la entidad
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> ActualizarUsuario(Usuario usuario)
        {
            SimpleResponse simpleResponseActualizacionUsuario = new SimpleResponse();
            await baseDeDatos.Database.OpenConnectionAsync();
            var dbCommand = baseDeDatos.Database.GetDbConnection().CreateCommand();
            try
            {
                #region Paramethers

                DbParameter IdParameter = dbCommand.CreateParameter();
                IdParameter.ParameterName = "Id";
                IdParameter.Value = usuario.Id;
                dbCommand.Parameters.Add(IdParameter);

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

                dbCommand.CommandText = "[dbo].[ActualizarUsuario]";
                dbCommand.CommandType = System.Data.CommandType.StoredProcedure;

                DbDataReader resultadoDb = await dbCommand.ExecuteReaderAsync();
                if (resultadoDb.HasRows)
                {
                    if (resultadoDb.Read())
                    {
                        simpleResponseActualizacionUsuario.Exito = resultadoDb.GetBoolean(0);
                        simpleResponseActualizacionUsuario.Mensaje = resultadoDb.GetString(1);
                    }
                }
            }
            catch (Exception ex)
            {
                simpleResponseActualizacionUsuario.Mensaje = ex.ToString();
            }
            finally
            {
                await baseDeDatos.Database.CloseConnectionAsync();
            }
            return simpleResponseActualizacionUsuario;
        }

        public async Task<SimpleResponse> EliminarUsuario(Guid IdUsuario)
        {
            SimpleResponse simpleResponseActualizacionUsuario = new SimpleResponse();
            await baseDeDatos.Database.OpenConnectionAsync();
            var dbCommand = baseDeDatos.Database.GetDbConnection().CreateCommand();
            try
            {
                #region Paramethers

                DbParameter IdParameter = dbCommand.CreateParameter();
                IdParameter.ParameterName = "Id";
                IdParameter.Value = IdUsuario;
                dbCommand.Parameters.Add(IdParameter);

                #endregion

                dbCommand.CommandText = "[dbo].[EliminarUsuario]";
                dbCommand.CommandType = System.Data.CommandType.StoredProcedure;

                DbDataReader resultadoDb = await dbCommand.ExecuteReaderAsync();
                if (resultadoDb.HasRows)
                {
                    if (resultadoDb.Read())
                    {
                        simpleResponseActualizacionUsuario.Exito = resultadoDb.GetBoolean(0);
                        simpleResponseActualizacionUsuario.Mensaje = resultadoDb.GetString(1);
                    }
                }
            }
            catch (Exception ex)
            {
                simpleResponseActualizacionUsuario.Mensaje = ex.ToString();
            }
            finally
            {
                await baseDeDatos.Database.CloseConnectionAsync();
            }
            return simpleResponseActualizacionUsuario;
        }
        
        /// <summary>
        /// Obtiene los usuarios que se encuentran en la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            Response<List<Usuario>> responseUsuarios = new Response<List<Usuario>>();
            await baseDeDatos.Database.OpenConnectionAsync();
            var dbCommand = baseDeDatos.Database.GetDbConnection().CreateCommand();
            try
            {
                dbCommand.CommandText = "[dbo].[ConsutarUsuarios]";
                dbCommand.CommandType = System.Data.CommandType.StoredProcedure;

                DbDataReader resultadoDb = await dbCommand.ExecuteReaderAsync();
                if (resultadoDb.HasRows)
                {
                    responseUsuarios.Data = new List<Usuario>();
                    while (resultadoDb.Read())
                    {
                        responseUsuarios.Data.Add( new Usuario
                        {
                            Id = resultadoDb.GetGuid(0),
                            Correo = resultadoDb.GetString(1),
                            NombreUsuario = resultadoDb.GetString(2),
                            Estatus = resultadoDb.GetBoolean(3),
                            Sexo = resultadoDb.GetString(4)
                        });
                    }
                    responseUsuarios.Exito = true;
                }
            }
            catch (Exception ex)
            {
                responseUsuarios.Mensaje = ex.ToString();
            }
            finally
            {
                await baseDeDatos.Database.CloseConnectionAsync();
            }
            return responseUsuarios;
        }
        #endregion
    }
}
