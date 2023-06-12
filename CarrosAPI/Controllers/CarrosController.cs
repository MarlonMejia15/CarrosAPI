using CarrosAPI.Data;
using CarrosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarrosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrosController : Controller
    {
        private readonly CarroAPIDbContext context;

        public CarrosController(CarroAPIDbContext context)
        {
            this.context = context;
        }

        //Obtener todos los carros
        [HttpGet]
        public async Task<IActionResult> GetCarros()
        {
            return Ok(await context.Carros.ToListAsync());
        }

        //Obtener un carro
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCarroById([FromRoute] Guid id)
        {
            var carro = await context.Carros.FindAsync(id);
            if (carro == null) return NotFound();

            return Ok(carro);
        }

        //Agregar Carros 
        [HttpPost]
        public async Task<IActionResult> AddCarro(AddCarros carros)
        {
            var addCarros = new Carros()
            {
                id = Guid.NewGuid(),
                modelo = carros.modelo,
                marca = carros.marca,
                Gasolina = carros.Gasolina,
                millaje = carros.millaje
            };
            await context.Carros.AddAsync(addCarros);
            await context.SaveChangesAsync();

            return Ok(addCarros);
        }

        //Modificar un carro
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> ModCarro([FromRoute] Guid id,ModCarro carro)
        {
            var modCarro = await context.Carros.FindAsync(id);
            if (modCarro == null) return NotFound();

            modCarro.modelo = carro.modelo;
            modCarro.millaje = carro.millaje;
            modCarro.Gasolina = carro.Gasolina;
            modCarro.marca = carro.marca;

            await context.SaveChangesAsync();

            return Ok(modCarro);
        }

    
        //Eliminar un carro
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> EliminarCarro([FromRoute] Guid id)
        {
            var modCarro = await context.Carros.FindAsync(id);
            if (modCarro == null) return NotFound();

          
            context.Carros.Remove(modCarro);
            await context.SaveChangesAsync();

            return Ok(modCarro);
        }
 
    }
}
