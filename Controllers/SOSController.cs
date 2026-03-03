using Microsoft.AspNetCore.Mvc;
using ReportePAE_API.Data;
using ReportePAE_API.Models;

namespace ReportePAE_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SOSController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SOSController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("reportar")]
        public async Task<IActionResult> ReportarSOS([FromBody] ReporteSOS reporte)
        {
            if (reporte == null)
                return BadRequest("Datos inválidos");

            reporte.FechaHora = DateTime.Now;
            reporte.Estado = "Pendiente";
            reporte.MedioReporte = "SOS";

            _context.ReportesSOS.Add(reporte);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "SOS registrado", codigoReporte = reporte.CodigoReporte });
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarReportes()
        {
            var reportes = _context.ReportesSOS.OrderByDescending(x => x.FechaHora).ToList();
            return Ok(reportes);
        }

        [HttpPut("{id}/atender")]
        public async Task<IActionResult> AtenderReporte(int id)
        {
            var reporte = _context.ReportesSOS.FirstOrDefault(x => x.Id == id);
            if (reporte == null)
                return NotFound();

            reporte.Estado = "Atendido";
            _context.ReportesSOS.Update(reporte);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Reporte marcado como atendido" });
        }
    }
}
