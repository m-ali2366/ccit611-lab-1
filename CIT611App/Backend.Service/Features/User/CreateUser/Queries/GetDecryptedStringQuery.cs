using MediatR;
using Backend.Service.Common.Views;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Features.User.CreateUser;
using Backend.Service.Data;
using MapsterMapper;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;
using System.Text;
using System;
using Microsoft.VisualBasic;
using Backend.Service.Features.Common;

namespace Backend.Service.Features.CreateUser.Queries
{
    public record GetDecryptedStringQuery(string str, string salt) : IRequest<string>;
    public class GetDecryptedStringQueryHandler : IRequestHandler<GetDecryptedStringQuery, string>
    {
        private readonly Repository<Models.User> _repository;    
        private readonly IMapper _mapper;    
        public GetDecryptedStringQueryHandler(Repository<Models.User> repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public  async Task<string> Handle(GetDecryptedStringQuery request, CancellationToken cancellationToken)
        {
            var salt = request.salt;
            if (!string.IsNullOrEmpty(salt))
                salt = Constatns.Salt;
            string result;
            if (string.IsNullOrEmpty(request.str))
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
                byte[] array = Convert.FromBase64String(request.str);
                byte[] bytes;
                try
                {
                    ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
                    bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
                }
                catch (Exception ex)
                {
                    bytes = null;
                }
                finally
                {
                    tripleDESCryptoServiceProvider.Clear();
                    mD5CryptoServiceProvider.Clear();
                }
                result = uTF8Encoding.GetString(bytes);
            }
            return result;

        }
    }
}
