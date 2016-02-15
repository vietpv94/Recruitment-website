namespace Models.Objects
{
    /// <summary>
    /// Summary description for ExperienceLevel
    /// </summary>
    public class ExperienceLevel
    {
        private string _experianceLevelId;
        private string _levelOfEcperience;

        public ExperienceLevel()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ExperienceLevel(string id, string level)
        {
            ExperianceLevelId = id;
            LevelOfEcperience = level;
            //
            // TODO: Add constructor logic here
            //
        }

        public string ExperianceLevelId
        {
            get { return _experianceLevelId; }
            set { _experianceLevelId = value; }
        }

        public string LevelOfEcperience
        {
            get { return _levelOfEcperience; }
            set { _levelOfEcperience = value; }
        }
    }
}