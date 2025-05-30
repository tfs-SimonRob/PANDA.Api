﻿using FluentValidation;
using PANDA.Api.Helpers;
using PANDA.Shared.Common;
using PANDA.Shared.DTOs;

namespace PANDA.Api.Validation;

public class PatientDtoValidator : AbstractValidator<PatientDto>
{
    public PatientDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage(ErrorMessages.NameRequired);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage(ErrorMessages.NameRequired);

        RuleFor(x => x.DateOfBirth)
            .MustBeValidDateOfBirth();

        RuleFor(x => x.NHSNumber)
            .MustBeValidNhsNumber();

        RuleFor(x => x.Postcode)
            .MustBeValidPostcode();

        RuleFor(x => x.Gender)
            .NotNull()
            .WithMessage("Gender is required.")
            .IsInEnum()
            .WithMessage(ErrorMessages.InvalidGender);
    }
}