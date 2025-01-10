using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Domain.Abstractions
{
    public static class DoctorErros
    {
        public static Error NotFound = new("Doctor.NotFound", "The Doctor was not found");
    }
}
