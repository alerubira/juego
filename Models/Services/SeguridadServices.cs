using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace Juego.Services
{
    public class SeguridadService
    {
        private readonly string _globalSalt;

        public SeguridadService(IConfiguration configuration)
        {
            _globalSalt = configuration["Seguridad:GlobalSalt"]
                ?? throw new Exception("Seguridad:GlobalSalt no configurado");
        }

        public string HashearContraseña(string contraseña)
        {
            byte[] saltBytes = System.Text.Encoding.UTF8.GetBytes(_globalSalt);

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: contraseña,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        public bool VerificarContraseña(string contraseñaIngresada, string hashGuardado)
        {
            return HashearContraseña(contraseñaIngresada) == hashGuardado;
        }
    }
}
