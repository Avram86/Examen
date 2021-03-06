using GestionarePacienti.Data;
using GestionarePacienti.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionarePacienti.Services
{
    public class PatientRepository : Repository<Patient>
    {
        public PatientRepository(ApplicationDbContext context, ILogger<PatientRepository> logger)
            : base(context, logger)
        {

        }
    }
}
