using FullApp3.Core.Mvvm;
using FullApp3.Services.Interfaces;
using System;
using System.ComponentModel.Composition;

namespace FullApp3.Modules.ModuleName.ViewModels
{
  [Export]
  public class ViewAViewModel : ViewModelBase
  {
    private string _message;

    public string Message
    {
      get { return _message; }
      set { _message = value;OnPropertyChanged(); }
    }

    private string message2="vorher";

    public string Message2
    {
      get { return message2; }
      set { message2 = value; OnPropertyChanged(); }
    }

    public ViewAViewModel( IMessageService messageService)
    {
     IDisposable subscription =  messageService.TextMessage.Subscribe(text => Message2 = text);
      //Message = messageService.GetMessage();
    }

  
  }
}
