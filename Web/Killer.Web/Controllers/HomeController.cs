using Killer.Core;
using Killer.Infra;
using Killer.Core.DomainModel;
using Killer.Services;
using Killer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Killer.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPost()
        {
            if (Session["Testemunha"] == null)
                Session.Add("Testemunha", RandomCrimeGenerator.TestemunharAssassinato());
            return RedirectToAction("Opcoes");
        }

        public ActionResult Opcoes()
        {
            CargaDropdowns();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Opcoes(TeoriaViewModel palpite)
        {
            if (ModelState.IsValid)
            {
                Testemunha testemunha = (Session["Testemunha"] as Testemunha);
                if (testemunha != null)
                {
                    int resposta = testemunha.RespondeChute(new Assassinato(palpite.Arma, palpite.Local, palpite.Suspeito ));

                    switch (resposta)
                    {
                        case 0:
                            return RedirectToAction("FimDoJogo", palpite);
                        case 1:
                            ViewBag.Message = "Assassino Incorreto";
                            break;
                        case 2:
                            ViewBag.Message = "Local do Crime Incorreto";
                            break;
                        case 3:
                            ViewBag.Message = "Arma do Crime Incorreta";
                            break;
                        default:
                            ViewBag.Message = "Escolha o suspeito, o local e a arma do crime";
                            break;


                    }
                }
                else
                {
                    RedirectToAction("Index");
                }
            }

            CargaDropdowns((int)palpite.Suspeito, (int)palpite.Arma, (int)palpite.Local);

            return View();
        }


        public ActionResult FimDoJogo(TeoriaViewModel palpite)
        {
            ViewBag.Message = string.Format("Foi o {0} que cometeu o crime em {1} usando {2}", palpite.Suspeito.GetDescription(), palpite.Local.GetDescription(), palpite.Arma.GetDescription());
            return View(palpite);
        }






        private void CargaDropdowns(int? suspeito = null, int? arma = null, int? local = null)
        {
            var suspeitoSvc = new SuspeitoService();
            SelectList suspeitos = new SelectList(suspeitoSvc.GetSuspeitos(), "key", "value", suspeito);
            ViewBag.Suspeitos = suspeitos;

            var armaSvc = new ArmaService();
            SelectList armas = new SelectList(armaSvc.GetArmas(), "key", "value", arma);
            ViewBag.Armas = armas;

            var localSvc = new LocalService();
            SelectList locais = new SelectList(localSvc.GetLocais(), "key", "value", arma);
            ViewBag.Locais = locais;
        }

    }
}