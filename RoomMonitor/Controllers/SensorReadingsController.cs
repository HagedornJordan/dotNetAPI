using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomMonitor.Models;

namespace RoomMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorReadingsController : ControllerBase
    {
        private readonly RoomMonitorContext _context;

        public SensorReadingsController(RoomMonitorContext context)
        {
            _context = context;
        }

        // GET: api/SensorReadings
        [HttpGet]
        public IEnumerable<SensorReading> GetSensorReading()
        {
            return _context.SensorReading;
        }

        // GET: api/SensorReadings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensorReading([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sensorReading = await _context.SensorReading.FindAsync(id);

            if (sensorReading == null)
            {
                return NotFound();
            }

            return Ok(sensorReading);
        }

        // PUT: api/SensorReadings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorReading([FromRoute] int id, [FromBody] SensorReading sensorReading)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sensorReading.Id)
            {
                return BadRequest();
            }

            _context.Entry(sensorReading).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorReadingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SensorReadings
        [HttpPost]
        public async Task<IActionResult> PostSensorReading([FromBody] SensorReading sensorReading)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SensorReading.Add(sensorReading);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorReading", new { id = sensorReading.Id }, sensorReading);
        }

        // DELETE: api/SensorReadings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensorReading([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sensorReading = await _context.SensorReading.FindAsync(id);
            if (sensorReading == null)
            {
                return NotFound();
            }

            _context.SensorReading.Remove(sensorReading);
            await _context.SaveChangesAsync();

            return Ok(sensorReading);
        }

        private bool SensorReadingExists(int id)
        {
            return _context.SensorReading.Any(e => e.Id == id);
        }
    }
}