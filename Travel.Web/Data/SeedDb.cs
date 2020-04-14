using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Web.Data.Entities;

namespace Travel.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckTravelsAsync();
        }

        private async Task CheckTravelsAsync()
        {

            if (_dataContext.Travels.Any())
            {
                return;

            }




            _dataContext.Travels.Add(new TravelEntity
            {
                Name = "Margarita",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                City = "Londres",
                Expenses = new List<ExpenseEntity>
                {
                    new ExpenseEntity
                    {
                        Value = 300

                    }
                },
                User = new UserEntity
                {

                    Document = "454545",
                    FirstName = "Maria",
                    LastName = "Molina"
                }

            });


            await _dataContext.SaveChangesAsync();

        }
    }
}
