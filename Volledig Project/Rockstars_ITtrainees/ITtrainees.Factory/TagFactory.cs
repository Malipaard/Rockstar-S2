using ITtrainees.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ITtrainees.DataAcces;

namespace ITtrainees.Factory
{
    public static class TagFactory
    {
        public static ITagDAL GetTagDAL()
        {
            return new TagDAL();
        }
    }
}
