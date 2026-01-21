using Asp.Versioning;
using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/VillaAPI")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class VillaAPIController : ControllerBase
    {
        protected APIResponse _APIResponse;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;

        public VillaAPIController(APIResponse APIResponse, IVillaRepository dbVilla, IMapper mappper)
        {
            _APIResponse = APIResponse;
            _dbVilla = dbVilla;
            _mapper = mappper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
            _APIResponse.Result = _mapper.Map<List<VillaDTO>>(villaList);
            _APIResponse.IsSuccess = true;
            _APIResponse.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_APIResponse);
        }


        [MapToApiVersion("1.0")]
        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id){
            if (id == 0)
            {
                _APIResponse.ErrorMessage.Add("Id must not be 0");
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_APIResponse);
            }
            var villa = await _dbVilla.GetAsync(villa => villa.Id == id);
            if (villa == null)
            {
                _APIResponse.ErrorMessage.Add("Villa not Found");
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                return NotFound(_APIResponse);
            }
            _APIResponse.Result = _mapper.Map<VillaDTO>(villa);
            _APIResponse.IsSuccess = true;
            _APIResponse.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_APIResponse);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDTO createVillaDTO)
        {
            try
            {
                if (await _dbVilla.GetAsync(dbVilla => dbVilla.Name.ToLower() == createVillaDTO.Name.ToLower()) != null)
                {
                    _APIResponse.ErrorMessage.Add("Duplication Error");
                    _APIResponse.ErrorMessage.Add("Villa already exists");
                    _APIResponse.IsSuccess = false;
                    _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_APIResponse);
                }
                if (createVillaDTO == null)
                {
                    _APIResponse.ErrorMessage.Add("Villa is null Error");
                    _APIResponse.ErrorMessage.Add("Villa must be noy Empty");
                    _APIResponse.IsSuccess = false;
                    _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_APIResponse);
                }
                Villa villa = _mapper.Map<Villa>(createVillaDTO);

                await _dbVilla.CreateAsync(villa);
                _APIResponse.Result = _mapper.Map<VillaDTO>(villa);
                _APIResponse.IsSuccess = true;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = villa.Id }, _APIResponse);
            }catch(Exception ex)
            {
                _APIResponse.ErrorMessage.Add(ex.Message.ToString());
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return _APIResponse;
            }
        }




        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            if (id == 0)
            {
                _APIResponse.ErrorMessage.Add("Id is Zero Error");
                _APIResponse.ErrorMessage.Add("Id should not be zero");
                _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_APIResponse);
            }

            try{
                var villa = await _dbVilla.GetAsync(villa => villa.Id == id);
                if (villa == null)
                {
                    _APIResponse.ErrorMessage.Add("NotFound Error");
                    _APIResponse.ErrorMessage.Add("Villa not in List");
                    _APIResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(_APIResponse);
                }
                
                await _dbVilla.DeleteAsync(villa);
            }
            catch (Exception ex){
                _APIResponse.ErrorMessage.Add(ex.Message);
                _APIResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                return NotFound(_APIResponse);
            }

            _APIResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            _APIResponse.IsSuccess = true;
            return _APIResponse;
        }




        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody]VillaUpdateDTO updateVillaDTO) {
            if (id == 0 || updateVillaDTO == null){
                _APIResponse.ErrorMessage.Add("Body Error");
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_APIResponse);
            }
            updateVillaDTO.Id = id;

            Villa model = _mapper.Map<Villa>(updateVillaDTO);

            await _dbVilla.UpdateAsync(model);

            _APIResponse.IsSuccess = true;
            _APIResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return _APIResponse;

        }




        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> updateVillaDTO)
        {
            if (id == 0 || updateVillaDTO == null)
            {
                _APIResponse.ErrorMessage.Add("Body Error");
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_APIResponse);
            }
            var villa = await _dbVilla.GetAsync(v => v.Id == id, tracked: false);
            if (villa == null)
            {
                _APIResponse.ErrorMessage.Add("Villa is Not Found");
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                return NotFound(_APIResponse);
            }

            // convert villa model to villaDTO model
            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);

            updateVillaDTO.ApplyTo(villaDTO, ModelState);
            if(!ModelState.IsValid)
            {
                _APIResponse.ErrorMessage.Add("Villa is Not Valid");
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_APIResponse);
            }

            // convert villaDTO model to villa model
            Villa villaModel = _mapper.Map<Villa>(villaDTO);

            await _dbVilla.UpdateAsync(villaModel);

            _APIResponse.IsSuccess = true;
            _APIResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return _APIResponse;

        }
    }
}
