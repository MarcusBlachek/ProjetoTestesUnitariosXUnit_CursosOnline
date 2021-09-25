using Cursos.OnLine.Dominio._Enum;
using System;
namespace Cursos.OnLine.Dominio
{
    public class Curso
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public Publico PublicoAlvo { get; set; }
        public double Preco { get; set; }

        public Curso(string nome,string descricao,int cargaHoraria, Publico publicoAlvo, double preco)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("O Nome não pode ser nulo ou vazio");

            if (cargaHoraria < 1)
                throw new ArgumentException("A carga horária não pode ser menor que 1");

            if (preco < 50)
            {
                throw new ArgumentException("O valor do curso não pode ser menor que R$ 50,00");
            }

            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Preco = preco;
        }
    }
}
