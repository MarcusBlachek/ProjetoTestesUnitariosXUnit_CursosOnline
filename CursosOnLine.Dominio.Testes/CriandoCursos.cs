using Cursos.OnLine.Dominio;
using Cursos.OnLine.Dominio._Enum;
using CursosOnLine.Dominio.Testes._Builder;
using CursosOnLine.Dominio.Testes.Mensagem;
using System;
using Xunit;
namespace CursosOnLine.Dominio.Testes

    //Eu, enquanto administrador, quero criar e editar cursos para que sejam abertas matr�culas para o mesmo.
    //CRIT�RIOS DE ACEITE:
    //* Criar um curso com nome, descri��o, carga hor�ria, p�blico alvo e pre�o
    //*Todos os campos do curso s�o obrigat�rios.

{
    public class CriandoCursos
    {
        private readonly string _nome;
        private readonly string _descricao;
        private readonly int _cargaHoraria;
        private readonly Publico _publicoAlvo;
        private readonly double _preco;

        /*Atribuindo no contrutor dados v�lidos as propriedades para criar um curso, 
        j� que a cada teste chamado o construtor � executado.*/
        public CriandoCursos()
        {
            _nome = "Inform�tica Fundamentos";
            _descricao = "Uma descri�~so...";
            _cargaHoraria = 12;
            _publicoAlvo = Publico.Estudante;
            _preco = 300.00;
        }


        //Teste que cria um curso com os dados setados e valida a a��o.
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
            .Build()).ComMensagem("O Nome n�o pode ser nulo ou vazio");
        }


        //Teste de descri��o nula ou vazia
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoPermitirCriarCursoComDescricaoNuloOuVazio(string descricaoInvalida)
        {
            //Arrange = ctor
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => CursoBuilder.Novo().ComNome(descricaoInvalida)
            .Build()).ComMensagem("A descri��o n�o pode ser nula ou vazia");
        }


        //Teste de carga hor�ria do curso 
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
                .ComMensagem("A carga hor�ria n�o pode ser menor que 1");

        }


        //Teste de pre�o
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
                .ComMensagem("O valor do curso n�o pode ser menor que R$ 50,00");
        }
    }
}
