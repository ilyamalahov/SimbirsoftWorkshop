using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimbirsoftWorkshop.WebApi.Entities;
using SimbirsoftWorkshop.WebApi.Models;

namespace SimbirsoftWorkshop.WebApi.Extensions
{
    public static class EntityExtensions
    {
        public static string GetFullName(this Person person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            return string.Join(" ", person.LastName, person.FirstName, person.MiddleName);
        }

        public static string GetFullName(this DeletePeopleByFullNameModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return string.Join(" ", model.LastName, model.FirstName, model.MiddleName);
        }
    }
}
