using DVDWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Configuration;

namespace DVDWebApi.Controllers
{
    public class DvdController : ApiController
    {
        private static IDvdRepository _dvdRepository = DvdFactory.GetRepo();


        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvds/all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(_dvdRepository.GetAll());
        }

        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvd/{DvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int DvdId)
        {

            Dvd flick = _dvdRepository.Get(DvdId);

            if (flick == null)
            {
                return Ok("Out of Stock, try again later");
            }
            return Ok(flick);
        }

        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(AddDvd model)
        {

            Dvd flick = new Dvd();


            flick.title = model.title;
            flick.rating = model.rating;
            flick.director = model.director;
            flick.releaseYear = model.releaseYear;
            flick.notes = model.notes;

            _dvdRepository.Add(flick);


            return Ok(flick);
        }

        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvd/{dvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(EditDvd model)
        {
            Dvd flick = _dvdRepository.Get(model.dvdId);
            if (ModelState.IsValid)
            {

                flick.dvdId = model.dvdId;
                flick.title = model.title;
                flick.rating = model.rating;
                flick.director = model.director;
                flick.releaseYear = model.releaseYear;

                _dvdRepository.Edit(flick);

                return Ok(flick);
            }
            else {
                return Ok("New Dvd Added");
                 };

        }

        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvd/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {

            List<Dvd> flick = _dvdRepository.GetByTitle(title);

            if (flick == null)
            {
                return Ok("Out of Stock, try again later");
            }
            return Ok(flick);
        }

        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvd/year/{realeaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByYear(int realeaseYear)
        {

            List<Dvd> flick = _dvdRepository.GetByYear(realeaseYear);

            if (flick == null)
            {
                return Ok("Out of Stock, try again later");
            }
            return Ok(flick);
        }

        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvd/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string directorName)
        {

            List<Dvd> flick = _dvdRepository.GetByDirector(directorName);

            if (flick == null)
            {
                return Ok("Out of Stock, try again later");
            }
            return Ok(flick);
        }

        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvd/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {

            List<Dvd> flick = _dvdRepository.GetByRating(rating);

            if (flick == null)
            {
                return Ok("Out of Stock, try again later");
            }
            return Ok(flick);
        }


        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int DvdId)
        {
            _dvdRepository.Delete(DvdId);
            return Ok(_dvdRepository.GetAll());
        }

    }
}