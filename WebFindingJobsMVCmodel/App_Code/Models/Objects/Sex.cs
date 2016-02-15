namespace Models.Objects
    {
    /// <summary>
    /// Summary description for Sex
    /// </summary>
    public class Sex
    {
        private string _sexId;
        private string _sexName;
     

        public string SexName
        {
            get { return _sexName; }
            set { _sexName = value; }
        }

        public string SexId
        {
            get { return _sexId; }
            set { _sexId = value; }
        }
        public Sex()
        {
            _sexId = "1";
            _sexName = "other";
        }

        public Sex(string id, string name)
        {
            _sexId = id;
            _sexName = name;
        }
        
    }
}