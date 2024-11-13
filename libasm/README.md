<img src="https://github.com/Fartomy/42-Out-Core/blob/main/libasm/mats/imgs/welder.gif" align="right" height="400">

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

> [!IMPORTANT]  
> **Konu ile alakası olmayan bir bilgi**
> 
> Örneğin yine bir örnek olarak Arch-Linux'u ele alalım. Arch-Linux'un bir koşul haricinde aslında Linux ile bir gram alakası yoktur. Çünkü Arch, içine istenilen çekirdeği entegre etme seçeneği özgürlüğünü sunduğundan Linux çekirdeklerinden herhangi biri kurulmadığı veya başka bir çekirdek kurulabildiği taktirde `Arch`, `Arch-Linux` ile bağdaşık olmayacaktır. Ki değildir de zaten.

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
`...bu konvansiyonların sebeplerinin işletim sistemine bağlı olarak standartlaştırıldığı.` bilgisini verseydim bu soyutlamaya bilinçsizce bir katkı da bu yazınin kendisi 
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

---

## 🧭 Yol Haritası

...

---

## :one: CPU Nedir?

CPU, cihazın içindeki tüm hesaplama işlemlerini gerçekleştirir ve diğer bileşenleri (bellek, giriş-çıkış aygıtları vb.) yönlendirir.
Bir bilgisayarın çalışması için temel talimatları işler ve programların yürütülmesini sağlar.

**CPU'nun Temel Görevleri:**

-    **Talimatları Yorumlama**: CPU, bellekte saklanan talimatları alır ve ne yapılması gerektiğini anlar.
-    **Veri İşleme**: CPU, matematiksel ve mantıksal işlemler yaparak verileri işler.
-    **Veri Taşıma**: Veriyi bellekten alır, işler ve sonuçları tekrar belleğe veya ilgili çıkış aygıtlarına gönderir.
-    **Kontrol**: Diğer donanım bileşenlerini koordine eder ve gerektiğinde onlara veri veya talimatlar gönderir.

**CPU'nun Ana Bileşenleri:**

-    **Kontrol Birimi (Control Unit - CU)**: CPU'nun hangi işlemi yapacağını belirler ve talimatları yürütmek için gerekli verileri uygun bileşenlere yönlendirir.
-    **Aritmetik Mantık Birimi (Arithmetic Logic Unit - ALU)**: Tüm aritmetik (toplama, çıkarma vb.) ve mantıksal (AND, OR, NOT gibi işlemler) işlemleri gerçekleştirir.
-    **Kayıtlar (Registers)**: CPU içinde geçici olarak veri saklayan küçük, hızlı bellek alanlarıdır. İşlenen verilerin hızla erişilebilmesi için bu alanlar kullanılır.
-    **Önbellek (Cache)**: Sık kullanılan verilere hızlı erişim sağlamak için tasarlanmış bir bellektir. Bu sayede işlemler hızlandırılır.

**CPU'nun Çalışma Döngüsü (Fetch-Decode-Execute):**

-    **Fetch (Getir)**: CPU, RAM'den işlenecek bir talimat alır.
-    **Decode (Çözümle)**: Bu talimatı çözümler ve ne yapılması gerektiğini anlar.
-    **Execute (Yürüt)**: Talimatı işler ve sonucu elde eder.


### Mikro İşlemci Tarihinin Önemli Noktaları

Intel 8086 işlemcisi, bilgisayar tarihindeki en önemli mikroişlemcilerden biri olarak kabul edilir ve günümüz bilgisayar mimarisinin temelini oluşturmuştur. 
8086'nın tarihsel önemi, hem donanım hem de yazılım dünyasında yaptığı devrimsel yeniliklerle ilgilidir. Intel 8086'nın tarihsel açıdan neden bu kadar 
önemli olduğunun temel nedenlerine göz atalım:

1. **x86 Mimarisi'nin Doğuşu**

    Intel 8086, x86 mimarisi olarak bilinen işlemci ailesinin ilk üyesidir. Bu mimari, günümüzde kullandığımız modern bilgisayarların temelinde yer alır.
    x86 mimarisi, kişisel bilgisayarların ve sunucuların büyük çoğunluğunda kullanılan standart işlemci mimarisi haline gelmiştir. 8086 ile başlayan bu mimari,
    sürekli gelişim göstermiş ve bugünkü 64-bit işlemciler (x86-64) haline gelmiştir.

3. **16-bit İşlemci**

    Intel 8086, Intel'in ilk 16-bit mikroişlemcisiydi. Bu, o dönemin bilgisayarları için büyük bir gelişmeydi, çünkü önceki işlemciler genellikle 8-bit'ti.
    16-bit veri işleme kapasitesi, aynı anda daha fazla veri işleyebilme ve daha geniş bellek adresleme anlamına geliyordu. 8086, doğrudan 1 MB'a kadar bellek
    adresleyebiliyordu ki bu, önceki nesillere göre çok büyük bir iyileşmeydi.
    
5. **Mikroişlemci Devriminin Bir Parçası**

    8086, mikroişlemci devrimini hızlandıran işlemcilerden biri oldu. Mikroişlemciler, daha önce büyük ve pahalı olan bilgisayarları çok daha küçük, daha ucuz ve yaygın hale
    getirdi. 8086'nın yaygın olarak kullanılmasıyla bilgisayarlar, sadece iş dünyasında değil, evlerde de yer almaya başladı. Bu, kişisel bilgisayarın günlük yaşamda bir araç
    haline gelmesinin önünü açtı.

7. **Geriye Dönük Uyumluluk**

    8086 işlemcisi, Intel'in önceki 8-bit işlemcisi olan Intel 8080 ile yazılım uyumluluğunu koruyordu. Bu sayede, eski yazılımlar 8086'da da çalışabiliyordu.
    Bu geriye dönük uyumluluk stratejisi, Intel'in x86 mimarisinin büyük bir avantajı haline geldi ve sonraki yıllarda da sürdü. x86 ailesindeki her yeni işlemci,
    önceki nesillere uyumlu kalmaya çalıştı, bu da yazılım geliştirme açısından büyük bir kolaylık sağladı.

9. **Segmentli Bellek Adresleme**

    Intel 8086, segmentli bellek adresleme modelini tanıttı. Bu model, 16-bit adresleme sınırını aşarak 1 MB'a kadar bellek adreslenebilmesini sağladı.
    Segmentli bellek, o dönemin sınırlı bellek kapasitesine rağmen, daha büyük ve daha karmaşık programların çalıştırılmasına olanak tanıdı.

10. **Yazılım Gelişimi Üzerindeki Etkisi**

    Intel 8086, yeni yazılım paradigmalara öncülük etti. MS-DOS gibi işletim sistemleri ve çeşitli programlama dilleri (örneğin, Assembly, C) bu işlemci üzerine inşa edildi.
    x86 mimarisinin gücü ve yaygınlığı, yazılım geliştirme dünyasını etkiledi ve yazılım sektörü bu mimari üzerine büyük ölçüde odaklandı. 8086 ile başlayan bu yazılım ekosistemi,
    günümüzde Windows, Linux ve diğer büyük işletim sistemlerinin temelidir.

12. **Endüstri Standardı Haline Gelmesi**

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

1. **Talimat Seti Mimarisi (ISA - Instruction Set Architecture)**

    Talimat Seti, işlemcinin hangi komutları çalıştırabileceğini tanımlar. Bir işlemciye verilen görevler (örneğin, iki sayıyı toplama, bir değeri bellekten okuma) bu talimat seti aracılığıyla gerçekleştirilir.
    Örneğin, x86 ve ARM gibi mimariler farklı komut setlerine sahiptir. Bir yazılım, işlemcinin talimat setine uygun şekilde yazılmalıdır.
    Talimat seti mimarisi ayrıca, işlemcinin kaç bitlik veriyi işleyebileceğini (örneğin 32-bit veya 64-bit) ve hangi veri türlerini (tam sayılar, kayan noktalı sayılar, karakterler vb.) desteklediğini tanımlar.

2. **Veri Yolları ve Kayıtlar (Registers)**

    Kayıtlar (registers), işlemcinin verileri ve adresleri geçici olarak depoladığı çok hızlı küçük bellek alanlarıdır. İşlemci mimarisi, kaç adet kaydın olacağını ve bu kayıtların ne kadar veri tutabileceğini belirler (örneğin, 32-bit ya da 64-bit).
    Veri yolu ise, işlemcinin veri taşımak için kullandığı hatlardır. Veri yolları, işlemci içinde ve bellek, giriş/çıkış birimleri gibi dış kaynaklarla bağlantı sağlar.


Bazı farklı işlemci mimarisi örnekleri: _x86, ARM, PowerPC, RISC-V, MIPS, SPARC, VLIW_

Talimat Seti Yapisi Türleri:

1. **CISC (Complex Instruction Set Computing)**

    CISC talimat seti yapisi, çok sayıda ve karmaşık komutları destekleyen bir mimaridir. Bir CISC işlemcisi, genellikle bir komutla birden fazla işlemi yapabilir.
    x86 mimarisi, CISC türündedir. Bu tür mimarilerde, daha az komutla daha çok iş yapılması hedeflenir.

2. **RISC (Reduced Instruction Set Computing)**

    RISC talimat seti yapisi, basit ve sınırlı sayıda talimat seti kullanır, ancak bu komutlar hızlı ve verimli şekilde çalışır. Her komut, genellikle işlemcinin bir saat döngüsünde tamamlanır.
    ARM mimarisi, RISC tabanlıdır. RISC işlemciler, genellikle daha düşük güç tüketimi ve daha hızlı performans sunar.

### Talimat Seti Nedir? Neden Gereklidir?

Talimat seti (ISA - Instruction Set Architecture), bir işlemcinin çalıştırabileceği temel işlemlerin ve bu işlemleri nasıl gerçekleştirdiğinin tanımlandığı bir dizi talimattır. 
Diğer bir deyişle, talimat seti, bir işlemci ile onun çalıştırdığı yazılımlar arasında bir arabuluculuk görevi görür. Bir yazılım, işlemci üzerindeki donanımı kontrol etmek için 
talimat setini kullanır.

**Talimat seti'nin Bileşenleri:**

  **Talimatlar (Instructions):**
      Talimatlar, işlemciye hangi işlemi yapması gerektiğini anlatan komutlardır. Örneğin, toplama, çıkarma, veri taşıma, koşullu dallanma, veri okuma/yazma gibi işlemleri 
      içerebilir.

  **Veri Tipleri:**
      talimat seti, işlemcinin hangi tür verilerle çalışabileceğini tanımlar. Örneğin, tamsayılar, kayan noktalı sayılar, karakterler vb.

  **Adresleme Modları:**
      talimat seti, verilerin bellekte nasıl bulunacağını ve işleneceğini belirleyen adresleme modlarını tanımlar. Verilere doğrudan, dolaylı veya kaydırmalı şekilde ulaşılabilir.

  **Kayıtlar (Registers):**
      İşlemcinin komutlar üzerinde çalışırken kullandığı küçük, hızlı bellek alanları olan kayıtların ne amaçla kullanıldığı talimat seti ile tanımlanır.
        
1. **Donanım ile Yazılım Arasındaki Bağ**

    Talimat seti, donanım ile yazılım arasında bir köprü görevi görür. Bir yazılımın işlemci üzerinde çalışabilmesi için, işlemcinin tanıyacağı komutlar ile yazılması gerekir.
    Örneğin, bir yazılımın iki sayıyı toplaması gerektiğinde, işlemciye bu talimatı iletebilmek için belirli bir talimat setini kullanması gerekir.

2. **Yazılım Uyumluluğu**

    Belirli bir talimat seti, işlemciye hangi yazılımların çalışabileceğini belirler. Yazılım, belirli bir işlemci talimat setine uygun olarak yazılmışsa, o işlemci üzerinde
    çalışabilir. Bu nedenle, talimat seti aynı olan işlemcilerde yazılımlar uyumlu bir şekilde çalışabilir.
    Örneğin, x86 mimarisine sahip bir işlemci, x86 talimat setine uygun yazılımları çalıştırabilir. Aynı şekilde, ARM mimarisi işlemcilerde ARM talimat setine uygun yazılımlar
    çalışır. Eğer bir yazılım başka bir talimat setine göre yazılmışsa, bu farklı mimaride çalışmaz.

3. **Standart İşlemler**

    Talimat seti, işlemcinin gerçekleştireceği işlemler için standart bir yol sağlar. Bu, matematiksel işlemler (toplama, çıkarma), bellekten veri okuma/yazma,
    koşullu dallanma (if/else yapısı) gibi temel işlemlerin işlemci tarafından nasıl yapılacağını tanımlar.
    Her işlemci, bir toplama işlemi yapmak için belirli bir komut kullanır (örneğin, ADD komutu).

4. **Performans ve Verimlilik**

    Talimat seti, işlemcinin verimliliğini ve performansını doğrudan etkiler. Daha optimize edilmiş ve basit bir talimat seti, işlemcinin işlemleri daha hızlı gerçekleştirmesini
    sağlar.
    Özellikle RISC (Reduced Instruction Set Computing) mimarisinde, komutlar basit ve hızlı çalışacak şekilde optimize edilmiştir. Bu da işlemcinin enerji verimliliğini ve
    işlem hızını artırır.        

5. **Donanım Soyutlaması**

    talimat seti, geliştiricilere donanımın karmaşıklığını gizleyen bir soyutlama sağlar. Yazılım geliştiricileri, talimat setini kullanarak işlemcinin ne yaptığını anlamadan,
    yazılımlarını donanım üzerinde çalıştırabilirler.
    Bu sayede yazılım geliştirme, donanım tasarımından bağımsız hale gelir ve daha hızlı bir şekilde ilerleyebilir.
    
 
**Talimat Seti Türleri:**
1. **CISC (Complex Instruction Set Computing)**

    CISC talimat seti, çok sayıda karmaşık komut içerir ve bu komutlar, birden fazla işlem gerçekleştirebilir.
    CISC, her komutun donanımda karmaşık bir işlevi gerçekleştirmesine izin verir, bu da kodlamayı kolaylaştırır ancak işlemci daha fazla enerji harcayabilir ve daha karmaşık olabilir.
    Örnek: x86 mimarisi, CISC talimat setine dayalıdır.

2. **RISC (Reduced Instruction Set Computing)**

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

  **Bire Bir Eşleşme:**
      Eğer bir assembly dilinde yazılan her bir komut, doğrudan ve tam olarak bir makine kodu talimatı ile eşleşiyorsa, buna `one-to-one` eşleşme denir. 
      Yani, her assembly komutu için sadece bir makine kodu talimatı vardır.
    
  **Güçlü Ama Bire Bir Değil:**
     Assembly dilindeki bazı komutların birden fazla makine kodu talimatına dönüşebileceği veya bir makine kodu talimatının birden fazla assembly komutuyla temsil edilebileceği 
     anlamına gelir. Bir assembly komutu, belirli bir işlem için daha karmaşık bir makine kodu talimatı gerektirebilir. Veya bir makine kodu talimatı, farklı durumlarda farklı 
     assembly komutları ile temsil edilebilir.

_One-to-one_ ifadesi, bir assembly komutunun doğrudan bir makine kodu talimatı ile eşleşip eşleşmediğini belirtir. 
Bu bağlamda, güçlü bir ilişki olsa da, her zaman bire bir bir eşleşme söz konusu olmayabilir, bu da dilin esnekliğini ve karmaşıklığını artırır.

#### Assembly Kodunun Sistemler Arasında ki Çalışma Farklılıkları

1. **Kodun İşlemci Mimarisine Göre Çalışıp Çalışmaması Durumu:**

Bir mimariye özgü yazılmış assembly kodu farklı bir mimaride çalışamaz. Bu da assembly dilini taşınılabilir yapmaz.
Örneğin x86 mimarisi kullanan bir cihaz da yazılmış olan bir assembly kodu, ARM mimarisi kullanan bir cihaz da çalışamaz

2. **Kodun İşletim Sitemine Göre Çalışıp Çalışmaması Durumu:**

Bunu etkileyen bazı fakörler:

- Sistem çağrı numaraları
- Calling Convention (stdcall, cdecl, fastcall vb. (bunlar calling convention türleridir)) fonksiyonların parametrelerinin ve argümanlarının çağrılma konvansiyonu
- Parametre geçişleri örneğin Linux System V ABI kullanır. MacOS ise Mach-O ABI kullanır. Bu ABI'ler, sistem çağrılarının ve fonksiyon çağrılarının nasıl yapılacağını, parametrelerin nasıl iletileceğini ve dönüş değerlerinin nasıl alınacağın belirler.
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

- **Çağrı Numarası**: Sistem çağrısı yaparken, işlemcinin belirli bir kaydına (register) hangi çekirdek işleminin yapılması gerektiğini gösteren bir sistem çağrısı numarası yerleştirilir.
- **Parametreler**: İşlemin gerçekleştirilmesi için gereken veriler ve parametreler diğer kayıtlara yüklenir.
- **Sistem Çağrısını Başlatma**: int 0x80 (32-bit Linux) veya syscall (64-bit Linux ve bazı diğer sistemlerde) gibi bir talimat ile çağrı yapılır.
- **Sonuç**: Çekirdek işlemi tamamlayıp sonucu döndürür ve kontrol tekrar kullanıcı moduna geçer.

Sistem çağrısı numaraları işletim sistemine göre farklılık gösterir çünkü her işletim sistemi, kendi çekirdek tasarımına ve ihtiyaçlarına göre bu çağrıları tanımlar ve sıralar.
Bu yüzden Linux, macOS, Windows gibi işletim sistemlerinde aynı işleve sahip sistem çağrıları farklı numaralara sahip olabilir.

Örneğin:

	Linux: sys_write çağrısı 32-bit Linux sistemlerde 1 numarasına sahiptir.
	macOS: Aynı write çağrısı için macOS'ta 4 numarası kullanılır.

Bu farklılıkların nedeni, her işletim sisteminin kendi sistem çağrısı tablosuna ve iç organizasyonuna sahip olmasıdır. 
Her işletim sistemi çekirdeği kendi sistem çağrı numaralarını tanımlarken kendi öncelik ve ihtiyaçlarını gözetir. 
Örneğin, Linux, dosya işlemlerini başlangıçta tanımlarken, macOS başka bir işlevi öncelikli hale getirmiş olabilir.

**Sistem çağrıları standart olmadığından:**

  Çekirdek Tasarımı ve Geliştirme Farklılıkları: İşletim sistemleri farklı çekirdek mimarilerine ve iç tasarıma sahiptir. Linux ve macOS gibi Unix benzeri sistemler bile bu 
  numaralar konusunda farklı tasarımlara sahip olabilirler.
  Taşınabilirlikten Çok Performansa Odaklanma: Sistem çağrıları düşük seviyeli işlemler olduğundan, işletim sistemi geliştiricileri taşınabilirlikten ziyade kendi sistemlerinin 
  performansına ve güvenliğine öncelik verirler. Bu nedenle, sistem çağrılarının standart hale getirilmesi beklenmez.
  Farklı İşlevlere Sahip Olma: Her işletim sisteminin sağladığı fonksiyonlar ve yetenekler aynı değildir. Bu nedenle bazı sistem çağrıları belirli bir işletim sistemine özgü 
  olabilir.

Sistem çağrıları, uygulamaların işletim sisteminin çekirdek işlevlerini kullanmasını sağlayan yöntemlerdir. Sistem çağrı numaraları, işletim sistemine özgüdür ve standart 
değildir; çünkü her işletim sistemi çekirdeği, sistem çağrılarını kendi ihtiyaçlarına göre sıralar ve tanımlar. Bu farklılık, işletim sistemlerinin özgün çekirdek 
tasarımından kaynaklanır ve bir sistemdeki sistem çağrı numaraları başka bir sistemdekiyle aynı olmak zorunda değildir.


2. **Calling Convention (Çağrı Konvansiyonları)**

Calling convention, bir programın fonksiyonları nasıl çağırdığı ve bu çağrılar sırasında parametrelerin nasıl iletildiği, geri dönüş değerlerinin nasıl alındığı gibi konuları 
tanımlayan bir dizi kural ve protokoldür (konvansiyon). Bu, programın farklı bileşenleri (örneğin, derleyici, link'leme ve runtime'da) arasında tutarlılığı sağlamak için 
önemlidir. Calling convention'lar, yazılım geliştirme sürecinde işlevlerin ve prosedürlerin doğru bir şekilde çağrılmasını ve yönetilmesini sağlar. 

Calling convention'lar, aşağıdaki unsurları içerir:

  **Parametrelerin Geçişi:**
      Kayıtlar: Parametreler, işlemci kayıtları (register) üzerinden geçilebilir. Örneğin, bazı calling convention'lar ilk birkaç parametreyi belirli kayıtlara yerleştirir.
      Yığın: Parametreler yığının (stack) üstüne itilebilir. Bu yöntem genellikle daha fazla parametre gerektiğinde kullanılır.

  **Stack Cleanup:**
      Fonksiyon çağrıldığında, yığın alanı nasıl temizlenecek? Çağıran fonksiyon mu yoksa çağrılan fonksiyon mu yığını temizleyecek? Bu, calling convention'a göre değişir.

  **Dönüş Değeri:**
      Fonksiyonun döndürdüğü değer nerede saklanacak? Genellikle, dönüş değerleri bir kayıt (örneğin, RAX kaydı x86-64 mimarisinde) üzerinden iletilir.

  **Fonksiyon İçi İşlemler:**
      Fonksiyon içinde yerel değişkenlerin nasıl tanımlanacağı ve yönetileceği de calling convention kapsamında belirlenir.


Calling convention türlerine örnek olarak:

- **cdecl (c declaration):** C dilinde yaygın olarak kullanılır. Parametreler yığına itilir ve çağıran fonksiyon yığını temizler. Dönüş değeri genellikle RAX kaydında saklanır.
- **stdcall:** Windows API'lerinde yaygın olarak kullanılır. Parametreler yığına itilir, ancak çağrılan fonksiyon yığını temizler. Dönüş değeri yine RAX kaydında saklanır.
- **fastcall:** İlk birkaç parametre kayıtlar (örneğin, ECX ve EDX) üzerinden geçer; geri kalan parametreler yığına itilir. Daha hızlı çağrılar yapmak için tasarlanmıştır.
- **System V ABI:** x86-64 mimarisinde Linux için kullanılır. İlk altı parametre sırasıyla RDI, RSI, RDX, R10, R8 ve R9'a yerleştirilir. Dönüş değeri genellikle RAX kaydında saklanır.
- **Mach-O ABI:** Mach-O ABI'yi kullanan macOS ve iOS için tipik olarak System V ABI'ye benzer bir calling convention uygulanır. İlk altı parametre sırasıyla RDI, RSI, RDX, R10, R8 ve R9'a yerleştirilir. Geri dönüş değeri genellikle RAX kaydında saklanır. Bazı farklılıkları mevcuttur System V ABI'ye göre.


2.1. **Parametre Geçişleri**

Parametre geçişi, bir fonksiyonun çağrıldığı sırada, fonksiyona iletilen argümanların nasıl aktarılacağını belirleyen bir süreçtir. 
Calling convention’a bağlı olarak, bu geçiş çeşitli yöntemlerle yapılabilir.

**Register Üzerinden Geçiş:**

İlk birkaç parametre, işlemci kayıtları (registers) üzerinden iletilir. Bu yöntem, parametrelerin yığına (stack) göre daha hızlı erişilmesini sağlar.
x86-64 System V ABI için, ilk altı tam sayı veya işaretçi (pointer) türündeki parametre, sırasıyla aşağıdaki kayıtlara yerleştirilir:
        
  - **RDI**: İlk parametre
  - **RSI**: İkinci parametre
  - **RDX**: Üçüncü parametre
  - **R10**: Dördüncü parametre
  - **R8**: Beşinci parametre
  - **R9**: Altıncı parametre

Yeterli kayıt yoksa veya daha fazla parametre varsa, geri kalan parametreler yığına itilir.
    
**Yığın (Stack) Üzerinden Geçiş:**

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

**Yığın Kullanımı**

Fonksiyon çağrıldığında, yığın pointer'ı (RSP) güncellenir:
    
RSP, dördüncü parametre için yığının üst kısmına işaret eder.
Fonksiyon myFunction çalıştıktan sonra, yığın temizlenir ve yığın pointer'ı eski konumuna döner.

Fonksiyonun döndürdüğü değer (örneğin, bir tam sayı), genellikle RAX kaydında saklanır. Bu sayede, çağıran fonksiyon, dönen değere kolayca erişebilir.
        
Calling convention, bir fonksiyonun nasıl çağrılacağını, parametrelerin nasıl iletileceğini ve dönüş değerlerinin nasıl alınacağını belirleyen kurallar bütünüdür.
Farklı platformlar, derleyiciler ve işletim sistemleri farklı calling convention'lar kullanabilir. Bu nedenle, bir programı geliştirirken veya farklı diller ve kütüphanelerle
çalışırken calling convention'ların anlaşılması önemlidir.


3. **Assembler Farklılıkları**

Farklı assembler (montaj programları) kullanıldığında bazı önemli farklılıklar ortaya çıkar. Bu farklılıklar, kodun yazımı, derlenmesi ve çalıştırılması üzerinde etkili olabilir.

Farklı assembler’lar, farklı sözdizimleri kullanabilir.

Örneğin:

  	GAS (GNU Assembler): AT&T sözdizimini kullanır.
  	NASM (Netwide Assembler): Intel sözdizimini kullanır.

Bu sözdizimsel farklılıklar, aynı işlemci mimarisine sahip sistemlerde bile assembly kodunun yazılışını ve derlenmesini etkiler.

Örnek Sözdizimi Farklılıkları:

- **GAS AT&T (Hedeften önce kaynak):**

```asm
movl %eax, %ebx   ; EAX içeriğini EBX'e kopyala
```


- **NASM Intel **(Kaynaktan önce hedef):**

```asm
mov ebx, eax      ; EAX içeriğini EBX'e kopyala
```

Bu iki sözdizimi, komutların yazımını ve parametrelerin sırasını etkiler. Örneğin, AT&T sözdiziminde kaynak ve hedef sıralaması farklıdır.


4. **İşletim Sistemi Konvansiyon Standartları**

Örnek olarak `global _main` ifadesinin macOS'ta, `global _start` ifadesinin ise Linux'ta kullanılmasının sebepleri, işletim sistemlerinin yükleme ve başlatma (initialization) 
süreçlerinde kullanılan konvansiyonlardan ve standartlardan kaynaklanmaktadır.

**macOS:**

`_main`: macOS uygulamaları genellikle bir C runtime (çalışma zamanı) ortamı altında başlar. Bu nedenle, uygulama çalıştırıldığında işletim sistemi, main fonksiyonunu çağırmadan 
önce gerekli başlangıç işlemlerini (örn. bellek ayırma, dosya sistemi hazırlığı) yapar.

Uygulama kodunda `global _main` ifadesi kullanıldığında, assembler (montaj programı) bu fonksiyonu dışarıdan erişilebilir hale getirir, böylece işletim sistemi program çalıştığında 
main fonksiyonunu çağırabilir. macOS'da, uygulama başlamadan önce bir C kütüphane başlatıcısı (startup routine) kullanılır, bu da main fonksiyonunun başlangıç noktası olarak 
belirlenmesini sağlar.


**Linux:**

`_start`: Linux'ta ise, uygulamalar doğrudan `_start` isimli bir etiketle başlar. Bu, işletim sisteminin doğrudan uygulama kodunun giriş noktasına atlaması anlamına gelir.
    
`_start` etiketi genellikle, işletim sisteminin C runtime'ı başlatmadan önce yaptığı bazı temel hazırlık işlemlerini içerir. Örneğin, yığın (stack) ve yığın göstergesi 
(stack pointer) gibi bazı temel yapılandırmalar yapılır.
    
İşletim sistemi, `_start` etiketi ile başlarken, C kütüphanesi main fonksiyonunu çağırmadan önce gerekli tüm başlatma işlemlerini (örneğin, sistem çağrılarına erişim ve çevre 
değişkenlerinin hazırlanması) yapar.
    

**Kütüphane ve Runtime Farklılıkları**

macOS, genellikle C tabanlı uygulamaları başlatmak için `libSystem.dylib` veya `libc.dylib` kütüphanesini kullanırken, Linux, `glibc` kütüphanesini kullanır.
Bu farklı kütüphane yapılandırmaları, başlatma sürecinin nasıl yürütüleceğini ve hangi etiketlerin kullanılacağını etkiler.
    
    
    
**Yükleme ve Çalışma Zamanı Ortamları**

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

**Linux sisteminde link'leme yapılırken alınan bir hata:**

```
ld: warning: cannot find entry symbol _start; defaulting to 0000000000702000
```

Bu hata, linker (bağlayıcı) programının, yürütülebilir dosyanın giriş noktasını (entry point) belirlemekte zorlandığını gösteriyor. 
Linker, bir programın başlama noktasını tanımlayan bir etiket arar. Bu noktaya genellikle `_start` adı verilir. Kodunuzda `_start` etiketi tanımlı değil, 
bu nedenle linker varsayılan olarak giriş noktası olarak `0x0000000000702000` adresini kullanıyor.


Kodunuzun başlangıcında `_start` etiketini tanımlayarak, işletim sisteminin uygulamanızın başlangıç noktasını bilmesini sağlamalısınız. `_start`, 
işletim sisteminin uygulamayı başlattığında ilk olarak ulaşacağı yer olacaktır.

**Neden `_start`**

- Tamamıyla işletim sisteminin tasarımında ki konvansiyon ile ilgidir. 

- `_start`, genellikle işletim sisteminin uygulamanızı başlatırken ilk olarak çağırdığı etikettir. Bu etiketin bulunmaması durumunda, linker hatası ile karşılaşırsınız.

Bu gibi faktörler yazılan assembly kodunun farklı bir sistem de çalışmamasına sebebiyet verebilir.

---

## :two: CPU'da ki Register'lar Nedir?

CPU'daki register'lar (kayıtlar), işlemcinin içerisinde bulunan ve çok hızlı veri depolayan küçük bellek alanlarıdır. Bu register'lar, CPU'nun işlediği verileri geçici olarak saklar ve doğrudan erişim sağlar. İşlemcinin en hızlı çalışan bileşenlerinden biri olarak, register'lar CPU'nun verileri işlemesinde büyük bir rol oynar ve işlem sırasında anında erişim gereken bilgiler burada tutulur.

Register'ların Özellikleri:

    Çok hızlıdırlar: Register'lar, CPU'nun diğer hafıza türlerinden (RAM, önbellek gibi) çok daha hızlı çalışır, çünkü doğrudan işlemci çekirdeği ile bağlantılıdırlar.
    Küçük boyutludurlar: Register'lar, kapasite açısından oldukça küçüktür. Genellikle sadece birkaç byte tutabilirler.
    Geçici depolama sağlarlar: Veriler yalnızca kısa bir süre (işlem süresi boyunca) register'da tutulur; bir sonraki işlemde yeni verilerle değiştirilirler.


CPU'nun içerisinde birkaç farklı sınıfta register'lar bulunur ve bunların özel bir işlevi vardır. Her işlemci mimarisi, tasarımında farklı amaçlara hizmet eden farklı sayıda ve türde register içerir:

	1. 8086 (16 Bit) 
	Toplam Register Sayısı: 14 register 
	Genel Amaçlı: 4 (AX, BX, CX, DX) 
	Pointer ve Index: 4 (SP, BP, SI, DI) 
	Segment: 4 (CS, DS, SS, ES)
	Diğer: 2 (IP, FLAGS)


	2. x86-32 (32 Bit)
	Toplam Register Sayısı: 16 register
	Genel Amaçlı: 8 (EAX, EBX, ECX, EDX, ESI, EDI, EBP, ESP)
	Segment: 6 (CS, DS, SS, ES, FS, GS) </br>
	Diğer: 2 (EIP, EFLAGS) </br>


	3. x86-64 (64 Bit)
	Toplam Register Sayısı: 22 register
	Genel Amaçlı: 16 (RAX, RBX, RCX, RDX, RSI, RDI, RBP, RSP, R8, R9, R10, R11, R12, R13, R14, R15)
	Segment: 6 (CS, DS, SS, ES, FS, GS)
	Diğer: 2 (RIP, RFLAGS)


8086'dan x86-32'ye geçişte genel amaçlı register sayısı artmıştır (4'ten 8'e). Bu, daha fazla veri işleme yeteneği sağlar.
x86'dan x86-64'e geçişte ise genel amaçlı register sayısı daha da artmıştır (8'den 16'ya). Bu da 64 bit işlem yapabilme ve daha fazla veri iletimi sağlar.

Daha yeni mimariler, daha fazla genel amaçlı register, genişletilmiş adresleme yetenekleri ve daha fazla iş parçacığı desteği sunar. Örneğin, x86-64 mimarisi, işlemci performansını artırmak için birden fazla ek register içerir (R8, R9, R10, R11, R12, R13, R14, R15).
Bu nedenle, işlemci mimarisi geliştikçe, register sayısı ve fonksiyonları genellikle artar, bu da işlemci performansını ve veri işleme yeteneklerini artırır.


Genel olarak register'lar bu şekilde sınıflandırılabilir. Yukarı da mimari geliştikçe register'larda da olan değişimler gözlemlenebilir. Ancak geliştikçe amaçların benzer kaldığı söylenebilir. 

### **Genel Amaçlı Register'lar (General Purpose Registers - GPRs):**
Bu register'lar, aritmetik işlemler, mantıksal işlemler veya veri geçişi gibi genel görevler için kullanılır.
Yukarı da genel amaçlı register sayısı, mimari geliştikçe arttığı gözlemlenebilir.
Genel amaçlı register'ların bazıları bazı durumlarda özel bir amaca hizmet etmek için kullanılır. Mimari geliştikçe örneğin 8086'da ki Pointer ve Index Register'ları sonra ki mimari de genel amaçlı hale gelip genel amaçlı bir şekilde kullanılabilirken bazı durumlarda halen kendi amaçları için de kullanılabiliyorlar:

   1. **Adres Register'lar:**
   Bellekteki belirli bir adrese işaret eden register'lardır. Bellek adreslerinin saklanması ve işlenmesi için kullanılır.
   Örnek: SP (Stack Pointer), BP (Base Pointer) gibi register'lar bellek yığınlarının yönetimi için kullanılır. 
   Daha sonra ki mimarilerde bunlar genel amaçlı hale genişletilmiştir (ESP, EBP (32-bit), RSP, RBP (x86-64)).

      1. **Yığın Gösterici (Stack Pointer - SP):**
         
         Yığın (stack) işlemlerini yöneten bir register'dır. Yığın, fonksiyon çağrılarında, yerel değişkenlerde ve geçici verilerin tutulduğu özel bir bellektir. Stack Pointer, yığının en son kullanılan öğesinin adresini gösterir.
         
         Örnek: SP veya RSP (64-bit sistemlerde).
         
      2. **Baz Pointer (Base Pointer - BP):**
     
         Yığın işlemleri sırasında sabit bir referans noktası sağlar. Özellikle alt programların (fonksiyonlar) çağrıları sırasında kullanılır.
		
		 Örnek: EBP (32-bit sistemlerde), RBP (64-bit sistemlerde).

   2. **Index Register'lar:**
       Indeks register'lar, programların bellekle etkileşiminde ve veri yapılarını yönetmesinde kritik bir rol oynar.
       	Genelde sistem çağrısı parametre geçişlerinde ABI standardına göre rol oynarlar. Genel olarak en çok bilinen index register'ları SI ve DI'dir. Ancak bunlar mimariden mimariye parametre geçişlerinde artış göstermiştir.       
       	Örneğin x86-64 mimarisinde, register'lar hem genel amaçlı olarak kullanılabilir hem de bazı özel görevler için atanmış olabilir. Özel olarak belirlenmesi mimariye göredir. Parametre geçişlerinde bunların sıralaması da işletim sisteminin kullandığı ABI konvansiyonuna göredir. Aşağıda en yaygın olanlar ve işlevleri yer alıyor:

         1. **RDI (Register Destination Index):**
            RDI, genellikle dizilerdeki veri üzerinde işlem yaparken hedef (destination) dizin olarak kullanılır. Fonksiyonlara parametre geçişinde, ilk parametre genellikle RDI register'ına atanır. Fonksiyon çağrılarında, çağrılan fonksiyona verilen ilk argüman bu register'da bulunur.
            
         2. **RSI (Register Source Index):**
            RSI, genellikle dizilerdeki kaynak (source) dizin olarak kullanılır. Bellekten veri okuma ve yazma işlemleri sırasında veri adresi göstergesi olabilir.
            Fonksiyon çağrılarında, ikinci argüman olarak kullanılır.
         
   3. **x86-64 mimarisin de RDX ve özel ekstra genel amaçlı register'lar (R8 - R15):**
     	R8 ile R15 register'ları, x86-64 mimarisi ile eklenmiş ekstra genel amaçlı register'lardır. Bu register'lar 64-bit veri depolayabilir ve fonksiyon çağrılarında argümanların taşınması için kullanılabilirler. Bazılarının sistem çağrılarında parametre geçişlerinde rolü de vardır.

	    _İşletim sisteminin kullandığı ABI'ye göre sistem çağrılarında ki parametre geçişlerinde ki sıralama (Örneğin Linux x86-64 ABI'ye göre):_

	    **RDI**: Fonksiyona iletilen ilk parametre bu register'da tutulur. </br>
	    **RSI**: Fonksiyona iletilen ikinci parametre burada yer alır. </br>
	    **RDX**: Üçüncü parametre için kullanılır. </br>
	    **R10**: Dördüncü parametre için kullanılır. </br>
	    **R8**: Beşinci parametre için kullanılır. </br>
	    **R9**: Altıncı parametre için kullanılır. </br>
		
	    _Fonksiyon çağrılarında ki sıralama:_
		
	    **RDI**: Fonksiyona iletilen ilk parametre bu register'da tutulur. </br>
	    **RSI**: Fonksiyona iletilen ikinci parametre burada yer alır. </br>
	    **RDX**: Üçüncü parametre için kullanılır. </br>
	    **RCX**: Dördüncü parametre için kullanılır. </br>
	    **R8**: Beşinci parametre için kullanılır. </br>
	    **R9**: Altıncı parametre için kullanılır. </br>

### Bazı Genel Amaçlı Register'ların Özel Durumlarına Detaylı Bakış

Register'lar, genel amaçlı register (GPR) olarak adlandırılsalar da, bazı belirli durumlar için özel kullanımları vardır.

Genel amaçlı register'lar, kullanıcı tarafından istenilen şekilde kullanılabilmesi için tasarlanmıştır. Ancak bazı konvansiyonlar, fonksiyonların ve sistem çağrılarının daha tutarlı bir şekilde işlenmesini sağlamak için belirli register'ların belirli görevleri üstlenmesini gerektirir. Bu, register'ların genel amaçlı olma niteliğini değiştirmez; daha ziyade, bu register'ların kullanımına ilişkin bir konvansiyon oluşturur. Yani, kullanıcılar bu register'ları farklı amaçlarla kullanabilir, ancak belirli standartlar ve protokoller, işlevlerin düzgün çalışmasını sağlamak için bazı register'ların belirli amaçlarla kullanılmasını önerir. Genel amaçlı olmakla belirli olmak arasındaki denge gibi bir durum söz konusudur. 

Bir sistem çağrısında hangi kaydın hangi rolü üstleneceği veya benzerleri, Application Binary Interface (ABI) denilen bir sözleşmeyle belirlenir. Linux için bu, x86_64 System V ABI sözleşmesiyle tanımlanmıştır. Bu ABI, kullanıcı modundaki programlar ile işletim sisteminin çekirdeği arasında bir arayüz sunar ve sistem çağrılarında hangi kaydın hangi amaçla kullanılacağını standartlaştırır.

Farklı mimari ve işletim sistemlerinde bu kayıt düzeni farklılık gösterebilir. Örneğin, ARM mimarisinde sistem çağrıları için farklı kayıtlarda veri taşınır. Bunun nedeni, her mimarinin donanımsal yapısının farklı olması ve dolayısıyla sistem çağrıları için en uygun kaydın, işlemci mimarisinin özelliklerine göre değişiklik göstermesidir.

Bazı register'lar belirli durumlar için standardize edilmiştir, bu da onların belirli bir işlevi yerine getirmek için tercih edilmesini sağlar. 

Örneğin Linux x86-64 baz alınırsa:

1. **RDI ve RSI:**
Fonksiyon ve sistem çağrılarında sırasıyla ilk ve ikinci parametre olarak kullanılırlar. Bu, belirli bir düzenin sağlanmasını ve yazılımların çalışmasını kolaylaştırır.
Yani, RDI ve RSI, fonksiyon ve sistem çarğıları için bir konvansiyon olarak kullanılır.
  
**Sistem Çağrıları için Kullanımları**

Örnek:

```asm
section .data
msg: db "selam", 0xa ; "0xa" yeni satıra geçmesi için. "\n" gibi düşünülebilir.

section .text
global _start

_start:
	mov rax, 1 		; sys_write çağrısı
	mov rdi, 1 		; sys_write parametre geçiş konvansiyonuna göre ilk argümana yapılan atama
	mov rsi, msg 	; aynısının ikinci argümana uygulanışı
	mov rdx, 5 		; aynısının üçüncü argümana uygulanışı
	syscall 		; Sistem çağrısı yapmak için çekirdeği tetikleme talimatı

	mov rax, 60 	; sys_exit çağrısı
	mov rdi, 0 		; sys_exit için ilk parametreye geçiş için gerekli atama
	syscall
```

Şayet konvansiyona uygun bir şekilde parametre geçişleri sağlanırsa programın çalıştığı gözlemlenebilir. Ancak örneğin konvansiyona uymayacak şekilde bir düzenleme yaparsak `mov rdi, 1`, `rdi` register'ı yerine `rbx` register'ını, `mov rsi, msg` yerine de `rcx` register'ını kullanırsak bu sefer çıktının basılmadığını görmüş olacağız.

>[!WARNING]
> Register'lara atanan değerler kaldığından yukarıda çalıştırılan örnek şayet ilk örnek olursa ve daha sonra register'ları konvansiyona uymayacak şekilde değiştirip tekrar programı çalıştırırsanız program yine `selam` çıktısını basacaktır. Bunun sebebi halen `rsi` ve `rdi` register'ların da atanan değerlerin bulunuyor olmasıdır **(1 ve msg değerleri)**. Konvansiyona uymayacak şekilde değiştirmeden önce `rsi` ve `rdi` değerlerine sys_write parametrelerine uymayacak başka değerler atayın ve daha sonra farklı register'ları deneyin. Ya da bu durumun yaşanmaması için farklı register'lar kullanmak yerine direkt olarak `rdi` ile `rsi` register'larının yerini değiştirin. Yani `mov rsi, 1` ve `mov rdi, msg` yaparak sıralamalarını değiştiriyoruz ve böylece konvansiyona uygun bir şekilde atamalar yapmadığımızdan programın çıktı vermediğini gözlemliyoruz.


**Fonksiyon Çağrıları için kullanımları**

**sum.s:**

```asm
; sum.s - Assembly fonksiyonu

section .text
    global sum   ; C kodundan erişim için global olarak tanımlıyoruz

sum:
    ; İlk argüman `rdi`'de, ikinci argüman `rsi`'de olacak
    mov rax, rdi         ; İlk argümanı `rax` kaydına kopyala
    add rax, rsi         ; İkinci argümanı `rax` ile topla
    ret                  ; Sonucu `rax`'da döndürür

```
**main.c:**
```c
// main.c - C programı

#include <stdio.h>

// Assembly fonksiyonunu burada bildiriyoruz
extern long sum(long a, long b);

int main() {
    long a = 5;
    long b = 10;

    long result = sum(a, b);  // `sum` fonksiyonunu çağırıyoruz

    printf("Result: %ld\n", result);  // Sonucu yazdırıyoruz
    return 0;
}
```

**Derleme Adımları:**

Assembly dosyasını nesne dosyasına çevirin:
```
nasm -f elf64 -o sum.o sum.s
```

C kodunu nesne dosyasıyla birlikte derleyin:
```
gcc -no-pie -o main main.c sum.o
```

Programı çalıştırın:
```
./main
```

Burada derleyecinin rolü önemli. Değerleri nereden alacağını konvansiyona göre o biliyor ve böylece C dosyasında atanan değerleri `rdi` ve `rsi` register'larından alıp geri kalan işlemi C kodu yapıyor. `sum.s` dosyasında `rdi` değerini farkli bir register ile değiştirirsek (örneğin `rbx` (mov rax, rbx) şeklinde) ve tekrardan derleme işlemlerini yaparsak sonucun `10` olacağını gözlemleyebiliriz.


2. **RAX**

**Sistem çağrısı numarasını belirtmek için**

Sistem çağrısı numarasını belirtmek için kullanılır. Çekirdek bu kayıttaki değeri okuyarak hangi sistem çağrısının yapılması gerektiğini anlar.

Örnek:

```asm
section .data
msg: db "selam", 0xa ; "0xa" yeni satıra geçmesi için. "\n" gibi düşünülebilir.

section .text
global _start

_start:
	mov rax, 1 ; sys_write çağrısı
	mov rdi, 1 ; sys_write parametre geçiş konvansiyonuna göre ilk argümana yapılan atama
	mov rsi, msg ; aynısının ikinci argümana uygulanışı
	mov rdx, 5 ; aynısının üçüncü argümana uygulanışı
	syscall ; Sistem çağrısı yapmak için çekirdeği tetikleme talimatı

	mov rax, 60 ; sys_exit çağrısı
	mov rdi, 0 ; sys_exit için ilk parametreye geçiş için gerekli atama
	syscall
```

`_start:` etiketinden sonra ki ilk 5 satır `rax` register'ına işlem yapılacak sistem çağrısının numarası atanarak _(sys_write)_ ve gerekli parametre geçişleri yapılarak `syscall` talimatı ile çekirdeğe sistem çağrısı yapılacağı söyleniyor. Aslında ilk 5 satır C'sel düşünürsek `ssize_t write(int fd, const void *buf, size_t count);` burada ki prototipin Assembly'ce çağrılma şekli. Daha sonra ki 3 satır ise programı sonlandırmak için `sys_exit` sistem çağrısının çağrılışı. Bu da yine C'sel düşünürsek `void exit(int status);` burada ki prototipin Assembly'ce çağrılma şekli.

**Dönüş Değeri Olarak**
Genellikle bir fonksiyondan dönen değer için kullanılır. Yani, fonksiyon sonuçlarının saklanması için belirlenmiş bir register'dır.
RAX, genel amaçlı bir register olmasına rağmen, geri dönüş değerleri için bir standart oluşturulmuştur.
Çekirdek, işlem tamamlandıktan sonra dönen değeri yine rax kaydına yazar. Bu, başarılı veya başarısız bir sonucun kullanıcı moduna döndürülmesini sağlar.

Örnek:

Yukarıda ki örneği geliştirerek geri dönüş değerinin gerçekten `rax`a dönüp dönmediğini teyit edelim;

```asm
section .data
    msg db 'Hello, World!', 0xA         ; Yazılacak mesaj ve yeni satır karakteri
    msg_len equ $ - msg                 ; Mesajın uzunluğu

section .text
    global _start

_start:
    ; sys_write sistem çağrısı (yazdırma işlemi)
    mov rax, 1              ; sys_write sistem çağrısı numarası
    mov rdi, 1              ; Dosya tanımlayıcı (1 = stdout)
    mov rsi, msg            ; Yazılacak mesajın adresi
    mov rdx, msg_len        ; Mesajın uzunluğu
    syscall                 ; Sistem çağrısını yap

    ; Geri dönüş değerini kontrol et (rax'ta yazılan byte sayısı olmalı)
    cmp rax, msg_len 	    ; rax'taki değer mesaj uzunluğuna eşit mi?
    je success              ; Eşitse, başarı durumuna git
    jne fail                ; Değilse, hata durumuna git

success:
    ; Başarı durumu mesajı
    mov rax, 1              ; sys_write sistem çağrısı numarası
    mov rdi, 1              ; stdout
    mov rsi, success_msg    ; Başarı mesajının adresi
    mov rdx, success_len    ; Mesaj uzunluğu
    syscall                 ; Başarı mesajını yazdır
    jmp end                 ; Programı bitir

fail:
    ; Hata durumu mesajı
    mov rax, 1              ; sys_write sistem çağrısı numarası
    mov rdi, 1              ; stdout
    mov rsi, fail_msg       ; Hata mesajının adresi
    mov rdx, fail_len       ; Mesaj uzunluğu
    syscall                 ; Hata mesajını yazdır

end:
    ; Programdan çıkış
    mov rax, 60             ; sys_exit sistem çağrısı numarası
    xor rdi, rdi            ; Çıkış kodu (0)
    syscall

section .data
    success_msg db "Geri dönüş Değeri Eşit", 0xA
    success_len equ $ - success_msg

    fail_msg db "Geri Dönüş Değeri Eşit değil", 0xA
    fail_len equ $ - fail_msg

```

`man 2 write` ile `sys_write`ın geri dönüş değerinin ne döndürdüğüne bakacak olursak, sistem çağrısı başarılı bir şekilde çalıştığında yazılan byte sayısını döndürür. Bu kontrolü sağlamak için sistem çağrısından sonra (syscall) `rax` register'ına yazılan byte sayısının döndüğünü kontrol etmek olacaktır. Bu kontrolü de `cmp`, `je` ve `jne` gibi talimatların kombinasyonu ile sağlayabiliriz. `cmp rax, msg_len` satırı bu şekilde olursa dönen değerin uzunkuğu mesajın uzunluk sayısına eşit olacağından `success` etiketine zıplanacaktır ve gerekli mesaj basılıp program sonlanacaktır. Lakin `msg_len` değeri yerine mesajın uzunluğuna eşit olmayacak şekilde bir byte sayısı girilirse şayet `fail` etiketine zıplanılıp gerekli mesaj yazıldıktan sonra program sonlanacaktır. Burada `sys_write` çalıştıktan sonra geri dönüş değerinin `rax` register'ına döndüğünü bu şekilde teyit etmiş oluyoruz.

3. **RSP ve RBP**

rsp ve rbp, fonksiyonun yığın çerçevesine erişmek için kullanılır. rsp, yığının en üstündeki adresi gösterirken; rbp, yığın çerçevesinin tabanını gösterir. 
Bu register'lar, fonksiyon içindeki parametrelere ve yerel değişkenlere erişim sağlar. Örneğin, rbp kullanılarak yerel değişkenlere belirli bir ofset ile erişilir.

Register sayısı sınırlı olduğundan ciddi programlarda verileri saklamak yetersiz kalabiliyor. Buna çözüm olarak verileri stack gibi bölümlerde tutarak verileri geçici olarak saklayabiliriz. Bu sayede hem sınırlı register sorununu çözebilir hem de veriyi stack bölümüne gönderebilir ve gerektiğinde alabiliriz. 
`rsp` ve `rbp` register'ları, özellikle fonksiyon çağrıları ve yığın (stack) işlemleri sırasında özel olarak kullanılan iki register'dır. Bu register'lar, stack'deki veri düzenini koruyarak ve gerektiğinde stack'de ki verilere erişimi sağlayarak programın istikrarlı çalışmasını sağlar.

**Stack Nedir?**

Stack (yığın), bilgisayar belleğinde geçici verilerin saklandığı bir bölümdür. Özellikle fonksiyon çağrıları sırasında fonksiyon parametreleri, yerel değişkenler ve dönüş adresleri gibi verileri saklamak için kullanılır. Yığın, LIFO (Last In, First Out) mantığıyla çalışır, yani son eklenen veri ilk alınır.

**Stack Frame (Yığın Çerçevesi) Nedir?**

Bir fonksiyon çağrıldığında, bu fonksiyonun çalışması için bir yığın çerçevesi (stack frame) oluşturulur. Bu yığın çerçevesi, fonksiyonun çalışma süresi boyunca ihtiyaç duyacağı verilerin tutulduğu yerdir. Her fonksiyonun kendi stack frame'i vardır ve bu, çağrı zinciri boyunca farklı fonksiyonlar arasında izole bir bellek alanı sağlar.

Stack frame, genellikle şunları içerir:

Fonksiyonun yerel değişkenleri.
Fonksiyonun parametreleri.
Daha önceki fonksiyonun dönüş adresi (yani çağrılan fonksiyondan sonra hangi komuta geri dönüleceği).
Kayıtlı register'lar (örneğin, çağrıdan önce kaydedilen RBP, RSP gibi register'lar).

**Stack'in Büyümesi ve Küçülmesi Nedir?**

x86-64 mimarisinde stack, yüksek adreslerden düşük adreslere doğru genişler. Stack'in genişleyip küçülmesi verilerin gönderilip daha sonra alınması ile ilgilidir. Stack ters yönde büyüyor. Bu nedenle Stack tabanı işaretçisi (RBP), yığın belleğinin ucundan daha yüksek bir adrese ayarlanır ve aşağı doğru büyür. Örneğin, tahsis edilen hafıza 1200 adresinde biterse, yığın Taban İşaretçisi 1300'ü işaret ediyor olabilir ve 1200 adresine kadar büyüyecektir veya genişleyecektir (yığın 100 bayt büyüklüğünde olduğu anlamına gelir). Bunlar sadece çalışma şeklini gösteren hayali sayılar ve örneklerdir.
Önemli olan nokta öğeler stack'e gönderildikçe yığın daha yüksek adreslerden daha düşük adreslere doğru "büyür" yani "genişler".

**rsp (Stack Pointer) Register:**

rsp kaydı, stack'in en üst elemanını (yani son eklenen öğeyi) işaret eder ve "stack pointer" (yığın işaretçisi) olarak adlandırılır. Stack pointer, yığına yeni bir veri eklendiğinde veya yığından bir veri çıkarıldığında güncellenir.

**rsp Register Görevleri:**

Stack’in en üst elemanını gösterir: rsp, yığına veri eklendiğinde veya çıkarıldığında otomatik olarak güncellenir.
Yığının büyümesi ve küçülmesini yönetir: x86-64 mimarisinde, stack yüksek adreslerden düşük adreslere doğru büyür, bu yüzden stack’e her veri eklendiğinde rsp azalır, her veri çıkarıldığında ise rsp artar.

**rbp (Base Pointer) Register:**

rbp kaydı, genellikle bir fonksiyonun yığın çerçevesini (stack frame) işaret etmek için kullanılır ve "base pointer" olarak adlandırılır. Bu, stack üzerindeki verilerin (fonksiyon parametreleri ve yerel değişkenler gibi) konumunu sabitlemek için sabit bir referans noktası sağlar.

**rbp Register'ının Görevleri:**

Yığın çerçevesini işaret eder: rbp, çağrılan bir fonksiyonun yığın çerçevesinin (stack frame) başlangıcını işaret eder. Bu, fonksiyon içindeki parametreler ve yerel değişkenlere erişimi sağlar.
Sabit bir referans noktası oluşturur: rbp kaydı, fonksiyon çağrısı boyunca sabit kalır. Bu, rsp değeri değişse bile, rbp sabit kalır ve değişmez.

**`pop` ve `push` Talimatları:**

`push` talimatı: Bir değeri stack'e ekler

`pop` talimatı: Stack'in en üstündeki değeri alır

**`pop` ve `push` Talimatlarının `rsp` ve `rbp` register'ları ile ilişkisi:**

**rsp ile ilişkisi:**

push talimatı kullanıldığında bir değeri yığına ekler ve rsp kaydını otomatik olarak 8 bayt azaltır (64-bit sistemde). "Azaltma" ifadesinin nedeni, eklenen öğenin büyük adreslerden küçük adreslere doğru adreslenmesinden ve saklanmasından kaynaklı. Bir öğe eklendiğinde o öğe küçük bir adreste adresleneceğinden rsp değeri o adresi işaret eder.

pop talimatı kullanıldığında rsp yığının en üstünü işaret ettiğinden o değeri alır ve rsp kaydını 8 bayt artırır. "arttırma" ifadesinin nedeni, eklenen öğenin büyük adreslerden küçük adreslere doğru adreslenmesinden ve saklanmasından kaynaklı. Bir öğe alındığında rsp'nin işaret edeceği adres artmış büyümüş olacaktır.

Örnek:

```asm
mov rax, 10      ; rax = 10
push rax         ; rax değeri stack’e eklenir, rsp 8 bayt azalır
pop rbx          ; Stack’ten veri rbx'e alınır, rsp 8 bayt artar
```

**rbp ile ilişkisi:**

rbp register'ının `pop` ve `push` ile ilişkisi bir bakıma isteğe bağlıdır. Şayet call talimatı ile bir fonksiyon çağrısı yapıldığında eğer ki eski fonksiyonun stack çerçevesini kaybetmek istemiyorsanız (bunun nedeni eski fonksiyonun parametreleri ve yerel değişkenleri ile bir işlem yapma isteği olabilir) eski rbp değerini yani eski fonksiyonun stack çerçevesinin taban adresini stack'de saklamanız gereklidir. Bu da eski rbp değeri stack'e push'layarak yapılabilir. Çünkü Linux için `_start` MacOS için `_main` fonksiyonları yani programın ilk baş ana fonksiyonları da bir stack çerçevesi olduğundan ve bu ana fonksiyonların yerel değişkenleri ve parametrelerine erişimin kaybedilmesi istenmiyorsa şayet bir fonksiyon çağrısı yapıldığında rbp değerini saklamak gereklidir bunu da stack'de yapabiliriz. Çünkü rbp değeri programın başında herhangi bir şekilde hiç call talimatı kullanılmadıysa, rbp değeri ana fonksiyonun (_start, _main vb.) stack çerçevesininin base'ini işaret eder. Bilindiği üzere her bir program için stack'de bir alan çerçeve oluşturulur ve rbp değeri de programın başında bu ana fonksiyonun base'ini işaret ediyor.

Fonksiyon işlevini yerine getirdiğinde yani bittiğinde program akışı fonksiyonun çağrıldığı yerin bir sonra ki kısmından devam edeceği için eski fonksiyon çerçevesine geri dönmek (programın amacına göre değişir (yani yine isteğe bağlı) eğer eski fonksiyonun stack çerçevesinde ki bileşenlerle (yerel değişkenler, parametreler vb. işimiz varsa) için önceden push'lanan eski rbp değerini stack'den çekmemiz gerekiyor bunu da pop talimati ile gerçekleştirebiliriz.

Örnek:

```asm
section .text
    global _start

_start:
    call my_function       ; my_function fonksiyonunu çağır

    ; Programdan çıkış
    mov rax, 60            ; sys_exit sistem çağrısı numarası
    xor rdi, rdi           ; Çıkış kodu 0
    syscall

my_function:
    push rbp               ; Eski `rbp` değerini yığına kaydet
    mov rbp, rsp           ; `rbp`yi yeni çerçeve için `rsp`'ye sabitle

    ; Fonksiyon işlemleri (örneğin yerel değişkenler burada kullanılır)

    pop rbp                ; Eski `rbp` değerini geri yükle
    ret                    ; Geri dönüş adresine dön

```

**Fonksiyon çağrısı `call` ve `ret` talimatları**

Assembly'de bir fonksiyon çağrısı, çağrılan fonksiyonun çalışması ve sonrasında geri dönmesi için bir dizi işlemi içerir. Bu işlem genellikle şu adımları içerir:

Fonksiyonun parametrelerinin stack'e (yığın) yerleştirilmesi. </br>
Fonksiyonun geri döndüğünde programın hangi noktadan devam edeceğini bilmesi için geri dönüş adresinin saklanması. </br>
Fonksiyonun çalıştırılması. </br>
Fonksiyonun tamamlanmasıyla birlikte geri dönüş adresine dönülmesi ve sonuçların işlenmesi. </br>

Assembly dilinde, özellikle x86 mimarisinde, bir fonksiyon çağrısı sırasında yapılan işlemler çok daha açıktır. Temel olarak:

Parametreler belirli register'lar veya yığın (stack) üzerinden iletilir. </br>
Çağrılan fonksiyona gitmek için call komutu kullanılır. </br>
Fonksiyon bittikten sonra, geri dönmek için ret komutu kullanılır. </br>

Örnek:

```asm
section .data
    ; Veriler burada tanımlanabilir

section .text
    global _start   ; Program başlangıç noktası

_start:
    ; a ve b için değerler yükleniyor (örneğin 5 ve 3)
    mov rdi, 5      ; İlk parametre olarak 5'i RDI register'ına koy
    mov rsi, 3      ; İkinci parametre olarak 3'ü RSI register'ına koy

    ; add fonksiyonunu çağır
    call add        ; add fonksiyonunu çağırıyoruz

    ; Sonucu RAX register'ından alıp çıkıyoruz
    mov rdi, rax    ; Sonucu RAX'ten alıp RDI'ye koy
    mov rax, 60     ; Sistem çağrısı için 'exit' kodunu hazırla
    syscall         ; Programı sonlandır

add:
    ; Toplama işlemi: a = rdi, b = rsi
    mov rax, rdi    ; RAX'e ilk parametreyi (rdi) koy
    add rax, rsi    ; İkinci parametreyi (rsi) RAX'e ekle
    ret             ; Sonucu geri döndür (RAX'te)
```

**Detaylı Açıklama:**

**Fonksiyon Çağrısı (call):**

`call` add komutu, programın add fonksiyonuna gitmesini sağlar ve bu sırada mevcut kodun kaldığı adres yığına (stack) saklanır. Böylece, ret komutu çalıştığında bu adrese geri dönülecektir.

**Fonksiyonun Çalışması:**

add fonksiyonunda, RAX register'ına ilk parametre (RDI) yüklenir ve ardından ikinci parametre (RSI) eklenir. Sonuç yine RAX'te tutulur, çünkü fonksiyon geri döndüğünde sonuç bu register'dan okunur.
    
**Geri Dönüş (ret):**

`ret` komutu, çağrılan fonksiyondan geri dönülmesini sağlar. Yığından geri dönüş adresini alarak, programın call komutundan sonraki ilk satırına geri döner.

**Fonksiyon Çağrısının rdp ve rsp üzerinde etkisi**

bir `call` talimatı kullanıldığında sadece rsp kaydı otomatik olarak güncellenir; rbp kaydına dokunulmaz. `call` talimatı çalıştırıldığında, yalnızca dönüş adresi (geri dönülecek yerin adresi) stack’e eklenir ve bu sırada rsp kaydı otomatik olarak güncellenir.

**rsp'deki etkisi:**

`call` talimatı, geri dönüş adresini stack’e (yığına) ekleyerek rsp kaydını 8 bayt azaltır (x86-64 sisteminde). Bu işlem sırasında rsp kaydı otomatik olarak güncellenir.

**rdp'deki etkisi:**

`call` talimatı rbp kaydını otomatik olarak güncellemez. rbp, stack çerçevesini (stack frame) başlatmak için genellikle fonksiyonun ilk satırında manuel olarak ayarlanır.

**call Talimatından Sonra rbp’nin Ayarlanması**

Bir fonksiyon çağrıldığında, yeni bir yığın çerçevesi başlatmak için rbp kaydını güncellemek gerekir. Bu işlem, genellikle fonksiyonun başında `push rbp` ve `mov rbp, rsp` talimatları ile manuel olarak yapılır. Bu adımlar, rbp’yi yeni fonksiyon çerçevesini işaret etmek üzere ayarlamanıza olanak tanır.

`call` Talimatının Adım Adım Çalışma Süreci

`call` talimatı çalıştırıldığında:
    
Dönüş adresi stack’e eklenir. </br>
rsp kaydı 8 bayt azaltılır. </br>

Fonksiyon başında rbp güncellemesi (manuel olarak yapılır):
    
Genellikle fonksiyonun ilk satırında push rbp talimatı ile eski rbp değeri stack’e kaydedilir. </br>
Ardından mov rbp, rsp ile rbp, rsp’nin mevcut değerine ayarlanarak yeni bir yığın çerçevesi başlatılır. </br>
        
Örnek:

```asm
section .text
    global _start

_start:
    call my_function       ; `rsp` kaydı otomatik olarak güncellenir, geri dönüş adresi stack’e eklenir

    ; Programdan çıkış
    mov rax, 60            ; sys_exit sistem çağrısı numarası
    xor rdi, rdi           ; Çıkış kodu 0
    syscall

my_function:
    push rbp               ; Eski `rbp` değerini stack’e kaydet (manuel işlem)
    mov rbp, rsp           ; `rbp` kaydını güncelle (manuel işlem)

    ; Fonksiyonun işlemleri burada yapılır...

    pop rbp                ; `rbp`’yi eski değerine döndür
    ret                    ; `rsp`’deki geri dönüş adresine dön, `rsp` otomatik olarak artar

```

`call` talimatı rsp kaydını otomatik günceller (geri dönüş adresini ekler ve rsp'yi azaltır). </br>
rbp kaydını güncellemek manuel bir işlemdir ve rbp genellikle fonksiyonun başında ayarlanır. </br>
ret talimatı geri dönüş adresini rsp’den alır ve rsp’yi otomatik olarak artırır. </br>

Bu nedenle, `call` komutu rbp'yi otomatik olarak güncellemez; rbp güncellemesi manuel yapılır.

**Stack üzerinde ki belirli değerlere erişim**

**`[]` Parantezinin Anlamı ve Kullanımı**

Örneğin:

```asm
mov rax, [rbx]
```

Bu ifade, `rbx` kaydında tutulan adresin işaret ettiği bellek konumundaki değeri `rax` kaydına yükler. Yani, rbx bir adres içerir ve `[]` kullanımı sayesinde bu adresteki değere erişmiş oluruz.

`mov rax, [rbx]`: rbx'in işaret ettiği bellek adresindeki değeri alır ve rax'e kopyalar. </br>
`mov rax, rbx`: rbx'in kendisindeki değeri rax'e kopyalar (bu durumda rbx bir adres değil, doğrudan bir değerdir). </br>

C'de ki pointer'ların değerlere erişiminin (örn: *ptr) assembly'deki şekli gibi düşünülebilir.

**`[]` ve offset Kullanarak Stack Üzerinden Değere Erişim**

Fonksiyon çağrılarında stack (yığın) kullanıldığında `rbp` veya `rsp` ile yığındaki belirli değerlere erişmek için `[]` kullanırız:

```asm
mov rax, [rbp-8]   ; `rbp`'den 8 bayt aşağıdaki değeri `rax`'e al
mov rbx, [rsp+16]  ; `rsp`'den 16 bayt yukarıdaki değeri `rbx`'e al
```

8'lik ofset kullanımının sebebi ise x86-64 mimarisinde, register'lar 64 bit (8 bayt) uzunluğundadır. Dolayısıyla, bir yerel değişken veya stack frame'deki her bir öğe, genellikle 8 baytlık alan kaplar. Örneğin, bir int veya long gibi 64 bit veri türleri 8 bayt tutar.

Bu ifadelerde `rbp` ve `rsp`, stack'in belirli konumlarını işaret eder. `rbp-8` ile, rbp’nin 8 bayt aşağısındaki yığın değerine erişmiş oluruz.

### Segment Register'lar

Belleğin belirli segmentlerini işaret etmek için kullanılırlar. Eski x86 sistemlerinde, bellek adresleme segment tabanlı olduğu için bu register'lar bellek segmentlerini gösterirdi.

Örnek: CS (Code Segment), DS (Data Segment), SS (Stack Segment) gibi segment register'ları.


### Diğer

   1. **İşlem Durum Register'ı (Flags / Status Register):**
      İşlem sırasında çeşitli durum bilgilerini tutar. Örneğin, bir işlem sonucunda sıfır çıkarsa, taşma olup olmadığını, negatif sonuç olup olmadığını veya taşıma bitini bu register'dan öğrenir.

      Örnek: EFLAGS veya RFLAGS register'ları x86 mimarisinde yaygın olan örneklerdir. Bu register'lar, taşma, sıfır, negatif sonuç gibi bilgileri saklar. Ayrıca Assembly'de ki koşullu ifadelerin ("cmp", je, jl vb.) sonuçlarıda bu register'a yansıtılır.
   
   2. **Program Sayacı (Program Counter - PC):**
      CPU'nun bir sonraki işleyeceği talimatın adresini tutar. Bu sayede işlemci, sıradaki talimatın nerede olduğunu bilir ve işleme devam eder.

      Örnek: x86 mimarisinde bu genellikle IP (Instruction Pointer) veya modern 64-bit sistemlerde RIP olarak bilinir.

### Register Terminolojisi ve Önekler

Register isimlendirmesi, Intel'in erken mikroişlemci tasarımında (özellikle Intel 8086 ve 8088 işlemcilerinde) işlevsel bir mantıkla yapılmıştır. Bu harfler, register'ların farklı amaçlar için nasıl kullanıldığını yansıtır. Bu isimler, başta register'ların ne tür işlemler için optimize edileceğini veya kullanıldığını belirtmek için düşünülmüş olsa da, zamanla daha genel amaçlı hale gelmiştir. O dönemki işlemci tasarımında, farklı register'ların belirli işlevler için optimize edilmesi yaygındı. Intel'in bu isimlendirme mantığı, erken dönem mikroişlemci mimarilerinde yaygındı ve her register'ın belirli bir göreve sahip olduğu varsayılıyordu. Ancak zamanla bu register'lar genel amaçlı hale geldi ve her biri farklı işler için kullanılabilir oldu. Yine de, bu ilk isimlendirmeler bugün bile devam etmektedir ve bu tarihi kökeni yansıtır. Modern x86 işlemci mimarilerinde bu register'lar hala aynı isimlerle anılmaktadır. Ancak günümüzde genel amaçlı (general purpose) register'lar olarak görev yaparlar ve belirli işlemlerle sınırlı değillerdir. 32-bit ve 64-bit işlemcilerdeki register isimlerinde yer alan `E` ve `R` harfleri, işlemcinin bit genişliği ve tarihsel gelişimi ile ilgilidir. Bu harfler, register'ların büyüklüğünü ve CPU'nun mimarisini bir bakıma ifade eder.

#### Intel 8086 (16-bit):

8086 işlemcisinde her register 16-bit genişliğindeydi. Bu nedenle bu register'lar AX, BX, CX ve DX olarak adlandırıldı. Bu register'lar 16-bit veri saklayabiliyordu, yani 2 byte'lık (16 bit) veriyi aynı anda işleyebiliyordu.

Register isimleri, Intel 8086 işlemcisinin tasarımına kadar uzanır. Intel 8086, 16-bit bir işlemciydi ve register'ları şu şekilde adlandırıldı:

	AX: Accumulator register (toplayıcı) – genellikle aritmetik ve mantıksal işlemler için kullanılır. 
	BX: Base register – bellek adreslemesi ve veri taşımada temel register olarak görev yapar.
	CX: Counter register – genellikle döngü sayacı olarak kullanılır. </br>
	DX: Data register – geniş veri işlemlerinde, giriş/çıkış operasyonlarında kullanılır. 

Bu isimlendirme, register'ların hangi görevlerde kullanılacağına dair bir mantığı ifade eder. Ancak, bu register'lar sadece belirli işlere atanmış değildi; hepsi genel amaçlı olarak da kullanılabiliyordu.

Ayrıca, bu 16-bit register'lar kendi içinde ikiye bölünebiliyordu:

	AH (High): Accumulator'ın üst 8 bit'i. 
	AL (Low): Accumulator'ın alt 8 bit'i. 

Bu da, aynı register'ın hem 8-bit hem de 16-bit olarak kullanılabilmesini sağlıyordu. Örneğin:

	AX (16-bit): Tüm register. 
	AH (8-bit): Üst yarısı. 
	AL (8-bit): Alt yarısı. 

Bu yapı diğer register'lar için de geçerliydi (örneğin, BH/BL, CH/CL, DH/DL).

1. **AX: Accumulator Register**
AX, Accumulator (Toplayıcı) anlamına gelir ve genellikle aritmetik ve mantıksal işlemler için kullanılırdı.
Bu register, çoğu matematiksel işlemde varsayılan olarak kullanıldığı için "toplayıcı" olarak adlandırıldı. Örneğin, iki sayının toplanması gibi işlemler AX'te gerçekleştiriliyordu. Geleneksel bilgisayar tasarımında, toplayıcı (accumulator) genellikle işlemcinin ana aritmetik birimi olarak kullanılır.

2. **BX: Base Register**
BX, Base (Taban) register'ı olarak bilinir ve bellek adreslemelerinde temel adres saklayıcısı olarak kullanılırdı.
Özellikle bellek adresleme işlemlerinde, bellek adresini tutmak ve adres hesaplamalarında bir taban değer olarak kullanmak amacıyla tasarlanmıştır. Bu yüzden "Base" ismini almıştır. Örneğin, veri yapıları üzerinde gezinirken BX kullanılarak bellekten veri çekilebilirdi.

3. **CX: Count Register**
CX, Count (Sayaç) register'ı olarak adlandırılır ve döngü sayacı veya tekrar eden işlemler için kullanılırdı.
Özellikle döngülerde ve zamanlayıcı işlemlerinde kullanıldığından "Count" ismi verilmiştir. Örneğin, bir döngüdeki tekrar sayısını tutmak için CX kullanılırdı.
Bu register, LOOP gibi talimatlarla döngü kontrolü yaparken varsayılan register olarak kullanılırdı.

4. **DX: Data Register**
DX, Data (Veri) register'ı olarak bilinir ve genellikle giriş/çıkış işlemlerinde kullanılırdı.
Veri taşımada veya geniş aritmetik işlemlerde kullanılan bir register'dır. Örneğin, bir işlemin sonucunu saklamak veya büyük veri miktarlarını işlemekte görev alır.
Özellikle bazı I/O (giriş/çıkış) işlemlerinde ve 32-bit geniş verilerin tutulmasında DX register'ı kullanılırdı. 16-bit işlemcilerde 32-bit veri işlemek için DX ve AX birlikte kullanılırdı.

**`X` Harfinin Register'larda ki Yeri:**

Bunun ile alakalı iki teori mevcut;

İlk teori `X` in çift anlamına geldiği. Bununla alakalı yorumlar:

```
The X means pair, and goes back to at least the 8080. It had 8-bit registers B,C,D,E,H,L (among others) which could also be used in pairs (BC, DE and HL). The BC and DE pairs were used mostly for 16-bit arithmetic; the HL pair generally held a memory address. Some examples of the usage of X for pair:

LXI  D,12ABH    ; "load pair immediate"
DCX  B          ; "decrement pair"
STAX D          ; "store A (indirect) at pair"

Fast forward to the 8086. It has registers AL,AH,BL,BH,CL,CH,DL,DH, which, similarly to the 8080, can be used in pairs: AX, BX, CX, DX.
```

```
On the 8086, the AX register was the combination of AH and AL. Likewise BX was BH and BL, etc. On the 80386, rather than combining 16-bit registers into 32-bit registers, Intel added 16 bits to each register. The name "AL" still refers to bits 0-7 of the first letter-named register, "AH" to bits 8-15, and "AX" to bits 0-15; the name "EAX" now refers to all 32 bits of the register.

It's interesting to note that most other 16- and 32-bit processors do not offer any equivalent means of accessing just the upper or lower parts of a register. The costs of allowing such access, both in hardware complexity and instruction-encoding bits, were significant, and in today's day and age, the ability to add one 8-bit portion of a register to an 8-bit portion of another register is far less useful than many other uses to which such hardware or instruction-encoding space might be put. On the other hand, there are still times when such abilities can be useful when they exist.
```

```
One could suggest that "X" was a shorthand for "H or L", since AX could be interpreted to mean "all the registers whose first letter is H, and whose second letter is H or L", but that has nothing to do with "normal" state. 
```

```
One posible reason I can think of, is to denote that it has not 'normal' state. When talking about serial communication in electronics, if one of the data lines can be anything, you might say its state is X as it is neither/both/either 0 or 1.
```

```
 X was used in the mnemonics (such as LXI and DCX) on the 8080 for instructions that treated a pair of otherwise-separate 8-bit registers as a 16-bit integer, similar to how AX represents the AH:AL pair. Thus, another possible interpretation is that X means pair, and this usage was continued when naming the high:low pairs on subsequent processors, including the 8086, which was a full 16-bit extension of the 8080.
```

İkinci teori ise hiçbir anlama gelmediği sadece bir adlandırma kuralı olduğuna dayalı:

```
Nothing, as far as I know. It stands for a general purpose register.

The 16 bit AX register can be addressed as AH (high byte) and AL (low byte).

The EAX register is the 32 bit version of the AX register. The E stands for extended.
```

```
As Mihai says, it is just a naming convention.

However, given that 'X' is often used for "fill in your value" and is commonly used by mathematicians as the first variable name of choice in equations, and that those particular registers are general purpose (as opposed to say ESP which is the extended (32-bit) stack pointer or EIP the extended instruction pointer) that is perhaps why X is chosen as opposed to say 'B'.
```

#### 32-bit Register'lar

Intel 80386 işlemcisi tanıtıldı ve bu işlemci 32-bit'lik bir mimariye sahipti. Bu, daha geniş verilerin işlenebilmesi anlamına geliyordu. 16-bit olan register'lar, 32-bit'e genişletildi ve bu yeni 32-bit register'lara "E" (Extended veya Enhanced) harfi eklendi:

    EAX: Extended AX (32-bit genişletilmiş AX).
    EBX: Extended BX (32-bit genişletilmiş BX).
    ECX: Extended CX (32-bit genişletilmiş CX).
    EDX: Extended DX (32-bit genişletilmiş DX).        
    
Bu register'lar, yine geriye dönük uyumluluk sağlamak için 16-bit ve 8-bit alt bölümlere de sahipti:

    EAX (32-bit): Tüm 32-bit register.
        AX (16-bit): İlk 16-bit'lik kısmı.
            AH: AX'in üst 8 bit'i.
            AL: AX'in alt 8 bit'i.

Bu yapı diğer register'lar için de geçerliydi (EBX/BX/BH/BL, ECX/CX/CH/CL, EDX/DX/DH/DL).


#### 64-bit Register'lar

Intel, x86-64 mimarisine geçtiğinde (AMD tarafından geliştirilen ve daha sonra Intel tarafından benimsenen 64-bit mimari), register'lar yeniden genişletildi. Bu genişleme ile birlikte register'lar 64-bit oldu. Bu sefer register isimlerine "R" (Register) harfi eklendi:

    RAX: 64-bit genişletilmiş AX.
    RBX: 64-bit genişletilmiş BX.
    RCX: 64-bit genişletilmiş CX.
    RDX: 64-bit genişletilmiş DX.

Yine geriye dönük uyumluluk korundu, bu yüzden 64-bit register'lar da bölünebilir:

    RAX (64-bit): Tam register.
        EAX (32-bit): Alt 32 bit.
            AX (16-bit): Alt 16 bit.
                AH: AX'in üst 8 bit'i.
                AL: AX'in alt 8 bit'i.

Bu bölünme yapısı diğer register'lar için de geçerlidir (örneğin, RBX/EBX/BX/BH/BL).

```
64-bit register | Lower 32 bits | Lower 16 bits | Lower 8 bits
==============================================================
rax             | eax           | ax            | al
rbx             | ebx           | bx            | bl
rcx             | ecx           | cx            | cl
rdx             | edx           | dx            | dl
rsi             | esi           | si            | sil
rdi             | edi           | di            | dil
rbp             | ebp           | bp            | bpl
rsp             | esp           | sp            | spl
r8              | r8d           | r8w           | r8b
r9              | r9d           | r9w           | r9b
r10             | r10d          | r10w          | r10b
r11             | r11d          | r11w          | r11b
r12             | r12d          | r12w          | r12b
r13             | r13d          | r13w          | r13b
r14             | r14d          | r14w          | r14b
r15             | r15d          | r15w          | r15b
```

```
| 63 - 32 | 31 - 16 | 15 - 8 | 7 - 0 |
======================================
.         .         | AH     | AL    |
.         .         | AX             |
.         | EAX                      | 
| RAX                                |
======================================
| 63 - 32 | 31 - 16 | 15 - 8 | 7 - 0 |
```

**64-bit:**

![x86-64-registers](https://github.com/Fartomy/42-Out-Core/blob/main/libasm/mats/imgs/x86-64-registers.png)

**32-bit:**

![x86-32-registers](https://github.com/Fartomy/42-Out-Core/blob/main/libasm/mats/imgs/32-bit-registers.png)
	
**16-bit:**

![x86-16-registers](https://github.com/Fartomy/42-Out-Core/blob/main/libasm/mats/imgs/16-bit-registers.png)

**8-bit:**

![x86-8-registers](https://github.com/Fartomy/42-Out-Core/blob/main/libasm/mats/imgs/8-bit-registers.png)

**Genel Göürünüm:**

![rdx](https://github.com/Fartomy/42-Out-Core/blob/main/libasm/mats/imgs/rdx.png)

---

## :three: YAYGIN ASSEMBLY TALIMATLARI, SECTİON'LAR, DİREKTİFLER, ETİKETLER VE İŞLENENLER (OPERANDS)

![nasmstructure](https://github.com/Fartomy/42-Out-Core/blob/main/libasm/mats/imgs/nasmstructure.png)

### Yaygın assembly talimatları

Assembly dilinde, özellikle x86-64 gibi mimarilerde yaygın olarak kullanılan talimatlar (instructions), bellek erişimi, aritmetik işlemler, mantıksal işlemler, kontrol akışı, veri hareketi ve fonksiyon çağrıları gibi temel işlemleri kapsar. Assembly'de çok fazla talimat olduğundan en çok kullanılanlara değinmek daha makul olacaktır:

![talimatlar](https://github.com/Fartomy/42-Out-Core/blob/main/libasm/mats/imgs/talimatlar.png)

1. **Veri Hareketi (Data Movement) Talimatları**

Bu talimatlar, verileri register'lar, bellek ve işlemci arasında taşımak için kullanılır.

    mov: Bir kaynaktan bir hedefe veri taşır.
        Örnek: mov rax, rbx (RBX register'ındaki değeri RAX register'ına taşır)
    lea: Adres hesaplaması yapar (pointer aritmetiği için kullanılır).
        Örnek: lea rax, [rbx + 4] (RBX'e 4 ekleyip sonucu RAX'e yazar)
    push: Bir değeri yığına (stack) koyar.
        Örnek: push rax (RAX'teki değeri stack'e ekler)
    pop: Yığından bir değer alır.
        Örnek: pop rbx (Yığının en üstündeki değeri alıp RBX'e yazar)

2. **Aritmetik Talimatlar**

Bu talimatlar, sayısal işlemler yapar.

    add: İki sayıyı toplar.
        Örnek: add rax, rbx (RAX ve RBX'teki değerleri toplar, sonucu RAX'e yazar)

    sub: İki sayıyı çıkarır.
        Örnek: sub rax, rbx (RAX'teki değerden RBX'teki değeri çıkarır)

    mul: Çarpma işlemi yapar (çarpılan değer register'a göre seçilir).
        Örnek: mul rbx (RAX ile RBX'teki değerleri çarpar, sonucu RAX'e yazar)

    div: Bölme işlemi yapar (bölünen ve bölen register'larda olur).
        Örnek: div rbx (RAX'i RBX'e böler, bölüm RAX, kalan RDX'tedir)

    inc: Bir değeri bir artırır.
        Örnek: inc rax (RAX'teki değeri 1 artırır)

    dec: Bir değeri bir azaltır.
        Örnek: dec rbx (RBX'teki değeri 1 azaltır)

3. **Mantıksal Talimatlar**

Bu talimatlar, mantıksal bit düzeyinde işlemler yapar.

    and: Bit düzeyinde VE (AND) işlemi yapar.
        Örnek: and rax, rbx (RAX ve RBX'teki değerlerin bitlerini AND'ler)

    or: Bit düzeyinde VEYA (OR) işlemi yapar.
        Örnek: or rax, rbx (RAX ve RBX'teki değerlerin bitlerini OR'lar)

    xor: Bit düzeyinde ÖZEL VEYA (XOR) işlemi yapar.
        Örnek: xor rax, rax (RAX'i sıfırlamak için kullanılır, çünkü XOR aynı sayılar arasında sıfır verir)

    not: Bit düzeyinde tersleme (NOT) işlemi yapar.
        Örnek: not rax (RAX'teki tüm bitleri tersine çevirir)

    shl: Bitleri sola kaydırır (çarpma etkisi yaratır).
        Örnek: shl rax, 1 (RAX'teki değeri 1 bit sola kaydırır, yani 2 ile çarpar)

    shr: Bitleri sağa kaydırır (bölme etkisi yaratır).
        Örnek: shr rax, 1 (RAX'teki değeri 1 bit sağa kaydırır, yani 2'ye böler)

4. **Program Akışı Talimatları**

Bu talimatlar, dallanma, döngüler ve koşullu işlemler için kullanılır.

    jmp: Koşulsuz sıçrama yapar (programın belirtilen adrese gitmesini sağlar).
        Örnek: jmp label (Label adlı yere git)

    cmp: İki değeri karşılaştırır (farkı hesaplar, ancak sonucu kaydetmez, bayrakları ayarlar).
        Örnek: cmp rax, rbx (RAX ile RBX'i karşılaştırır)

    je: Bayraklara göre sıçrama yapar, iki değer eşitse sıçrama.
        Örnek: je equal_label (Karşılaştırma sonucu eşitse, equal_labele git)

    jne: Eşit değilse sıçrama.
        Örnek: jne not_equal_label (Karşılaştırma sonucu eşit değilse not_equal_labele git)

    jl: Küçükse sıçrama.
        Örnek: jl less_label (Karşılaştırma sonucu küçükse less_labele git)

    jg: Büyükse sıçrama.
        Örnek: jg greater_label (Karşılaştırma sonucu büyükse greater_labele git)

5. **Fonksiyon Talimatları**

Fonksiyon çağrıları ve dönüşleri için kullanılan talimatlardır.

    call: Bir fonksiyonu çağırır.
        Örnek: call my_function (My_function adlı fonksiyonu çağırır)

    ret: Bir fonksiyondan dönüş yapar.
        Örnek: ret (Fonksiyondan geri döner)

6. **Stack Yönetim Talimatları**

Yığın (stack) ile ilgili işlemleri yönetmek için kullanılırlar.

    push: Bir değeri stack'e kaydeder.
        Örnek: push rbx (RBX'teki değeri stack'e ekler)

    pop: Stack'ten bir değeri alır.
        Örnek: pop rbx (Stack'ten bir değeri alır ve RBX'e yazar)

    leave: Stack pointer ve base pointer'ı sıfırlar (genelde fonksiyon dönüşlerinde kullanılır).
        Örnek: leave (RBP'yi geri yükler ve RSP'yi geri ayarlar)

7. **Bayrak Yönetimi Talimatları**

Bayrakların durumunu ayarlamak veya kontrol etmek için kullanılır.

    clc: Taşıma bayrağını sıfırlar (carry flag).
        Örnek: clc (Carry flag'ı sıfırlar)

    stc: Taşıma bayrağını set eder.
        Örnek: stc (Carry flag'ı set eder)

    cmc: Taşıma bayrağını tersine çevirir.
        Örnek: cmc (Carry flag'ı tersine çevirir)

    seta: Belirli bir koşula göre bayrağı set eder.
        Örnek: seta al (Taşıma bayrağı sıfırsa AL register'ını 1 yapar)

8. **Sistem Talimatları**

Genellikle işletim sistemi ile etkileşim için kullanılır.

    syscall: Bir sistem çağrısı yapar (Linux'ta).
        Örnek: syscall (Belirli bir sistem işlevini çağırır)

    int: Yazılım kesmesi (interrupt) üretir.
        Örnek: int 0x80 (Linux 32-bit sistem çağrısı)

  ### Direktifler

  Assembly dilinde direktifler (directives), derleyici veya assembler tarafından programın derleme sürecinde belirli bir şekilde ele alınması için talimat veren özel komutlardır. Direktifler, işlemci tarafından doğrudan çalıştırılmaz; yani, makine koduna dönüştürülmezler. Bunun yerine, derleme sürecinde assembler’ın veya linker’ın (bağlayıcı) programı nasıl işleyip organize edeceğini belirlerler.

Direktifler, programın bellekte nasıl organize edileceğini belirlemek, veri ve kod segmentlerini tanımlamak, değişkenleri başlatmak, makroları tanımlamak gibi birçok işlem için kullanılır. NASM ve MASM gibi farklı assembler’larda benzer görevler için kullanılan direktifler değişiklik gösterebilir, ancak çoğu direktif temel görevlerde benzerdir.

1. **`section`/`segment` Direktifi**

`section`/`segment` direktifi, programın kod ve veri bölümlerini tanımlamak için kullanılır. Her programın, kod (program talimatlarının yer aldığı bölüm) ve veri (sabitler ve değişkenler) gibi bölümleri vardır. Assembly dilinde kullanılan section veya segment yapıları, programın bellekteki düzenini ve yapısını tanımlamak için kullanılır. Her section, belirli türdeki kod veya verilerin yerleştirileceği bellek alanlarını ifade eder. x86-64 mimarisinde en yaygın kullanılan section bölümleri şunlardır:

    Kod Bölümü (.text): Bu bölümde programın çalıştırılacak talimatları bulunur.
    Veri Bölümü (.data): Bu bölümde programın sabit veri veya değişkenleri yer alır.
    BSS (Block Starting Symbol) Bölümü (.bss): Bu bölümde ise sıfırlanmış (başlatılmamış) değişkenler bulunur.

```asm
section .bss
	; variables

section .data

	; constants
	
section .text
global _start ; entry point for linker

_start: ; start here

 ; ...
```
Her section bölümü, derleyici ve işletim sistemi tarafından farklı bellek alanlarına yerleştirilir ve her bölümün kendine özgü işlevleri vardır.

**`.text` Bölümü**

	Amaç: Programın çalıştırılabilir talimatlarını içerir. Buradaki kodlar salt okunurdur ve çalışma sırasında değiştirilemez.
	İçerik: Fonksiyonlar, prosedürler, ve programın ana akışını oluşturan diğer komutlar yer alır.
	Kısıtlamalar: Kod güvenliği için .text bölümünde depolanan talimatlar genellikle salt okunur olarak ayarlanır, bu da programın kendi kodunu değiştirmesini engeller.

Örnek:

```asm
section .text
    global _start   ; Programın başlangıç noktası

_start:
    mov rax, 60     ; `sys_exit` sistem çağrısı numarası (Linux'ta program sonlandırmak için)
    mov rdi, 0      ; Çıkış kodu (0) (success anlamına gelir. Program da hata yok gibi düşünülebilir veya 1 verirsek program da hata var anlamında düşünülebilir) 
    syscall         ; Sistem çağrısını gerçekleştir
```

Bu örnekte .text bölümü, mov, xor, ve syscall gibi çalıştırılabilir talimatları içerir.

**`.data` Bölümü**

	Amaç: Programın başlatılmış sabit ve değişken verilerini depolar. Bu bölümdeki veriler program başladığında bellekte belirli değerlerle başlatılmış olur.
	İçerik: Genellikle db, dw, dd, ve dq gibi talimatlarla tanımlanan sabit veri ve değişkenler yer alır.
	Bellek Yapısı: .data bölümü bellekte programın sabit veri ve değişkenlerini tutacak özel bir alana yerleştirilir.

 Örnek:

```asm
section .data
    msg db 'Hello, World!', 0xA   ; msg adlı bir string veri (yeni satır karakteri ile)
    num1 db 42                    ; Bir byte (8-bit) boyutunda sayısal veri
    num2 dw 256                   ; İki byte (16-bit) boyutunda sayısal veri
```

Bu örnekte .data bölümündeki msg, num1, ve num2 değişkenleri program başladığında bellekte belirli değerlerle başlatılacaklardır.

**`.bss` Bölümü**

	Amaç: Başlatılmamış veri bölümüdür ve program başladığında bellekte sıfırlanmış olarak tanımlanır. .bss bölümü, çalışma sürecinde kullanılan ve başlangıçta belirli bir değer 	gerektirmeyen değişkenler için kullanılır.
	İçerik: resb, resw, resd, ve resq gibi direktiflerle ayrılan bellek alanları yer alır.
	Bellek Yapısı: .bss bölümünde başlatılmamış veriler bulunur, bu nedenle dosya boyutunu artırmaz. Çalışma zamanı geldiğinde bu bölümdeki alanlar sıfır ile başlatılır.

 Örnek:

```asm
section .bss
    buffer resb 64    ; 64 baytlık bir bellek alanı ayır (başlatılmamış)
    count resd 1      ; 4 baytlık bir alan ayır (başlatılmamış)
```

buffer, 64 baytlık bir başlatılmamış bellek alanıdır.
count, 4 baytlık bir başlatılmamış bellek alanıdır.

2. `global` Direktifi:

`global` direktifi, belirli bir etiketi (label) veya fonksiyonu dışarıya açık hale getirir. Bu sayede, başka bir dosyada veya modülde tanımlanan bir etiket ya da fonksiyon, bu dosyada kullanılabilir. Örneğin, `global _start` ifadesi, `_start` etiketini global hale getirir, böylece programın başlangıç noktası olarak bu etiketi kullanabiliriz.

Örnek:

```asm
global _start   ; `_start` etiketini global hale getiriyoruz

_start:
    ; Kod işlemleri
```

**`global` direktifinin özel `_start` etiketiyle ilişkisi:**

Assembly dilinde `_start` etiketi, programın başlangıç noktası olarak kullanılan özel bir etikettir. Bir işletim sisteminde, program başlatıldığında, programın başlama noktasını (entry point) bilmesi gerekir. Linux gibi sistemlerde `_start` etiketi, programın çalışma süreci boyunca ilk çağrılan yeri belirtir. Ancak, `_start` etiketinin bu işlevi görebilmesi için onu global direktifiyle dış erişime açık hale getirmemiz gerekir. İşletim sisteminin konvansiyon tasarımı sebebiyle Linux'da linker `_start` (Örn: MacOS'da bu `_main` dir.) etiketini programı başlatmak için arar. Bu yüzden Linux'da `_start` ve MacOS'da `_main` özel etiketler oluyor.

`global` direktifi, belirli bir sembolü veya etiketi programın dışından erişilebilir hale getirir. Bu, derleyicinin veya assembler'ın (örneğin NASM) etiketin (sembolün) dış modüllerden veya işletim sisteminden erişilebilir olmasını sağlaması için gereklidir. `_start` etiketini global yapmazsak, işletim sistemi programın başlangıç noktası olarak `_start` etiketini tanımlayamaz ve bağlayıcı (linker) bu durumda bir hata verir.

**Neden `_start` Global Olmalı?**

Linux ve diğer bazı işletim sistemlerinde _start, programın başlangıç noktası olarak kabul edilir. global olarak tanımlanmazsa:

    Linker _start etiketini göremez ve programın nereden başlatılacağını bilemez.
    İşletim sistemi, programın giriş noktası olarak _start etiketine ulaşamaz ve program başlatılamaz.

 Örnek:

```asm
section .text
    global _start        ; _start etiketini global yaparak erişilebilir hale getiriyoruz

_start:
    mov rax, 60          ; sys_exit sistem çağrısı numarası
    xor rdi, rdi         ; Çıkış kodu 0
    syscall              ; Programı bitir
```

**`global` direktifi ile bir fonksiyonu (aslında etiketi) dışarıdan erişilebilir hale getirme:**

`global` direktifi yalnızca `_start` etiketiyle sınırlı değildir. Aynı zamanda diğer fonksiyonları ve etiketleri de dış erişime açmak için kullanılır. Başka bir modülde veya dosyada tanımlanmış assembly fonksiyonlarını çağırmak istediğimizde global direktifini kullanırız. Böylece, global yapılan semboller ve etiketler, diğer dosyalarda extern olarak tanımlanabilir ve bu sayede farklı modüller arası etkileşim sağlanır.

Örnek:

`functions.s`:
```asm
section .text
    global add_numbers        ; Fonksiyonu dışarıya açmak için `global` direktifi kullanıyoruz

add_numbers:
    mov rax, rdi              ; İlk argümanı rax'e yükle
    add rax, rsi              ; İkinci argümanı rax'e ekle
    ret                       ; Sonucu rax'ta döndür
```

`main.c`:
```
#include <stdio.h>

extern long add_numbers(long a, long b);   // Assembly fonksiyonunu `extern` ile bildiriyoruz

int main() {
    long result = add_numbers(5, 10);      // Assembly fonksiyonunu çağırıyoruz
    printf("Result: %ld\n", result);       // Sonucu yazdırıyoruz
    return 0;
}
```

Bu örnekte `add_numbers`, `global` direktifi ile dışarıya açıldığından, `main.c` dosyasında extern anahtar kelimesiyle erişilebilir hale gelir. Böylece, main fonksiyonu assembly’de tanımlanmış `add_numbers` fonksiyonunu çağırabilir.

	Giriş Noktasını Belirleme: _start etiketi global yapılmazsa, linker bu etiketi bulamaz ve program başlatılamaz.
    Fonksiyon ve Sembolleri Paylaşma: global, bir assembly fonksiyonunun veya sembolünün başka dosyalardan kullanılmasına olanak tanır.
    Modüler Programlama: global ve extern direktifleri sayesinde, C ve Assembly gibi farklı dillerde yazılmış kodlar birbiriyle entegre çalışabilir.

Bu şekilde global direktifi, programın çeşitli bölümlerine dış erişim izni sağlayarak modüler yapıda programlama imkânı sunar ve derleme sürecinde linker’a doğru sembolleri bağlama imkânı verir.

3. `extern` Direktifi

`extern` direktifi, başka bir dosyada veya modülde tanımlanan bir sembolü kullanmak istediğimizde kullanılır. Örneğin, C dilinde yazılmış bir fonksiyon veya başka bir assembly dosyasında tanımlı bir fonksiyon, `extern` direktifi ile çağrılabilir.

```asm
extern printf   ; printf fonksiyonunun harici olarak kullanılması
extern malloc	; malloc fonksiyonunun harici olarak kullanılması

section .text
    global _start

_start:
    ; printf çağrısı yapılabilir
```

4. `db` direktifi ve ona benzer diğer direktifler:

Bu direktifler, veri tanımlamak ve bellekte belirli büyüklükte alan ayırmak için kullanılır:

    db (Define Byte): 1 baytlık veri tanımlar.
    dw (Define Word): 2 baytlık veri tanımlar.
    dd (Define Doubleword): 4 baytlık veri tanımlar.
    dq (Define Quadword): 8 baytlık veri tanımlar.


Örnek:

```asm
section .data
    byte_val db 10           ; 1 baytlık veri
    word_val dw 512          ; 2 baytlık veri
    dword_val dd 1024        ; 4 baytlık veri
    quad_val dq 2048         ; 8 baytlık veri

section .bss
    buffer resb 64           ; 64 baytlık başlatılmamış bellek alanı
```

5. `equ` (equate) direktifi ve `$`:

`equ` direktifi, bir etiketi (label) sabit bir değere eşlemek için kullanılır. Program boyunca aynı değeri kullanmak istediğimizde equ kullanarak bu değeri daha anlamlı bir isimle ifade edebiliriz.

Örnek:

```asm
MAX_SIZE equ 100     ; MAX_SIZE, 100 olarak tanımlandı

section .bss
    buffer resb MAX_SIZE     ; Bellekte 100 baytlık alan ayır
```

Assembly dilinde `$` işareti, genellikle programın o anki adresini ya da mevcut konumunu belirtmek için kullanılır. Bu, assembler tarafından programın o noktadaki bellek adresi olarak değerlendirilir ve özellikle veri uzunluklarını hesaplamak veya bellek içinde belirli konumları tanımlamak için oldukça kullanışlıdır.

**`$` İşaretinin Kullanım Alanları**

**Veri Uzunluğunu Hesaplamak**

Veri tanımlamalarında `$` işareti, veri bloğunun başlangıç ve bitiş adreslerini kullanarak uzunluğunu hesaplamak için kullanılabilir. Örneğin, bir string uzunluğunu belirlerken `$` işareti başlangıç noktasından o anki adresi çıkarmak için kullanılır.

Örnek:

```asm
section .data
    message db 'Hello, World!', 0xA  ; Mesaj ve yeni satır karakteri
    msg_len equ $ - message          ; msg_len, mesajın uzunluğunu hesaplar
```

`message` etiketi mesajın başlangıç adresini işaret eder. </br>
`$` işareti ise mevcut adresi (bu durumda mesajın bitişini) ifade eder. </br>
`msg_len equ $ - message` ifadesi, `msg_len` etiketini `message` adlı veri bloğunun uzunluğuna eşitler. Bu sayede, mesajın uzunluğu doğrudan hesaplanmış olur. </br>

**Mevcut Adrese Etiket Vermek**

Bazı durumlarda, mevcut konumu işaret eden bir etiket tanımlamak için `$` kullanılabilir. Bu, programın belirli bir adresini işaret eden dinamik etiketler oluşturmak için faydalıdır.

Örnek:

```asm
section .text
    global _start

_start:
    jmp $  ; Bu komut sonsuz döngü oluşturur
```

Burada jmp `$`, `jmp` komutunun kendisine dönmesini sağlar ve bu şekilde sonsuz bir döngü yaratır. `$`, burada bulunduğu adresi işaret ettiğinden program `jmp` komutuna her ulaştığında tekrar aynı noktaya döner.

**`$` ve `equ` ile Birlikte Kullanımı**

`$` işareti, equ ile birlikte kullanıldığında, belirli bir adresin anlık konumunu sabit bir etikete eşitlemeye olanak tanır. Bu, özellikle verinin dinamik uzunluğunu veya bir veri bloğunun konumunu belirlemede yardımcıdır. `$ - etiket` şeklinde bir kullanım, `$` işaretinin mevcut adresi işaret etmesi sayesinde bu etiketin adresiyle mevcut adres arasındaki farkı hesaplar.

Bu nedenle `$`, assembly programlamada veri uzunlukları ve konumları dinamik olarak hesaplamak için sıklıkla kullanılır.

### Etiketler

Assembly dilinde etiketler (labels), kod veya veri bloklarının belirli adreslerini temsil eden sembolik isimlerdir. Etiketler, bellekteki belirli bir adresi işaret eder ve bu adreslerin sembolik isimlerle gösterilmesi, programın okunabilirliğini ve yönetilebilirliğini artırır.

Etiketler, işlemcinin doğrudan eriştiği bellek adreslerini insan tarafından anlaşılır hale getirir. Örneğin:

    Kontrol akışını düzenlemek için, koşullu veya koşulsuz dallanmalar (jmp, je, jne, vb.) yaparken belirli talimatlara atlamak için kullanılır.
    Veri bloklarını işaretlemek için, belirli bir veri bloğunu etiketleyerek o veriye kolayca erişilmesini sağlar.
    Programın başlangıç noktalarını belirtmek için, örneğin _start gibi özel etiketlerle programın giriş noktasını tanımlar.

 1. **Kod Etiketleri**

Kod etiketleri, belirli bir komutun adresini işaret eder. Dallanma `jmp, je, jne vb.` komutları ile kontrol akışını yönlendirmek için kullanılır. `_start`, bir kod etiketine örnektir; programın başlangıcını işaret eden bir etiket olarak kullanılır. Ayrıca kendi oluşturduğumuz etiketleri de belirli kod blokları için kullanabiliriz.

Örnek:

```asm
section .text
    global _start

_start:
    mov rax, 5
    jmp my_label

my_label:
    mov rbx, 10
```

`_start`, programın başlama noktası olarak işaretlenmiştir. my_label, kod akışında jmp ile ulaşılacak bir etikettir.

2. **Veri Etiketleri**

Veri etiketleri, programdaki belirli veri bloklarını işaret eder. Veri etiketleri genellikle `.data` veya `.bss` bölümünde bulunur ve veriye erişimi kolaylaştırır.

Örnek:

```asm
section .data
    msg db 'Hello, World!', 0xA     ; `msg` bir veri etiketidir
```

Burada `msg`, `'Hello, World!'` mesajının bellek adresini işaret eden bir veri etiketidir.

3. **`_start` (Linux) ve `_main` (MacOS) etiketleri (Özel etiketler denilebilir)**

`_start` veya `_main` etiketi, özellikle Linux ve MacOS işletim sisteminde programın başlangıç noktası olarak kullanılan tipik varsayılan bir etikettir. Program çalıştırıldığında, işletim sistemi `_start` etiketini arar ve programın bu noktadan itibaren başlatılmasını sağlar. Ancak `_start`, yalnızca özel bir etiket olduğundan, `global` direktifi ile dış erişime açık hale getirilmesi gerekir. Bu etiketi kullanmak zorunda değiliz; ancak `_start` kullanılmazsa, işletim sisteminin veya derleyicinin tanıyacağı başka bir giriş noktası sağlanmalıdır. Bazı derleyiciler veya linker araçları, programın giriş noktasını özelleştirmek için özel komut satırı seçenekleri sunar. Örneğin, `GCC` veya `ld` gibi linker araçlarında `-e` (entry) seçeneği ile giriş noktası farklı bir etiket olarak ayarlanabilir.

>[!IMPORTANT]
> **Konu ile alakasız bir bilgi**
>
> Çoğu derleyici, işletim sisteminin varsayılan başlatma düzenini takip eder. Örneğin, C/C++ programlarında işletim sistemi, main fonksiyonuna ulaşmadan önce çeşitli başlangıç kodlarını (crt0 gibi) çalıştırır. Bu başlangıç kodları, C dilinin gerektirdiği ortamı hazırlayıp main fonksiyonunu çağırır.

### Operands

Assembly dilinde operandlar, bir talimatın üzerinde işlem yaptığı verilerdir. Operandlar, işlem yapılacak veri veya adresleri ifade eder ve her işlemci komutunun operandlara ihtiyacı vardır. Çoğu assembly komutu, iki veya daha fazla operand ile çalışır. Ancak bazı komutların hiç operandı yoktur (`nop, ret gibi`), bazı komutların ise yalnızca bir operandı vardır (`inc, dec gibi`). Kayıt, sabit, bellek ve adresleme modları gibi farklı operand türleri bulunur ve her tür farklı bir erişim yöntemi sağlar. Bu çeşitlilik, assembly dilinin esnekliği ve gücü açısından önemlidir. Operandların hangi bellek konumlarına veya kayıtlara işaret ettiğini doğru anlamak, düşük seviyeli programlamada performansı doğrudan etkiler.

Assembly dilinde dört ana operand türü vardır:

    Register (Kayıt) Operandları
    Immediate (Sabit) Operandlar
    Memory (Bellek) Operandları
    Adresleme Modları (dolaylı olarak bellek erişimlerini ifade eden kombinasyonlar)

1. **Register Operandları**

Register operandları, işlemcinin içinde veri tutmak için kullanılan kayıtlardır. Register operandları doğrudan işlemci içinde bulunduğundan, üzerlerinde yapılan işlemler hızlıdır.

Örnek:

```asm
mov rax, rbx   ; rbx'deki değeri rax'e kopyalar
add rcx, rdx   ; rcx ve rdx'yi toplar, sonucu rcx'e yazar
```

Bu örnekte rax, rbx, rcx, ve rdx gibi genel amaçlı kayıtlar operand olarak kullanılmıştır. mov, add gibi komutlarla bu kayıtlara veri yükleyebilir veya işlemler gerçekleştirebiliriz.

2. **Immediate (Sabit) Operandlar**

Immediate operandlar, sabit bir değeri temsil eder. Bu değer doğrudan komut içinde belirtilir ve işlem sırasında doğrudan kullanılır. Immediate operandlar, doğrudan veriyi içerdiği için en hızlı işlenen operand türlerinden biridir.

Örnek:

```asm
mov rax, 10     ; rax'e sabit bir sayı olan 10'u yükler
add rbx, 20     ; rbx'e 20 ekler
```

Burada 10 ve 20 birer immediate operanddır. Sabit bir değer oldukları için işlem sırasında değişmezler.

3. **Memory (Bellek) Operandları**

Memory operandları, bir bellekteki veri adresini temsil eder. Bu tür operandlarda, işlem doğrudan bir bellek adresi üzerinde yapılır. Bu adres, bir değişkenin veya sabit bir değerin bulunduğu yeri işaret edebilir.

Örnek:

```asm
section .data
    num db 10            ; num adlı bir bellek alanına 10 yükler

section .text
    global _start

_start:
    mov rax, [num]       ; num'un bellekteki adresindeki değeri rax'e yükler
    mov [num], 20        ; num'un işaret ettiği belleğe 20 yazar
```

num etiketini `[num]` olarak kullandığımızda, `num`un bellek adresindeki değere ulaşırız. mov rax, `[num]` komutu num etiketinin işaret ettiği bellek adresindeki değeri rax kaydına yükler.

**Adresleme Modları**

Adresleme modları, bellek operandlarına erişimi sağlayan yöntemleri ifade eder. Assembly dilinde kullanılan başlıca adresleme modları şunlardır:

**_Doğrudan Adresleme_**: Bellekteki belirli bir adrese doğrudan erişim sağlar.

```asm
mov rax, [num]    ; num adresindeki değeri rax'e yükler
```

**_Dolaylı Adresleme_**: Bir kaydın içerdiği adres kullanılarak bellekteki değere ulaşılır.

```asm
mov rbx, num      ; rbx’e num adresini yükler
mov rax, [rbx]    ; rbx’in işaret ettiği adresteki değeri rax’e yükler
```

**_Kayıt İndeksli Adresleme_**: Belirli bir kayıta ek olarak bir indeks veya ofset ekleyerek belleğe erişim sağlar. Bu mod, özellikle diziler ve yapıların elemanlarına erişim için kullanışlıdır.

```asm
mov rax, [rbx + 4]    ; rbx'ten 4 bayt sonraki bellek adresindeki değeri rax'e yükler
```

**_Taban ve İndeksli Adresleme_**: Bir taban kaydı ve indeks kaydı ile bellekteki bir değere erişir. Dizi ve matrislerde çokça kullanılır.

```asm
mov rax, [rbx + rcx*4] ; rbx'in işaret ettiği adresten rcx*4 kadar ilerideki değeri rax'e yükler
```

**Operandların Kombinasyonları**

Komutlarda kullanılan operand sayısı ve türleri değişebilir. Örneğin:

**_Tek Operandlı Komutlar_**: inc, dec gibi komutlar sadece bir operand kullanır.

```asm
inc rax    ; rax'in değerini 1 artırır
```

**_İki Operandlı Komutlar_**: mov, add gibi komutlar iki operand alır ve birini diğerine kopyalar veya üzerinde işlem yapar.


```asm
add rax, rbx   ; rax ve rbx'i toplar, sonucu rax'e yazar
```

---

## :four: Assembler'lar (Nasm) ve Yazım Şekli - Linkleme `ld` ve Sıkıştırma - Gömme `arc rcs` - Obje Dosyaları - Statik (`.a` uzantılı dosyalar `libasm.a` gibi) ve Dinamik Kütüphaneler `.dll` `.so` - Runtime ve Compile Time - `errno` - Assembly ve C ile İlişkisel Bağlantı Kurma - `-no-pie` Flag'i nedir? Dışarıdan Harici Fonksiyon Çağırsma (malloc) - `.asm` ve `.s` Dosyası

Hazırlanıyor..
