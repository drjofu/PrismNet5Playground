using FullApp3.Services.Interfaces;
using System.ComponentModel.Composition;
using System.Reactive.Subjects;

namespace FullApp3.Services
{
  [Export(typeof(IMessageService))]
  [PartCreationPolicy(CreationPolicy.Shared)]
  public class MessageService : IMessageService
  {
    public Subject<string> TextMessage { get; }

    public MessageService()
    {
      TextMessage = new Subject<string>();
    }

    public string GetMessage()
    {
      var x = TextMessage;
      return "Hello from the Message Service";
    }
  }
}
