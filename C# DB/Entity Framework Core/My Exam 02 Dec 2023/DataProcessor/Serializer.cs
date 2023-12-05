using System.Globalization;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ExportDtos;
using Medicines.Utilities;
using Newtonsoft.Json;

namespace Medicines.DataProcessor
{
    using Medicines.Data;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            XmlHelper xmlHelper = new XmlHelper();

            DateTime dateToCompare = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            ExportPatientDto[] patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(m => m.Medicine.ProductionDate > dateToCompare))
                .Select(p => new ExportPatientDto()
                {
                    Gender = p.Gender.ToString().ToLower(),
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Medicines = p.PatientsMedicines
                        .Where(m => m.Medicine.ProductionDate > dateToCompare)
                        .OrderByDescending(pm => pm.Medicine.ExpiryDate)
                        .ThenBy(pm => pm.Medicine.Price)
                        .Select(pm => new ExportMedicineDto()
                        {
                            Category = pm.Medicine.Category.ToString().ToLower(),
                            Name = pm.Medicine.Name,
                            Price = pm.Medicine.Price.ToString("f2"),
                            Producer = pm.Medicine.Producer,
                            BestBefore = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd",CultureInfo.InvariantCulture)

                        })
                        .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.Name)
                .ToArray();

            return xmlHelper.Serialize(patients, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .ToArray()
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Where(m => m.Pharmacy.IsNonStop && (int)m.Category == medicineCategory)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price.ToString("f2"),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .ToArray();

            return JsonConvert.SerializeObject(medicines, Formatting.Indented);
        }
    }
}
