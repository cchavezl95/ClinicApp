namespace ClinicApp.Domain.Doctor
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(Guid id);
    }
}
