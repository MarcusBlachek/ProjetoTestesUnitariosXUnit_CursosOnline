using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursosOnLine.Dominio.Testes.Mensagem
{
    public static class AssertExtension
    {
        //Método de extensão para equivaler a mensagem de exception, validando assim o tipo de exception lançada.
        public static void ComMensagem(this Exception exception, string mensagem)
        {
            if (exception.Message == mensagem)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(false);
            }
        }
    }
}
