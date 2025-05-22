using MPCalcHub.Application.DataTransferObjects;
using MPCalcHub.Tests.Shared.Fixtures.DataTransferObjects;

namespace MPCalcHub.Tests.Domain.Validations;

public class BasicContactValidationTests : BaseValidationTest
{
    [Fact]
    public void BasicContact_AllAttributesValid_ShouldHaveRequiredAttribute_ResultValid()
    {
        // Arrange
        var basicContact = BasicContactFixtures.CreateAs_Base();

        // Act
        var validationResults = ValidateModel(basicContact);

        // Assert
        Assert.Empty(validationResults);
    }

    /// <summary>
    /// Data for testing invalid BasicContact
    /// </summary>
    public static IEnumerable<object[]> GetBasicContactInvalidData()
    {
        yield return new object[] { BasicContactFixtures.CreateAs_InvalidName() };
        yield return new object[] { BasicContactFixtures.CreateAs_InvalidEmail() };
        yield return new object[] { BasicContactFixtures.CreateAs_InvalidPhoneNumber() };
        yield return new object[] { BasicContactFixtures.CreateAs_InvalidDDD() };
    }

    [Theory]
    [MemberData(nameof(GetBasicContactInvalidData))]
    public void BasicContact_ShouldHaveRequiredAttribute_AllResultsInvalid(BasicContact basicContact)
    {
        // Act
        var validationResults = ValidateModel(basicContact);

        // Assert
        Assert.NotEmpty(validationResults);
    }
}