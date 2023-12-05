using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ImportDtos;
using Medicines.Utilities;
using Newtonsoft.Json;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPatientDto[] patientDtos = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);

            ICollection<Patient> validPatients = new HashSet<Patient>();
            foreach (var patientDto in patientDtos)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender
                };

                ICollection<PatientMedicine> validPatientMedicine = new HashSet<PatientMedicine>();
                List<int> patientMedicationIds = new List<int>();

                foreach (var medicineId in patientDto.Medicines)
                {
                    if (patientMedicationIds.Contains(medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine pm = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = medicineId
                    };
                    validPatientMedicine.Add(pm);
                    patientMedicationIds.Add(medicineId);
                }

                patient.PatientsMedicines = validPatientMedicine;
                validPatients.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient,patient.FullName, patient.PatientsMedicines.Count));

            }

            context.Patients.AddRange(validPatients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ImportPharmacyDto[] pharmacyDtos = xmlHelper.Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            ICollection<Pharmacy> validPharmacies = new HashSet<Pharmacy>();
            foreach (var pharmacyDto in pharmacyDtos)
            {
                if (!IsValid(pharmacyDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                //if (pharmacyDto.Name.Length > 50 || pharmacyDto.Name.Length < 2)
                //{
                //    sb.AppendLine(ErrorMessage);
                //    continue;
                //}
                //
                //if (pharmacyDto.PhoneNumber.Length > 14 || pharmacyDto.PhoneNumber.Length < 14)
                //{
                //    sb.AppendLine(ErrorMessage);
                //    continue;
                //}

                if (pharmacyDto.IsNonStop != "true" && pharmacyDto.IsNonStop != "false") // check how this works
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy()
                {
                    Name = pharmacyDto.Name,
                    IsNonStop = Convert.ToBoolean(pharmacyDto.IsNonStop),
                    PhoneNumber = pharmacyDto.PhoneNumber
                };

                ICollection<Medicine> validMedicines = new HashSet<Medicine>();
                foreach (var medicineDto in pharmacyDto.Medicines)
                {
                    if (!IsValid(medicineDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime productionDate = DateTime.ParseExact(medicineDto.ProductionDate, "yyyy-MM-dd",
                        CultureInfo.InvariantCulture);
                    DateTime expiryDate = DateTime.ParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture);

                    if (productionDate >= expiryDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (validMedicines.Any(m => m.Producer == medicineDto.Producer && m.Name == medicineDto.Name))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine medicine = new Medicine()
                    {
                        Category = (Category)medicineDto.Category,
                        Name = medicineDto.Name,
                        Price = medicineDto.Price,
                        ProductionDate = productionDate,
                        ExpiryDate = expiryDate,
                        Producer = medicineDto.Producer
                    };

                    validMedicines.Add(medicine);

                }

                pharmacy.Medicines = validMedicines;
                validPharmacies.Add(pharmacy);

                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
