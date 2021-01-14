using ApiOneCore.Infraestructure.Data;
using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.Entites;
using ApOneCore.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace ApiOneCore.Infraestructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public LoginRepository(OneCoreContext baseDeDatos)
        {
            this.baseDeDatos = baseDeDatos;
        }
        private readonly OneCoreContext baseDeDatos;

        public async Task<Response<Usuario>> Login(Usuario usuario)
        {
            Response<Usuario> responseRepository = new Response<Usuario>();
            try
            {
                await baseDeDatos.Database.OpenConnectionAsync();
                var dbCommand = baseDeDatos.Database.GetDbConnection().CreateCommand();

                #region Paramethers

                DbParameter CorreoParameter = dbCommand.CreateParameter();
                CorreoParameter.ParameterName = "Correo";
                CorreoParameter.Value = usuario.Correo;
                dbCommand.Parameters.Add(CorreoParameter);

                DbParameter passWordParameter = dbCommand.CreateParameter();
                passWordParameter.ParameterName = "Password";
                passWordParameter.Value = usuario.Password;
                dbCommand.Parameters.Add(passWordParameter);
                #endregion

                dbCommand.CommandText = "[dbo].[LoginUsuario]";
                dbCommand.CommandType = System.Data.CommandType.StoredProcedure;

                DbDataReader resultadoDb = await dbCommand.ExecuteReaderAsync();
                if (resultadoDb.HasRows)
                {
                    if (resultadoDb.Read())
                    {
                        responseRepository.Exito = true;
                        responseRepository.Data = new Usuario
                        {
                            Id = resultadoDb.GetGuid(0),
                            Correo = resultadoDb.GetString(1),
                            NombreUsuario = resultadoDb.GetString(2),
                            Password = resultadoDb.GetString(3),
                            Estatus = resultadoDb.GetBoolean(4),
                            Sexo = resultadoDb.GetString(5),
                            FechaCreacion = resultadoDb.GetDateTime(6)
                        };
                    }
                }
                else
                {
                    responseRepository.Mensaje = "Revise Usaurio y Contraseña";
                }
            }
            catch (Exception ex)
            {
                responseRepository.Mensaje = ex.ToString();
            }
            await baseDeDatos.Database.CloseConnectionAsync();
            return responseRepository;
        }
    }
}
