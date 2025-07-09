using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PruebaMasterLoyalty.Data.Entities;
using PruebaMasterLoyalty.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMasterLoyalty.Business.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public AuthResponseDTO? Login(LoginDTO dto)
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.Usuario1 == dto.Usuario && x.Password == dto.Password);
            if (user == null) return null;

            var token = GenerarToken(user);
            return new AuthResponseDTO
            {
                Usuario = user.Usuario1,
                TipoUsuario = user.TipoUsuario,
                Token = token
            };
        }

        private string GenerarToken(Usuario usuario)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, usuario.Usuario1),
            new Claim(ClaimTypes.Role, usuario.TipoUsuario),
            new Claim("IdUsuario", usuario.IdUsuario.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
