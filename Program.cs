using System;

namespace cadastrodeclientes
{
    public class Program
    {
        static List<Client> clients = new List<Client>();
        public static void Main(string[] args)
        {
            bool executing = true;

            while(executing)
            {
                Console.WriteLine("Informe uma opção:");
                Console.WriteLine("1 - Adicionar cliente");
                Console.WriteLine("2 - Visualizar clientes");
                Console.WriteLine("3 - Editar cliente");
                Console.WriteLine("4 - Excluir cliente");
                Console.WriteLine("5 - Sair");

                int opcao = Convert.ToInt32(Console.ReadLine());

                switch(opcao)
                {
                    case 1:
                        AddClient();
                    break;
                    case 2:
                        ViewClient();
                    break;
                    case 3:
                        EditClient();
                    break;
                    case 4:
                        DeleteClient();
                    break;
                    case 5:
                        executing = false;
                    break;
                    default:
                        Console.WriteLine("Invalid option!!!");
                    break;
                }
            }
        }
        public static void AddClient()
        {
            Console.WriteLine("Digite o nome do cliente que será adicionado: ");
            string name = Console.ReadLine();

            Console.WriteLine("Digite o email do cliente que será adicionado: ");
            string mail = Console.ReadLine();

            Client client = new Client(name, mail);
            clients.Add(client);
        }
        public static void ViewClient()
        {
            foreach(Client client in clients)
            {
                Console.WriteLine("Nome: {0} ", client.Name);
                Console.WriteLine("Email: {0} ", client.Mail);
                Console.WriteLine("----------------------");
            }
        }
        public static void EditClient()
        {
            Console.WriteLine("Informe o nome do cliente que deseja editar: ");
            string name = Console.ReadLine();

            Client client = clients.Find(c => c.Name.Contains(name));

            if(client != null)
            {
                Console.WriteLine("Informe que informação deseja editar: ");
                Console.WriteLine("1 - Nome: ");
                Console.WriteLine("2 - Email: ");
                int editInfo = Convert.ToInt32(Console.ReadLine());

                switch(editInfo)
                {
                    case 1:
                        Console.WriteLine("Informe o novo nome do cliente: ");
                        string newName = Console.ReadLine();
                        client.Name = newName;
                    break;
                    case 2:
                        Console.WriteLine("Informe o novo email do cliente: ");
                        string newMail = Console.ReadLine();
                        client.Mail = newMail;
                    break;
                    default:
                        Console.WriteLine("Option not found!!! ");
                    break;
                }
            }
            else{
                Console.WriteLine("Client not found!!!");
            }
        }
        public static void DeleteClient()
        {
            Console.WriteLine("Informe o nome do cliente que deseja excluir: ");
            string name = Console.ReadLine();

            Client client = clients.Find(c => c.Name.Contains(name));

            if(client != null)
            {
                clients.Remove(client);
                Console.WriteLine("Cliente excluído com sucesso.");
            }
            else{
                Console.WriteLine("Client not found!!!");
            }
        }
        class Client
        {
            public string Name { get; set; }
            public string Mail { get; set; }

            public Client(string name, string mail)
            {
                Name = name;
                Mail = mail;
            }
        }
    }
}