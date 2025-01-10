namespace ClinicApp.Application.Appointments.DTOs
{
    public class AppointmentDTO
    {
        public Guid Id { get; set; }
        public string PatientName { get; set; }
        public Guid DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool AppointmentStatus { get; set; } 
    }
}
