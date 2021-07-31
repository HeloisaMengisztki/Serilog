using System;

namespace Testeserilog
{
    public interface InterfaceComHerculesContextId
    {
        const string HerculesContextId = Guid.NewGuid().ToString();
    }
}