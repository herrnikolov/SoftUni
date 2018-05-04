using System.Collections.Generic;
public interface ILeutenantGeneral : IPrivate
{
    List<IPrivate> Privates { get; }
}