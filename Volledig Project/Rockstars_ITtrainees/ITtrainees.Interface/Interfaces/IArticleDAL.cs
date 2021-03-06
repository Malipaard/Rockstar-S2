﻿using ITtrainees.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITtrainees.Interface.Interfaces
{
    public interface IArticleDAL
    {
        public List<Article> GetAll();
        public List<ArticleCard> GetAllCards();
        public Article GetArticle(int id);
        public ArticleCard GetCard(int id);
        public void DeleteArticle(int id);
        public void Create(Article article);
        public void Update(Article article);
        public int GetArticleId(string author);
    }
}
