# Test Ortamı

AWS, Google Cloud, Azure vb. bulut sağlayıcıları, ücretsiz servislerinde limitli kullanım verdiğinden test içerikli eylemler yavaşlamaya ve hiç yapılamamaya uğruyor. Bu yüzden de bir test ortamı ihtiyacı ortaya çıkıyor.
Çözüm olarak Terraform üzerinden çalışan Vagrant sanal makinelerini kullanmak. Böylece yazılan script'ler kodlar vb. materyaller bu ortamda gerçeğini pek yansıtmasa da en azından akılda bir fikir oluşturmaya yeter denemeler
uygulanabilir.

## Projeyi Çalıştırmak İçin Gerekenler

> [!TIP]
> Kendi makinenizde de bu projeyi çalıştırabilir veya sanal makine oluşturup burada da çalıştırabilirsiniz ancak sanal makinenin Nested-Virtualization özelliğinin aktif olduğundan
> ve yeteri kadar kaynak (CPU, RAM vb.) verdiğinizden emin olun.

1. **Terraform**
2. **Vagrant**
3. **Virtualbox (7.0 sürümü. Üstü sürümler Vagrant ile uyumlu değil)**

## Diagram
![Diagram](https://github.com/Fartomy/42-Out-Core/blob/main/cloud-1/cloud-1-simu/cloud-1-test.png)
