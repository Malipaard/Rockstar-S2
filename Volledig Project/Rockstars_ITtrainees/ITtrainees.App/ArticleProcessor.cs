using System;
using System.Collections.Generic;
using System.Text;
using ITtrainees.Models;

namespace ITtrainees.Logic
{
    public static class ArticleProcessor
    {
        //class is volledig tijdelijk

        static List<Article> ArticleStorage = new List<Article>() { 
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

        public static Article Get(string title)
        {
            for (var i = 0; i < ArticleStorage.Count; i++)
            {
                Article article = ArticleStorage[i];
                if (article.Title == title)
                {
                    return article;
                }
            }
            return null;
        }

        public static List<Article> GetAll()
        {
            return ArticleStorage;
        }
    }
}
