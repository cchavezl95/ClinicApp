using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Domain.Abstractions
{
    public static class AppointmentErros
    {
        public static Error NotFound = new("Appointment.NotFound", "The Appointment was not found");

        public static Error Canceled = new("Appointment.Canceled", "The Appointment was already cancelled");

        public static Error DateError = new("Appointment.DateError", "The Appointment has a date greater than the one entered");
    }
}
