using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using WebAPIOracle.Auth;
using System.Security.Principal;
using WebAPIOracle.Entidades;
using WebAPIOracle.Servico;
using Dapper;

namespace WebAPIOracle.Controllers
{
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        private readonly TokenConfiguration _tokenConfiguration;
        private DapperContexto _contexto;

        public LoginController(IOptions<TokenConfiguration> tokenConfiguration, DapperContexto contexto)
        {
            _tokenConfiguration = tokenConfiguration.Value;
            _contexto = contexto;
        }

        [AllowAnonymous]
        [HttpPost]
        public object Login([FromBody]User user)
        {
            bool ok = false;
            Usuario usuario = new Usuario();
            if (user != null)
            {
                usuario = _contexto.ConexaoOracle().Query<Usuario>("select usuarioid,nome,login,senha,email from usuario where LOGIN = :LOGIN and SENHA = :SENHA",
                    new Dictionary<string, object>() { { "LOGIN", user.Login }, { "SENHA", user.Senha } }).FirstOrDefault();
                if (usuario != null)
                {
                    ok = true;
                }
            }

            if (ok)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Login, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Nome),
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao.AddDays(1);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfiguration.Issuer,
                    Audience = _tokenConfiguration.Audience,
                    SigningCredentials = _tokenConfiguration.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        public object UsuarioLogado()
        {
            var nome = User.Identity.Name;
            var guid = User.FindFirst("jti").Value;

            return new
            {
                nome,
                guid
            };

        }
    }
    
}