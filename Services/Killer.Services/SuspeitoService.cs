using Killer.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Killer.Infra;

namespace Killer.Services
{
    public class SuspeitoService
    {
        public virtual Dictionary<int, string> GetSuspeitos()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            foreach (Suspeitos elemento in Enum.GetValues(typeof(Suspeitos)))
            {
                result.Add((int)elemento, elemento.GetDescription());
            }

            return result;
        }
    }
}
