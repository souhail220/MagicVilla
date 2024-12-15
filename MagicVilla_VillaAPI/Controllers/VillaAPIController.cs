using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public VillaAPIController(ILogger<VillaAPIController> logger, ApplicationDbContext db, IMapper mappper)
        {
            _logger = logger;
            _db = db;
            _mapper = mappper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            IEnumerable<Villa> villaList = await _db.Villas_API.ToListAsync();
            return Ok(_mapper.Map<List<VillaDTO>>(villaList));
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id){
            if (id == 0)
            {
                _logger.LogError("The villa id is 0");
                return BadRequest();
            }
            var villa = await _db.Villas_API.AsNoTracking().FirstOrDefaultAsync(villa => villa.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDTO>(villa));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO createVillaDTO)
        {
            if(await _db.Villas_API.AsNoTracking().FirstOrDefaultAsync(dbVilla => dbVilla.Name.ToLower() == createVillaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Duplication Error", "Villa already exists");
                return BadRequest(ModelState);
            }
            if (createVillaDTO == null)
            {
                return BadRequest(createVillaDTO);
            }
            Villa model = _mapper.Map<Villa>(createVillaDTO);

            await _db.Villas_API.AddAsync(model);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = model.Id }, model);
        }


        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("Id not Zero Error", "Id should not be zero");
                return BadRequest(ModelState);
            }

            try{
                var villa = await _db.Villas_API.AsNoTracking().FirstOrDefaultAsync(villa => villa.Id == id);
                if (villa == null)
                {
                    ModelState.AddModelError("NotFount Error", "Villa not in List");
                    return NotFound(ModelState);
                }
                _db.Villas_API.Remove(villa);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex){
                ModelState.AddModelError("NotFount Error", ex.Message);
                return NotFound(ModelState);
            }

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateVilla(int id, [FromBody]VillaUpdateDTO updateVillaDTO) {
            if (id == 0 || updateVillaDTO == null){
                return BadRequest(ModelState);
            }

            Villa model = _mapper.Map<Villa>(updateVillaDTO);

            _db.Villas_API.Update(model);
            await _db.SaveChangesAsync();

            return NoContent();

        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> updateVillaDTO)
        {
            if (id == 0 || updateVillaDTO == null)
            {
                return BadRequest(ModelState);
            }
            var villa = await _db.Villas_API.FirstOrDefaultAsync(v => v.Id == id);
            if (villa == null)
            {
                return BadRequest(ModelState);
            }

            // convert villa model to villaDTO model
            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);

            updateVillaDTO.ApplyTo(villaDTO, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // convert villaDTO model to villa model
            Villa villaModel = _mapper.Map<Villa>(villaDTO);

            await _db.Villas_API.AddAsync(villaModel);
            await _db.SaveChangesAsync();

            return NoContent();

        }
    }
}
