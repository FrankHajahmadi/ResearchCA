using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class Ethnicity
    {
        public int EthnicityId { get; set; }
        public int EthnicGroupId { get; set; }
        public int SubjectId { get; set; }

        public virtual EthnicGroup EthnicGroup { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
