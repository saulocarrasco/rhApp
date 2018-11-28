using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhApp.Model
{
     
    public enum ObjectStatus
    {
        Disabled = 0,
        Enable = 1
    }
    public interface IBaseInterface
    {
        ObjectStatus Status { get; set; }
    }
}
