using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Domain.Model
{
    public class Car
    {
        private string _id = Guid.NewGuid().ToString();

        public Car(string name, string company, string modelYear, string ownerEmail)
        {
            Name = name;
            Company = company;
            ModelYear = modelYear;
            OwnerEmail = ownerEmail;
        }

        public string Id { get { return _id; } }
        public string Name { get; private set; }
        public string Company { get; private set; }
        public string ModelYear { get; private set; }
        public string OwnerEmail { get; private set; }
    }
}
