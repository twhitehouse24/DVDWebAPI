using System;
using System.Collections.Generic;
using System.Data.Entity;
using DVDWebApi.EF;
using DVDWebApi.Models;

namespace DVDWebApi.EF
{
    public class DvdLibraryEF : DbContext
    {
        public DvdLibraryEF() : base("DvdLibraryEF")
        {
            Database.SetInitializer<DvdLibraryEF>(new CreateDatabaseIfNotExists<DvdLibraryEF>());
        }

        public DbSet<Dvd> Dvds { get; set; }
    }
}