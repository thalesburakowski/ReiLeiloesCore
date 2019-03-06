﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

using System.Text;
using System.Security.Cryptography;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class CriptografarSenha : IStrategy
    {
        public string Processar(Entity entidade)
        {
            var _stringHash = "";
            try
            {
                if (entidade is User)
                {
                    var user = (User)entidade;

                    UnicodeEncoding _encode = new UnicodeEncoding();
                    byte[] _hashBytes, _massageBytes = _encode.GetBytes(user.Password);
                    SHA512Managed _sha512Manager = new SHA512Managed();
                    _hashBytes = _sha512Manager.ComputeHash(_massageBytes);

                    foreach (byte b in _hashBytes)
                    {
                        _stringHash += String.Format("{0:X2}", b);
                    }
                    user.Password = _stringHash;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
    }
}
