namespace Models.Objects
{
    /// <summary>
    /// Summary description for JobPosition
    /// </summary>
    public class JobPosition
    {
        private string _jobPositionId;
        private string _position;

        public JobPosition()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public JobPosition(string id, string position)
        {
            JobPositionId = id;
            Position = position;
        }

        public string JobPositionId
        {
            get { return _jobPositionId; }
            set { _jobPositionId = value; }
        }

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}