// -------------------------------------------------------------------------------------------------
// <summary>
//  Original: http://www.codeproject.com/Articles/28093/Using-RoutedCommands-with-a-ViewModel-in-WPF
// </summary>
// -------------------------------------------------------------------------------------------------

namespace WPF.ViewModels
{
  using System;
  using System.Windows;
  using System.Windows.Input;

  /// <summary>
  /// A CommandBinding subclass that will attach its
  /// CanExecute and Executed events to the event handling
  /// methods on the object referenced by its CommandSink property.  
  /// Set the attached CommandSink property on the element 
  /// whose CommandBindings collection contain CommandSinkBindings.
  /// If you dynamically create an instance of this class and add it 
  /// to the CommandBindings of an element, you must explicitly set
  /// its CommandSink property.
  /// </summary>
  public class CommandSinkBinding : CommandBinding
  {
    #region CommandSink [instance property]

    private ICommandSink _commandSink;

    public ICommandSink CommandSink
    {
      get
      {
        return this._commandSink;
      }
      set
      {
        if (value == null) throw new ArgumentNullException("Cannot set CommandSink to null.");

        if (this._commandSink != null) throw new InvalidOperationException("Cannot set CommandSink more than once.");

        this._commandSink = value;

        base.CanExecute += (s, e) =>
          {
            bool handled;
            e.CanExecute = this._commandSink.CanExecuteCommand(e.Command, e.Parameter, out handled);
            e.Handled = handled;
          };

        base.Executed += (s, e) =>
          {
            bool handled;
            this._commandSink.ExecuteCommand(e.Command, e.Parameter, out handled);
            e.Handled = handled;
          };
      }
    }

    #endregion // CommandSink [instance property]

    #region CommandSink [attached property]

    public static ICommandSink GetCommandSink(DependencyObject obj)
    {
      return (ICommandSink)obj.GetValue(CommandSinkProperty);
    }

    public static void SetCommandSink(DependencyObject obj, ICommandSink value)
    {
      obj.SetValue(CommandSinkProperty, value);
    }

    public static readonly DependencyProperty CommandSinkProperty = DependencyProperty.RegisterAttached(
      "CommandSink",
      typeof(ICommandSink),
      typeof(CommandSinkBinding),
      new UIPropertyMetadata(null, OnCommandSinkChanged));

    private static void OnCommandSinkChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
    {
      ICommandSink commandSink = e.NewValue as ICommandSink;

      if (!ConfigureDelayedProcessing(depObj, commandSink)) ProcessCommandSinkChanged(depObj, commandSink);
    }

    // This method is necessary when the CommandSink attached property is set on an element 
    // in a template, or any other situation in which the element's CommandBindings have not 
    // yet had a chance to be created and added to its CommandBindings collection.
    private static bool ConfigureDelayedProcessing(DependencyObject depObj, ICommandSink commandSink)
    {
      bool isDelayed = false;

      CommonElement elem = new CommonElement(depObj);
      if (elem.IsValid && !elem.IsLoaded)
      {
        RoutedEventHandler handler = null;
        handler = delegate
          {
            elem.Loaded -= handler;
            ProcessCommandSinkChanged(depObj, commandSink);
          };
        elem.Loaded += handler;
        isDelayed = true;
      }

      return isDelayed;
    }

    private static void ProcessCommandSinkChanged(DependencyObject depObj, ICommandSink commandSink)
    {
      CommandBindingCollection cmdBindings = GetCommandBindings(depObj);
      if (cmdBindings == null)
        throw new ArgumentException(
          "The CommandSinkBinding.CommandSink attached property was set on an element that does not support CommandBindings.");

      foreach (CommandBinding cmdBinding in cmdBindings)
      {
        CommandSinkBinding csb = cmdBinding as CommandSinkBinding;
        if (csb != null && csb.CommandSink == null) csb.CommandSink = commandSink;
      }
    }

    private static CommandBindingCollection GetCommandBindings(DependencyObject depObj)
    {
      var elem = new CommonElement(depObj);
      return elem.IsValid ? elem.CommandBindings : null;
    }

    #endregion // CommandSink [attached property]

    #region CommonElement [nested class]

    /// <summary>
    /// This class makes it easier to write code that works 
    /// with the common members of both the FrameworkElement
    /// and FrameworkContentElement classes.
    /// </summary>
    private class CommonElement
    {
      private readonly FrameworkElement _fe;

      private readonly FrameworkContentElement _fce;

      public readonly bool IsValid;

      public CommonElement(DependencyObject depObj)
      {
        this._fe = depObj as FrameworkElement;
        this._fce = depObj as FrameworkContentElement;

        this.IsValid = this._fe != null || this._fce != null;
      }

      public CommandBindingCollection CommandBindings
      {
        get
        {
          this.Verify();

          if (this._fe != null) return this._fe.CommandBindings;
          else return this._fce.CommandBindings;
        }
      }

      public bool IsLoaded
      {
        get
        {
          this.Verify();

          if (this._fe != null) return this._fe.IsLoaded;
          else return this._fce.IsLoaded;
        }
      }

      public event RoutedEventHandler Loaded
      {
        add
        {
          this.Verify();

          if (this._fe != null) this._fe.Loaded += value;
          else this._fce.Loaded += value;
        }
        remove
        {
          this.Verify();

          if (this._fe != null) this._fe.Loaded -= value;
          else this._fce.Loaded -= value;
        }
      }

      private void Verify()
      {
        if (!this.IsValid) throw new InvalidOperationException("Cannot use an invalid CommmonElement.");
      }
    }

    #endregion // CommonElement [nested class]
  }
}