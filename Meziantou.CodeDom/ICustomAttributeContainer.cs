namespace Meziantou.CodeDom
{
    public interface ICustomAttributeContainer
    {
        CodeObjectCollection<CodeCustomAttribute> CustomAttributes { get; }
    }
}