using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PostAnteWallet.Methods
{
    class SendTokenClass
    {
        public class PARAMS
        {
            public string assetID { get; set; }
            public string amount { get; set; }
            public List<string> from { get; set; }
            public string to { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }

        public class Root
        {
            public string jsonrpc { get; set; }
            public int id { get; set; }
            public string method { get; set; }
            public PARAMS PARAMS { get; set; }
        }

        //returnvalue

        public class ReturnValue
        {
            public string jsonrpc { get; set; }
            public Result result { get; set; }
            public int id { get; set; }
        }

        public class Result
        {
            public string txID { get; set; }
            public string changeAddr { get; set; }
        }

      
        public async Task<string> SendToken(string amount, string adress)
        {
            var obj = new Root
            {
                jsonrpc = "2.0",
                id = 1,
                method = "avm.send",
                PARAMS = new PARAMS
                {
                    assetID = "Göndereceğiniz tokenin Asset idsi",
                    amount = amount,
                    from = new List<string>
                    {
                    "X-fuji148sqvj4nq6f4xv9ke9y9xletreu60m2cvd5uwp"
                    },
                    to = adress,
                    username = "Wallet kullanıcı",
                    password = "Wallet şifresi"
                }
            };

            HttpClient client = new HttpClient();
            var jsonObj = JsonConvert.SerializeObject(obj);
            //  string asd = jsonObj.ToString();

            // var jsonObj = JsonConvert.SerializeObject(obj);

            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("İşlem yapacağınız Node adresi", content);

                var result = await response.Content.ReadAsStringAsync();
                var asd = JsonConvert.DeserializeObject<ReturnValue>(result);
                return asd.result.txID;
            }
            catch
            {
                return null;
            }

        }

    }
}
