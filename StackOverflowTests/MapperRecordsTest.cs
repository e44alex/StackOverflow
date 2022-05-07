using AutoMapper;
using NUnit.Framework;

namespace StackOverflowTests;

public class MyClass
{
    public string Str { get; set; }
    public int IntValue { get; set; }
}

public record MyRecord(int IntValue, string Str);

[TestFixture]
public class MapperRecordsTest
{
    private IMapper _mapper;

    [SetUp]
    public void Setup()
    {
        _mapper = new MapperConfiguration(c =>
        {
            c.CreateMap<MyClass, MyRecord>().ReverseMap();
        }).CreateMapper();
    }

    [Test]
    public void Mapper_MapToRecord()
    {
        var cl = new MyClass { IntValue = 10, Str = "string" };
        var rec = _mapper.Map<MyRecord>(cl);

        Assert.AreEqual(cl.Str, rec.Str);
        Assert.AreEqual(cl.IntValue, rec.IntValue);
    }

    [Test]
    public void Mapper_MapFromRecord()
    {
        var rec = new MyRecord( 10, "string");
        var cl = _mapper.Map<MyClass>(rec);

        Assert.AreEqual(cl.Str, rec.Str);
        Assert.AreEqual(cl.IntValue, rec.IntValue);
    }
}