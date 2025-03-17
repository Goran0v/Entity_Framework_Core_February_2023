using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Common
{
    public static class ValidationConstants
    {
        //Truck
        public const int RegistrationNumberLength = 8;
        public const int VinNumberLength = 17;
        public const string RegistrationNumberRegex = @"[A-Z]{2}\d{4}[A-Z]{2}";
        public const int TankCapacityMinValue = 950;
        public const int TankCapacityMaxValue = 1420;
        public const int CargoCapacityMinValue = 5000;
        public const int CargoCapacityMaxValue = 29000;
        public const int CategoryTypeMinValue = 0;
        public const int CategoryTypeMaxValue = 3;
        public const int MakeTypeMinValue = 0;
        public const int MakeTypeMaxValue = 4;


        //Client
        public const int ClientNameMinLength = 3;
        public const int ClientNameMaxLength = 40;
        public const int ClientNationalityMinLength = 2;
        public const int ClientNationalityMaxLength = 40;

        //Despatcher
        public const int DespatcherNameMaxLength = 40;
        public const int DespatcherNameMinLength = 2;
    }
}
