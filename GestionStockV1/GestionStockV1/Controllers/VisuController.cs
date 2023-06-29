using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionStockV1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using X.PagedList;

namespace GestionStockV1.Controllers
{


    public class VisuController : Controller
    {
        static List<Article> articles = new List<Article>();
        static List<Article> articlewanted = new List<Article>();
        static List<Article> articleseen = new List<Article>();
        static int cmp;
        static int offset;
        static int enablesn=0;


        public IActionResult Accueil()
        {
            return View();
        }

        //LISTE***************************
        public IActionResult Liste(int? page)
        {
            enablesn = 0;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(articles.ToPagedList(pageNumber, pageSize));
        }

        //EDIT*************************
        public IActionResult Edit(int num)
        {

            var change = articles.Where(s => s.ArticleId == num).FirstOrDefault();

            return View(change);

        }
        [HttpPost]
        public IActionResult Edit(Article nouv)
        {
            Article last = articles.Where(s => s.ArticleId == nouv.ArticleId).FirstOrDefault();
            last.ArticleName = nouv.ArticleName;
            last.ArticleDescription = nouv.ArticleDescription;
            last.ArticleSeuilSecurite = nouv.ArticleSeuilSecurite;
            return RedirectToAction("Liste");
        }


        //SUPPRIME***********************

        [Route("Visu/Supprime/{nums?}")]
        public IActionResult Supprime(int nums)
        {
            var supp = articles.Where(s => s.ArticleId == nums).FirstOrDefault();
            articles.Remove(supp);
            return RedirectToAction("Liste");
        }


        //preCREATE*************************** 
        [Route("Visu/preCreate")]
        public IActionResult preCreate()
        {
            return View();
        }


        //CREATE*************************** 
        [Route("Visu/Create/{nbr?}")]
        public IActionResult Create(int nbr)
        {

            for (int i = 0; i < nbr + offset; i++)
            {
                Article toto = new Article();
                toto.ArticleId = cmp;
                toto.ArticleName = "article " + cmp;
                toto.ArticleDescription = "description " + cmp;
                articles.Add(toto);
                cmp += 1;
            }
            offset = 0;
            return RedirectToAction("Liste");
        }




        //SEARCH_id*************************************
        /*[Route("Search_id/{wanted_id?}")]
        public IActionResult Search_id(int wanted_id, int? page)
        {
            articlewanted.Clear();
            var wanted = articles.Where(s => s.ArticleId == wanted_id).FirstOrDefault();
            if (wanted != null)
            {
                articlewanted.Add(wanted);
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(articlewanted.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("ErreurSearch");
            }

        }*/
        //ErreurSearch***************************
        public IActionResult ErreurSearch()
        {

            return View();

        }
        //ADD5*****************************
        public IActionResult Add5()
        {
            offset = offset + 5;
            return RedirectToAction("preCreate");

        }


        //SUB5*****************************
        public IActionResult Sub5()
        {
            offset = offset - 5;
            return RedirectToAction("preCreate");

        }


        //SEARCH_nom*************************************
        [Route("Search_nom/{wanted_nom?}")]
        public IActionResult Search_nom(string wanted_nom,int? page)
        {
            if (enablesn == 0)
            {
                articlewanted.Clear();
                foreach (Article wanted in articles)
                {

                    if ((wanted.ArticleName.Contains(wanted_nom))|(wanted.ArticleId.ToString().Contains(wanted_nom)))
                    {
                        Article wanted2 = wanted;
                        articlewanted.Add(wanted2);
                    }
                }
                
                if (articlewanted != null)
                {
                    enablesn = 1;
                    int pageSize = 5;
                    int pageNumber = (page ?? 1);
                    return View(articlewanted.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return RedirectToAction("ErreurSearch");
                }
            }
            
            else
            {

                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(articlewanted.ToPagedList(pageNumber, pageSize));
            }
        }


    }
}





