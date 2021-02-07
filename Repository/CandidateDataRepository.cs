using CandidatesPortal.Models;
using CandidatesPortal.Pattern;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesPortal.Repository
{
    public class CandidateDataRepository:ICandidateDataRepository
    {
        private readonly DataBaseContext _databaseContext;


        public CandidateDataRepository(DataBaseContext databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
           
        }

           public async Task<CandidateData> GetCandidateDatabyID(int id)
        =>  await _databaseContext.CandidateDatas.FindAsync(id);

        public async Task<List<CandidateData>> GetListOfCandidates() => await _databaseContext.CandidateDatas.ToListAsync().ConfigureAwait(false);

        public async Task<CandidateData> SaveCandidateData(CandidateData candidateData)
        {
            CandidateData candidateDataDefault = CreateDefaultEmptyCandidateData();
            if(candidateData is null)
            {
                return candidateDataDefault;
            }
            //Determine the next ID//+ 1
            var newID =  _databaseContext.CandidateDatas.Select(x => x.Id).Max()+1 ;
            candidateData.Id = newID;
           _databaseContext.CandidateDatas.Add(candidateData);
            int result=  await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            if (result.Equals(1))
            {
                return candidateData;
            }

             return candidateDataDefault;
        }


        private static CandidateData CreateDefaultEmptyCandidateData() => new CandidateData()
        {
            Id = 0,
           FirstName = string.Empty,
            LastName = string.Empty,
           IsSelected=false
        };

        public async Task<CandidateData> UpdateCandidateData(CandidateData updatingCandidateData)
        {
            CandidateData defaultCandidateData = CreateDefaultEmptyCandidateData();
            CandidateData existingCandidateData = await _databaseContext.CandidateDatas.FirstOrDefaultAsync(item => item.Id == updatingCandidateData.Id).ConfigureAwait(false);
            if(existingCandidateData !=null)
            {
                existingCandidateData.Id = updatingCandidateData.Id;
                existingCandidateData.FirstName = updatingCandidateData.FirstName;
                existingCandidateData.LastName = updatingCandidateData.LastName;
                existingCandidateData.IsSelected = updatingCandidateData.IsSelected;
            }
            _databaseContext.CandidateDatas.Update(existingCandidateData);
            int result = await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            if (result.Equals(1))
            {
                return existingCandidateData;
            }

            return defaultCandidateData;
        }
    }
}
