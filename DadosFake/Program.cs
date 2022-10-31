using Bogus;
using Bogus.Extensions.Brazil;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using System.Text.Json;

namespace DadosFake
{
    class Program
    {
        static void Main(string[] args)
        {
            var funcionarioFake = new Faker<Funcionario>()
                .RuleFor(f => f.Cpf, d => new Person("pt_BR").Cpf(false))
                .RuleFor(f => f.NomeCompelto, d => d.Name.FullName())
                .RuleFor(f => f.DataNascimento, d => d.Date.Past(50))
                .RuleFor(f => f.Contato, d => d.Phone.PhoneNumber());

            var funcinario = funcionarioFake.Generate(100);
            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(funcinario, options);

            Console.WriteLine(jsonString);

            //using (var connection = new SqlConnection("Data Source = Jimmy\\SQLEXPRESS; Initial Catalog = Funcioanrio; Integrated Security = True"))
            //{
            //    connection.Open();
            //    connection.Insert(funcinario);
            //}
        }

    }
}