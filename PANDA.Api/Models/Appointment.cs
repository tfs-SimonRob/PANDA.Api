﻿using PANDA.Api.Common;

namespace PANDA.Api.Models;

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public DateTimeOffset AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; }
    public required string Clinician { get; set; }
    public Department Department { get; set; }
    public DateTimeOffset? MissedTimestamp { get; set; }  // Field to track missed timestamp
}