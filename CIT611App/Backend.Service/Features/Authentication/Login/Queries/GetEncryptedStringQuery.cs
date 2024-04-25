using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Service.Data;
using Backend.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System;
using Backend.Service.Features.Common;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Service.Features.Authentication.Login.Queries
{
   
    public record GetEncryptedStringQuery(string str , string salt ="") : IRequest<string>;
    public class GetEncryptedStringQueryHandler : IRequestHandler<GetEncryptedStringQuery, string>
    {
        public GetEncryptedStringQueryHandler()
        {
        }
        public async Task<string> Handle(GetEncryptedStringQuery request, CancellationToken cancellationToken)
        {
            var salt = request.salt;
                if (!string.IsNullOrEmpty(salt))
                    salt = Constatns.Salt;
                string result;
                if (request.str== "")
                {
                    result = "";
                }
                else
                {
                    UTF8Encoding uTF8Encoding = new UTF8Encoding();
                    MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                    byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(salt));
                    TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                    tripleDESCryptoServiceProvider.Key = key;
                    tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
                    tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
                    byte[] bytes = uTF8Encoding.GetBytes(request.str);
                    byte[] inArray;
                    try
                    {
                        ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
                        inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
                    }
                    finally
                    {
                        tripleDESCryptoServiceProvider.Clear();
                        mD5CryptoServiceProvider.Clear();
                    }
                    result = Convert.ToBase64String(inArray);
                }
                return result;
            

        }

    }

}
