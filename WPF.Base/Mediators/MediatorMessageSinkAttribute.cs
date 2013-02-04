// http://marlongrech.wordpress.com/2009/04/16/mediator-v2-for-mvvm-wpf-and-silverlight-applications/

namespace WPF.Mediators
{
  using System;

  /// <summary>
  /// Attribute to decorate a method to be registered to the Mediator
  /// </summary>
  [AttributeUsage(AttributeTargets.Method)]
  public class MediatorMessageSinkAttribute : Attribute
  {
    /// <summary>
    /// The message to register to 
    /// </summary>
    public string Message { get; private set; }

    /// <summary>
    /// The type of parameter for the Method
    /// </summary>
    public Type ParameterType { get; set; }

    /// <summary>
    /// Constructs a method
    /// </summary>
    /// <param name="message">The message to subscribe to</param>
    public MediatorMessageSinkAttribute(string message)
    {
      this.Message = message;
    }
  }
}