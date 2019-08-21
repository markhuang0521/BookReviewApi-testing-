using BookReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Services
{
   public  interface ICountryRepository
    {
        //get methods
        ICollection<Country> GetCountries();
        Country GetCountry(int countryId);
        Country GetCountryOfAuthor(int AuthorId);

        ICollection<Author> GetAuthorsFromCountry(int countryId);
        bool CountryExist(int countryId);

        //post methods

        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        bool save(Country country);

    }
}
