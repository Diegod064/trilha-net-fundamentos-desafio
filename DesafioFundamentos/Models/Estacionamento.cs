namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        private bool EhPlacaValida(string placa)
        {
            // Converte a placa para maiúsculas e remove espaços e caracteres não alfanuméricos
            placa = new string(placa.Where(c => Char.IsLetterOrDigit(c)).ToArray()).ToUpper();

            // Verifica se a placa tem o formato correto
            return placa.Length == 7 &&
                   Char.IsLetter(placa[0]) &&
                   Char.IsLetter(placa[1]) &&
                   Char.IsLetter(placa[2]) &&
                   Char.IsDigit(placa[3]) &&
                   (Char.IsDigit(placa[4]) || Char.IsLetter(placa[4])) &&
                   Char.IsDigit(placa[5]) &&
                   Char.IsDigit(placa[6]);
        }

        private string NormalizarPlaca(string placa)
        {
            placa = placa.Replace(" ", "").Replace("-", "");  // Remove espaços e o caractere '-'
            placa = placa.ToUpper();  // Converte toda a placa para maiúsculas

            if (EhPlacaValida(placa))
            {
                // Insere o caractere '-' na posição correta
                placa = placa.Insert(3, " - ");
                return placa;
            }

            // Placa inválida, você pode lidar com isso de acordo com suas necessidades
            Console.WriteLine("Placa inválida. Certifique-se de inserir no padrão brasileiro de placas: AAA-0A00 ou AAA-0000");
            return null;
        }


        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            // Normaliza a placa antes de adicionar à lista
            string placaNormalizada = NormalizarPlaca(placa);

            if (placaNormalizada != null)
            {
                veiculos.Add(placaNormalizada);
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Normalizar a placa antes de verificar se o veículo existe
            string placaNormalizada = NormalizarPlaca(placa);

            // Verifica se o veículo existe
            if (veiculos.Contains(placaNormalizada))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // Remover a placa normalizada da lista de veículos
                veiculos.Remove(placaNormalizada);

                Console.WriteLine($"O veículo {placaNormalizada} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }


        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Realizando um laço de repetição, exibindo os veículos estacionados
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
