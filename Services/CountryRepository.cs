using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReview.Models;

namespace BookReview.Services
{
    public class CountryRepository : ICountryRepository
    {
        private BookDbContext _context;
        public CountryRepository(BookDbContext context)
        {
            _context = context;
        }

        public bool CountryExist(int countryId)
        {
            return _context.Countries.Any(c => c.CountryId == countryId);
        }

        public bool CreateCountry(Country country)
        {
           
            _context.Countries.Add(country);
            return save(country);
        }

        public bool DeleteCountry(Country country)
        {
            _context.Countries.Remove(country);
            return save(country);
        }

        public ICollection<Author> GetAuthorsFromCountry(int countryId)
        {
            return _context.Authors.Where(c => c.Country.CountryId == countryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(c => c.Name).ToList();
        }

        public Country GetCountry(int countryId)
        {
            return _context.Countries.Where(c => c.CountryId == countryId).FirstOrDefault();

        }

        public Country GetCountryOfAuthor(int AuthorId)
        {
            return _context.Authors.Where(c => c.AuthorId == AuthorId)
                .Select(c => c.Country).FirstOrDefault();

        }

        public bool save(Country country)
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return save(country);
        }
    }
}
