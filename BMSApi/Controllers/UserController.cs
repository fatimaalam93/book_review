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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        BMSDBContext context = new BMSDBContext();
        UserRepository repo = new UserRepository();

        [BasicAuthentication]
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<User> list = repo.GetAll();

            if (list != null)
                return Ok(list);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [BasicAuthentication]
        [HttpPost]
        public IHttpActionResult Post(User bk)
        {
            repo.Insert(bk);
            return Created("", bk);
        }

        [BasicAuthentication]
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Put(User bk, int id)
        {
            User user = repo.Update(bk, id);

            if (user != null)
                return Ok(user);
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

        [BasicAuthentication]
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            User usr = repo.Get(id);

            if (usr != null)
                return Ok(usr);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [BasicAuthentication]
        [Route("name/{name}")]
        [HttpGet]
        public IHttpActionResult GetName(string name)
        {
            User usr = repo.GetName(name);

            if (usr != null)
                return Ok(usr);
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [BasicAuthentication]
        [Route("logincheck")]
        [HttpPost]
        public IHttpActionResult GetEmailNdPass(string email, string password)
        {
            bool usr = repo.GetEmailNdPass(email, password);

            if (usr)
                return Ok();
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("duplicateMail")]
        [HttpGet]
        public IHttpActionResult GetDuplicateEmail(string email)
        {
            //List<User> usr = repo.DuplicateMail(us);
            bool exist = repo.DuplicateMail(email);

            if (exist)
                return Ok();
            else
                return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

    

