using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Killer.Core.DomainModel;

namespace Killer.Core.Test
{
    [TestClass]
    public class TestemunhaTest
    {
        [TestMethod]
        public void RespondeChuteCertoTest()
        {
            Assassinato a = new Assassinato(Armas.Bomba, Locais.Gotham, Suspeitos.Coringa);
            Testemunha t = new Testemunha(a);

            Assert.AreEqual(0, t.RespondeChute(new Assassinato(Armas.Bomba, Locais.Gotham, Suspeitos.Coringa)));
        }


        [TestMethod]
        public void RespondeChuteErradoTest()
        {
            Assassinato a = new Assassinato(Armas.Bomba, Locais.Gotham, Suspeitos.Coringa);
            Testemunha t = new Testemunha(a);

            Assert.AreNotEqual(0, t.RespondeChute(new Assassinato(Armas.Peixeira, Locais.Siberia, Suspeitos.Coringa)));
        }
    }
}
