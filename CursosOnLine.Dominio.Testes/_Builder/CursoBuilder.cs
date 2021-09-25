using Cursos.OnLine.Dominio;
using Cursos.OnLine.Dominio._Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursosOnLine.Dominio.Testes._Builder
{
    public class CursoBuilder
    {
        private string _nome = "Informática Fundamentos";
        private string _descricao = "Uma descrição...";
        private int _cargaHoraria = 12;
        private Publico _publicoAlvo = Publico.Estudante;
        private double _preco = 300.00;

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder ComCargaHoraria(int cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComPublico(Publico publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder ComPreco(double preco)
        {
            _preco = preco;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _preco);
        }
    }
}
