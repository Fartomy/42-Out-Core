section .note.GNU-stack noexec nowrite
section .text
    global ft_read
    extern __errno_location
    default rel

ft_read:
    push rbp
    mov rbp, rsp

    ; sys_read
    mov rax, 0
    syscall

    cmp rax, 0
    jl .err
    jmp .end

.err:
    neg rax
    push rax
    lea rdi, [rel __errno_location wrt ..got]
    call [rdi]
    pop qword [rax]
    mov rax, -1

.end:
    mov rsp, rbp
    pop rbp
    ret