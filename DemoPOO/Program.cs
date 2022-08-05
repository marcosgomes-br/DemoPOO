using System;
using System.Linq;
using DemoPOO.Domains;
using DemoPOO.Repositories;

namespace DemoPOO
{
    class Program
    {
        private static EventoRepository _eventoRepository = new EventoRepository();
        
        static void Main(string[] args)
        {
            int operacao = 0;
            do
            {
                operacao = ExibirMenu();
                switch (operacao)
                {
                    case 1:
                        CriarEvento();
                        break;
                    case 2:
                        ExcluirEvento();
                        break;
                    case 3:
                        ParticiparEvento();
                        break;
                    case 4:
                        ListarPessoasEvento();
                        break;
                }
            } while (operacao != 0);
        }
        private static int ExibirMenu()
        {
            Console.WriteLine("||=========================||");
            Console.WriteLine("|| 1- CRIAR EVENTO         ||");
            Console.WriteLine("|| 2- EXCLUIR EVENTO       ||");
            Console.WriteLine("|| 3- ADICIONAR CONVIDADO  ||");
            Console.WriteLine("|| 4- PESSOAS DO EVENTO    ||");
            Console.WriteLine("|| 0- SAIR                 ||");
            Console.WriteLine("||=========================||");
            Console.Write("Insira uma opção: ");
            var valor = Console.ReadLine();
            return !string.IsNullOrEmpty(valor) ? int.Parse(valor) : 0;
        }
        private static void CriarEvento()
        {
            Console.Clear();
            Console.WriteLine("*CRIAÇÃO DE EVENTO");
            Console.WriteLine("*ETAPA 1/2");
            Console.WriteLine("*DADOS DO ORGANIZADOR");
            Console.Write("Insira o seu nome: ");
            var nome = Console.ReadLine();
            Console.Write("Insira o seu documento: ");
            var documento = Console.ReadLine();
            var organizador = new Organizador(nome, documento);
            Console.Clear();
            Console.WriteLine("*CRIAÇÃO DE EVENTO");
            Console.WriteLine("**ETAPA 2/2");
            Console.WriteLine("**DADOS DO EVENTO");
            Console.Write("Insira a data do evento: ");
            var strData = Console.ReadLine();
            var splitData = strData.Split("/");
            var data = new DateTime(int.Parse(splitData[2]), int.Parse(splitData[1]), int.Parse(splitData[0]));
            Console.Write("Insira o nome do evento: ");
            var nomeEvento = Console.ReadLine();
            Console.Write("Insira quantas vagas serão disponibilizadas: ");
            string vagas = Console.ReadLine();
            var local = new Local(Guid.NewGuid(), "Local Demo", "BH", "MG", "Afonso Pena");
            _eventoRepository.Salvar(new Evento(Guid.NewGuid(), data, nomeEvento, organizador, Int32.Parse(vagas), local));
            Console.Clear();
            Console.WriteLine("Evento criado com SUCESSO! Aperte qualquer tecla para continuar...");
            Console.Read();
        }
        private static void ExcluirEvento()
        {   
            var evento = ListarEventos();
            _eventoRepository.Remover(evento);
            Console.Clear();
            Console.WriteLine($"Evento {evento.Nome} excluído com sucesso!  Aperte qualquer tecla para continuar...");
            Console.Read();
        }
        private static void ParticiparEvento()
        {
            var evento = ListarEventos();
            Console.Clear();
            Console.WriteLine($"Insira os seus dados para participar do {evento.Nome}");
            Console.Write("Insira o seu nome: ");
            var nome = Console.ReadLine();
            Console.Write("Insira o seu documento: ");
            var documento = Console.ReadLine();

            _eventoRepository.AdicionarConvidado(evento, new Convidado(nome, documento));
        }
        private static void ListarPessoasEvento()
        {
            var evento = ListarEventos();
            Console.Clear();
            Console.WriteLine($"EVENTO - {evento.Nome} SERÁ REALIZADO EM {evento.Data.ToString("dd/MM/yyyy")} ");
            foreach (var convidado in evento.Convidados)
            {
                Console.WriteLine($"{convidado.Nome} - {convidado.Documento}");
            }
            Console.WriteLine($"Organização: {evento.Organizador.Nome}");
            Console.WriteLine($"Total de Convidados: {evento.Convidados.Count}");
            Console.WriteLine("Aperte qualquer tecla para continuar...");
            Console.Read();
        }
        private static Evento ListarEventos()
        {
            Console.Clear();
            Console.WriteLine("*EVENTOS DISPONÍVEIS:");
            var eventos = _eventoRepository.Listar();
            for (int i = 0; i < eventos.Count; i++)
            {
                Console.WriteLine($@"{i+1} - {eventos[i].Nome}");
            }
            Console.Write("Insira o código do evento que deseja selecionar: ");
            var opcao = Console.ReadLine();
            var eventoSelecionado = string.IsNullOrEmpty(opcao) ? 0 : int.Parse(opcao)-1;
            return eventos[eventoSelecionado];
        }
    }
}