using e_Clinic.DataAccess.Db;
using e_Clinic.DataAccess.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace e_Clinic.DataAccess
{
    public class SeedData
    {
        public static async Task SeedAsync(ApplicationContext context, ILogger<ApplicationContext> logger)
        {
            var patients = new List<Patient>
            {
                new()
                {
                    FirstName = "Kristian", LastName = "Iversen", DateOfBirth = new DateTime(1984, 6, 29),
                    Visits = new List<Visit>
                    {
                        new()
                        {
                            Description =
                                "The patient complained of a sharp, stabbing pain in the lower abdomen that had been worsening over the last two days.",
                            DateTime = new DateTime(2023, 09, 12, 12, 15, 00)
                        },
                        new()
                        {
                            Description =
                                "The patient reported having a fever, sore throat, and body aches for the past 48 hours",
                            DateTime = new DateTime(2023, 10, 15, 13, 00, 00)
                        },
                    },
                },
                new()
                {
                    FirstName = "Anna", LastName = "Larsen", DateOfBirth = new DateTime(1966, 11, 21),
                    Visits = new List<Visit>
                    {
                        new()
                        {
                            Description =
                                "The patient's right eye exhibited redness, itchiness, and excessive watering for about a week.",
                            DateTime = new DateTime(2023, 09, 12, 12, 15, 00)
                        },
                        new()
                        {
                            Description =
                                "The patient expressed concerns about a persistent, unexplained rash on their arms and legs.",
                            DateTime = new DateTime(2023, 08, 12, 11, 00, 00)
                        },
                        new()
                        {
                            Description =
                                "The patient conveyed worries about recurring stomach pain, which seemed to worsen after meals.",
                            DateTime = new DateTime(2023, 07, 12, 11, 00, 00)
                        },
                        new()
                        {
                            Description =
                                "The patient complained of a constant, throbbing pain in their lower back that had been bothering them for the past month.",
                            DateTime = new DateTime(2022, 02, 14, 10, 45, 00)
                        },
                    },
                },
                new()
                {
                    FirstName = "Sven", LastName = "Andersen", DateOfBirth = new DateTime(1975, 10, 30),
                },
                new()
                {
                    FirstName = "Elin", LastName = "Nygaard", DateOfBirth = new DateTime(1991, 7, 2),
                },
            };


            try
            {
                if (!context.Patients.Any() && !context.Visits.Any())
                {
                    foreach (var patient in patients)
                    {
                        context.Patients.Add(patient);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}