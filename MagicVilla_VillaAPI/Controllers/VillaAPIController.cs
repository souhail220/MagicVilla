using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogger _logger;
        public VillaAPIController(ILogger<VillaAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.LogInformation("Getting the villa information");
            return Ok(VillaStore.villaStore);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("The villa id is 0");
                return BadRequest();
            }
            var villa = VillaStore.villaStore.FirstOrDefault(villa => villa.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villa)
        {
            if(VillaStore.villaStore.FirstOrDefault(v => v.Name.ToLower() == villa.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Duplication Error", "Villa already exists");
                return BadRequest(ModelState);
            }
            if (villa == null)
            {
                return BadRequest(villa);
            }

            if (villa.Id > 0)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }

            villa.Id = VillaStore.villaStore.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            VillaStore.villaStore.Add(villa);

            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }


        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("Id not Zero Error", "Id should not be zero");
                return BadRequest(ModelState);
            }
            var villa = VillaStore.villaStore.FirstOrDefault(villa => villa.Id == id);
            if (villa == null)
            {
                ModelState.AddModelError("NotFount Error", "Villa not in List");
                return NotFound(ModelState);
            }
            VillaStore.villaStore.Remove(villa);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult updateVilla(int id, [FromBody]VillaDTO villaDTO) {
            if (id == 0 || villaDTO == null){
                return BadRequest(ModelState);
            }
            var villa = VillaStore.villaStore.FirstOrDefault(v  => v.Id == id);
            villa.Name = villaDTO.Name;

            return NoContent();

        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult updatePartialVilla(int id, JsonPatchDocument<VillaDTO> villaDTO)
        {
            if (id == 0 || villaDTO == null)
            {
                return BadRequest(ModelState);
            }
            var villa = VillaStore.villaStore.FirstOrDefault(v => v.Id == id);
            if(villa == null)
            {
                return BadRequest(ModelState);
            }
            villaDTO.ApplyTo(villa, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();

        }
    }
}
