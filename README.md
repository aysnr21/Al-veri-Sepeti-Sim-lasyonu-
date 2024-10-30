# Aliveris-Sepeti-Simulasyonu-
C# Alışveriş Sepeti Simülasyonu
Bir alışverş sepet smülasyonu oluşturun. Program en az 3 farklı exceptAon handlAng çermeldr. 
Adımlar: 
1. Ürün lAstesA: Önceden tanımlanmış brkaç ürün ve bunların fyatlarını çeren br lste 
oluşturun (örneğn: elma, muz, süt, ekmek). 
2. Ürün seçAmA: Kullanıcı hang üründen almak stedğn ve mktarını grsn. Program, 
kullanıcının grdğ mktarları kontrol ederek geçerl br değer olup olmadığını kontrol etsn 
ve sepete eklesn. 
3. Sepet toplamı: Kullanıcı farklı ürünler ekleyeblr ve sonunda sepetnn toplam tutarını 
göreblr. Sepet boşsa hata fırlatılmalı (throw) ve kullanıcıya sepetn boş olduğunu 
söylemelsnz. 
4. Sepetten ürün çıkarma: Kullanıcı, ekledğ br ürünü sepetten çıkarablr. Eklenmemş br 
ürün çıkarılmaya çalışılırsa hata fırlatın. 
Örnek ExceptAon HandlAng durumları: 
1. Kullanıcı ürün mktarını grerken geçerl br sayı grmezse FormatExceptAon yakalayın ve 
geçerl br sayı grmesn sağlayın. 
2. Kullanıcı stokta olmayan br ürünü seçmeye çalışırsa ArgumentExceptAon yakalayın ve 
ürünün stokta olmadığını belrtn. 
3. Kullanıcı ürün çıkarmaya çalıştığında sepet boşsa veya çıkarılmak stenen ürün sepette 
yoksa InvalAdOperatAonExceptAon yakalayın.
