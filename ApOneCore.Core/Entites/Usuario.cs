namespace ApOneCore.Core.Entites
{
    using System;
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public bool? Estatus { get; set; }
        public string Sexo { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
