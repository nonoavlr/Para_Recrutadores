-- Projeto em construção --

Bem vindxs ao meu projeto-vitrine.

Criei esse projeto com a intenção de demonstrar meus conhecimentos de desenvolvimento adquiridos durante meu curso.

Apesar de ainda não ter experiência profissional na área, consigo oferecer uma amostra de tudo que estou aprendendo durante o ano. Sei que pode ser dificil contratar alguem sem experiência profissional na área mas aqui posso mostrar o que eu tenho aprendido, meu desempenho e a minha vontade de contribuir/aprender.

Novo na área, posso absorver com maior facilidade o estilo de desenvolvimento da sua empresa e oferecer soluções alternativas para agregar no projeto.

Agora vou explicar melhor como construí o projeto. Desde já, agradeço muito sua atenção.

Back-end (Orientado a Objeto) - 3 Projetos{

    Loja.Domain (Core) {

        Aqui eu elaborei um projeto-modelo dos objetos que serão utilizados. Tudo que será utilizado na loja esta bem definido no Core.
    }

    Loja.Application (Aplicação) {

        Nesse projeto, ainda em construção, elaborei as classes de manipulação dos objetos (Handlers). 

        Inicialmente criei uma interface (IEntityCrudHandler<Type>) com as assinaturas padrões do REST (Get, Post, Put, Delete) para ser herdado por todas as classes e posteriormente desenvolvido conforme a função de cada.

        Elaborei também uma interface de manipulação dos objetos no banco de dados (IApplicationDbContext). 
        Motivo? Utilizando interfaces é mais fácil e seguro realizar qualquer alteração no banco de dados ou aplicação sem precisar alterar todo o código. A interface me permite trabalhar como uma especie de contrato desde que, alterando uma parte, eu apenas preciso configurar para que ela ofereça as informações no mesmo padrão definido.

        Por último, crei o DependencyInjection, ou melhor, uma classe de Injeção de Dependência apenas para deixar a aplicação mais organizada e adicionar facilmente no StartUp do projeto através da interface IServiceColletion.
    }

    Loja.Persistency (Persistência ou Banco de dados){

        Nesse projeto defini a configuração da persistência, configurando um banco de dados relacional.

        Na classe LojaDbContext herdei a classe de configuração do banco e a interface da aplicação para construir o banco relacional. Posteriormente configurei o relacionamento da persistência criando um elo de identificação entre todos os objetos através da chave estrangeira.

        Criei aqui também uma classe de Injeção de Dependência (DependencyInjection) para confirugar o SQLite, com o mesmo intuito de organização e fácil aplicação no StartUp do projeto.
    }
}

Front-End React{
    Projeto criado a partir do ASP.NET.CORE para trabalhar o server-client. 

    Esta parte do projeto visa oferecer toda a navegação do usuário através dos React.Components.

    Os componentes conversarão diretamente com o Controller para a troca de informações e manipulação dos objetos através das funções Get, Post, Put e Delete. As funções conversarão diretamente com a Interface dos Handlers criados no projeto Application.

    As duas injeções de dependência foram adicionadas na classe StartUp.
}