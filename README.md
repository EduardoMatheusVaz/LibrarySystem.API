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

### Status do Sistema:
#### BookStatusEnum (Status dos Livros)
- **Available (0)**: Disponível
- **Rented (1)**: Alugado
- **Reserved (2)**: Reservado
- **Late (3)**: Atrasado
- **Off (4)**: Desligado/Inativo

#### UserEnum (Status dos Usuários)
- **Active (0)**: Ativo
- **Off (1)**: Desligado/Inativo

#### LoanStatusEnum (Status dos Empréstimos)
- **Active (0)**: Empréstimo Ativo
- **Returned (1)**: Devolvido
- **Late (2)**: Atrasado
- **Reserved (3)**: Reservado
- **Cancelled (4)**: Cancelado

### Exclusão de Dados
- Não é possível excluir dados diretamente através do Swagger, pois isso resultaria na perda de informações associadas a outras tabelas. Ao invés de uma exclusão, deve ser atualizado o status do registro para indicar que ele foi: excluído, cancelado ou desativo. Embora ainda seja possível uma exclusão direta via banco de dados.

![image](https://github.com/user-attachments/assets/700a69e1-a7e6-41e3-a096-bf40eb56a039)
