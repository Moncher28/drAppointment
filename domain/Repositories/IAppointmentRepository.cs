﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Repositories
{
    public interface IAppointmentRepository
    {
        DateTime[]? GetFreeAppointmentDateByDrSpec(DrSpec spec);
        Appointment MakeAppointmentOnSelectedDateSpecificDoctor(int id, DateTime selectedDate);
        Appointment MakeAppointmentOnSelectedDateFreeDoctor(DateTime selectedDate, DrSpec spec);
    }
}
