using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniSales.API.Contracts;
using UniSales.API.Models.Korisnik;

namespace UniSales.API.Controllers
{
    [ApiController]
    [Route("api/korisnik")]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikRepository _repository;
        private readonly IMapper _mapper;

        public KorisnikController(IKorisnikRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employeesFromRepo = await _repository.PreuzmiKorisnikeAsync().ConfigureAwait(false);

            return Ok(_mapper.Map<IEnumerable<KorisnikDto>>(employeesFromRepo));
        }
    }
}
