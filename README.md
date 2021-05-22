# PostAnteWallet
Avalanche Wallet (c# xamarin)

Telegram: Avalanche türkiye ve offical gruplarında varım etiketliyerek veya özelden yazabilirsiniz. (Berkay Kaplan)

## Türkçe :

Avalanche Node sisteminde postman ile yapabileceğiniz "send ve getBalance" metotlarını Xamarin üzerinden mantığını kavramınız açısından oluşturduğum proje. Bu proje sayesinde postmande bulunan diğer metotlarıda ekliyerek Mobile platforma kendi walletlarınızı yazabilirsiniz.

https://github.com/zazuui2/PostAnteWallet/blob/master/PostAnteWallet/PostAnteWallet/Methods/SendTokenClass.cs 
https://github.com/zazuui2/PostAnteWallet/blob/master/PostAnteWallet/PostAnteWallet/Methods/getBalance.cs

Yukarıda belirttiğim Class da değiştirmeniz gereken bazı alanlar var lütfen işlem yapacağınız node ip adreslerinin sonuna uzantıları eklemeyi unutmayalım yoksa node ile haberleşme işlemleri gerçekleşmez.
```bash
Örnek olarak: "http://NODEIPADRESI:PORT(DEĞİŞTİRMEDİYSENİZ 9650)/ext/bc/X"
```
şeklinde 

## Değiştirecek alanlar

[getBalance](https://github.com/zazuui2/PostAnteWallet/blob/master/PostAnteWallet/PostAnteWallet/Methods/getBalance.cs) için:

56. satır:

```c
 assetID = "Gönderim yapacağınız coinin asset idsi", // coin asset id
```

71. satır:
```c
 HttpResponseMessage response = await client.PostAsync("işlem yapacağınız node adresi", content); //node ip adresiniz
```

[SendTokenClass](https://github.com/zazuui2/PostAnteWallet/blob/master/PostAnteWallet/PostAnteWallet/Methods/SendTokenClass.cs) için:

56 ve 64 arası: 
```c
assetID = "Göndereceğiniz tokenin Asset idsi", // burası
amount = amount,
from = new List<string>
{
   "Gönderim yapılacak coinin wallet adresi" // burası
},
to = adress,
username = "Wallet kullanıcı", // burası
password = "Wallet şifresi" // burası
```    
78. satır:  
```c
 HttpResponseMessage response = await client.PostAsync("İşlem yapacağınız Node adresi", content);
```
 ## English
 The project that I created in terms of your concept of "send and getBalance" methods, which you can do with postman in Avalanche Node system, over Xamarin. Thanks to this project, you can add other methods on the post and write your own wallets to the Mobile platform. 
 https://github.com/zazuui2/PostAnteWallet/blob/master/PostAnteWallet/PostAnteWallet/Methods/SendTokenClass.cs
 https://github.com/zazuui2/PostAnteWallet/blob/master/PostAnteWallet/PostAnteWallet/Methods/getBalance.cs
 There are some areas that you need to change in the Class I mentioned above, please do not forget to add extensions to the end of the node ip addresses where you will make transactions, otherwise communication with the node will not occur. 
```bash
Example: "http://NODEIPADRESI:PORT(IF YOU DONT CHANGE SHOULD BE: 9650)/ext/bc/X"
```
## Areas to Change 
for [getBalance](https://github.com/zazuui2/PostAnteWallet/blob/master/PostAnteWallet/PostAnteWallet/Methods/getBalance.cs) 
Line 56:

```c
 assetID = "Asset id of the coin you will send ", // coin asset id
```
Line 71:

```c
 HttpResponseMessage response = await client.PostAsync("the node address you will make a transaction", content); //node ip adress
```

For [SendTokenClass](https://github.com/zazuui2/PostAnteWallet/blob/master/PostAnteWallet/PostAnteWallet/Methods/SendTokenClass.cs).
Line 56 to 64: 
```c
assetID = "Asset id of the coin you will send", // here
amount = amount,
from = new List<string>
{
   "The wallet address of the coin to send to " // here
},
to = adress,
username = "Wallet username", // here
password = "Wallet password" // here
```    
Line 78:  
```c
 HttpResponseMessage response = await client.PostAsync("the node address you will make a transaction", content);//node ip adress
```
