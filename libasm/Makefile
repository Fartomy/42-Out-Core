NAME				=	libasm.a

# ASM
ASM					=	@nasm
ASM_FLAGS			=	-f elf64
ASM_SRCS			=	ft_write.s		ft_read.s		ft_strlen.s		ft_strcmp.s		ft_strcpy.s		ft_strdup.s
ASM_OBJS			=	$(ASM_SRCS:.s=.o)

# C
CC					=	@gcc
SRC					=	main.c
CFLAGS				=	-Wall -Werror -Wextra -fPIE -pie

RM					= 	@rm -rf

all: $(NAME)

$(NAME): $(ASM_OBJS)
	ar rcs $(NAME) $(ASM_OBJS)
	ranlib $(NAME)

test_main: all
	$(CC) $(CFLAGS) $(SRC) -L. -lasm -o test

test: test_main

%.o: %.s
	$(ASM) $(ASM_FLAGS) $< -o $@


clean:
	$(RM) $(ASM_OBJS)

fclean: clean
	$(RM) $(NAME) test

re: fclean all

.PHONY: all test_main test clean fclean re