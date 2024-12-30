namespace PP_PAM_I.Models
{
    public class Spell
    {
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string School { get; set; } = string.Empty;
    }
        
    public class SpellListResponse
    {
        public List<Spell> Results { get; set; }
    }
}