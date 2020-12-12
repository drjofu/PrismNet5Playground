using FullApp3.Core.Mvvm;
using FullApp3.Services.Interfaces;
using System;
using System.ComponentModel.Composition;

namespace Module2.ViewModels
{
  [Export]
  public class ViewAViewModel: ViewModelBase
  {
    private string _message;
    private readonly IMessageService messageService;

    public string Message
    {
      get { return _message; }
      set { _message = value;OnPropertyChanged(); }
    }

    public DelegateCommand MeldenCommand { get; set; }

    public ViewAViewModel(IMessageService messageService)
    {
      this.messageService = messageService;
      messageService.TextMessage.Subscribe(text => Console.WriteLine("Meldung: " + text));
      MeldenCommand = new DelegateCommand(Melden);
    }
    

    private void Melden()
    {
      messageService.TextMessage.OnNext(DateTime.Now.ToLongTimeString());
    
    }
  }
}
