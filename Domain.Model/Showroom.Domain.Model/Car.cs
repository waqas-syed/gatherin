using System;

namespace Gatherin.Domain.Model
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

        /// <summary>
        /// Update the car with new values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="company"></param>
        /// <param name="modelYear"></param>
        /// <param name="ownerEmail"></param>
        public void UpdateCar(string name, string company, string modelYear, string ownerEmail)
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
