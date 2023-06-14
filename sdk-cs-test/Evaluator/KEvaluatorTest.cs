using System.Collections.Generic;
using FluentAssertions;
using Koople.Sdk.Evaluator;
using Xunit;

namespace Koople.Sdk.Test.Evaluator;

public class KEvaluatorTest
{
    [Fact]
    public void Features_evaluation()
    {
        var sut = KEvaluator.Create(Fixture.Store);

        var result = sut.Evaluate(Fixture.TestUser);

        var expected = new KEvaluationResult(new Dictionary<string, bool>
        {
            {"disabledForAll", false},
            {"enabledForTestUser", true},
            {"enabledForOtherUser", false},
            {"enabledForSpainAdults", true},
            {"enabledForEeuuAdults", false},
            {"enabledForAll", true},
        });
            
        result.Should().BeEquivalentTo(expected);
    }
        
    [Fact]
    public void Feature_false_evaluation()
    {
        var sut = KEvaluator.Create(Fixture.Store);

        var result = sut.Evaluate("disabledForAll", Fixture.TestUser);

        result.Should().BeFalse();
    }
        
    [Fact]
    public void Feature_true_evaluation()
    {
        var sut = KEvaluator.Create(Fixture.Store);

        var result = sut.Evaluate("enabledForAll", Fixture.TestUser);

        result.Should().BeTrue();
    }
}