using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace PetClinic.DataProcessor
{
    using System;

    using PetClinic.Data;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals;



            var result = JsonConvert.SerializeObject(animals, Formatting.Indented);

            return result;
            //throw new NotImplementedException();
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            throw new NotImplementedException();
        }
    }
}
