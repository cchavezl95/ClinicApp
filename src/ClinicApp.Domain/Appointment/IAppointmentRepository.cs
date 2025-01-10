namespace ClinicApp.Domain.Appointment
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(Guid id);
    }
}
