Trabalho Final Windows Phone
============================

Nome do aplicativo: GitHub App.

Descrição:
O aplicativo desenvolvido tem a finalidade de mostrar os projetos de usuários no GitHub. Suas funçoes são: Cadastro de usuário e Listagem de projetos por usuário.
O cadastro de usuários é armazenado em banco de dados e podemos criar Tile secundário para cada usuário. 
A relação de projetos é obtida via acesso ao webservice do GitHub, onde extraimos os dados de cada repositório do usuário selecionado no ListBox.
O app suporta os idiomas Português (Brasil) e Inglês de acordo com as configurações do celular (settings - language).

Características e recursos:
- Tile principal personalizado.
- Estado das páginas é mantido ao retornar do state tombstoned/dormant.
- Suporta os idiomas Inglês e Português.
- Uso do banco de dados para armazenar a relação de usuarios.
- Criação de tiles secundários no cadastro de usuarios (Tile dará acesso a relação de projetos do usuário).
- Consumo do webservice do GitHub (https://api.github.com/users/<usuario>/repos)

Alunos:
Francisco Glailton Rodrigues Costa 
Osmar de Oliveira Martins Filho
