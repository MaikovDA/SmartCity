using System.Collections.Generic;
using Repository.Models.Base;

namespace Repository.Models
{
    public class Machine : NamedModel
    {
	    public MachineType Type { get; set; }
    }
}
