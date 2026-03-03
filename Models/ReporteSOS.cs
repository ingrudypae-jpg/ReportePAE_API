namespace ReportePAE_API.Models
{
    public class ReporteSOS
    {
        public int Id { get; set; }
        public string DNI { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string CodigoReporte { get; set; } = string.Empty;
        public DateTime FechaHora { get; set; }
        public string MedioReporte { get; set; } = "SOS";
        public string Estado { get; set; } = "Pendiente";
    }
}