using Force.DeepCloner;
using Fueller.Domain.Model.Audit;
using Moq;

namespace Fueller.Domain.Test.Unit.Model.Audit;

[TestFixture]
public class AuditRecordTests
{
    [TestCase("Original", "Original", 123, 123, 0)]
    [TestCase("Original", "Updated", 123, 123, 1)]
    [TestCase("Original", "Original", 123, 456, 1)]
    [TestCase("Original", "Updated", 123, 456, 2)]
    public void AuditRecordMetadataContainsElementForEachUpdatedProperty(
        string originalPropOne,
        string updatedPropOne,
        int originalPropTwo,
        int updatedPropTwo,
        int updatedPropCount)
    {
        var original = new TestEntityOne(originalPropOne, originalPropTwo);
        var updated = original.DeepClone();
        updated.PropOne = updatedPropOne;
        updated.PropTwo = updatedPropTwo;

        var auditRecord = new AuditRecord<TestEntityOne>(original, updated);
        
        Assert.That(auditRecord.Metadata, Is.Not.Null);
        Assert.That(auditRecord.Metadata.Count(), Is.EqualTo(updatedPropCount));
    }

    [TestCase(null, null, 0)]
    [TestCase(null, "Updated", 1)]
    [TestCase("Original", null, 1)]
    public void AuditRecordMetadataTracksNullableProperties(
        string? originalPropThree,
        string? updatedPropThree,
        int updatedPropCount)
    {
        var original = new TestEntityOne("Original", 123, originalPropThree);
        var updated = original.DeepClone();
        updated.PropThree = updatedPropThree;

        var auditRecord = new AuditRecord<TestEntityOne>(original, updated);
        
        Assert.That(auditRecord.Metadata, Is.Not.Null);
        Assert.That(auditRecord.Metadata.Count(), Is.EqualTo(updatedPropCount));
    }

    [Test]
    public void AuditRecordMetadataDoesNotTrackComplexProperties()
    {
        var testEntityThree = new TestEntityThree("Original");
        var original = new TestEntityOne("Original", 123, null, testEntityThree);
        var updated = original.DeepClone();

        var auditRecord = new AuditRecord<TestEntityOne>(original, updated);
        
        Assert.That(auditRecord.Metadata, Is.Not.Null);
        Assert.That(auditRecord.Metadata.Any(x => x.PropertyName is nameof(TestEntityOne.ComplexProp)), Is.False);
    }

    [Test]
    public void AuditablePropertyIsAudited()
    {
        var testEntityOne = new Mock<IAuditable>();
        var testEntityTwo = new TestEntityTwo(testEntityOne.Object);

        _ = new AuditRecord<TestEntityTwo>(testEntityTwo, testEntityTwo);
        
        testEntityOne.Verify(x => x.AddAuditRecord(), Times.Once);
    }

    private class TestEntityOne : IAuditable
    {
        public string PropOne { get; set; }
        public int PropTwo { get; set; }
        public string? PropThree { get; set; }
        public TestEntityThree? ComplexProp { get; set; }
        
        public TestEntityOne(
            string propOne, 
            int propTwo, 
            string? propThree = null,
            TestEntityThree? complexProp = null)
        {
            PropOne = propOne;
            PropTwo = propTwo;
            PropThree = propThree;
            ComplexProp = complexProp;
        }
        
        public void AddAuditRecord()
        {
            throw new NotImplementedException();
        }
    }

    private class TestEntityTwo : IAuditable
    {
        public IAuditable? AuditableProp { get; set; }
        
        public TestEntityTwo(IAuditable? auditableProp)
        {
            AuditableProp = auditableProp;
        }
        
        public void AddAuditRecord()
        {
            throw new NotImplementedException();
        }
    }

    private class TestEntityThree
    {
        public string PropOne { get; set; }

        public TestEntityThree(string propOne)
        {
            PropOne = propOne;
        }
    }
}