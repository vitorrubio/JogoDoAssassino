using Killer.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Killer.Infra;

namespace Killer.Services
{
    public class LocalService
    {
        public virtual Dictionary<int, string> GetLocais()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            foreach (Locais elemento in Enum.GetValues(typeof(Locais)))
            {
                result.Add((int)elemento, elemento.GetDescription());
            }

            return result;
        }
    }
}
