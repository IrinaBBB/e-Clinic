﻿using AutoMapper;
using e_Clinic.DataAccess;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.ViewModels.Patient;
using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace e_Clinic.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientRepository(ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager) : base(db, userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        public void Update(Patient patient)
        {
            var patientFromDb = _db.Patients.FirstOrDefault(p => p.Id == patient.Id);
            if (patientFromDb != null)
            {
                _mapper.Map(patient, patientFromDb);
            }
        }
    }
}
