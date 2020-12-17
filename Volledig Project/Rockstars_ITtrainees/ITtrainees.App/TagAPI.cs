using Microsoft.AspNetCore.Mvc;
using ITtrainees.Models;
using ITtrainees.Interface.Interfaces;
using ITtrainees.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITtrainees.Logic
{
    [Route("api/tag")]
    [ApiController]
    public class TagAPI : ControllerBase
    {
        //api/tag
        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            ITagDAL dal = TagFactory.GetTagDAL();
            dal.Create(tag);
            return Accepted();
        }

        //api/tag/{id}
        [HttpGet("{id:int:min(1)}")]
        public Tag Get(int id)
        {
            try
            {
                ITagDAL dal = TagFactory.GetTagDAL();
                var tag = dal.Get(id);
                return tag;
            }
            catch
            {
                return null;
            }
        }

        //api/tag
        [HttpGet]
        public IEnumerable<Tag> GetAll()
        {
            ITagDAL dal = TagFactory.GetTagDAL();
            List<Tag> tags = dal.GetAll();
            return tags;
        }

        //api/tag/{id}
        [HttpDelete("{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            ITagDAL dal = TagFactory.GetTagDAL();
            dal.Delete(id);
            return Accepted();
        }
    }
}
