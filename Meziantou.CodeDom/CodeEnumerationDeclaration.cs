namespace Meziantou.CodeDom
{
    public class CodeEnumerationDeclaration : CodeTypeDeclaration
    {
        private CodeTypeReference _baseType;

        public CodeEnumerationDeclaration()
        {
            Members = new CodeObjectCollection<CodeEnumerationMember>(this);
        }

        public CodeTypeReference BaseType
        {
            get { return _baseType; }
            set { _baseType = SetParent(value); }
        }

        public CodeObjectCollection<CodeEnumerationMember> Members { get; }
    }
}