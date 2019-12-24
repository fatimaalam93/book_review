using BMSEntity;
using BMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BMSApi.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/UserBook")]
    public class UserBookController : ApiController
    {
        UserBookRepository repo = new UserBookRepository();

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<UserBook> list = repo.GetAll();

            if (list != null)
                return Ok(list);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }


        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            UserBook bk = repo.Get(id);

            if (bk != null)
                return Ok(bk);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("AverageRating/{id}")]
        [HttpGet]
        public IHttpActionResult GetAverageRating(int id)
        {
            double rating = repo.GetAverageRating(id);

            return Ok(rating);
        }

        [Route("AverageRatingForUser/{id}")]
        [HttpGet]
        public IHttpActionResult GetAverageRatingForUser(int id)
        {
            double rating = repo.GetAverageRatingForUser(id);

            return Ok(rating);
        }

        //for user
        [Route("BookCount/{id}")]
        [HttpGet]
        public IHttpActionResult GetBookCount(int id)
        {
            int count = repo.GetBookCount(id);

            return Ok(count);
        }

        [Route("UserAndBookId/{uid}/{bid}")]
        [HttpGet]
        public IHttpActionResult GetUserAndBookId(int uid, int bid)
        {
            UserBook us = repo.GetUserAndBookId(uid, bid);

            if (us != null)
                return Ok(us);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("UserBookList/{uid}/{status}")]
        [HttpGet]
        public IHttpActionResult GetUserBookList(int uid, int status)
        {
            List<Book> us = repo.GetUserBookList(uid, status);

            if (us != null)
                return Ok(us);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Post(UserBook us)
        {
            repo.Insert(us);

            return Created("", us);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Put(UserBook us, int id)
        {
            UserBook book = repo.Update(us, id);

            if (book != null)
                return Ok(book);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
