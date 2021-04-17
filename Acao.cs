using System;

namespace teset{
    public class Acao{
        public string nome { get; set; }
        public string codigo { get; set; }        
        public int quantidade { get; set; }
        public Acao(string nome, string codigo, int quantidade){
            this.nome = nome;
            this.codigo = codigo;
            this.quantidade = quantidade;
        }

        public Acao(){}
        public string GetDescricaoAcao(){
            return $"Nome: {nome}, Código: {codigo}, Quantidade: {quantidade}\n\n";
        }

    
    }
}