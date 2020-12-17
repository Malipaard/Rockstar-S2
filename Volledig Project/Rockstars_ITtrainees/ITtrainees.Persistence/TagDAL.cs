using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITtrainees.Interface.Interfaces;

namespace ITtrainees.DataAcces
{
    public class TagDAL : ITagDAL
    {
        public void Create(Models.Tag tag)
        {
            using (var context = new ArticlesContext())
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }

        public Models.Tag Get(int id)
        {
            using (var context = new ArticlesContext())
            {
                var tag = context.Tags.Single(a => a.TagId == id);
                return tag;
            }
        }

        public List<Models.Tag> GetAll()
        {
            using (var context = new ArticlesContext())
            {
                var tags = context.Tags.ToList();
                return tags;
            }
        }

        public void Delete(int id)
        {
            using (var context = new ArticlesContext())
            {
                try { 
                var tag = context.Tags.Single(a => a.TagId == id);
                context.Tags.Attach(tag);
                context.Tags.Remove(tag);
                context.SaveChanges();
                }
                catch
                {
                    return;
                }
            }    
        }
    }
}
