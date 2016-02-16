using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.model.bo
{
    public class BO_Usuario : GenericoBO<Usuario>
    {
        public BO_Usuario(EFDBContext dbContext)
            : base(dbContext)
        {
        }

        public BO_Usuario()
            : base(new EFDBContext())
        {
            this._DbContext.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Este método é resposável por resetar a senha de um usuario
        /// <para> 1. Recupera um Usuario atraves do email </para>
        /// <para> 2. Reseta senha do usuario + marca o usuario como senha resetada</para>
        /// <para> 3. Envia um email para usuario com nova senha</para>
        /// </summary>
        /// <returns>Usuario</returns>
        public Usuario doResetarSenha(String email)
        {
            throw new NotImplementedException();
        }

    }
}
