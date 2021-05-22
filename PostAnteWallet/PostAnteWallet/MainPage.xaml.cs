using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using PostAnteWallet.Methods;
using Xamarin.Essentials;
//using ModernHttpClient;

namespace PostAnteWallet
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            TabbedLabel();
        }


        
        private async void Button_Clicked(object sender, EventArgs e)
        {

            SendTokenClass sendmoney = new SendTokenClass();
           var asd = await sendmoney.SendToken(send_amount.Text, walled_adress.Text);
            if (asd == null)
                await DisplayAlert("Transaction is failed", "Your Transaction is failed please try again but first check you wallet amount. If have problem please contact us", "OK");
            else {
                await DisplayAlert("Transaction is succesfull", "Transaction is succesfull. Your TxID copied clipboard", "OK");
                txid.Text = "Your TxID: "+asd;
                await Clipboard.SetTextAsync(asd);

            }

        }

        private void TabbedLabel()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) => {
                await Clipboard.SetTextAsync(txid.Text.Remove(0,11));
                if (Clipboard.HasText)
                {
                    var text = await Clipboard.GetTextAsync();
                    await DisplayAlert("Success", string.Format("TxID is copied clipboard", text), "OK");
                }
            };
            txid.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            getBalance gettokenbalance = new getBalance();
            var asd = await gettokenbalance.GetBalance(walled_adress.Text);
            if (asd == null)
                await DisplayAlert("Get Balance Failed", "Get balance function is failed please try again or check your wallet adress", "OK");
            else
            {
                await DisplayAlert("Get Balance Success", "Get balanc is succes please check your balance again.", "OK");
                wallet_amount.Text = asd + " PostanteToken";

            }

        }
    }
}
