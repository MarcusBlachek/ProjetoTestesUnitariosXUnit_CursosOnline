using Cursos.OnLine.Dominio;
using Cursos.OnLine.Dominio._Enum;
using CursosOnLine.Dominio.Testes._Builder;
using CursosOnLine.Dominio.Testes.Mensagem;
using System;
using Xunit;
namespace CursosOnLine.Dominio.Testes

    //Eu, enquanto administrador, quero criar e editar cursos para que sejam abertas matrículas para o mesmo.
    //CRITÉRIOS DE ACEITE:
    //* Criar um curso com nome, descrição, carga horária, público alvo e preço
    //*Todos os campos do curso são obrigatórios.

{
    public class CriandoCursos
    {
        private readonly string _nome;
        private readonly string _descricao;
        private readonly int _cargaHoraria;
        private readonly Publico _publicoAlvo;
        private readonly double _preco;

        /*Atribuindo no contrutor dados válidos as propriedades para criar um curso, 
        já que a cada teste chamado o construtor é executado.*/
        public CriandoCursos()
        {
            _nome = "Informática Fundamentos";
            _descricao = "Uma descriç~so...";
            _cargaHoraria = 12;
            _publicoAlvo = Publico.Estudante;
            _preco = 300.00;
        }


        //Teste que cria um curso com os dados setados e valida a ação.
        [Fact]
        public void EsperaCriarCursoCompletoDadoValoresDeEntradaValidos()
        {
            //Arrange ctor

            //Act
            var curso = new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _preco);

            //Assert
            Assert.Equal(_nome, curso.Nome);
            Assert.Equal(_descricao, curso.Descricao);
            Assert.Equal(_cargaHoraria, curso.CargaHoraria);
            Assert.Equal(_publicoAlvo, curso.PublicoAlvo);
            Assert.Equal(_preco, curso.Preco);
        }


        //Teste de nome nulo ou vazio
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoPermitirCriarCursoComNomeNuloOuVazio(string nomeInvalido)
        {
            //Arrange = ctor
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => CursoBuilder.Novo().ComNome(nomeInvalido)
            .Build()).ComMensagem("O Nome não pode ser nulo ou vazio");
        }


        //Teste de descrição nula ou vazia
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoPermitirCriarCursoComDescricaoNuloOuVazio(string descricaoInvalida)
        {
            //Arrange = ctor
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => CursoBuilder.Novo().ComNome(descricaoInvalida)
            .Build()).ComMensagem("A descrição não pode ser nula ou vazia");
        }


        //Teste de carga horária do curso 
        [Theory]
        [InlineData(0)]
        [InlineData(-30)]
        [InlineData(-100)]
        public void CursoNaoPodeTerCargaHorariaMenorQue1(int cargaHorariaInvalida)
        {
            //Arrange = ctor
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
                .ComMensagem("A carga horária não pode ser menor que 1");

        }


        //Teste de preço
        [Theory]
        [InlineData(10)]
        [InlineData(-20)]
        [InlineData(0)]
        public void NaoPodeTerPrecoMenorQue50(double precoInvalido)
        {
            //Arrange = ctor
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComPreco(precoInvalido).Build())
                .ComMensagem("O valor do curso não pode ser menor que R$ 50,00");
        }
    }
}
