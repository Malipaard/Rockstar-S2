using ITtrainees.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ITtrainees.DataAcces;

namespace ITtrainees.Factory
{
    public static class ArticleFactory
    {
        public static IArticleDAL GetArticleDAL()
        {
            return new ArticleDAL();
        }
    }
}
