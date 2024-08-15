# Monitor de Sites

## Descrição
Este é um programa em C# para monitorar a disponibilidade de sites. Ele permite aos usuários verificar o status de vários sites, adicionar novos sites à lista de monitoramento e visualizar logs de verificações anteriores.

## Funcionalidades
- Monitoramento de múltiplos sites
- Adição de novos sites à lista de monitoramento
- Exibição de logs de verificações anteriores
- Interface de linha de comando interativa

## Requisitos
- .NET Core 3.1 ou superior
- Sistema operacional compatível (Windows, macOS, Linux)

## Instalação
1. Clone este repositório:
git clone https://github.com/seu-usuario/monitor-de-sites-csharp.git
2. Navegue até o diretório do projeto:
cd monitor-de-sites-csharp
3. Compile o projeto:
dotnet build

## Uso
1. Execute o programa:
dotnet run

2. Siga as instruções no menu interativo:
- Digite '1' para iniciar o monitoramento
- Digite '2' para exibir logs
- Digite '3' para adicionar um novo site
- Digite '0' para sair do programa

## Configuração
Os sites a serem monitorados são armazenados no arquivo `sites.txt`. Você pode editar este arquivo manualmente ou usar a opção 3 no menu do programa para adicionar novos sites.

## Estrutura do Projeto
- `Program.cs`: Contém a lógica principal do programa
- `sites.txt`: Lista de sites a serem monitorados
- `log.txt`: Arquivo de log gerado pelo programa

## Contribuição
Contribuições são bem-vindas! Por favor, sinta-se à vontade para submeter pull requests ou abrir issues para sugerir melhorias ou reportar bugs.

## Licença
Este projeto está licenciado sob a [MIT License](https://opensource.org/licenses/MIT).

## Contato
[Matheus Filipe de Deus] - [matheusfilipedesilva@gmail.com]

Link do projeto: https://github.com/0matheusfilipe/monitor-de-sites-csharp
