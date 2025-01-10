using ClinicApp.Domain.Abstractions;
using ClinicApp.Domain.Appointment.ValueObjects;
using ClinicApp.Domain.Doctor;
using ClinicApp.Domain.Shared;

namespace ClinicApp.Domain.Appointment
{
    public sealed class Appointment : Entity
    {
        public Name PatientName { get; private set; }
        public Guid DoctorId { get; private set; }
        public AppointmentDate Date { get; private set; }
        public AppoinmentStatus Status { get; private set; }

        // Constructor público para crear una nueva cita
        private Appointment(Guid id, Guid doctorId , Name patientName, AppointmentDate date)
        {
            Id = id;
            DoctorId = doctorId;
            PatientName = patientName ?? throw new ArgumentNullException(nameof(patientName));
            Date = date ?? throw new ArgumentNullException(nameof(date));
            Status = new AppoinmentStatus(true);
        }

        // Constructor privado para EF Core
        private Appointment() { }

        public static Appointment Reserve(
            Guid doctorId, Name patientName, AppointmentDate date
            ) { 
            var reservation = new Appointment(Guid.NewGuid(), doctorId, patientName, date);
            return reservation;
        }

        // Método para reprogramar una cita
        public void UpdateAppointmentDate(AppointmentDate newDate)
        {
            if (newDate.Date <= DateTime.Now)
            {
                throw new InvalidOperationException("Cannot reschedule to a past date.");
            }

            Date = newDate;
        }

        public void UpdatePatientName(Name name)
        {
            PatientName = name;
        }

        public void UpdateStatus(AppoinmentStatus state)
        {
            Status = state;
        }
    }
}
