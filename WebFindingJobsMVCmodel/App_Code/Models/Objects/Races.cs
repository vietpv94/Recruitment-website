namespace Models.Objects
{
    /// <summary>
    /// Summary description for Races
    /// </summary>
    public class Races
    {
        private string _raceId;
        private string _raceName;
	
        public string RaceId
        {
            get { return _raceId; }
            set { _raceId = value; }
        }

        public string RaceName
        {
            get { return _raceName; }
            set { _raceName = value; }
        }
        public Races()
        {
        }
        public Races(string id,string raceName)
        {
            RaceId = id;
            RaceName = raceName;
        }
    }
}