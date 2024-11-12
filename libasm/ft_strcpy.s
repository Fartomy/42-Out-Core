section .text
global ft_strcpy
extern ft_strlen

ft_strcpy:
    push rdi

.cpy:
    mov dl, BYTE [rsi]  ; byte cinsinden atama yapilacagi belirtiliyor
    mov BYTE [rdi], dl

    cmp dl, 0
    je .ret

    inc rsi             ; bu sekilde de indeks ilerletmesi yapilabilir
    inc rdi             ; bu sekilde de indeks ilerletmesi yapilabilir
    jmp .cpy


.ret:
    pop rax             ; dest'in adresi donuleceginden ve ilk parametrenin adresi yukarida push'landigindan (dest), simdi bellekten rax'a geri cekiliyor
    ret
    
