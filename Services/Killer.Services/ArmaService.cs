using Killer.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Killer.Infra;

namespace Killer.Services
{
    public class ArmaService
    {
        public virtual Dictionary<int, string> GetArmas()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            foreach (Armas elemento in Enum.GetValues(typeof(Armas)))
            {
                result.Add((int)elemento, elemento.GetDescription());
            }

            return result;
        }
    }
}
