section .note.GNU-stack noexec nowrite
section .text
	global ft_write
	extern __errno_location
	default rel

ft_write:
	push rbp
	mov rbp, rsp
	
	;sys_write
	mov rax, 1
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
