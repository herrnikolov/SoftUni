using System.Linq;

namespace PetClinic.DataProcessor
{
    using System;

    using PetClinic.Data;

    public class Bonus
    {
        public static string UpdateVetProfession(PetClinicContext context, string phoneNumber, string newProfession)
        {
            var vetToUpdate = context.Vets.FirstOrDefault(i => i.PhoneNumber == phoneNumber);

            var result = string.Empty;

            if (vetToUpdate== null)
            {
                result = $"Vet with phone number {phoneNumber} not found!";
            }
            else
            {
                var oldVetPos = vetToUpdate.Profession;

                var oldProfession = vetToUpdate.Profession;

                vetToUpdate.Profession = newProfession;
                context.SaveChanges();

                result = $"{vetToUpdate.Name}'s profession updated from {oldProfession} to {newProfession}.";
            }

            return result;
            throw new NotImplementedException();
        }
    }
}
