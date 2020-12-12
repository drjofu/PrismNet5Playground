
using System.Reactive.Subjects;

namespace FullApp3.Services.Interfaces
{
  public interface IMessageService
  {
    string GetMessage();
    Subject<string> TextMessage { get; }
  }
}
