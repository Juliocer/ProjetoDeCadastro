using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Lista para armazenar os usuários em memória
    static List<Usuario> usuarios = new List<Usuario>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Sistema de Cadastro de Usuários ===");
            Console.WriteLine("1. Cadastrar Usuário");
            Console.WriteLine("2. Listar Usuários");
            Console.WriteLine("3. Buscar Usuário");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();
            Console.Clear();

            switch (opcao)
            {
                case "1":
                    CadastrarUsuario();
                    break;
                case "2":
                    ListarUsuarios();
                    break;
                case "3":
                    BuscarUsuario();
                    break;
                case "4":
                    Console.WriteLine("Encerrando o programa...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // Método para cadastrar um novo usuário
    static void CadastrarUsuario()
    {
        Console.WriteLine("=== Cadastro de Usuário ===");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        
        Console.Write("E-mail: ");
        string email = Console.ReadLine();
        
        Console.Write("Idade: ");
        if (int.TryParse(Console.ReadLine(), out int idade))
        {
            usuarios.Add(new Usuario(nome, email, idade));
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }
        else
        {
            Console.WriteLine("Idade inválida. Tente novamente.");
        }
        
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    // Método para listar todos os usuários cadastrados
    static void ListarUsuarios()
    {
        Console.WriteLine("=== Lista de Usuários ===");
        if (usuarios.Count == 0)
        {
            Console.WriteLine("Nenhum usuário cadastrado.");
        }
        else
        {
            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario);
            }
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    // Método para buscar um usuário pelo nome
    static void BuscarUsuario()
    {
        Console.Write("Digite o nome do usuário para buscar: ");
        string nomeBusca = Console.ReadLine() ?? string.Empty;

        // Remove espaços extras no início e no final
        nomeBusca = nomeBusca.Trim();

        var usuarioEncontrado = usuarios.FirstOrDefault(u => u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

        if (usuarioEncontrado != null)
        {
            Console.WriteLine("Usuário encontrado:");
            Console.WriteLine(usuarioEncontrado);
        }
        else
        {
            Console.WriteLine("Usuário não encontrado.");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}

// Classe para representar um usuário
class Usuario
{
    public string Nome { get; }
    public string Email { get; }
    public int Idade { get; }

    public Usuario(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }

    public override string ToString()
    {
        return $"Nome: {Nome} | E-mail: {Email} | Idade: {Idade}";
    }
}
