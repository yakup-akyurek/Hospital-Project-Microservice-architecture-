﻿using AutoMapper;
using Hospital.Patient.Dtos.PatientAdultDtos;
using Hospital.Patient.Entites;
using Hospital.Patient.Settings;
using MongoDB.Driver;

namespace Hospital.Patient.Services.PatientAdultServices
{
    public class PatientAdultService : IPatientAdultServices
    {
        private readonly IMongoCollection<PatientAdult> _patientAdultCollection;
        private readonly IMapper _mapper;

        public PatientAdultService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _patientAdultCollection = database.GetCollection<PatientAdult>(_databaseSettings.PatientAdultCollectionName);
            _mapper = mapper;
        }

        public async Task CreatePatientAdultAsync(CreatePatientAdultDto createPatientAdultDto)
        {
            var value = _mapper.Map<PatientAdult>(createPatientAdultDto);
            await _patientAdultCollection.InsertOneAsync(value);
        }

        public async Task DeletePatientAdultAsync(string id)
        {
            await _patientAdultCollection.DeleteOneAsync(x => x.PatientAdultId == id);
        }

        public async Task<List<ResultPatientAdultDto>> GetAllPatientAsync()
        {
            var values = await _patientAdultCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultPatientAdultDto>>(values);
        }

        public async Task<GetByIdPatientAdultDto> GetByIdPatientAdultAsync(string id)
        {
            var value = await _patientAdultCollection.Find(x => x.PatientAdultId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdPatientAdultDto>(value);

        }

        public async Task UpdatePatientAdultAsync(UpdatePatientAdultDto updatePatientAdultDto)
        {
            var value = _mapper.Map<PatientAdult>(updatePatientAdultDto);
            await _patientAdultCollection.FindOneAndReplaceAsync(x => x.PatientAdultId == updatePatientAdultDto.PatientAdultId, value);


        }
    }
}
