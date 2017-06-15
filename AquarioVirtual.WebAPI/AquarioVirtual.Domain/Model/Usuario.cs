namespace AquarioVirtual.Domain.Model
{
    public class Usuario : ModelBase
    {
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }

    }
}
