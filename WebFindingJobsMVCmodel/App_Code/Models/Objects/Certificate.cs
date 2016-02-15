namespace Models.Objects
{
    /// <summary>
    /// Summary description for Certificate
    /// </summary>
    public class Certificate
    {
        private string certificateId;
        private string certificateName;

        public Certificate()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Certificate(string id, string name)
        {
            //
            // TODO: Add constructor logic here
            //
            CertificateId = id;
            CertificateName = name;
        }

        public string CertificateId
        {
            get { return certificateId; }
            set { certificateId = value; }
        }

        public string CertificateName
        {
            get { return certificateName; }
            set { certificateName = value; }
        }
    }
}