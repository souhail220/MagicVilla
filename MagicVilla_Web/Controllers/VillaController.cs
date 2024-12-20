using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService villaService;
        private readonly IMapper mapper;

        public VillaController(IVillaService villaService, IMapper mapper)
        {
            this.villaService = villaService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> list = new();

            var response = await villaService.GetAllAsync<APIResponse>();
            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));

            }
            return View(list);
        }

        public IActionResult CreateVilla()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await villaService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));

                }
            }
            return View(model);
        }


        public async Task<IActionResult> UpdateVillaForm(int VillaId)
        {
            var response = await villaService.GetAsync<APIResponse>(VillaId);
            if (response != null && response.IsSuccess)
            {
                Villa villa = JsonConvert.DeserializeObject<Villa>(Convert.ToString(response.Result));
                return View(mapper.Map<VillaUpdateDTO>(villa));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await villaService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteVilla(int VillaId)
        {
            var response = await villaService.DeleteAsync<APIResponse>(VillaId);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexVilla));
            }
            return BadRequest();
        }

        
    }
}
