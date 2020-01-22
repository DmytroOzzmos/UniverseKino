using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseKino.Data.Entities
{
    class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
