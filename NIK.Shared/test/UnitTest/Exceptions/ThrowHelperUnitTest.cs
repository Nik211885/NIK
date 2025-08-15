using System.Collections;
using System.Dynamic;
using NIK.Shared.Exceptions;

namespace UnitTest.Exceptions;

public class ThrowHelperUnitTest
{
    [Theory]
    [InlineData(null, "ArgumentNullException")]
    public void ArgumentNull_ThrowIfArgumentNull_ThenThrowException(object? argument, string message)
    {
        try
        {
            ThrowHelper.ThrowIfArgumentNull(argument, message);
        }
        catch (Exception ex)
        {
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal(message, ex.Message);
            return;
        }
        Assert.Fail();
    }

    [Theory]
    [InlineData(5, "ArgumentIsNotNull")]
    public void ArgumentIsNotNull_ThrowIfArgumentNull_ThenNotThrowException(object argument, string message)
    {
        try
        {
            ThrowHelper.ThrowIfArgumentNull(argument, message);
        }
        catch (Exception ex)
        {
            Assert.Fail();
        }
    }
    [Theory]
    [InlineData("ExceptionMessage")]
    public void ExceptionWithMessage_Throw_ThenThrowException(string message)
    {
        try
        {
            ThrowHelper.Throw(message);
        }
        catch (Exception ex)
        {
            Assert.IsType<Exception>(ex);
            Assert.Equal(message, ex.Message);
            return;
        }
        Assert.Fail();
    }
    [Theory]
    [MemberData(nameof(ArrayListWithNullOrEmpty))]
    public void CollectionWithEmptyData_ThrowIfCollectionIsNullOrEmpty_ThenThrowException(IEnumerable<int>? collection, string message)
    {
        try
        {
            ThrowHelper.ThrowIfCollectionIsNullOrEmpty(collection, message);
        }
        catch (Exception ex)
        {
            Assert.IsType<Exception>(ex);
            Assert.Equal(message, ex.Message);
            return;
        }
        Assert.Fail();
    }
    [Theory]
    [MemberData(nameof(ArrayListWithData))]
    public void CollectionData_ThrowIfCollectionIsNullOrEmpty_ThenDontThrowException(IEnumerable<int> collection, string message)
    {
        try
        {
            ThrowHelper.ThrowIfCollectionIsNullOrEmpty(collection, message);
        }
        catch (Exception ex)
        {
            Assert.Fail();
        }
    }
    public static IEnumerable<object[]> ArrayListWithNullOrEmpty()
    {
        yield return [null, "ArgumentIsNull"];
        yield return [new List<int>(), "ArgumentIsNull"];
    }

    public static IEnumerable<object[]> ArrayListWithData()
    {
        yield return [new List<int>(){5}, "ArgumentIsNotNull"];
    }
}

