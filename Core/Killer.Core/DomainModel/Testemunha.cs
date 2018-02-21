using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;


namespace Killer.Core.DomainModel
{
    public class Testemunha
    {
        private Assassinato _assassinato;

        public Testemunha(Assassinato killer)
        {
            _assassinato = killer;

        }



        public virtual int RespondeChute(Assassinato palpite)
        {
            List<int> comparacoes = new List<int>();

            if ((_assassinato.Suspeito == palpite.Suspeito) 
                && (_assassinato.Arma == palpite.Arma) 
                && (_assassinato.Local == palpite.Local))
            {
                return 0;
            }

            if (_assassinato.Suspeito != palpite.Suspeito)
                comparacoes.Add(1);

            if (_assassinato.Local != palpite.Local)
                comparacoes.Add(2);

            if (_assassinato.Arma != palpite.Arma)
                comparacoes.Add(3);

            if (comparacoes.Count == 1)
            {
                return comparacoes[0];
            }
            else
            {
                int idx = RandomCrimeGenerator.Gen(0, comparacoes.Count);
                return comparacoes[idx];
            }
        }
    }
}
