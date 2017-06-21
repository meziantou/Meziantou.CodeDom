namespace Meziantou.CodeDom
{
    public interface ITypeParameters
    {
        CodeObjectCollection<CodeTypeReference> Parameters { get; }
    }
}