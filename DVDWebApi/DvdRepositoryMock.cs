using DVDWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DVDWebApi
{
    public class DvdRepositoryMock : IDvdRepository
    {

        //public int DvdId { get; set; }
        //public string Title { get; set; }

        private static List<Dvd> _dvds = new List<Dvd>
        {
            new Dvd
            { dvdId = 0,
              title = "Movie 1", 
              releaseYear = 2015,  
              director = "Bau Regard",
              rating = "PG",
              notes = "Great flick"},

            new Dvd
            { dvdId = 1,
              title = "Movie 1",
              releaseYear = 2010,
              director = "Tom Wells",
              rating = "PG",
              notes = "Sick flick"},

            new Dvd
            { dvdId = 2,
              title = "Movie 3",
              releaseYear = 2015,
              director = "Tom Wells",
              rating = "R",
              notes = "Scary flick"}
        };

        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd Get(int DvdId)
        {
            return _dvds.FirstOrDefault(m => m.dvdId == DvdId);
        }
        public void Add(Dvd dvd)
        {
            dvd.dvdId = _dvds.Max(m => m.dvdId) + 1;
            _dvds.Add(dvd);
        }
        public void Edit(Dvd dvd)
        {
            var found = _dvds.FirstOrDefault(m => m.dvdId == dvd.dvdId);

            if (found != null)
                found = dvd;
        }
        public void Delete(int DvdId)
        {
            _dvds.RemoveAll(m => m.dvdId == DvdId);
        }



        public List<Dvd> GetByTitle(string title)
        {
            List<Dvd> list = _dvds.FindAll(m => m.title == title);
            return list;

        }


        public List<Dvd> GetByYear(int realeaseYear)
        {
            List<Dvd> list =  _dvds.FindAll(m => m.releaseYear == realeaseYear);

            return list;
        }
        public List<Dvd> GetByDirector(string directorName)
        {

            List<Dvd> list = _dvds.FindAll(m => m.director == directorName);
            return list;
        }

        public List<Dvd> GetByRating(string rating)
        {
            List<Dvd> list = _dvds.FindAll(m => m.rating == rating);
            return list;
        }
    }
}