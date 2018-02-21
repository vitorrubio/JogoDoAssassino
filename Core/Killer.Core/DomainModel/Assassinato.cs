using System;
using System.Collections.Generic;
using System.Text;

namespace Killer.Core.DomainModel
{
    public class Assassinato
    {
        private Armas _arma;

        private Locais _local;

        private Suspeitos _suspeito;


        public Assassinato(Armas arma, Locais local, Suspeitos suspeito)
        {
            _arma = arma;
            _local = local;
            _suspeito = suspeito;
        }

        public virtual Armas Arma { get { return _arma; } }

        public virtual Locais Local { get { return _local; } }

        public virtual Suspeitos Suspeito { get { return _suspeito; } }


    }
}
