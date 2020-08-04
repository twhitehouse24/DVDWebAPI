using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDWebApi.EF;
using DVDWebApi.Models;

namespace DVDWebApi
{
    public class DvdRepositoryEF : IDvdRepository
    {
        public void Add(Dvd dvd)
        {
            var repository = new DvdLibraryEF();
            var newdvd = repository.Dvds.Add(
                new Dvd
                {
                    director = dvd.director,
                    notes = dvd.notes,
                    releaseYear = dvd.releaseYear,
                    rating = dvd.rating,
                    title = dvd.title
                });
            repository.SaveChanges();
        }

        public void Delete(int DvdId)
        {
            var repository = new DvdLibraryEF();
            var dvdList = repository.Dvds.Find(DvdId);

            if (dvdList != null)
            {
                Dvd deleted = new Dvd
                {
                    dvdId = dvdList.dvdId,
                    director = dvdList.director,
                    notes = dvdList.notes,
                    releaseYear = dvdList.releaseYear,
                    rating = dvdList.rating,
                    title = dvdList.title
                };
                repository.Dvds.Remove(dvdList);
                repository.SaveChanges();
            }
        }

        public void Edit(Dvd dvd)
        {
            var repository = new DvdLibraryEF();
            var dvdList = repository.Dvds.FirstOrDefault(d => d.dvdId == dvd.dvdId);

            if (dvdList != null)
            {
                dvdList.dvdId = dvd.dvdId;
                dvdList.director = dvd.director;
                dvdList.notes = dvd.notes;
                dvdList.releaseYear = dvd.releaseYear;
                dvdList.rating = dvd.rating;
                dvdList.title = dvd.title;
            }
            repository.SaveChanges();
        }


        public Dvd Get(int DvdId)
        {
            var repository = new DvdLibraryEF();
            var dvdList = repository.Dvds.Find(DvdId);
            Dvd returnDvd = new Dvd();

            if (dvdList != null)
            {
                returnDvd.dvdId = dvdList.dvdId;
                returnDvd.director = dvdList.director;
                returnDvd.notes = dvdList.notes;
                returnDvd.releaseYear = dvdList.releaseYear;
                returnDvd.rating = dvdList.rating;
                returnDvd.title = dvdList.title;
                return returnDvd;
            }
            else
                return null;
        }



        public List<Dvd> GetAll()
        {
            var repository = new DvdLibraryEF();
            List<Dvd> returnList = new List<Dvd>();
            var dvdList = repository.Dvds.ToList();

            foreach (Dvd d in dvdList)
            {
                returnList.Add(
                    new Dvd
                    {
                        dvdId = d.dvdId,
                        director = d.director,
                        notes = d.notes,
                        releaseYear = d.releaseYear,
                        rating = d.rating,
                        title = d.title
                    });

                        };

            return returnList;
        }

        public List<Dvd> GetByDirector(string director)
        {
            var repository = new DvdLibraryEF();
            List<Dvd> returnList = new List<Dvd>();
            var dvdList =  repository.Dvds.ToList()  ;

            foreach (Dvd d in dvdList)
            {
                if (d.director.Contains(director))
                {
                    returnList.Add(
                        new Dvd
                        {
                            dvdId = d.dvdId,
                            director = d.director,
                            notes = d.notes,
                            releaseYear = d.releaseYear,
                            rating = d.rating,
                            title = d.title
                        });
                };
            };

            return returnList;

        }


        public List<Dvd> GetByRating(string rating)
        {
            var repository = new DvdLibraryEF();
            List<Dvd> returnList = new List<Dvd>();
            var dvdList = repository.Dvds.ToList();

            foreach (Dvd d in dvdList)
            {
                if (d.rating.Contains(rating))
                {
                    returnList.Add(
                        new Dvd
                        {
                            dvdId = d.dvdId,
                            director = d.director,
                            notes = d.notes,
                            releaseYear = d.releaseYear,
                            rating = d.rating,
                            title = d.title
                        });
                };
            };
            return returnList;
        }

        public List<Dvd> GetByTitle(string title)
        {
            var repository = new DvdLibraryEF();
            List<Dvd> returnList = new List<Dvd>();
            var dvdList = repository.Dvds.ToList();

            foreach (Dvd d in dvdList)
            {
                if (d.title.Contains(title))
                {
                    returnList.Add(
                        new Dvd
                        {
                            dvdId = d.dvdId,
                            director = d.director,
                            notes = d.notes,
                            releaseYear = d.releaseYear,
                            rating = d.rating,
                            title = d.title
                        });
                };
            };
            return returnList;
        }

        public List<Dvd> GetByYear(int releaseYear)
        {
            var repository = new DvdLibraryEF();
            List<Dvd> returnList = new List<Dvd>();
            var dvdList = repository.Dvds.ToList();

            foreach (Dvd d in dvdList)
            {
                if (d.releaseYear == releaseYear)
                {
                    returnList.Add(
                        new Dvd
                        {
                            dvdId = d.dvdId,
                            director = d.director,
                            notes = d.notes,
                            releaseYear = d.releaseYear,
                            rating = d.rating,
                            title = d.title
                        });
                };
            };
            return returnList;
        }
    }
}