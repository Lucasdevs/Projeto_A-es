using System.Collections.Generic;
using System.IO;
using System.Text;

namespace teset
{
    public class Programa : Menu
    {   
        List<Acao> acoes = new List<Acao>();
        public void Executar(){
            int opc = -1;
            do
            {
                Limpar();
                Escrever("|----MENU-----| \n\n1- Listar ações \n2- Cadastrar ação \n3- Exportar informações \n4- Remover ações \n5- Pesquisar ação \n6- Sair \n\nOpção: ");
                opc = int.Parse(Ler());
                switch (opc)
                {
                    case 1:
                        Limpar();
                        ListarAcoes();
                        break;
                    case 2:
                        Limpar();
                        CadastrarAcao();
                        break;
                    case 3:
                        Limpar();
                        string fileName = @"dados.txt";
                        ExportarInformacoes(fileName);
                        break;
                    case 4:
                        ExcluirAcao();
                        break;
                    case 5:
                        Limpar();
                        SearchAcao();
                        break;
                    default:
                        break;
                }
            } while (opc != 6);
        }


        public void CadastrarAcao()
        {
            Limpar();
            Acao acao = new Acao();
            Escrever("Digite o nome da ação: ");
            acao.nome = Ler();
            Escrever("Digite o código da ação: ");
            acao.codigo = Ler();
            Escrever("Digite quantas ações deseja cadastar:");
            acao.quantidade = int.Parse(Ler());
            acoes.Add(acao);
            Limpar();
            Escrever("Gostaria de Cadastrar outra ação? [s/n]");
            var cadastrarNovamente = Ler().ToLower();
            if (cadastrarNovamente == "s")
                CadastrarAcao();
        }

        public void ListarAcoes()
        {
            foreach (Acao acao in acoes)
                Escrever(acao.GetDescricaoAcao());
            Escrever("Aperte qualquer tecla para voltar ao menu...\n");
            SeguraTela();
        }

        public void ExportarInformacoes(string retorno)
        {
            string nmArquivo = retorno; 
            try
            {
                using (FileStream fs = File.Create(nmArquivo))
                    foreach (Acao acao in acoes)
                    {
                        Escrever(acao.GetDescricaoAcao());
                        byte[] info = new UTF8Encoding(true).GetBytes(acao.GetDescricaoAcao());
                        fs.Write(info, 0, info.Length);
                    }
            }
            catch (System.Exception)
            {
                throw;
            }
            Escrever("Aperte qualquer tecla para voltar ao menu...\n");
            SeguraTela();
        }

        public Acao PesquisarAcao(string nome){
            foreach (Acao acao in acoes)
                if (nome == acao.nome)
                    return acao;
            return null;
        }

        public void ExcluirAcao(){
            Acao acao = new Acao();
            Escrever("Digite o nome da ação a ser excluida:");
            var nome = Ler();
            acao = PesquisarAcao(nome);
            if (PesquisarAcao(nome) != null)
                acoes.Remove(acao);
        }

        public void SearchAcao(){
            Escrever("Digite o nome da ação a ser pesquisada:");
            var nome = Ler();
            foreach (Acao acao in acoes)
                if (nome == acao.nome)
                    Escrever(acao.GetDescricaoAcao()+"\n");
                else
                    Escrever("Nenhuma ação encontrada.\n\n");
            Escrever("Aperte qualquer tecla para voltar ao menu...\n");
            SeguraTela();
        }
    }
}