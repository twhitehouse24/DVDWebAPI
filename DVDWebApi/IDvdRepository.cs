using DVDWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDWebApi
{
        public interface IDvdRepository
        { 
            List<Dvd> GetAll();
            Dvd Get(int DvdId);
            void Add(Dvd dvd);
            void Edit(Dvd dvd);
            void Delete(int DvdId);
            List<Dvd> GetByTitle(string title);
            List<Dvd> GetByYear(int releaseYear);
            List<Dvd> GetByDirector(string directorName);
            List<Dvd> GetByRating(string rating);

    }
}