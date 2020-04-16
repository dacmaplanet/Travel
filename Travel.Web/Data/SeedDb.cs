
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.common.Enums;
using Travel.Web.Data.Entities;
using Travel.Web.Helpers;

namespace Travel.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext dataContext,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Danny", "Castro", "dannyalexandercastromacias@gmail.com", "300207483", UserType.Admin);
            var employee1 = await CheckUserAsync("1010", "Danny", "Castro", "dacmasolutions@gmail.com", "300207483", UserType.Employee);
            var employee2 = await CheckUserAsync("3030", "Danny", "Castro", "dannycastro42459@correo.itm.edu.co", "300207483", UserType.Employee);
            await CheckTravelsAsync(employee1, employee2);
        }

        private async Task<UserEntity> CheckUserAsync(
           string document,
           string firstName,
           string lastName,
           string email,
           string phone,
           UserType userType
           )
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,                  
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    UserType = userType


                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }



        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Employee.ToString());
        }

        private async Task CheckTravelsAsync(
            UserEntity employee1,
            UserEntity employee2)
        {
            if (!_dataContext.Travels.Any())
            {
                _dataContext.Travels.Add(new TravelEntity
                {

                    Name = "Visita catedral",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    City = "Londres",
                    Expenses = new List<ExpenseEntity>
                     {
                    new ExpenseEntity
                    {
                        Value = 300

                    }
                    }
                });
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
