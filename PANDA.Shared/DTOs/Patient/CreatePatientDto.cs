﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PANDA.Shared.Common;
using PANDA.Shared.Converters;

namespace PANDA.Shared.DTOs.Patient;

public class CreatePatientDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    [DataType(DataType.Date)]
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly DateOfBirth { get; set; }

    public string NHSNumber { get; set; } = default!;
    public string Postcode { get; set; } = default!;
    public Gender? Gender { get; set; }
}