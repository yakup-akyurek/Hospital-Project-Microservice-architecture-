﻿using AutoMapper;
using Hospital.Patient.Dtos.PatientChildDtos;
using Hospital.Patient.Entites;
using Hospital.Patient.Settings;
using MongoDB.Driver;

namespace Hospital.Patient.Services.PatientChildServices
{
    public class PatientChildService : IPatientChildServices
    {
        private readonly IMongoCollection<PatientChild> _patientChildCollection;
        private readonly IMapper _mapper;
        public PatientChildService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _patientChildCollection = database.GetCollection<PatientChild>(_databaseSettings.PatientChildCollectionName);
            _mapper = mapper;
        }

        public async Task CreatePatientChildAsync(CreatePatientChildDto createPatientChildDto)
        {
            var value = _mapper.Map<PatientChild>(createPatientChildDto);
            await _patientChildCollection.InsertOneAsync(value);
        }

        public async Task DeletePatientChildAsync(string id)
        {
            await _patientChildCollection.DeleteOneAsync(x => x.PatientChildId == id);
        }

        public async Task<List<ResultPatientChildDto>> GetAllPatientAsync()
        {
            var values= await _patientChildCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultPatientChildDto>>(values);
        }

        public async Task<GetByIdPatientChildDto> GetByIdPatientChildAsync(string id)
        {
            var values = await _patientChildCollection.Find(x => x.PatientChildId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdPatientChildDto>(values);
        }

        public async Task UpdatePatientChildAsync(UpdatePatientChildDto updatePatientChildDto)
        {
            var values = _mapper.Map<PatientChild>(updatePatientChildDto);
            await _patientChildCollection.FindOneAndReplaceAsync(x => x.PatientChildId == updatePatientChildDto.PatientChildId, values);
        }
    }
}
