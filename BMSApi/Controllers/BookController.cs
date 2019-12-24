using BMSEntity;
using BMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BMSApi.Controllers
{
    [RoutePrefix("api/Book")]
    public class BookController : ApiController
    {
        BookRepository repo = new BookRepository();
        private BMSDBContext context = new BMSDBContext();

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Book> list = repo.GetAll();

            if(list!=null)
                return Ok(list);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }
    

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Book bk = repo.Get(id);

            if (bk != null)
                return Ok(bk);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [BasicAuthentication]
        public IHttpActionResult Post(Book bk)
        {                 
            repo.Insert(bk);

            return Created("",bk);
        }

        [BasicAuthentication]
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Put(Book bk, int id)
        {
            Book book = repo.Update(bk, id);

            if (book != null)
                return Ok(book);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [BasicAuthentication]
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        [Route("search/{name}")]
        [HttpGet]
        public IHttpActionResult Search(string name)
        {
            List<Book> list = repo.BookSearch(name);

            if (list != null)
                return Ok(list);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("category/{name}")]
        [HttpGet]
        public IHttpActionResult ListByCategory(string name)
        {
            List<Book> list = repo.GetCategory(name);

            if (list != null)
                return Ok(list);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("uniqueCategory")]
        [HttpGet]
        public IHttpActionResult UniqueCategory()
        {
            List<string> list = repo.DistinctCategoryString();

            if (list != null)
                return Ok(list);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        //[Route("{bookId}/{str}")]
        //public IHttpActionResult GetRating(double str, int bookId)
        //{
        //    return Ok(repo.rating(str,bookId));
        //}
    }
}
