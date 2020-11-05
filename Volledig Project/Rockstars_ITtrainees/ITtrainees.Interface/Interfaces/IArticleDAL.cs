using ITtrainees.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITtrainees.Interface.Interfaces
{
    public interface IArticleDAL
    {
        public List<Article> GetAll();
        public void DeleteArticle(int id);
        public void Create(Article article);
    }
}
