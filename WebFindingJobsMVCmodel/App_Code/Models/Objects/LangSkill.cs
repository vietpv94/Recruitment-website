namespace Models.Objects
{
    /// <summary>
    /// Summary description for LangSkill
    /// </summary>
    public class LangSkill
    {
        private string _sillId;
        private string _skillName;
        private string _description;

        public LangSkill()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public LangSkill(string id, string name)
        {
            //
            // TODO: Add constructor logic here
            //
            SillId = id;
            SkillName = name;
        }

        public LangSkill(string id, string name, string description)
        {
            //
            // TODO: Add constructor logic here
            //
            SillId = id;
            SkillName = name;
            Description = description;
        }

        public string SillId
        {
            get { return _sillId; }
            set { _sillId = value; }
        }

        public string SkillName
        {
            get { return _skillName; }
            set { _skillName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}