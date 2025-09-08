using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericService<Subscriber> _subscriberService, IMapper _mapper) : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var values = _subscriberService.GetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _subscriberService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _subscriberService.TDelete(id);
            return Ok("Abone silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateSubscriberDto createSubcriberDto)
        {
            var newValue = _mapper.Map<Subscriber>(createSubcriberDto);
            _subscriberService.TCreate(newValue);
            return Ok("Yeni abone oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateSubscriberDto updateSubcriberDto)
        {
            var value = _mapper.Map<Subscriber>(updateSubcriberDto);
            _subscriberService.TUpdate(value);
            return Ok("Abone güncellendi");
        }
    }
}
