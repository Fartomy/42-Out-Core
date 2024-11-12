section .text

    extern malloc
    extern ft_strlen

    global ft_strdup


ft_strdup:
    call ft_strlen              ; Heap'te tahsis edilecek yer icin string'in (rdi'den) length'ini al
    inc rax                     ; '\0' null icin rax'i arttir
    push rdi                    ; rdi'de ki degeri bellege gonder
    mov rdi, rax                ; malloc'un ilk parametresi yani rdi'de ki sayi kadar yer tahsis edileceginden rax'i rdi'ye tasi
    call malloc WRT ..plt       ; rax register'ina tahsis edilen bolmenin adresi donulecek fonksiyon sonucunda. O bolmeye rax ile ulasacagiz
    cmp rax, 0                  ; Sayet malloc basarili bir sekilde
    je .end                     ; yer ayiramamisa fonksiyonu bitir
    mov rcx, 0              
    pop rdi                     ; bellekte ki eski rdi adresini tekrardan rdi'ye geri al

.dup:
    cmp BYTE [rdi], 0           ; string'in sonuysa 
    je .ret                     ; .ret'e sicra 

    mov bl, [rdi]               ; karakteri ([rdi]), 8-bit'lik register'a (bl) kopyala
    mov [rax + rcx], bl         ; malloc ile yeni tahsis edilmis bolmenin indeksine bl'de ki degeri kopyala
    
    inc rdi
    inc rcx
    jmp .dup

.ret:
    mov BYTE [rax + rcx], 0     ; string'in sonuna null koy
    jmp .end

.end:
    ret