using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaNbController : Controller
    {
        private readonly IVillaNbService villaNbService;
        private readonly IMapper mapper;
        public VillaNbController(IVillaNbService villaNbService, IMapper mapper)
        {
            this.villaNbService = villaNbService;
            this.mapper = mapper;
        }
        public async Task<IActionResult> IndexVillaNb()
        {
            List<VillaNbDTO> villaNbs = new();
            APIResponse response = await villaNbService.GetAllAsync<APIResponse>();
            if(response.IsSuccess)
            {
                villaNbs = JsonConvert.DeserializeObject<List<VillaNbDTO>>(Convert.ToString(response.Result));
            }
            return View(villaNbs);
        }

        public IActionResult CreateVillaNbForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNb(VillaNbDTO model)
        {
            if (ModelState.IsValid)
            {
                APIResponse response = await villaNbService.CreateAsync<APIResponse>(model);
                if (response.IsSuccess && response != null)
                {
                    return RedirectToAction(nameof(IndexVillaNb));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateVillaNbForm(int VillaNumber)
        {
            APIResponse response = await villaNbService.GetAsync<APIResponse>(VillaNumber);
            if(response.IsSuccess && response != null)
            {
                VillaNbDTO model = JsonConvert.DeserializeObject<VillaNbDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNb(VillaNbDTO model)
        {
            if (ModelState.IsValid)
            {
                APIResponse response = await villaNbService.UpdateAsync<APIResponse>(model);
                if (response.IsSuccess && response != null)
                {
                    return RedirectToAction(nameof(IndexVillaNb));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteVillaNb(int VillaNumber)
        {
            APIResponse response = await villaNbService.DeleteAsync<APIResponse>(VillaNumber);
            if (response.IsSuccess && response != null)
            {
                return RedirectToAction(nameof(IndexVillaNb));
            }
            return NotFound();
        }
    }
}
