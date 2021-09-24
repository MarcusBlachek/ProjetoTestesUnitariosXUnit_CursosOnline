using Cursos.OnLine.Dominio;
using Cursos.OnLine.Dominio._Enum;
using CursosOnLine.Dominio.Testes.Mensagem;
using System;
using Xunit;
namespace CursosOnLine.Dominio.Testes
{
    public class CriandoCursos
    {
        private readonly string _nome;
        private readonly int _cargaHoraria;
        private readonly Publico _publicoAlvo;
        private readonly double _preco;

        /*Atribuindo no contrutor dados válidos as propriedades para criar um curso, 
        já que a cada teste chamado o construtor é executado.*/
        public CriandoCursos()
        {
            _nome = "Informática Fundamentos";
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
            var curso = new Curso(_nome, _cargaHoraria, _publicoAlvo, _preco);

            //Assert
            Assert.Equal(_nome, curso.Nome);
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
            Assert.Throws<ArgumentNullException>(() => new Curso(nomeInvalido, _cargaHoraria,
                _publicoAlvo, _preco)).ComMensagem("O Nome não pode ser nulo ou vazio");
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
            Assert.Throws<ArgumentException>(() => new Curso(_nome, cargaHorariaInvalida,
                _publicoAlvo, _preco)).ComMensagem("A carga horária não pode ser menor que 1");

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
            Assert.Throws<ArgumentException>(() => new Curso(_nome, _cargaHoraria,
                _publicoAlvo, precoInvalido)).ComMensagem("O valor do curso não pode ser menor que R$ 50,00");
        }
    }
}
