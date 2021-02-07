using CandidatesPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesPortal.Pattern
{
   public interface ICandidateDataRepository
    {
        Task<List<CandidateData>> GetListOfCandidates();

        Task<CandidateData> GetCandidateDatabyID(int id);

        Task<CandidateData> SaveCandidateData(CandidateData candidateData);

        Task<CandidateData> UpdateCandidateData(CandidateData updatingCandidateData);
    }
}
