using System;

namespace GUIapp
{
  public interface Option<T>
  {
    U Visit<U>(Func<U> onNone, Func<T, U> onSome);
    void Visit(Action onNone, Action<T> onSome);
  }

  public class None<T> : Option<T>
  {
    public U Visit<U>(Func<U> onNone, Func<T, U> onSome)
    {
      return onNone();
    }

    public void Visit(Action onNone, Action<T> onSome)
    {
      onNone();
    }
  }


  public class Some<T> : Option<T>
  {
    T value;

    public Some(T value)
    {
      this.value = value;
    }

    public U Visit<U>(Func<U> onNone, Func<T, U> onSome)
    {
      return onSome(value);
    }

    public void Visit(Action onNone, Action<T> onSome)
    {
      onSome(value);
    }
  }
}