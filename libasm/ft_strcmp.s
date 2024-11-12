section .text
global ft_strcmp


ft_strcmp:
    mov rbx, 0

.cmp:
    mov cl, [rdi + rbx]

    cmp [rsi + rbx], cl
    jne .diff

    cmp cl, 0
    je .diff
    
    inc rbx
    jmp .cmp

.diff:
    sub cl, [rsi + rbx]
    movsx rax, cl 
    ret
