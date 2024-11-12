<img src="https://github.com/Fartomy/42-Out-Core/blob/main/libasm/welder.gif" align="right" height="500">

# En Basitinden Assembly

Bilgisayar terimleri ve kavramları pek kompleks ve iç içe geçmiş olduğundan anlam olarak bir kavramın veya teriminin bağlama ve konuya göre değişkenlik gösterip farklı bir anlamla 
veya örneklerle karşı karşıya bırakması muhtemeldir. Bağlamdan bağlama veya konudan konuya anlam olarak değişkenlik göstermesi modern yaklaşımla ilgidir. Teknolojik gelişim hızı 
çılgınlık seviyesinde olduğundan bir konu veya alan ile alakalı yeni bir terim bu hız ile beraber paralel olarak genişliyor bu da en temel anlamı kaçırmaya sebebiyet verip 
karmaşıklığı arttırıyor. Teknik olarak **Computer Architecture** ifadesi şuan çok geniş bir anlama sahip. Örneğin Assembly bağlamında verilen örnekler arasında **x86, ARM, MIPS vb.** 
mimari örnekleri mevcut. Lakin bu örnekler temelde işlemci mimarisi örnekleridir. İşlemci mimarisi, genellikle **Computer Architecture**'ın bir parçası olarak ele alınır ancak bağlama 
göre verilen böyle örnekler ile karşılaşınca **Computer Architecture** ifadesine ait örneklermiş gibi gözüküyor. Bu da işlemci mimarisi konusu ele alındığında birbirleriyle özdeşlermiş
(bir bakıma doğru veya belki de değil) gibi bir mana ortaya çıkarıyor. Ancak **Computer Architecture** örnekleri arasında temelde bağımsız olarak **Von Neumann, Harvard vb.** 
gibi bilgisayarın genel organizasyon yapısı gibi örnekler barındırıyor. Başka bir örnek olarak **x86** terimini ele alalım. Genel olarak bu terim 32-bit kavramıyla ilişkilendirilir 
ve özdeşleştirilir. Ancak terim, ilk olarak Intel 8086 işlemcisi ile başlamış olup, daha sonra birçok işlemci neslini ve çeşitli üreticileri (Intel, AMD vb.) içerecek şekilde 
genişlemiştir. **x86**, Intel tarafından geliştirilen bir mikroişlemci mimarisinin genel bir adıdır ve genellikle 16-bit, 32-bit ve 64-bit işlemcileri kapsayan bir terim olarak 
kullanılır. Yani teknolojik gelişim açısından 8086 mikroişlemcisi çıkış yaptığından beri bu kulvarda büyük bir etki, domine, standardizasyon ve genel olarak işlemci mimarilerinin 
temeli olarak bir dönüm noktası oluşturduğundan bu terim zamanla çok geniş bir anlama sahip olmuştur. O yüzden **x86** terimi sadece 32-bit anlamına gelmez. Ancak **x86** uzun bir 
dönem 32-bit'lik işlemciler de kullanılan bir terim olduğundan artık o terim ile özdeşleşmiş durumda. 32-bit terimi ile yanıltıcılığı azaltmak için bir ilişkilendirme yapılacaksa 
Intel'in ilk 32-bit'lik mikroişlemcisi olan **i386** veya **Pentium** gibi işlemcileriyle ilişkilendirilebilir. Sonra ki en klişe örnek olan kavram **Linux**'tur. Linux, işletim 
sistemi tarihi boyunca anlam olarak öyle bir genişlemişir ki artık onun bir işletim sistemi çekirdeği (kernel) değil bir işletim sistemi olarak tanınmasına yol açtı. Halbu ki 
en temel de işletim sistemi olarak bu **GNU/Linux** olarak tanımlanır. Linux çekirdeği ve GNU araçları birlikte tümleşik olarak çalıştığından zamanında böyle bir adlandırılma yapılmış.

Pek çok nokta da yapay zekadan teori bakımından yardım alındı ve yapay zeka dahi sorulan soruya ilişkin bazı terimlerle alakalı açıklama yaparken muhteşem bir karmaşa yaşıyor. 
Ancak bu onun hatası değil kaynak olarak interneti kullanıyor ve sadece ona göre bir derleme yapıyor. Sorunun kaynaktan kaynaklandığını, yani kaynakları hazırlayanların karmaşasından
kaynaklı hata yapması pek şaşırtıcı değil. Hatta yapmış olduğu hatayı kendisi fark edip kendisini düzeltmesine rağmen tekrardan maalesef ki aynı hatayı yapmaya devam ediyor. 
Hatta bazı cevapları kendisinden talep ederken bazen soyutlama (kasıtlı olarak yaptığını zannetmiyorum yukarı da bahsedilen gibi; kaynaktan kaynaklı) yapıyor ve bu yüzden sorunun 
kaynağını tam olarak tespit etmek işi daha da zorlaştırıyor. Üstelik yapılmış olan soyutlama bu şekilde yayılıp öğrenildiği taktirde soyut, artık işin kaynağıymış (özü) gibi 
gözüküyor. Bu da altta yatan asıl temelin yavaştan erimesine sebebiyet veriyor. Böylece asıl kaynağı bulmak ve doğrusunu öğrenmek pek zorlayıcı hale geliyor. 
Bilinçsiz soyutlama ya da belki kasıtsız dezenformasyon gibi bir durum söz konusu oluyor. Verilecek örnek, yukarıda bahsedilenleri ne kadar etkili bir biçimde karşılar/yansıtır/doğrular bunu 
öngöremiyorum ancak özellikle Assembly'de ki genel amaçlı register'lar ile alakalı konu araştırmasında register konvansiyonları ve öncelikleri (rdi, rsi, rax vb. bazı durumlarda 
özel davranışları olan register'lar) ile alakalı yapay zekanın ve genel olarak internet de karşılaşmış olduğum tartışma sitelerin de (stackoverflow, stackexchange vb.) bu 
konvansiyonların sebeplerinin işletim sistemine bağlı olarak standartlaştırıldığı söyleniyor. Ancak bunun asıl sebebi işletim sisteminin kullanmış olduğu bir ABI konvansiyonu 
standartından kaynaklı. Evet, ilk başta söylenilen ifade kısmen doğrudur ama tamamen değil. Çünkü bu şekilde ifade edildiğinde System V ABI veya Macho ABI gibi katmanların 
(asıl belirliyicilerin) keşfedilmesi soyutlanmış oluyor. Böylece bu gibi asıl bilgilere erişim zorlaşıyor ve tam olarak kavranılamıyor. ABI İşletim sistemi çekirdeği (kernel) 
ile uygulama yazılımları (program) arasında aracılık ve katman sağlıyor. Bu da konvansiyon sağlıyor ve oluyor. Şayet az önce ki bilgiyi (ABI) bu yazı da hiç bahsetmemiş olup sadece 
`...bu konvansiyonların sebeplerinin işletim sistemine bağlı olarak standartlaştırıldır.` bilgisini verseydim bu soyutlamaya bilinçsizce bir katkı da bu yazınin kendisi 
sağlamış olacaktı ve aynı şekilde asıl temelin erimesine de yine bilinçsizce katkı sağlamış olunacaktı.

Assembly konusuna geri dönülecek olursa bu tip karmaşıklıkların aksine konu ile alakalı kaynak bulmak bile pek meşakkatli. Kaynak bulunsa dahi bu sefer de doğrusunu yanıltmış ifadeden ayrıştırmak pek zor. 
Bu tür dinamik terim ve genişletilmiş kavramlar (veya sabit anlamsız terim veya kavramlar da denilebilir) bu şekilde olunca bağlamdan bağımsız temel anlamı kavrayışı zorlaştırıyor, 
karmaşıklaştırıyor ve yanıltıcı olabiliyor. Assembly'de bu tür konularla ilişkili olduğundan Assembly'i kavrama konusunda zorluk olabilir. O yüzden burada yazılanlar bir başkası tarafından 
anlaşılamayıp reddedilebilir. Bu kaçınılmazdır. Çılgın karmaşa dalgasının hızına kapılıp işin sonunda kayaya çarpmaktansa daha yavaş ve dikkatli bir biçimde çözümleyip ayrıştırmak, 
işin doğrusuna yakınlaştırıp farkındalık uyandıracaktır. Bu farkındalığın kazanılmasına rolü ve yardımı olan genişlemiş, dinamik ve sabit anlamsız terim veya kavramlara 
teşekkür ederim. Burada yazılanların kavranıldığı kadarıyla ele alındığını belirtmek gerek. Burada ki belirtimleri ve ifadeleri en azından kavrayış bakımından daha kolay hale 
getirmek için **CS1** deneyiminin olması bir bakıma bu durumu çözümleyebilir.

</br>
</br>

```
"Bilinen bir doğru veya gerçek bir sonra ki doğru veya gerçeğin keşfedilene kadar bir referans noktası gibi. Böylece hiçbir zaman doğru veya gerçek olmuyor. 
Sadece yakınlaştığımızı zannediyoruz ta ki uzaklaştığımızı fark edemeyene kadar."

- Wayfaring Pilgrim
```

</br>
</br>

Bu yazıda x86 (:d) mimarisi baz alınmıştır ve ona göre hazırlanmıştır. ARM mimarisi için veya başka mimariler için burada yazılanlar geçerli olmayabilir. Çoğunlukla GNU/Linux (:d) 
sistemine özgü örnekler ve ifadeler üzerinde durulmuş ve anlatım yapılmıştır. Ancak bu MacOS veya diğer sistemler ile ilgili bilgi bulamayacağınız anlamına gelmiyor.

Neredeyse her konu birbiriyle ilişkili olduğundan sadece yukarıdan aşağıya okumak fayda sağlamayabilir. Bir bütün olarak ele alın. Bir el kitabı gibi.


## 🧭 Yol Haritası

...

## :one: CPU Nedir?

CPU, cihazın içindeki tüm hesaplama işlemlerini gerçekleştirir ve diğer bileşenleri (bellek, giriş-çıkış aygıtları vb.) yönlendirir.
Bir bilgisayarın çalışması için temel talimatları işler ve programların yürütülmesini sağlar.

CPU'nun Temel Görevleri:

-    Talimatları Yorumlama: CPU, bellekte saklanan talimatları alır ve ne yapılması gerektiğini anlar.
-    Veri İşleme: CPU, matematiksel ve mantıksal işlemler yaparak verileri işler.
-    Veri Taşıma: Veriyi bellekten alır, işler ve sonuçları tekrar belleğe veya ilgili çıkış aygıtlarına gönderir.
-    Kontrol: Diğer donanım bileşenlerini koordine eder ve gerektiğinde onlara veri veya talimatlar gönderir.

CPU'nun Ana Bileşenleri:

-    Kontrol Birimi (Control Unit - CU): CPU'nun hangi işlemi yapacağını belirler ve talimatları yürütmek için gerekli verileri uygun bileşenlere yönlendirir.
-    Aritmetik Mantık Birimi (Arithmetic Logic Unit - ALU): Tüm aritmetik (toplama, çıkarma vb.) ve mantıksal (AND, OR, NOT gibi işlemler) işlemleri gerçekleştirir.
-    Kayıtlar (Registers): CPU içinde geçici olarak veri saklayan küçük, hızlı bellek alanlarıdır. İşlenen verilerin hızla erişilebilmesi için bu alanlar kullanılır.
-    Önbellek (Cache): Sık kullanılan verilere hızlı erişim sağlamak için tasarlanmış bir bellektir. Bu sayede işlemler hızlandırılır.

CPU'nun Çalışma Döngüsü (Fetch-Decode-Execute):

-    Fetch (Getir): CPU, RAM'den işlenecek bir talimat alır.
-    Decode (Çözümle): Bu talimatı çözümler ve ne yapılması gerektiğini anlar.
-    Execute (Yürüt): Talimatı işler ve sonucu elde eder.


### Mikro İşlemci Tarihinin Önemli Noktaları

Intel 8086 işlemcisi, bilgisayar tarihindeki en önemli mikroişlemcilerden biri olarak kabul edilir ve günümüz bilgisayar mimarisinin temelini oluşturmuştur. 
8086'nın tarihsel önemi, hem donanım hem de yazılım dünyasında yaptığı devrimsel yeniliklerle ilgilidir. Intel 8086'nın tarihsel açıdan neden bu kadar 
önemli olduğunun temel nedenlerine göz atalım:

1. x86 Mimarisi'nin Doğuşu

    Intel 8086, x86 mimarisi olarak bilinen işlemci ailesinin ilk üyesidir. Bu mimari, günümüzde kullandığımız modern bilgisayarların temelinde yer alır.
    x86 mimarisi, kişisel bilgisayarların ve sunucuların büyük çoğunluğunda kullanılan standart işlemci mimarisi haline gelmiştir. 8086 ile başlayan bu mimari,
    sürekli gelişim göstermiş ve bugünkü 64-bit işlemciler (x86-64) haline gelmiştir.

3. 16-bit İşlemci

    Intel 8086, Intel'in ilk 16-bit mikroişlemcisiydi. Bu, o dönemin bilgisayarları için büyük bir gelişmeydi, çünkü önceki işlemciler genellikle 8-bit'ti.
    16-bit veri işleme kapasitesi, aynı anda daha fazla veri işleyebilme ve daha geniş bellek adresleme anlamına geliyordu. 8086, doğrudan 1 MB'a kadar bellek
    adresleyebiliyordu ki bu, önceki nesillere göre çok büyük bir iyileşmeydi.
    
5. Mikroişlemci Devriminin Bir Parçası

    8086, mikroişlemci devrimini hızlandıran işlemcilerden biri oldu. Mikroişlemciler, daha önce büyük ve pahalı olan bilgisayarları çok daha küçük, daha ucuz ve yaygın hale
    getirdi. 8086'nın yaygın olarak kullanılmasıyla bilgisayarlar, sadece iş dünyasında değil, evlerde de yer almaya başladı. Bu, kişisel bilgisayarın günlük yaşamda bir araç
    haline gelmesinin önünü açtı.

7. Geriye Dönük Uyumluluk

    8086 işlemcisi, Intel'in önceki 8-bit işlemcisi olan Intel 8080 ile yazılım uyumluluğunu koruyordu. Bu sayede, eski yazılımlar 8086'da da çalışabiliyordu.
    Bu geriye dönük uyumluluk stratejisi, Intel'in x86 mimarisinin büyük bir avantajı haline geldi ve sonraki yıllarda da sürdü. x86 ailesindeki her yeni işlemci,
    önceki nesillere uyumlu kalmaya çalıştı, bu da yazılım geliştirme açısından büyük bir kolaylık sağladı.

9. Segmentli Bellek Adresleme

    Intel 8086, segmentli bellek adresleme modelini tanıttı. Bu model, 16-bit adresleme sınırını aşarak 1 MB'a kadar bellek adreslenebilmesini sağladı.
    Segmentli bellek, o dönemin sınırlı bellek kapasitesine rağmen, daha büyük ve daha karmaşık programların çalıştırılmasına olanak tanıdı.

10. Yazılım Gelişimi Üzerindeki Etkisi

    Intel 8086, yeni yazılım paradigmalara öncülük etti. MS-DOS gibi işletim sistemleri ve çeşitli programlama dilleri (örneğin, Assembly, C) bu işlemci üzerine inşa edildi.
    x86 mimarisinin gücü ve yaygınlığı, yazılım geliştirme dünyasını etkiledi ve yazılım sektörü bu mimari üzerine büyük ölçüde odaklandı. 8086 ile başlayan bu yazılım ekosistemi,
    günümüzde Windows, Linux ve diğer büyük işletim sistemlerinin temelidir.

12. Endüstri Standardı Haline Gelmesi

    Intel 8086, endüstri standardı haline geldi ve bu durum bugün hala devam ediyor. x86 mimarisi, büyük bilgisayar üreticilerinin çoğu tarafından kullanıldı ve zamanla
    işlemcilerde ve kişisel bilgisayarlarda dominant bir yapı haline geldi.
    x86'nın başarısı, Intel'in rakiplerine karşı büyük bir avantaj sağladı ve diğer mikroişlemci üreticilerini Intel'in tasarımlarına benzer ürünler geliştirmeye yöneltti.
    
    
Intel 8086, yalnızca bir işlemci değil, modern bilgi teknolojilerinin başlangıcını simgeleyen bir dönüm noktası olarak görülür. Hem bilgisayar dünyasında hem de teknoloji 
tarihinde çok önemli bir yere sahiptir.

### İşlemci Mimarisi Ne Anlama Geliyor?

İşlemci mimarisi (veya CPU mimarisi), bir mikroişlemcinin nasıl tasarlandığını ve çalıştığını tanımlayan yapısal, işlevsel ve mantıksal prensiplerin bütünüdür.
Bu kavram, işlemcinin talimat seti, bellek yönetimi, veri işleme kapasitesi, giriş/çıkış mekanizmaları ve genel çalışma prensiplerini kapsar.
İşlemci mimarisi, hem donanımın (fiziksel devre tasarımı) hem de yazılımın (işletim sistemi ve uygulama yazılımlarının) üzerinde çalıştığı temel çerçeveyi belirler.

**İşlemci Mimarisi'nin Ana Bileşenleri:**

1. Talimat Seti Mimarisi (ISA - Instruction Set Architecture)

    Talimat Seti, işlemcinin hangi komutları çalıştırabileceğini tanımlar. Bir işlemciye verilen görevler (örneğin, iki sayıyı toplama, bir değeri bellekten okuma) bu talimat seti aracılığıyla gerçekleştirilir.
    Örneğin, x86 ve ARM gibi mimariler farklı komut setlerine sahiptir. Bir yazılım, işlemcinin talimat setine uygun şekilde yazılmalıdır.
    Talimat seti mimarisi ayrıca, işlemcinin kaç bitlik veriyi işleyebileceğini (örneğin 32-bit veya 64-bit) ve hangi veri türlerini (tam sayılar, kayan noktalı sayılar, karakterler vb.) desteklediğini tanımlar.

2. Veri Yolları ve Kayıtlar (Registers)

    Kayıtlar (registers), işlemcinin verileri ve adresleri geçici olarak depoladığı çok hızlı küçük bellek alanlarıdır. İşlemci mimarisi, kaç adet kaydın olacağını ve bu kayıtların ne kadar veri tutabileceğini belirler (örneğin, 32-bit ya da 64-bit).
    Veri yolu ise, işlemcinin veri taşımak için kullandığı hatlardır. Veri yolları, işlemci içinde ve bellek, giriş/çıkış birimleri gibi dış kaynaklarla bağlantı sağlar.


Bazı farklı işlemci mimarisi örnekleri: x86, ARM, PowerPC, RISC-V, MIPS, SPARC, VLIW 

Talimat Seti Yapisi Türleri:

1. CISC (Complex Instruction Set Computing)

    CISC talimat seti yapisi, çok sayıda ve karmaşık komutları destekleyen bir mimaridir. Bir CISC işlemcisi, genellikle bir komutla birden fazla işlemi yapabilir.
    x86 mimarisi, CISC türündedir. Bu tür mimarilerde, daha az komutla daha çok iş yapılması hedeflenir.

2. RISC (Reduced Instruction Set Computing)

    RISC talimat seti yapisi, basit ve sınırlı sayıda talimat seti kullanır, ancak bu komutlar hızlı ve verimli şekilde çalışır. Her komut, genellikle işlemcinin bir saat döngüsünde tamamlanır.
    ARM mimarisi, RISC tabanlıdır. RISC işlemciler, genellikle daha düşük güç tüketimi ve daha hızlı performans sunar.

### Talimat Seti Nedir? Neden Gereklidir?

Talimat seti (ISA - Instruction Set Architecture), bir işlemcinin çalıştırabileceği temel işlemlerin ve bu işlemleri nasıl gerçekleştirdiğinin tanımlandığı bir dizi talimattır. 
Diğer bir deyişle, talimat seti, bir işlemci ile onun çalıştırdığı yazılımlar arasında bir arabuluculuk görevi görür. Bir yazılım, işlemci üzerindeki donanımı kontrol etmek için 
talimat setini kullanır.

Talimat seti'nin Bileşenleri:

  Talimatlar (Instructions):
      Talimatlar, işlemciye hangi işlemi yapması gerektiğini anlatan komutlardır. Örneğin, toplama, çıkarma, veri taşıma, koşullu dallanma, veri okuma/yazma gibi işlemleri 
      içerebilir.

  Veri Tipleri:
      talimat seti, işlemcinin hangi tür verilerle çalışabileceğini tanımlar. Örneğin, tamsayılar, kayan noktalı sayılar, karakterler vb.

  Adresleme Modları:
      talimat seti, verilerin bellekte nasıl bulunacağını ve işleneceğini belirleyen adresleme modlarını tanımlar. Verilere doğrudan, dolaylı veya kaydırmalı şekilde ulaşılabilir.

  Kayıtlar (Registers):
      İşlemcinin komutlar üzerinde çalışırken kullandığı küçük, hızlı bellek alanları olan kayıtların ne amaçla kullanıldığı talimat seti ile tanımlanır.
        
1. Donanım ile Yazılım Arasındaki Bağ

    Talimat seti, donanım ile yazılım arasında bir köprü görevi görür. Bir yazılımın işlemci üzerinde çalışabilmesi için, işlemcinin tanıyacağı komutlar ile yazılması gerekir.
    Örneğin, bir yazılımın iki sayıyı toplaması gerektiğinde, işlemciye bu talimatı iletebilmek için belirli bir talimat setini kullanması gerekir.

2. Yazılım Uyumluluğu

    Belirli bir talimat seti, işlemciye hangi yazılımların çalışabileceğini belirler. Yazılım, belirli bir işlemci talimat setine uygun olarak yazılmışsa, o işlemci üzerinde
    çalışabilir. Bu nedenle, talimat seti aynı olan işlemcilerde yazılımlar uyumlu bir şekilde çalışabilir.
    Örneğin, x86 mimarisine sahip bir işlemci, x86 talimat setine uygun yazılımları çalıştırabilir. Aynı şekilde, ARM mimarisi işlemcilerde ARM talimat setine uygun yazılımlar
    çalışır. Eğer bir yazılım başka bir talimat setine göre yazılmışsa, bu farklı mimaride çalışmaz.

4. Standart İşlemler

    Talimat seti, işlemcinin gerçekleştireceği işlemler için standart bir yol sağlar. Bu, matematiksel işlemler (toplama, çıkarma), bellekten veri okuma/yazma,
    koşullu dallanma (if/else yapısı) gibi temel işlemlerin işlemci tarafından nasıl yapılacağını tanımlar.
    Her işlemci, bir toplama işlemi yapmak için belirli bir komut kullanır (örneğin, ADD komutu).

6. Performans ve Verimlilik

    Talimat seti, işlemcinin verimliliğini ve performansını doğrudan etkiler. Daha optimize edilmiş ve basit bir talimat seti, işlemcinin işlemleri daha hızlı gerçekleştirmesini
    sağlar.
    Özellikle RISC (Reduced Instruction Set Computing) mimarisinde, komutlar basit ve hızlı çalışacak şekilde optimize edilmiştir. Bu da işlemcinin enerji verimliliğini ve
    işlem hızını artırır.        

8. Donanım Soyutlaması

    talimat seti, geliştiricilere donanımın karmaşıklığını gizleyen bir soyutlama sağlar. Yazılım geliştiricileri, talimat setini kullanarak işlemcinin ne yaptığını anlamadan,
    yazılımlarını donanım üzerinde çalıştırabilirler.
    Bu sayede yazılım geliştirme, donanım tasarımından bağımsız hale gelir ve daha hızlı bir şekilde ilerleyebilir.
    
 
Talimat seti Türleri:
1. CISC (Complex Instruction Set Computing)

    CISC talimat seti, çok sayıda karmaşık komut içerir ve bu komutlar, birden fazla işlem gerçekleştirebilir.
    CISC, her komutun donanımda karmaşık bir işlevi gerçekleştirmesine izin verir, bu da kodlamayı kolaylaştırır ancak işlemci daha fazla enerji harcayabilir ve daha karmaşık olabilir.
    Örnek: x86 mimarisi, CISC talimat setine dayalıdır.

2. RISC (Reduced Instruction Set Computing)

    RISC talimat seti, daha az sayıda ve daha basit komutlara dayanır. Her komut, yalnızca tek bir işlem gerçekleştirir ve genellikle işlemcinin bir saat döngüsünde tamamlanır.
    RISC mimarisi, daha hızlı işlem yapma ve enerji verimliliği sağlama amacıyla tasarlanmıştır. Karmaşık işlemler, birden fazla basit komutun birleşimiyle yapılır.
    Örnek: ARM mimarisi, RISC tabanlıdır.
    
**Talimat Seti Olmazsa Ne Olur?**

Eğer talimat seti olmasaydı, yazılımlar işlemcinin nasıl çalıştığını anlamak zorunda kalır ve her donanım türü için ayrı ayrı yazılımlar yazılması gerekirdi. 
Bu da yazılım geliştirme sürecini inanılmaz derecede karmaşık ve zaman alıcı hale getirirdi. 
Talimat seti, yazılım geliştiricilerin donanımı anlamadan işlemcide işlem yapabilmelerini sağlar, bu da donanım-yazılım uyumu açısından büyük bir kolaylık sunar.

Komut seti, işlemcinin ne tür komutları çalıştırabileceğini, hangi veri tipleriyle çalışabileceğini ve donanım üzerinde nasıl işlemler gerçekleştireceğini belirleyen 
talimatlar kümesidir. İşlemci mimarisinin temel bir parçası olan komut seti, donanım ile yazılım arasındaki en önemli bağlantıdır ve yazılımın işlemci üzerinde çalışmasını 
sağlayarak verimlilik, uyumluluk ve standartlar açısından büyük bir öneme sahiptir.

### Assembly Nedir?

Assembly, bir bilgisayarın CPU'suna beslenen talimatları basitleştirmek için tasarlanmış düşük seviyeli bir programlama dilidir.
Başka bir deyişle, programcıların birleri ve sıfırları manuel olarak saymasına gerek kalmaması için makine kodunun üzerinde insan tarafından okunabilen bir soyutlamadır.

_One-to-one_ ifadesi, Türkçe'ye _birbiriyle bire bir eşleşme_ olarak çevrilebilir. Assembly dili ve makine kodu bağlamında bu terim, her bir assembly komutunun 
tam olarak bir makine kodu talimatına karşılık gelip gelmediğini ifade eder.

Daha Detaylı Açıklama:

  Bire Bir Eşleşme:
      Eğer bir assembly dilinde yazılan her bir komut, doğrudan ve tam olarak bir makine kodu talimatı ile eşleşiyorsa, buna `one-to-one` eşleşme denir. 
      Yani, her assembly komutu için sadece bir makine kodu talimatı vardır.
    
  Güçlü Ama Bire Bir Değil:
     Assembly dilindeki bazı komutların birden fazla makine kodu talimatına dönüşebileceği veya bir makine kodu talimatının birden fazla assembly komutuyla temsil edilebileceği 
     anlamına gelir. Bir assembly komutu, belirli bir işlem için daha karmaşık bir makine kodu talimatı gerektirebilir. Veya bir makine kodu talimatı, farklı durumlarda farklı 
     assembly komutları ile temsil edilebilir.

_One-to-one_ ifadesi, bir assembly komutunun doğrudan bir makine kodu talimatı ile eşleşip eşleşmediğini belirtir. 
Bu bağlamda, güçlü bir ilişki olsa da, her zaman bire bir bir eşleşme söz konusu olmayabilir, bu da dilin esnekliğini ve karmaşıklığını artırır.

#### Assembly Kodunun Sistemler Arasında ki Çalışma Farklılıkları

1. Kodun İşlemci Mimarisine Göre Çalışıp Çalışmaması Durumu:

Bir mimariye özgü yazılmış assembly kodu farklı bir mimaride çalışamaz. Bu da assembly dilini taşınılabilir yapmaz.
Örneğin x86 mimarisi kullanan bir cihaz da yazılmış olan bir assembly kodu, ARM mimarisi kullanan bir cihaz da çalışamaz

2. Kodun İşletim Sitemine Göre Çalışıp Çalışmaması Durumu:

Bunu etkileyen bazı fakörler:

- Sistem çağrı numaraları
- Calling Convention (stdcall, cdecl, fastcall vb. (bunlar calling convention türleridir)) fonksiyonların parametrelerinin ve argümanlarının çağrılma konvansiyonu
- Parametre geçişleri: örneğin Linux System V ABI kullanır. MacOS ise Mach-O ABI kullanır. Bu ABI'ler, sistem çağrılarının ve fonksiyon çağrılarının nasıl yapılacağını, parametrelerin nasıl iletileceğini ve dönüş değerlerinin nasıl alınacağın belirler.
- Assembler farklılıkları (GAS(GNU Assembler), NASM) GAS AT&T syntax'iını kullanır NASM intel syntax'ini kullanır.
- İşletim sistemi konvansiyon Standartları
- İşletim sistemi API'lerine ve kütüphanelere erişim yöntemi farklılıkları.
- Bellek yönetim şekilleri ve adresleme farklılıkları.


1. **Sistem Çağrıları**

Sistem çağrısı, bir programın işletim sisteminin çekirdeğine (kernel) erişmek ve onun sunduğu hizmetleri kullanmak için başvurduğu bir mekanizmadır.
Kullanıcı modunda çalışan bir program, dosya açma, okuma, yazma, ağ bağlantısı kurma gibi donanım veya sistem kaynaklarına erişemez. 
Bu tür işlemler güvenliğin sağlanması amacıyla işletim sistemi çekirdeği tarafından yönetilir. Sistem çağrıları, uygulamaların bu çekirdek hizmetlerine erişmelerini sağlayan 
kontrollü bir yoldur.

Bir sistem çağrısı yapılırken, program çekirdek moduna geçer ve ardından gerekli işlemi gerçekleştirdikten sonra tekrar kullanıcı moduna döner. 
Bu geçiş süreci genellikle bir kesme (interrupt) ya da sistem çağrısı talimatı (syscall instruction) ile sağlanır.

- Çağrı Numarası: Sistem çağrısı yaparken, işlemcinin belirli bir kaydına (register) hangi çekirdek işleminin yapılması gerektiğini gösteren bir sistem çağrısı numarası yerleştirilir.
- Parametreler: İşlemin gerçekleştirilmesi için gereken veriler ve parametreler diğer kayıtlara yüklenir.
- Sistem Çağrısını Başlatma: int 0x80 (32-bit Linux) veya syscall (64-bit Linux ve bazı diğer sistemlerde) gibi bir talimat ile çağrı yapılır.
- Sonuç: Çekirdek işlemi tamamlayıp sonucu döndürür ve kontrol tekrar kullanıcı moduna geçer.

Sistem çağrısı numaraları işletim sistemine göre farklılık gösterir çünkü her işletim sistemi, kendi çekirdek tasarımına ve ihtiyaçlarına göre bu çağrıları tanımlar ve sıralar.
Bu yüzden Linux, macOS, Windows gibi işletim sistemlerinde aynı işleve sahip sistem çağrıları farklı numaralara sahip olabilir.

Örneğin:

Linux: sys_write çağrısı 32-bit Linux sistemlerde 1 numarasına sahiptir.
macOS: Aynı write çağrısı için macOS'ta 4 numarası kullanılır.

Bu farklılıkların nedeni, her işletim sisteminin kendi sistem çağrısı tablosuna ve iç organizasyonuna sahip olmasıdır. 
Her işletim sistemi çekirdeği kendi sistem çağrı numaralarını tanımlarken kendi öncelik ve ihtiyaçlarını gözetir. 
Örneğin, Linux, dosya işlemlerini başlangıçta tanımlarken, macOS başka bir işlevi öncelikli hale getirmiş olabilir.

Sistem çağrıları standart olmadığından:

  Çekirdek Tasarımı ve Geliştirme Farklılıkları: İşletim sistemleri farklı çekirdek mimarilerine ve iç tasarıma sahiptir. Linux ve macOS gibi Unix benzeri sistemler bile bu 
  numaralar konusunda farklı tasarımlara sahip olabilirler.
  Taşınabilirlikten Çok Performansa Odaklanma: Sistem çağrıları düşük seviyeli işlemler olduğundan, işletim sistemi geliştiricileri taşınabilirlikten ziyade kendi sistemlerinin 
  performansına ve güvenliğine öncelik verirler. Bu nedenle, sistem çağrılarının standart hale getirilmesi beklenmez.
  Farklı İşlevlere Sahip Olma: Her işletim sisteminin sağladığı fonksiyonlar ve yetenekler aynı değildir. Bu nedenle bazı sistem çağrıları belirli bir işletim sistemine özgü 
  olabilir.

Sistem çağrıları, uygulamaların işletim sisteminin çekirdek işlevlerini kullanmasını sağlayan yöntemlerdir. Sistem çağrı numaraları, işletim sistemine özgüdür ve standart 
değildir; çünkü her işletim sistemi çekirdeği, sistem çağrılarını kendi ihtiyaçlarına göre sıralar ve tanımlar. Bu farklılık, işletim sistemlerinin özgün çekirdek 
tasarımından kaynaklanır ve bir sistemdeki sistem çağrı numaraları başka bir sistemdekiyle aynı olmak zorunda değildir.


2. Calling Convention (Çağrı Konvansiyonları)

Calling convention, bir programın fonksiyonları nasıl çağırdığı ve bu çağrılar sırasında parametrelerin nasıl iletildiği, geri dönüş değerlerinin nasıl alındığı gibi konuları 
tanımlayan bir dizi kural ve protokoldür (konvansiyon). Bu, programın farklı bileşenleri (örneğin, derleyici, link'leme ve runtime'da) arasında tutarlılığı sağlamak için 
önemlidir. Calling convention'lar, yazılım geliştirme sürecinde işlevlerin ve prosedürlerin doğru bir şekilde çağrılmasını ve yönetilmesini sağlar. 

Calling convention'lar, aşağıdaki unsurları içerir:

  Parametrelerin Geçişi:
      Kayıtlar: Parametreler, işlemci kayıtları (register) üzerinden geçilebilir. Örneğin, bazı calling convention'lar ilk birkaç parametreyi belirli kayıtlara yerleştirir.
      Yığın: Parametreler yığının (stack) üstüne itilebilir. Bu yöntem genellikle daha fazla parametre gerektiğinde kullanılır.

  Stack Cleanup:
      Fonksiyon çağrıldığında, yığın alanı nasıl temizlenecek? Çağıran fonksiyon mu yoksa çağrılan fonksiyon mu yığını temizleyecek? Bu, calling convention'a göre değişir.

  Dönüş Değeri:
      Fonksiyonun döndürdüğü değer nerede saklanacak? Genellikle, dönüş değerleri bir kayıt (örneğin, RAX kaydı x86-64 mimarisinde) üzerinden iletilir.

  Fonksiyon İçi İşlemler:
      Fonksiyon içinde yerel değişkenlerin nasıl tanımlanacağı ve yönetileceği de calling convention kapsamında belirlenir.


Calling convention türlerine örnek olarak:

- cdecl (c declaration): C dilinde yaygın olarak kullanılır. Parametreler yığına itilir ve çağıran fonksiyon yığını temizler. Dönüş değeri genellikle RAX kaydında saklanır.
- stdcall: Windows API'lerinde yaygın olarak kullanılır. Parametreler yığına itilir, ancak çağrılan fonksiyon yığını temizler. Dönüş değeri yine RAX kaydında saklanır.
- fastcall: İlk birkaç parametre kayıtlar (örneğin, ECX ve EDX) üzerinden geçer; geri kalan parametreler yığına itilir. Daha hızlı çağrılar yapmak için tasarlanmıştır.
- System V ABI: x86-64 mimarisinde Linux için kullanılır. İlk altı parametre sırasıyla RDI, RSI, RDX, R10, R8 ve R9'a yerleştirilir. Dönüş değeri genellikle RAX kaydında saklanır.
- Mach-O ABI: Mach-O ABI'yi kullanan macOS ve iOS için tipik olarak System V ABI'ye benzer bir calling convention uygulanır. İlk altı parametre sırasıyla RDI, RSI, RDX, R10, R8 ve
R9'a yerleştirilir. Geri dönüş değeri genellikle RAX kaydında saklanır. Bazı farklılıkları mevcuttur System V ABI'ye göre.


2.1. Parametre Geçişleri

Parametre geçişi, bir fonksiyonun çağrıldığı sırada, fonksiyona iletilen argümanların nasıl aktarılacağını belirleyen bir süreçtir. 
Calling convention’a bağlı olarak, bu geçiş çeşitli yöntemlerle yapılabilir.

Register Üzerinden Geçiş:

İlk birkaç parametre, işlemci kayıtları (registers) üzerinden iletilir. Bu yöntem, parametrelerin yığına (stack) göre daha hızlı erişilmesini sağlar.
x86-64 System V ABI için, ilk altı tam sayı veya işaretçi (pointer) türündeki parametre, sırasıyla aşağıdaki kayıtlara yerleştirilir:
        
  - RDI: İlk parametre
  - RSI: İkinci parametre
  - RDX: Üçüncü parametre
  - R10: Dördüncü parametre
  - R8: Beşinci parametre
  - R9: Altıncı parametre

Yeterli kayıt yoksa veya daha fazla parametre varsa, geri kalan parametreler yığına itilir.
    
Yığın (Stack) Üzerinden Geçiş:

Kayıtlarla geçilemeyen veya daha fazla parametre olması durumunda, parametreler yığına itilir. Yığın, çağrılan fonksiyonun yerel değişkenlerini ve parametrelerini saklamak için 
kullanılır. Parametreler yığına itilirken, son giren ilk çıkar (last-in, first-out (LIFO)) prensibiyle çalışır. Yani, en son eklenen parametre, en önce çıkar.
Yığın pointer'ı (RSP) bu işlem sırasında güncellenir.
    
Örnek (Aşağıda gerçekleştirilen register işlemleri arkaplanda ki parametre geçişlerinin gerçeğini yansıtmayabilir sebebi bunun kullanılan derleyici ve platforma bağlı olmasıdır. 
Sadece konunun daha iyi anlaşılması açısından varsayımda bulunulduğu söylenebilir.)
    
Aşağıdaki C dilinde yazılmış basit bir fonksiyon ve onun nasıl çağrıldığına dair bir örnek inceleyelim:
    
```c
#include <stdio.h>

void myFunction(int a, int b, int c, int d) 
{
  printf("a: %d, b: %d, c: %d, d: %d\n", a, b, c, d);
}

int main()
{
  myFunction(1, 2, 3, 4);
  return 0;
}
```

Fonksiyon Tanımı: myFunction dört tane int parametresi alır. İlk üç parametre RDI, RSI, RDX kayıtlarına yerleştirilirken, dördüncü parametre (d) yığına yerleştirilir.

Bu fonksiyon çağrıldığında, derleyici şu şekilde bir işlem yapar:
    
RDI kaydına 1 yazılır (ilk parametre).
RSI kaydına 2 yazılır (ikinci parametre).
RDX kaydına 3 yazılır (üçüncü parametre).
Dördüncü parametre (d) için yığına bir alan ayrılır ve 4 değeri buraya yazılır.

Yığın Kullanımı

Fonksiyon çağrıldığında, yığın pointer'ı (RSP) güncellenir:
    
RSP, dördüncü parametre için yığının üst kısmına işaret eder.
Fonksiyon myFunction çalıştıktan sonra, yığın temizlenir ve yığın pointer'ı eski konumuna döner.

Fonksiyonun döndürdüğü değer (örneğin, bir tam sayı), genellikle RAX kaydında saklanır. Bu sayede, çağıran fonksiyon, dönen değere kolayca erişebilir.
        
Calling convention, bir fonksiyonun nasıl çağrılacağını, parametrelerin nasıl iletileceğini ve dönüş değerlerinin nasıl alınacağını belirleyen kurallar bütünüdür.
Farklı platformlar, derleyiciler ve işletim sistemleri farklı calling convention'lar kullanabilir. Bu nedenle, bir programı geliştirirken veya farklı diller ve kütüphanelerle
çalışırken calling convention'ların anlaşılması önemlidir.


3. Assembler Farklılıkları

Farklı assembler (montaj programları) kullanıldığında bazı önemli farklılıklar ortaya çıkar. Bu farklılıklar, kodun yazımı, derlenmesi ve çalıştırılması üzerinde etkili olabilir.

Farklı assembler’lar, farklı sözdizimleri kullanabilir.

Örneğin:

  GAS (GNU Assembler): AT&T sözdizimini kullanır.
  NASM (Netwide Assembler): Intel sözdizimini kullanır.

Bu sözdizimsel farklılıklar, aynı işlemci mimarisine sahip sistemlerde bile assembly kodunun yazılışını ve derlenmesini etkiler.

Örnek Sözdizimi Farklılıkları:

- GAS AT&T ( Hedeften önce kaynak ):

```
movl %eax, %ebx   ; EAX içeriğini EBX'e kopyala
```


- NASM Intel ( Kaynaktan önce hedef ):

```
mov ebx, eax      ; EAX içeriğini EBX'e kopyala
```

Bu iki sözdizimi, komutların yazımını ve parametrelerin sırasını etkiler. Örneğin, AT&T sözdiziminde kaynak ve hedef sıralaması farklıdır.


4. İşletim Sistemi Konvansiyon Standartları 

Örnek olarak `global _main` ifadesinin macOS'ta, `global _start` ifadesinin ise Linux'ta kullanılmasının sebepleri, işletim sistemlerinin yükleme ve başlatma (initialization) 
süreçlerinde kullanılan konvansiyonlardan ve standartlardan kaynaklanmaktadır.

macOS:

`_main`: macOS uygulamaları genellikle bir C runtime (çalışma zamanı) ortamı altında başlar. Bu nedenle, uygulama çalıştırıldığında işletim sistemi, main fonksiyonunu çağırmadan 
önce gerekli başlangıç işlemlerini (örn. bellek ayırma, dosya sistemi hazırlığı) yapar.

Uygulama kodunda `global _main` ifadesi kullanıldığında, assembler (montaj programı) bu fonksiyonu dışarıdan erişilebilir hale getirir, böylece işletim sistemi program çalıştığında 
main fonksiyonunu çağırabilir. macOS'da, uygulama başlamadan önce bir C kütüphane başlatıcısı (startup routine) kullanılır, bu da main fonksiyonunun başlangıç noktası olarak 
belirlenmesini sağlar.


Linux:

`_start`: Linux'ta ise, uygulamalar doğrudan `_start` isimli bir etiketle başlar. Bu, işletim sisteminin doğrudan uygulama kodunun giriş noktasına atlaması anlamına gelir.
    
`_start` etiketi genellikle, işletim sisteminin C runtime'ı başlatmadan önce yaptığı bazı temel hazırlık işlemlerini içerir. Örneğin, yığın (stack) ve yığın göstergesi 
(stack pointer) gibi bazı temel yapılandırmalar yapılır.
    
İşletim sistemi, `_start` etiketi ile başlarken, C kütüphanesi main fonksiyonunu çağırmadan önce gerekli tüm başlatma işlemlerini (örneğin, sistem çağrılarına erişim ve çevre 
değişkenlerinin hazırlanması) yapar.
    

Kütüphane ve Runtime Farklılıkları

macOS, genellikle C tabanlı uygulamaları başlatmak için `libSystem.dylib` veya `libc.dylib` kütüphanesini kullanırken, Linux, `glibc` kütüphanesini kullanır.
Bu farklı kütüphane yapılandırmaları, başlatma sürecinin nasıl yürütüleceğini ve hangi etiketlerin kullanılacağını etkiler.
    
    
    
Yükleme ve Çalışma Zamanı Ortamları

macOS: macOS uygulamaları genellikle Cocoa veya Cocoa Touch gibi yüksek seviyeli çerçevelerle etkileşim halindedir, bu da başlatma sürecinin daha karmaşık olmasını sağlar.
Linux: Linux'ta ise uygulama daha doğrudan sistem kaynaklarına erişir, bu da daha düşük seviyeli bir etkileşim gerektirir.
    
    
    
- `global _main` ve `global _start` ifadeleri, macOS ve Linux'un uygulama başlatma konvansiyonlarından kaynaklanmaktadır.
- macOS'da main fonksiyonu bir C çalışma zamanı ile çağrılırken, Linux'ta `_start` etiketi doğrudan işletim sistemi tarafından çağrılır.
- Her iki işletim sistemi de kendi kütüphane yapılandırmalarını ve başlatma süreçlerini kullanarak uygulamaların başlangıç noktalarını belirler.
Bu farklılıklar, sistem çağrıları, bellek yönetimi ve uygulama başlatma süreçleri gibi konularda önemli etkilere sahiptir.

Örneğin aşağıda ki assembly kodunu Linux sisteminde çalıştırmaya kalkışırsak:

```asm
section .data
msg: db "Selam", 0xA

section .text
    global _main

_main:
	mov rax, 1
	mov rdi, 1
	mov rsi, msg
	mov rdx, 5
	syscall
	mov rax, 60
	mov rdi, 0
	syscall
```

Linux sisteminde link'leme yapılırken alınan bir hata (link'leme ve daha fazlası için 3. bölüme bkz.):

```
ld: warning: cannot find entry symbol _start; defaulting to 0000000000702000
```

Bu hata, linker (bağlayıcı) programının, yürütülebilir dosyanın giriş noktasını (entry point) belirlemekte zorlandığını gösteriyor. 
Linker, bir programın başlama noktasını tanımlayan bir etiket arar. Bu noktaya genellikle `_start` adı verilir. Kodunuzda `_start` etiketi tanımlı değil, 
bu nedenle linker varsayılan olarak giriş noktası olarak `0x0000000000702000` adresini kullanıyor.


Kodunuzun başlangıcında `_start` etiketini tanımlayarak, işletim sisteminin uygulamanızın başlangıç noktasını bilmesini sağlamalısınız. `_start`, 
işletim sisteminin uygulamayı başlattığında ilk olarak ulaşacağı yer olacaktır.

Neden `_start`

- Tamamıyla işletim sisteminin tasarımında ki konvansiyon ile ilgidir. 

- `_start`, genellikle işletim sisteminin uygulamanızı başlatırken ilk olarak çağırdığı etikettir. Bu etiketin bulunmaması durumunda, linker hatası ile karşılaşırsınız.

Bu gibi faktörler yazılan assembly kodunun farklı bir sistem de çalışmamasına sebebiyet verebilir.


## :two: CPU'da ki Register'lar Nedir?

Hazırlanıyor..


   
