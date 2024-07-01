namespace SkillTree.Server
{
    public class learingOutcome
    {
        public string name { get; set; }

        public string grade {  get; set; }

        public List<string> outcomeIds = [];

        public DateTime? lastsubmission {  get; set; }

        public string description { get; set; }

    }
}
