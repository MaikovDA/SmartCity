using System;
using System.Collections.Generic;
using Repository.Models.Base;

namespace Repository.Models
{
    public class WorkType : NamedModel
    {
        public CleanMethod CleanMethod { get; set; }

        public DateTime RegTimeStart { get; set; }

        public DateTime RegTimeEnd { get; set; }

        public Season SeasonCode { get; set; }

	    public int DayOperationCount { get; set; }

		public ICollection<Machine> Machines { get; set; } 

		public ICollection<Attachment> Attachments { get; set; } 
    }


    public enum Season
    {
        Winter = 0,

        Spring,

        Summer,

        Autumn
    }
}
