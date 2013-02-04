﻿// http://marlongrech.wordpress.com/2009/04/16/mediator-v2-for-mvvm-wpf-and-silverlight-applications/

namespace WPF.Mediators
{
  using System;
  using System.Reflection;

  /// <summary>
  /// This class is an implementation detail of the MessageToActionsMap class.
  /// </summary>
  internal class WeakAction
  {
    readonly MethodInfo method;
    readonly Type delegateType;
    readonly WeakReference weakRef;

    /// <summary>
    /// Constructs a WeakAction
    /// </summary>
    /// <param name="target">The instance to be stored as a weak reference</param>
    /// <param name="method">The Method Info to create the action for</param>
    /// <param name="parameterType">The type of parameter to be passed in the action. Pass null if there is not a paramater</param>
    internal WeakAction(object target, MethodInfo method, Type parameterType)
    {
      //create a Weakefernce to store the instance of the target in which the Method resides
      this.weakRef = new WeakReference(target);

      this.method = method;

      // JAS - Added logic to construct callback type.
      if (parameterType == null)
        this.delegateType = typeof(Action);
      else
        this.delegateType = typeof(Action<>).MakeGenericType(parameterType);
    }

    /// <summary>
    /// Creates a "throw away" delegate to invoke the method on the target
    /// </summary>
    /// <returns></returns>
    internal Delegate CreateAction()
    {
      object target = this.weakRef.Target;
      if (target != null)
      {
        // Rehydrate into a real Action
        // object, so that the method
        // can be invoked on the target.
        return Delegate.CreateDelegate(
                    this.delegateType,
                    this.weakRef.Target,
                    this.method);
      }
      else
      {
        return null;
      }
    }

    /// <summary>
    /// returns true if the target is still in memory
    /// </summary>
    public bool IsAlive
    {
      get
      {
        return this.weakRef.IsAlive;
      }
    }
  }
}