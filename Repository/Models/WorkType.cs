using System;
using Repository.Models.Base;

namespace Repository.Models
{
    public class WorkType : NamedModel
    {
        public CleanMethod CleanMethod { get; set; }

        public DateTime RegTimeStart { get; set; }

        public DateTime RegTimeEnd { get; set; }

        public Season SeasonCode { get; set; }
    }


    public enum Season
    {
        Winter = 0,

        Spring,

        Summer,

        Autumn
    }
}
