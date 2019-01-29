using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class EthnicGroup
    {
        public EthnicGroup()
        {
            Ethnicity = new HashSet<Ethnicity>();
        }

        public int EthnicGroupId { get; set; }
        public string EthnicGroupName { get; set; }

        public virtual ICollection<Ethnicity> Ethnicity { get; set; }
    }
}
