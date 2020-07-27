using School_Indicators.BO;
using School_Indicators_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BLL
{
    public class CityService
    {
        public List<City> GetCities()
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<City> model = (from e in db.tblCities
                                               select new City
                                               {
                                                   Id = e.Id,
                                                   Name1 = e.Name1,
                                                   Name2 = e.Name2,
                                                   Name3 = e.Name3
                                               }).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
