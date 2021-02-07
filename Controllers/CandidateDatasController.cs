using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CandidatesPortal.Models;
using CandidatesPortal.Pattern;

namespace CandidatesPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateDatasController : ControllerBase
    {
        private readonly ICandidateDataRepository _candidateDataRepository;
         /// <summary>
        /// CandidateDatas constructor.
        /// </summary>
        public CandidateDatasController(ICandidateDataRepository candidateDataRepository)
        {
            _candidateDataRepository = candidateDataRepository;
        }
        // GET: api/CandidateDatas
        [HttpGet]
        public async Task<IActionResult> GetCandidateDatas() => Ok(await _candidateDataRepository.GetListOfCandidates().ConfigureAwait(false));
         //// GET: api/CandidateDatas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidateDatabyId(int id)
        {
            var candidateData = await _candidateDataRepository.GetCandidateDatabyID(id);

            if (candidateData == null)
            {
                return NotFound();
            }

            return Ok(candidateData);
        }
        [HttpPost]
        public async Task<IActionResult> PostCandidateData([FromBody] CandidateData candidateData)
        {
            CandidateData resultCandidateData = await _candidateDataRepository.SaveCandidateData(candidateData);

            if (resultCandidateData.Id==0)
                return BadRequest();
            else
                return Ok(resultCandidateData);
        }

        [Route("UpdateCandidateData")]
        [HttpPatch]
        public async Task<IActionResult> UpdateCandidateData([FromBody] CandidateData candidateData)
        {
            CandidateData resultCandidateData = await _candidateDataRepository.UpdateCandidateData(candidateData);

            if (resultCandidateData.Id == 0)
                return BadRequest();
            else
                return Ok(resultCandidateData);
        }



    }
}
