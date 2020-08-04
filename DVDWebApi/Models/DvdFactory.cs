using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDWebApi.Models
{
    public class DvdFactory
    {
        public static IDvdRepository GetRepo()
        {

            switch (Settings.GetRepositoryType())
            {
                case "Mock":
                    return new DvdRepositoryMock();
                case "ADO":
                    return new DvdRepositoryADO();
                case "EF":
                    return new DvdRepositoryEF();
                default:
                    throw new Exception("Not a valid Repo type");
            }

        }

    }
}