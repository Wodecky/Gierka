using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Interfaces
{
    public interface IDeck
    {
        int Draw();        
        bool IsEmpty();
    }
}
