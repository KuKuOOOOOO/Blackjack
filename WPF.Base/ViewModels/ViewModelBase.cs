// -------------------------------------------------------------------------------------------------
// <summary>
//  Modified from original source here: http://msdn.microsoft.com/en-us/magazine/dd419663.aspx
// </summary>
// -------------------------------------------------------------------------------------------------

namespace WPF.ViewModels
{
  using System;
  using System.ComponentModel;
  using System.Diagnostics;
  using System.Windows.Input;

  using WPF.Mediators;

  /// <summary>
  /// Base class for all ViewModel classes in the application.
  /// It provides support for property change notifications 
  /// and has a DisplayName property.  This class is abstract.
  /// </summary>
  public abstract class ViewModelBase : ICommandSink, IDisposable, INotifyPropertyChanged
  {
    /// <summary>
    /// The command sink.
    /// </summary>
    protected readonly CommandSink CommandSink = new CommandSink();

    /// <summary>
    /// The mediator.
    /// </summary>
    private static readonly Mediator MediatorInstance = new Mediator();

#if DEBUG
    /// <summary>
    /// Finalizes an instance of the <see cref="ViewModelBase"/> class. 
    /// Useful for ensuring that ViewModel objects are properly garbage collected.
    /// </summary>
    ~ViewModelBase()
    {
      string msg = string.Format(
        "{0} ({1}) ({2}) Finalized",
        this.GetType().Name,
        this.DisplayName,
        this.GetHashCode());

      Debug.WriteLine(msg);
    }
#endif

    /// <summary>
    /// Raised when a property on this object has a new value.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Gets the mediator.
    /// </summary>
    public Mediator Mediator
    {
      get
      {
        return MediatorInstance;
      }
    }

    /// <summary>
    /// Gets or sets the user-friendly name of this object.
    /// Child classes can set this property to a new value,
    /// or override it to determine the value on-demand.
    /// </summary>
    public virtual string DisplayName { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether an exception is thrown, or if a Debug.Fail() is used
    /// when an invalid property name is passed to the VerifyPropertyName method.
    /// The default value is false, but subclasses used by unit tests might 
    /// override this property's getter to return true.
    /// </summary>
    protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

    /// <summary>
    /// Warns the developer if this object does not have
    /// a public property with the specified name. This 
    /// method does not exist in a Release build.
    /// </summary>
    /// <param name="propertyName">The property name.</param>
    [Conditional("DEBUG")]
    [DebuggerStepThrough]
    public void VerifyPropertyName(string propertyName)
    {
      // Verify that the property name matches a real,  
      // public, instance property on this object.
      if (TypeDescriptor.GetProperties(this)[propertyName] == null)
      {
        string msg = "Invalid property name: " + propertyName;

        if (this.ThrowOnInvalidPropertyName)
        {
          throw new Exception(msg);
        }

        Debug.Fail(msg);
      }
    }

    /// <summary>
    /// Handles the execution of command predicates.
    /// </summary>
    /// <param name="command">Command object.</param>
    /// <param name="parameter">Command parameter.</param>
    /// <param name="handled">Whether or not the command was handled.</param>
    /// <returns>Whether or not the command can be executed.</returns>
    public bool CanExecuteCommand(ICommand command, object parameter, out bool handled)
    {
      return this.CommandSink.CanExecuteCommand(command, parameter, out handled);
    }

    /// <summary>
    /// Handles the execution of command actions.
    /// </summary>
    /// <param name="command">Command object.</param>
    /// <param name="parameter">Command parameter.</param>
    /// <param name="handled">Whether or not the command was handled.</param>
    public void ExecuteCommand(ICommand command, object parameter, out bool handled)
    {
      this.CommandSink.ExecuteCommand(command, parameter, out handled);
    }

    /// <summary>
    /// Invoked when this object is being removed from the application
    /// and will be subject to garbage collection.
    /// </summary>
    public void Dispose()
    {
      this.OnDispose();
    }

    /// <summary>
    /// Child classes can override this method to perform 
    /// clean-up logic, such as removing event handlers.
    /// </summary>
    protected virtual void OnDispose()
    {
    }

    /// <summary>
    /// Raises this object's PropertyChanged event.
    /// </summary>
    /// <param name="propertyName">The property that has a new value.</param>
    protected virtual void OnPropertyChanged(string propertyName)
    {
      this.VerifyPropertyName(propertyName);

      PropertyChangedEventHandler handler = this.PropertyChanged;

      if (handler == null)
      {
        return;
      }

      var e = new PropertyChangedEventArgs(propertyName);
      handler(this, e);
    }
  }
}