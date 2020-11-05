﻿using ITtrainees.Factory;
using ITtrainees.Interface.Interfaces;
using ITtrainees.Models;
using System.Collections.Generic;

namespace ITtrainees.Logic
{
    public static class ArticleProcessor
    {
        //class is volledig tijdelijk

        public static List<Article> ArticleStorage = new List<Article>() { 
            new Article (00,"Australian Scientists Discover 500-Meter-Tall Coral Reef in the Great Barrier Reef", "Ruud" ,
                "Scientists have discovered a massive detached coral reef in the Great Barrier Reef, measuring more than 500 meters high -- taller than the Empire ..."),
            new Article (01,"Geologists Simulate Soil Conditions to Help Grow Plants on Mars","Ruud",
                "Humankind's next giant step may be onto Mars. But before those missions can begin, scientists need to make scores of breakthrough advances, including learning how to grow crops on the red ..."),
            new Article (02,"Galaxies in the Infant Universe Were Surprisingly Mature","Ruud",
                "ALMA telescope conducts largest survey yet of distant galaxies in the early"),
            new Article (03,"Antarctica Yields Oldest Fossils of Giant Birds With 21-Foot Wingspans","Ruud",
                "Some of the largest birds in history, called pelagornithids, arose a few million years after the mass extinction that killed off the dinosaurs and patrolled the oceans with giant wingspans for some ..."),
            new Article (04,"Cosmic Rays May Soon Stymie Quantum Computing","Ruud",
                "Infinitesimally low levels of radiation, such as from incoming cosmic rays, may soon stymie progress in quantum ..."),
        };

        public static string Save(Article article)
        {
            ArticleStorage.Add(article);
            return $"Artikel \"{ article.Title }\" is opgeslagen!";
        }

        public static Article GetArticle(int id)
        {
            //return ArticleStorage[id];
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            var article = dal.GetArticle(id);
            return article;
        }

        public static List<Article> GetAll()
        {
            //return ArticleStorage;

            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            List<Article> articles = dal.GetAll();
            return articles;
        }

        public static void Delete(int id)
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            dal.DeleteArticle(id);
        }

        public static void Create()
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            Article article = new Article()
            {
                Title = "This is a title",
                Author = "This is an author",
                Summary = "This is a summary"
            };
            dal.Create(article);
        }
    }
}
