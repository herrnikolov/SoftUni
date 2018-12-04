using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PetClinic.DataProcessor.Dto.Import;
using PetClinic.Models;

namespace PetClinic.DataProcessor
{
    using System;

    using PetClinic.Data;

    public class Deserializer
    {
        private const string FailureMessage = "Error: Invalid data.";
        private const string SuccessMessage = "Record {0} successfully imported.";
        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var deserializedAnimalAidsDto = JsonConvert.DeserializeObject<AnimalAidsDto[]>(jsonString);
            var validAnimalAids = new List<AnimalAid>();

            foreach (var animalAidsDto in deserializedAnimalAidsDto)
            {
                if (!IsValid(animalAidsDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool pictureExists = context.AnimalAids.Any(p => p.Name == animalAidsDto.Name) ||
                                     validAnimalAids.Any(p => p.Name == animalAidsDto.Name);

                if (pictureExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                var animalAid = new AnimalAid
                {
                    Name = animalAidsDto.Name,
                    Price = animalAidsDto.Price
                };

                validAnimalAids.Add(animalAid);
                sb.AppendLine(string.Format(SuccessMessage, animalAid.Name));
            }

            context.AnimalAids.AddRange(validAnimalAids);
            context.SaveChanges();

            var result = sb.ToString();
            return result;

            //throw new NotImplementedException();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            throw new NotImplementedException();
        }
    }
}
