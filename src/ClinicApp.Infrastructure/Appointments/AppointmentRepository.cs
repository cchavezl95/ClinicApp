using ClinicApp.Domain.Appointment;
using ClinicApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Guid> AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();

            return appointment.Id;
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var appointment = await GetByIdAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
