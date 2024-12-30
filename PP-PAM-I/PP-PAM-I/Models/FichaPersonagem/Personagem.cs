namespace PP_PAM_I.Models.FichaPersonagemModel
{
    public class Personagem
    {
        public string Nome { get; set; } = string.Empty;
        public string Classe { get; set; } = string.Empty;
        public int Nivel { get; set; }
        public string Raca { get; set; } = string.Empty;
    }
}
