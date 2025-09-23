﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.App.DTOs.ContactDtos;
using OnlineEdu.App.Helpers;

namespace OnlineEdu.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();     

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("Contacts");
            return View(values);
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _client.DeleteAsync($"Contacts/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _client.PostAsJsonAsync("Contacts", createContactDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            
            var value = await _client.GetFromJsonAsync<UpdateContactDto>("Contacts/" + id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _client.PutAsJsonAsync("Contacts/", updateContactDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
