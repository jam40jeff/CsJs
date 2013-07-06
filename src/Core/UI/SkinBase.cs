using System;
using System.Collections.Generic;
using MorseCode.CsJs.UI.Controls;

namespace MorseCode.CsJs.UI
{
    public abstract class SkinBase : ISkin
    {
        private readonly Dictionary<Type, List<Action<IControl, string>>> _skinActionsByType = new Dictionary<Type, List<Action<IControl, string>>>();

        private bool _isInitialized;

        public void Apply(IControl control, string skinCategory)
        {
            EnsureInitialized();

            if (control == null)
            {
                throw new InvalidOperationException("Argument control cannot be null.");
            }

            Stack<Type> types = new Stack<Type>();
            Type currentType = control.GetType();
            while (currentType != null)
            {
                types.Push(currentType);
                currentType = currentType.BaseType;
            }

            while (types.Count > 0)
            {
                List<Action<IControl, string>> skinActions;
                if (_skinActionsByType.TryGetValue(types.Pop(), out skinActions))
                {
                    skinActions.ForEach(skinAction => skinAction(control, skinCategory));
                }
            }
        }

        private void EnsureInitialized()
        {
            if (!_isInitialized)
            {
                AddSkinActions(skinAction =>
                    {
                        List<Action<IControl, string>> skinActions;
                        if (!_skinActionsByType.TryGetValue(skinAction.Type, out skinActions))
                        {
                            skinActions = new List<Action<IControl, string>>();
                            _skinActionsByType.Add(skinAction.Type, skinActions);
                        }
                        skinActions.Add(skinAction.SkinAction);
                    });

                _isInitialized = true;
            }
        }

        protected abstract void AddSkinActions(Action<SkinActionWithType> addSkinAction);

        protected SkinActionWithType CreateSkinAction<T>(Action<T> skinAction) where T : IControl
        {
            return new SkinActionWithType(typeof (T), (control, skinCategory) => skinAction((T) control));
        }

        protected SkinActionWithType CreateSkinAction<T>(Action<T, string> skinAction) where T : IControl
        {
            return new SkinActionWithType(typeof (T), (control, skinCategory) => skinAction((T) control, skinCategory));
        }

        public class SkinActionWithType
        {
            private readonly Type _type;
            private readonly Action<IControl, string> _skinAction;

            public SkinActionWithType(Type type, Action<IControl, string> skinAction)
            {
                _type = type;
                _skinAction = skinAction;
            }

            public Type Type
            {
                get { return _type; }
            }

            public Action<IControl, string> SkinAction
            {
                get { return _skinAction; }
            }
        }
    }
}