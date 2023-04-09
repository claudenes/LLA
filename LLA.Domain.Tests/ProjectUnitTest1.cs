using LLA.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace LLA.Domain.Tests;

public class ProjectUnitTest1
{
    [Fact]
    public void CreateProject_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Projeto(1, "Project Name", "Project Description", DateTime.Now);
        action.Should()
            .NotThrow<LLA.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProject_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Projeto(-1, "Project Name", "Project Description", DateTime.Now);

        action.Should().Throw<LLA.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
    }

    [Fact]
    public void CreateProject_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Projeto(1, "Pr", "Project Description", DateTime.Now);
        action.Should().Throw<LLA.Domain.Validation.DomainExceptionValidation>()
             .WithMessage("Invalid name, too short, minimum 3 characters");
    }

    
   
    
}
