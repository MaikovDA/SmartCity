using System.Collections.Generic;
using Repository.Models.Base;

namespace Repository.Models
{
    public class Machine : NamedModel
    {
        public int FreeSpeed { get; set; }

        public int WorkSpeed { get; set; }

        public int GazolineVol { get; set; }

		public ICollection<WorkType> WorkTypes { get; set; }

        public ICollection<Attachment> Attachments { get; set; }
    }
}
