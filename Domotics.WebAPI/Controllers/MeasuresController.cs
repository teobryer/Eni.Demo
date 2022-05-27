using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domotics.DataAccessLayer;
using Domotics.DataAccessLayer.Entities;
using Domotics.DataAccessLayer.AccessLayers.Abstractions;

namespace Domotics.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasuresController : ControllerBase
    {
  
        private readonly IMeasureAccessLayer measureAccessLayer;

        public MeasuresController( IMeasureAccessLayer measureAccessLayer)
        {
          
            this.measureAccessLayer = measureAccessLayer;
        }

        // GET: api/Measures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measure>>> GetMeasures()
        {
            return await measureAccessLayer.GetCollection().ToListAsync();
        }

        // GET: api/Measures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Measure>> GetMeasure(int id)
        {
            var measure = await measureAccessLayer.GetSingleAsync(filter: m=> m.Id == id);

            if (measure == null)
            {
                return NotFound();
            }

            return measure;
        }

        // PUT: api/Measures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeasure(int id, Measure measure)
        {
            if (id != measure.Id)
            {
                return BadRequest();
            }


           await measureAccessLayer.UpdateAsync(measure);
           

            return NoContent();
        }

        // POST: api/Measures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Measure>> PostMeasure(Measure measure)
        {
           await measureAccessLayer.AddAsync(measure);

            return CreatedAtAction("GetMeasure", new { id = measure.Id }, measure);

        
        }

        // DELETE: api/Measures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeasure(int id)
        {
            await measureAccessLayer.RemoveAsync(id);

            return NoContent();
        }

        private async Task<bool> MeasureExistsAsync(int id)
        {

            var measures = await measureAccessLayer.GetCollection().ToListAsync();
             var exist  = measures.Any(e => e.Id == id);
            return exist;
        }
    }
}
