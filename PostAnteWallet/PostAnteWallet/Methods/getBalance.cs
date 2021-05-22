using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PostAnteWallet.Methods
{
    class getBalance
    {

        public class PARAMS
        {
            public string address { get; set; }
            public string assetID { get; set; }
        }

        public class getBalanceToken
        {
            public string jsonrpc { get; set; }
            public int id { get; set; }
            public string method { get; set; }
            public PARAMS PARAMS { get; set; }
        }

        //return value
        public class UtxoID
        {
            public string txID { get; set; }
            public int outputIndex { get; set; }
        }

        public class Result
        {
            public string balance { get; set; }
            public List<UtxoID> utxoIDs { get; set; }
        }

        public class ReturnValue
        {
            public string jsonrpc { get; set; }
            public Result result { get; set; }
            public int id { get; set; }
        }

        public async Task<string> GetBalance(string adress)
        {
            var obj = new getBalanceToken
            {
                jsonrpc = "2.0",
                id = 1,
                method = "avm.getBalance",
                PARAMS = new PARAMS
                {
                    assetID = "Gönderim yapacağınız coinin asset idsi",
                    address = adress
                }
            };

            HttpClient client = new HttpClient();
            var jsonObj = JsonConvert.SerializeObject(obj);
            //  string asd = jsonObj.ToString();

            // var jsonObj = JsonConvert.SerializeObject(obj);

            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("işlem yapacağınız node adresi", content);

                var result = await response.Content.ReadAsStringAsync();
                var asd = JsonConvert.DeserializeObject<ReturnValue>(result);
                return asd.result.balance;
            }
            catch
            {
                return null;
            }

        }

    }
}
