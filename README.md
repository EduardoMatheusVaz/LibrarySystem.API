# Sistema de Gerenciamento de Biblioteca
## Esta aplicação simula um sistema de gerenciamento de biblioteca com determinadas operações, como o cadastro de usuários e inclusão de livros no sistema, a gestão do controle de livros e o registro de empréstimos.

### Funcionalidades:
- Gerenciamento de livros (inclusão, edição e exclusão)
- Gerenciamento de empréstimos (inclusão, edição e exclusão)
- Gerenciamento de usuários (inclusão, edição e exclusão)
- Consulta de livros, usuários e empréstimos

### Requisitos:
- Tecnologias: ASP.NET Core, Entity Framework Core, Fluent Validation, Dapper e MediatR
- Arquitetura: Clean Architecture, Padrão Repository e Padrão CQRS
- Banco de Dados: SQL Server

### Status do Sistema
####BookStatusEnum | (Status dos Livros)
  Status	    Valor	  Descrição
- Available	    0	    Disponível
- Rented	      1	    Alugado
- Reserved	    2	    Reservado
- Late	        3	    Atrasado
- Off	          4	    Desligado/Inativo


####UserEnum  |  (Status dos Usuários)
  Status	 Valor	Descrição
- Active	   0	  Ativo
- Off	       1	  Desligado/Inativo


####LoanStatusEnum | (Status dos Empréstimos)
  Status	   Valor	  Descrição
- Active	    0	      Empréstimo Ativo
- Returned	  1	      Devolvido
- Late	      2	      Atrasado
- Reserved	  3	      Reservado
- Cancelled	  4	      Cancelado

![image](https://github.com/user-attachments/assets/700a69e1-a7e6-41e3-a096-bf40eb56a039)
