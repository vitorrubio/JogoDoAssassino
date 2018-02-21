using Killer.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Killer.Core
{
    public static class RandomCrimeGenerator
    {
        public static int Gen()
        {
            //seed para aumentar a aletoriedade, porque embora o random não seja thread-safe, intâncias privadas criadas ao mesmo tempo em threads diferentes tendem a gerar valores próximos
            Random seed = new Random();
            Random rnd = new Random(seed.Next());
            return rnd.Next();
        }

        public static int Gen(int maximo)
        {
            Random seed = new Random();
            Random rnd = new Random(seed.Next());
            return rnd.Next(maximo);
        }

        public static int Gen(int minimo, int maximo)
        {
            Random seed = new Random();
            Random rnd = new Random(seed.Next());
            return rnd.Next(minimo, maximo);
        }


        public static Testemunha TestemunharAssassinato()
        {
            Locais primeiroLocal =          Enum.GetValues(typeof(Locais)).Cast<Locais>().Min();
            Locais ultimoLocal =            Enum.GetValues(typeof(Locais)).Cast<Locais>().Max();
            Locais localCrime =             (Locais)Gen((int)primeiroLocal, ((int)ultimoLocal)+1);

            Suspeitos primeiroSuspeito =    Enum.GetValues(typeof(Suspeitos)).Cast<Suspeitos>().Min();
            Suspeitos ultimoSuspeito =      Enum.GetValues(typeof(Suspeitos)).Cast<Suspeitos>().Max();
            Suspeitos assassino =           (Suspeitos)Gen((int)primeiroSuspeito, ((int)ultimoSuspeito)+1);

            Armas primeiraArma =            Enum.GetValues(typeof(Armas)).Cast<Armas>().Min();
            Armas ultimaArma =              Enum.GetValues(typeof(Armas)).Cast<Armas>().Max();
            Armas armaCrime =               (Armas)Gen((int)primeiraArma, ((int)ultimaArma)+1);

            return new Testemunha(new Assassinato(armaCrime, localCrime, assassino));
        }
    }
}
