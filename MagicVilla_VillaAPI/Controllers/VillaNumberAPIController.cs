using AutoMapper;
using Azure;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaNumberAPIController")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {
        protected APIResponse _APIResponse;
        private readonly IVillaNbRepository _dbVillaNb;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillaNumberAPIController(
            APIResponse APIResponse,
            IVillaNbRepository dbVillaNb,
            IVillaRepository dbVilla,
            IMapper mapper
            ) {
            _APIResponse = APIResponse;
            _dbVillaNb = dbVillaNb;
            _dbVilla = dbVilla;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillasNb()
        {
            IEnumerable<VillaNb> villasNbList = await _dbVillaNb.GetAllAsync(includeProperties: "Villa");
            _APIResponse.Result = _mapper.Map<List<VillaNbDTO>>(villasNbList);
            _APIResponse.IsSuccess = true;
            _APIResponse.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_APIResponse);
        }

        [HttpGet("{VillaNumber:int}", Name = "GetVillaNB")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNb(int VillaNumber)
        {
            try
            {
                if(VillaNumber == 0)
                {
                    _APIResponse.ErrorMessage.Add("Id is 0");
                    _APIResponse.IsSuccess = false;
                    _APIResponse.StatusCode  =System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_APIResponse);
                }

                VillaNb villaNB = await _dbVillaNb.GetAsync(v => v.VillaNumber == VillaNumber);
                if (villaNB == null)
                {
                    _APIResponse.ErrorMessage.Add("Villa is not Found");
                    _APIResponse.IsSuccess = false;
                    _APIResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(_APIResponse);
                }

                _APIResponse.Result = _mapper.Map<VillaNbDTO>(villaNB);
                _APIResponse.IsSuccess = true;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_APIResponse);
            }
            catch (Exception ex)
            {
                _APIResponse.ErrorMessage.Add(ex.Message);
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_APIResponse);
            }
        }

        [HttpPost(Name = "CreateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNbCreateDTO createDTO)
        {
            try
            {
                if(createDTO.VillaNumber == 0)
                {
                    _APIResponse.ErrorMessage.Add("Villa Number must not be 0");
                    _APIResponse.ErrorMessage.Add("Villa Number is 0");
                    _APIResponse.IsSuccess = false;
                    _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_APIResponse);
                }
                if (await _dbVillaNb.GetAsync(u => u.VillaNumber == createDTO.VillaNumber) != null)
                {
                    _APIResponse.ErrorMessage.Add("Villa Number already Exists!");
                    _APIResponse.ErrorMessage.Add("Villa Not Found");
                    _APIResponse.IsSuccess = false;
                    _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_APIResponse);
                }
                if(await _dbVilla.GetAsync(u => u.Id == createDTO.VillaID) == null)
                {
                    _APIResponse.ErrorMessage.Add("Villa is not Found");
                    _APIResponse.ErrorMessage.Add("Wrong Villa Id");
                    _APIResponse.IsSuccess = false;
                    _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_APIResponse);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                VillaNb villaNumber = _mapper.Map<VillaNb>(createDTO);


                await _dbVillaNb.CreateAsync(villaNumber);
                _APIResponse.Result = _mapper.Map<VillaNbDTO>(villaNumber);
                _APIResponse.IsSuccess = true;
                _APIResponse.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = villaNumber.VillaNumber }, _APIResponse);
            }
            catch (Exception ex)
            {
                _APIResponse.IsSuccess = false;
                _APIResponse.ErrorMessage.Add(ex.ToString());
            }
            return _APIResponse;
        }

        [HttpDelete("{VillaNumber:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int VillaNumber)
        {
            try
            {
                var villaNumber = await _dbVillaNb.GetAsync(u => u.VillaNumber == VillaNumber);
                if (villaNumber == null)
                {
                    return NotFound();
                }
                await _dbVillaNb.DeleteAsync(villaNumber);
                _APIResponse.StatusCode = HttpStatusCode.NoContent;
                _APIResponse.IsSuccess = true;
                return Ok(_APIResponse);
            }
            catch (Exception ex)
            {
                _APIResponse.IsSuccess = false;
                _APIResponse.ErrorMessage.Add(ex.ToString());
            }
            return _APIResponse;
        }

        [HttpPut("{VillaNumber:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int VillaNumber, [FromBody] VillaNbUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || VillaNumber != updateDTO.VillaNumber)
                {
                    _APIResponse.ErrorMessage.Add("Bad Request");
                    _APIResponse.IsSuccess = false;
                    _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_APIResponse);
                }
                if (await _dbVillaNb.GetAsync(u => u.VillaNumber == updateDTO.VillaNumber, tracked: false) == null)
                {
                    _APIResponse.ErrorMessage.Add("Villa ID is Invalid!");
                    _APIResponse.IsSuccess = false;
                    _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_APIResponse);
                }
                VillaNb model = _mapper.Map<VillaNb>(updateDTO);

                await _dbVillaNb.UpdateAsync(model);
                _APIResponse.StatusCode = HttpStatusCode.NoContent;
                _APIResponse.IsSuccess = true;
                return Ok(_APIResponse);
            }
            catch (Exception ex)
            {
                _APIResponse.IsSuccess = false;
                _APIResponse.ErrorMessage.Add(ex.ToString());
            }
            return _APIResponse;
        }
    }
}
