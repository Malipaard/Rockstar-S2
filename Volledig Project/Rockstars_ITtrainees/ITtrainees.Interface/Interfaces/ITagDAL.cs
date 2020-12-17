using System;
using System.Collections.Generic;
using System.Text;

namespace ITtrainees.Interface.Interfaces
{
    public interface ITagDAL
    {
        public void Create(Models.Tag tag);
        public Models.Tag Get(int id);
        public List<Models.Tag> GetAll();
        public void Delete(int id);
    }
}
