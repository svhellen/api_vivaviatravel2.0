# VivaVia Travel REST API

## Visão Geral

API para o gerenciamento de viagens, incluindo a criação e administração de clientes, hospedagens, passagens, pacotes turísticos e reservas. Desenvolvida com C#, .NET 6 e SQL Server.

## Tecnologias Usadas

- Framework: .NET 6.0
- ORM: Entity Framework Core
- Banco: SQL Server e SQLite
- Documentação e teste: Swagger e Postman
- Ferramentas de Design e CLI
- IDE: Visual Studio
- Versionamento: Git
- Deploy: Somee

## Prerequisitos

Antes de iniciar, certifique-se de ter os seguintes pacotes instalados:

- .NET 6
- SQL Server

## Clone o repositório:

   ```bash
   git clone https://github.com/svhellen/api_vivaviatravel2.0.git
   cd api_vivaviatravel2.0
   ```

## Documentação

### Endpoints

#### Clientes

- **Criar Cliente**: `POST /api/cliente`
    - Request body: 
        ``` json
        {
            "nome": "nome cliente",
            "email": "email@example.com",
            "senha": "senha123",
            "telefone": "(11) 98765-4321"
        }
        ```
    - resposta: Status 201 (Created)

- **Obter todos os Clientes**: `GET /api/cliente`
    - body: 
        ``` json
        [
            {
                "clienteId": 0,
                "nome": "nome cliente",
                "email": "email@example.com",
                "senha": "senha123",
                "telefone": "(11) 98765-4321"
            },
            ...
        ]
        ```
    - resposta: Status 200 (OK)

- **Obter Cliente por ID**: `GET /api/cliente/{id}`
    - body:
        ``` json
        {
            "clienteId": 0,
            "nome": "nome cliente",
            "email": "email@example.com",
            "senha": "senha123",
            "telefone": "(11) 98765-4321"
        }
        ```
    - resposta: Status 200 (OK)

- **Atualizar Cliente**: `PUT /api/cliente/{id}`
    - Request body: 
        ``` json
        {
            "clienteId": 0,
            "nome": "nome cliente",
            "email": "email@example.com",
            "senha": "senha123",
            "telefone": "(11) 98765-4321"
        }
        ```
    - resposta: Status 204 (No Content)

- **Excluir Cliente**: `DELETE /api/cliente/{id}`
    - resposta: Status 204 (No Content)

#### Hospedagens

- **Criar Hospedagem**: `POST /api/hospedagem`
    - Request body:
        ```json
        {
            "nomeHotel": "Hotel Copacabana Palace",
            "descricao": "Um hotel luxuoso na famosa praia de Copacabana, oferecendo vistas deslumbrantes do oceano.",
            "localizacao": "Rio de Janeiro - RJ",
            "avaliacao": 4.9,
            "precoDiaria": 350,
            "imagemUrl": "/images/hoteis/hotel-5.jpg"
        }
        ```
    - Resposta: Status 201 (Created)
    
- **Obter todas as Hospedagens**: `GET /api/hospedagem`
    - Resposta:
        ```json
        [
            {
                "hospedagemId": 1,
                "nomeHotel": "Hotel Copacabana Palace",
                "descricao": "Um hotel luxuoso na famosa praia de Copacabana, oferecendo vistas deslumbrantes do oceano.",
                "localizacao": "Rio de Janeiro - RJ",
                "avaliacao": 4.9,
                "precoDiaria": 350,
                "imagemUrl": "/images/hoteis/hotel-5.jpg"
            },
            ...
        ]
        ```
    - Resposta: Status 200 (OK)

- **Obter Hospedagem por ID**: `GET /api/hospedagem/{id}`
    - Resposta:
        ```json
        {
            "hospedagemId": 1,
            "nomeHotel": "Hotel Copacabana Palace",
            "descricao": "Um hotel luxuoso na famosa praia de Copacabana, oferecendo vistas deslumbrantes do oceano.",
            "localizacao": "Rio de Janeiro - RJ",
            "avaliacao": 4.9,
            "precoDiaria": 350,
            "imagemUrl": "/images/hoteis/hotel-5.jpg"
        }
        ```
    - Resposta: Status 200 (OK)

- **Atualizar Hospedagem**: `PUT /api/hospedagem/{id}`
    - Request body: 
        ```json
        {
            "hospedagemId": 1,
            "nomeHotel": "Hotel Copacabana Palace",
            "descricao": "Um hotel luxuoso na famosa praia de Copacabana, oferecendo vistas deslumbrantes do oceano.",
            "localizacao": "Rio de Janeiro - RJ",
            "avaliacao": 4.9,
            "precoDiaria": 350,
            "imagemUrl": "/images/hoteis/hotel-5.jpg"
        }
        ```
    - Resposta: Status 204 (No Content)

- **Excluir Hospedagem**: `DELETE /api/hospedagem/{id}`
    - Resposta: Status 204 (No Content)

#### Passagens

- **Criar Passagem**: `POST /api/passagem`
    - Request body:
        ```json
        {
            "origem": "São Paulo - SP",
            "destino": "Porto Seguro - BA",
            "classe": "Primeira Classe",
            "preco": 386,
            "imagemUrl": "/images/cidades/porto-seguro-ba.jpg",
            "dataVoo": "2024-03-24T00:00:00"
        }
        ```
    - Resposta: Status 201 (Created)

- **Obter todas as Passagens**: `GET /api/passagem`
    - Resposta:
        ```json
        [
            {
                "passagemId": 1,
                "origem": "São Paulo - SP",
                "destino": "Porto Seguro - BA",
                "classe": "Primeira Classe",
                "preco": 386,
                "imagemUrl": "/images/cidades/porto-seguro-ba.jpg",
                "dataVoo": "2024-03-24T00:00:00"
            },
            ...
        ]
        ```
    - Resposta: Status 200 (OK)

- **Obter Passagem por ID**: `GET /api/passagem/{id}`
    - Resposta:
        ```json
        {
            "passagemId": 1,
            "origem": "São Paulo - SP",
            "destino": "Porto Seguro - BA",
            "classe": "Primeira Classe",
            "preco": 386,
            "imagemUrl": "/images/cidades/porto-seguro-ba.jpg",
            "dataVoo": "2024-03-24T00:00:00"
        }
        ```
    - Resposta: Status 200 (OK)

- **Atualizar Passagem**: `PUT /api/passagem/{id}`
    - Request body: 
        ```json
        {
            "passagemId": 1,
            "origem": "São Paulo - SP",
            "destino": "Porto Seguro - BA",
            "classe": "Primeira Classe",
            "preco": 386,
            "imagemUrl": "/images/cidades/porto-seguro-ba.jpg",
            "dataVoo": "2024-03-24T00:00:00"
        }
        ```
    - Resposta: Status 204 (No Content)

- **Excluir Passagem**: `DELETE /api/passagem/{id}`
    - Resposta: Status 204 (No Content)

#### Pacotes

- **Criar Pacote**: `POST /api/pacote`
    - Request body:
        ```json
        {
            "percentDesconto": 10,
            "imagemUrl": "/images/hoteis/hotel-5.jpg",
            "passagemId": 1,
            "hospedagemId": 3
        }
        ```
    - Resposta: Status 201 (Created)

- **Obter todos os Pacotes**: `GET /api/pacote`
    - Resposta:
        ```json
        [
            {
                "pacoteId": 1,
                "percentDesconto": 10,
                "imagemUrl": "/images/hoteis/hotel-5.jpg",
                "passagemId": 1,
                "hospedagemId": 3,
                "passagem": {
                    "passagemId": 1,
                    "origem": "São Paulo - SP",
                    "destino": "Porto Seguro - BA",
                    "classe": "Primeira Classe",
                    "preco": 386,
                    "imagemUrl": "/images/cidades/porto-seguro-ba.jpg",
                    "dataVoo": "2024-03-24T00:00:00"
                },
                "hospedagem": {
                    "hospedagemId": 3,
                    "nomeHotel": "Pousada das Araras",
                    "descricao": "Uma pousada aconchegante em Porto Seguro, perfeita para relaxar e aproveitar as praias.",
                    "localizacao": "Porto Seguro - BA",
                    "avaliacao": 4.7,
                    "precoDiaria": 150,
                    "imagemUrl": "/images/hoteis/hotel-1.jpg"
                }
            },
            ...
        ]
        ```
    - Resposta: Status 200 (OK)

- **Obter Pacote por ID**: `GET /api/pacote/{id}`
    - Resposta:
        ```json
        {
            "pacoteId": 1,
            "percentDesconto": 10,
            "imagemUrl": "/images/hoteis/hotel-5.jpg",
            "passagemId": 1,
            "hospedagemId": 3,
            "passagem": {
                "passagemId": 1,
                "origem": "São Paulo - SP",
                "destino": "Porto Seguro - BA",
                "classe": "Primeira Classe",
                "preco": 386,
                "imagemUrl": "/images/cidades/porto-seguro-ba.jpg",
                "dataVoo": "2024-03-24T00:00:00"
            },
            "hospedagem": {
                "hospedagemId": 3,
                "nomeHotel": "Pousada das Araras",
                "descricao": "Uma pousada aconchegante em Porto Seguro, perfeita para relaxar e aproveitar as praias.",
                "localizacao": "Porto Seguro - BA",
                "avaliacao": 4.7,
                "precoDiaria": 150,
                "imagemUrl": "/images/hoteis/hotel-1.jpg"
            }
        }
        ```
    - Resposta: Status 200 (OK)

- **Atualizar Pacote**: `PUT /api/pacote/{id}`
    - Request body: 
        ```json
        {
            "pacoteId": 1,
            "percentDesconto": 10,
            "imagemUrl": "/images/hoteis/hotel-5.jpg",
            "passagemId": 1,
            "hospedagemId": 3
        }
        ```
    - Resposta: Status 204 (No Content)

- **Excluir Pacote**: `DELETE /api/pacote/{id}`
    - Resposta: Status 204 (No Content)

#### Reservas

- **Criar Reserva**: `POST /api/reserva`
    - Request body:
        ```json
        {
            "tipoServico": "Passagem",
            "clienteId": 12,
            "passagemId": 1
        }
        ```
    - Resposta: Status 201 (Created)

- **Obter todas as Reservas**: `GET /api/reserva`
    - Resposta:
        ```json
        [
            {
                "reservaId": 2,
                "tipoServico": "Passagem",
                "clienteId": 12,
                "passagemId": 1,
                "cliente": {
                    "clienteId": 12,
                    "nome": "Felipe Santos",
                    "email": "felipe.santos@email.com",
                    "senha": "senhaxyz",
                    "telefone": "(03) 98765-4321"
                },
                "passagem": {
                    "passagemId": 1,
                    "origem": "São Paulo - SP",
                    "destino": "Porto Seguro - BA",
                    "classe": "Primeira Classe",
                    "preco": 386.00,
                    "imagemUrl": "/images/cidades/porto-seguro-ba.jpg",
                    "dataVoo": "2024-03-24T00:00:00"
                },
            },
            ...
        ]
        ```
    - Resposta: Status 200 (OK)

- **Obter Reserva por ID**: `GET /api/reserva/{id}`
    - Resposta:
        ```json
        {
            "reservaId": 2,
            "tipoServico": "Passagem",
            "clienteId": 12,
            "passagemId": 1,
            "cliente": {
                "clienteId": 12,
                "nome": "Felipe Santos",
                "email": "felipe.santos@email.com",
                "senha": "senhaxyz",
                "telefone": "(03) 98765-4321"
            },
            "passagem": {
                "passagemId": 1,
                "origem": "São Paulo - SP",
                "destino": "Porto Seguro - BA",
                "classe": "Primeira Classe",
                "preco": 386.00,
                "imagemUrl": "/images/cidades/porto-seguro-ba.jpg",
                "dataVoo": "2024-03-24T00:00:00"
            },
        }
        ```
    - Resposta: Status 200 (OK)

- **Atualizar Reserva**: `PUT /api/reserva/{id}`
    - Request body: 
        ```json
        {
            "reservaId": 2,
            "tipoServico": "Passagem",
            "clienteId": 12,
            "passagemId": 1,
        }
        ```
    - Resposta: Status 204 (No Content)

- **Excluir Reserva**: `DELETE /api/reserva/{id}`
    - Resposta: Status 204 (No Content)

## Próximos Passos

- Criar testes unitários.
- Melhorar tratamento de erros.
- Criar filtros de pesquisa e listagem de objetos.
- Criar paginação.
- Criar ordenação.
- Criar rotas de login e registro de usuários.
- Criar tratamento de autenticação e autorização.

## Licença

Veja a licença do projeto [aqui](https://github.com/svhellen/api_vivaviatravel2.0/blob/main/LICENSE)
