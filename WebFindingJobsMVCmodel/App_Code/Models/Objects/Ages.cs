namespace Models.Objects
{
    /// <summary>
    /// Summary description for Ages
    /// </summary>
    public class Ages
    {
        private int _fromYear;
        private int _toYear;
        public Ages(int fromyear, int toyear)
        {
            FromYear = fromyear;
            ToYear = toyear;
        }
        public Ages()
        {
          
        }

        public int FromYear
        {
            get { return _fromYear; }
            set { _fromYear = value; }
        }

        public int ToYear
        {
            get { return _toYear; }
            set { _toYear = value; }
        }
    }
}