using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElevador1.Model
{
    internal class Elevador
    {
        public int AndarAtual { get; set; }
        public int AndaresDoPredio { get; set; }
        public int Capacidade { get; set; }

        List<string> Pessoa;
        List<int> AndarDesejado { get; set; }

        //CLASSE DE ARMAZENAMENTO DE DADOS BASE 
        public Elevador(int capacidade = 0, int totalAndares = 0)
        {
            this.Pessoa = new();
            this.AndaresDoPredio = totalAndares;
            this.Capacidade = capacidade;
            this.AndarAtual = 0;
            this.AndarDesejado = new List<int>();
        }
        //A CLASSE ABAIXO INFORMA EM QUAL ANDAR O ELEVADOR ESTÁ
        public int OndeEsta()
        {
            return this.AndarAtual;
        }
        //A CLASSE ABAIXO INFORMA QUANTAS PESSOAS ESTÃO DENTRO DO ELEVADOR 
        internal int Vagas()
        {
            return this.Pessoa.Count;
        }
        //NA CLASSE ABAIXO SE ENCONTRA O METODO PARA ADICIONAR PESSOAS AO ELEVADOR E IMPEDIR QUE O CONTADOR DEIXE QUE O NUMERO DE PASSAGEIROS ULTRAPASSE O NUMERO DE VAGAS
        public int Entrar(String Individuo, int proxAndar)
        {
            Pessoa.Add(Individuo);
            AndarDesejado.Add(proxAndar);
            return Pessoa.Count;

        }
        //A FUNÇÃO DA CLASSE ABAIXO É DE RETIRADA DE PESSOAS DOS ELEVADOR E IMPEDIR QUE SEJAM RETIRADAS MAIS PESSOAS DEPOIS QUE O ELEVADOR FICA VAZIO 
        public int Sair()
        {

            Pessoa.RemoveAt(0);
            return Pessoa.Count;

        }
        //ESTA CLASSE INFORMA QUANTAS VAGAS ESTAO DISPONIVEIS NO ELEVADOR 
        public int QuantasVagas()
        {
            return this.Capacidade - Pessoa.Count;
        }
        //FAZER COM QUE O ELEVADOR SUBA DE ANDARES 
        public int Subir()
        {
            return this.AndarAtual++;
        }
        //FAZER COM QUE O ELEVADOR DESÇA OS ANDARES 
        public int Descer()
        {

            return this.AndarAtual--;

        }
    }
}
