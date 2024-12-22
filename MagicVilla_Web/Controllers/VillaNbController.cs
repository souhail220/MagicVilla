using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.VM;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaNbController : Controller
    {
        private readonly IVillaNbService villaNbService;
        private readonly IVillaService villaService;
        private readonly IMapper mapper;
        public VillaNbController(IVillaNbService villaNbService, IMapper mapper, IVillaService villaService)
        {
            this.villaNbService = villaNbService;
            this.villaService = villaService;
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

        public async Task<IActionResult> CreateVillaNbForm()
        {
            VillaNbCreateVM villaNbCreateVM = new();
            APIResponse response = await villaService.GetAllAsync<APIResponse>();
            if (response.IsSuccess)
            {
                villaNbCreateVM.villaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(response.Result)).Select(v => new SelectListItem
                    {
                        Text = v.Name,
                        Value = v.Id.ToString()
                    });
            }
            return View(villaNbCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNbForm(VillaNbCreateVM model)
        {
            if (ModelState.IsValid)
            {
                APIResponse response = await villaNbService.CreateAsync<APIResponse>(model.VillaNb);
                if (response.IsSuccess && response != null)
                {
                    return RedirectToAction(nameof(IndexVillaNb));
                }else if(response.ErrorMessage.Count > 0)
                {
                    ModelState.AddModelError("Custom Error", response.ErrorMessage.FirstOrDefault());
                }
            }

            APIResponse resp = await villaService.GetAllAsync<APIResponse>();
            if (resp.IsSuccess)
            {
                model.villaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(resp.Result)).Select(v => new SelectListItem
                    {
                        Text = v.Name,
                        Value = v.Id.ToString()
                    });
            }

            return View(model);
        }

        public async Task<IActionResult> UpdateVillaNbForm(int VillaNumber)
        {
            APIResponse response = await villaNbService.GetAsync<APIResponse>(VillaNumber);
            if(response.IsSuccess && response != null)
            {
                VillaNbRequestDTO villaNb = JsonConvert.DeserializeObject<VillaNbRequestDTO>(Convert.ToString(response.Result));

                VillaNbCreateVM model = new VillaNbCreateVM(villaNb);
                APIResponse resp = await villaService.GetAllAsync<APIResponse>();
                if (resp.IsSuccess)
                {
                    model.villaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                        (Convert.ToString(resp.Result)).Select(v => new SelectListItem
                        {
                            Text = v.Name,
                            Value = v.Id.ToString()
                        });
                }
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNbForm(VillaNbCreateVM model)
        {
            if (ModelState.IsValid)
            {
                APIResponse response = await villaNbService.UpdateAsync<APIResponse>(model.VillaNb);
                if (response.IsSuccess && response != null)
                {
                    return RedirectToAction(nameof(IndexVillaNb));
                }
                else if (response.ErrorMessage.Count > 0)
                {
                    ModelState.AddModelError("Custom Error", response.ErrorMessage.FirstOrDefault());
                }
            }

            APIResponse resp = await villaService.GetAllAsync<APIResponse>();
            if (resp.IsSuccess)
            {
                model.villaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(resp.Result)).Select(v => new SelectListItem
                    {
                        Text = v.Name,
                        Value = v.Id.ToString()
                    });
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteVillaNb(int VillaNumber)
        {
            APIResponse response = await villaNbService.DeleteAsync<APIResponse>(VillaNumber);
            if (response.IsSuccess && response != null)
            {
                return RedirectToAction(nameof(IndexVillaNb));
            }else if (response.ErrorMessage.Count > 0)
            {
                ModelState.AddModelError("Custom Error", response.ErrorMessage.FirstOrDefault());
            }
            return NotFound();
        }
    }
}
