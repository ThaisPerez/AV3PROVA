namespace CasaNova.Dominio.Entidades
{
    public class Imovel
    {
        public Imovel(
            string cidade,
            string bairro,
            string logradouro,
            string qtdQuartos,
            string valor)
        {
            Cidade = cidade;
            Bairro = bairro;
            Logradouro = logradouro;
            QtdQuartos = qtdQuartos;
            Valor = valor;

        }

        public int Id { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Logradouro { get; private set; }
        public string QtdQuartos { get; private set; }
        public string Valor { get; private set; }

        public void AtualizarDados(
            string cidade,
            string bairro,
            string logradouro,
            string qtdQuartos,
            string valor)
        {
            Cidade = cidade;
            Bairro = bairro;
            Logradouro = logradouro;
            QtdQuartos = qtdQuartos;
            Valor = valor;
        }
    }
}
