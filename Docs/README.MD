# Como foi Desenvolvido

O sistema foi dividido em 4 camadas, segundo os princípios do DDD
* Uma camada de domínio, com as entidades de negócio e suas regras, que chamei de Killer.Core
* Uma camada de Infraestrutura com classes e métodos que poderiam ser utilizados pela aplicação em si, mas não são referentes as regras de negócio. Nela coloquei um extension method para obter as descrições dos Enums. Chamei ela de Killer.Infra
* Uma camada de Serviços chamada Killer.Service
* A quarta camada é a de apresentação e pode ser tanto a Killer.Web como a Killer.Xamarin. A Killer.Web é feita em asp.net mvc

As camadas Core, Infra e Services foram feitas em .Net Standard 2.0 para garantir a compatibilidade com os vários frameworks da Microsoft (.Net Framework 4.6, .Net Core etc)

Como não foi feito cadastro de jogador, contagem de partidas, pontuação etc não usamos nenhum banco de dados e nenhuma ferramenta ORM

Os dados das armas, locais e suspeitos podem ser obtidos dos próprios enums. 

Não usamos WebApi para fornecer os dados dos elementos do jogo para a aplicação mobile (esta arquitetura poderia ser uma alternativa) porque a aplicação mobile pode usar as mesmas bibliotecas.
