namespace Models.Objects
{
    /// <summary>
    /// Summary description for WorkType
    /// </summary>
    public class WorkType
    {
        private string _workTypeId;
        private string _workTypeName;


        public WorkType()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public WorkType(string id, string name)
        {
            WorkTypeId = id;
            WorkTypeName = name;
            //
            // TODO: Add constructor logic here
            //
        }

        public string WorkTypeId
        {
            get { return _workTypeId; }
            set { _workTypeId = value; }
        }

        public string WorkTypeName
        {
            get { return _workTypeName; }
            set { _workTypeName = value; }
        }
    }
}