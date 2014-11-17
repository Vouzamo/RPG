using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Assets.Scripts.Core
{
    public interface IXmlRepository
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
