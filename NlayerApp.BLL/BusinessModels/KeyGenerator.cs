using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NlayerApp.BLL.DTO;
using NlayerApp.BLL.Interfaces;
namespace NlayerApp.BLL.BusinessModels
{
    public class KeyGenerator : IKeyGenerator
    {
        static readonly int baseNum = 62;
        static readonly String baseDigits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public string Create(int id)
        {
            
            var toValue = new StringBuilder(id == 0 ? "0" : "");

            while (id != 0)
            {
                int mod = (int)(id % baseNum);
                toValue.Insert(0, baseDigits.Substring(mod, 1));
                id = id / baseNum;
            }

            return toValue.ToString();
        }
    }
}

